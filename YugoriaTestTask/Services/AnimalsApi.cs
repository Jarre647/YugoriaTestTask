using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Caching;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using System.Xml.Serialization;
using YugoriaTestTask.Models;
using YugoriaTestTask.Repositories;
using YugoriaTestTask.Services.Contracts;
using YugoriaTestTask.ViewModels;

namespace YugoriaTestTask.Services
{
    public class AnimalsApi : IAnimalsApi
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AnimalsApi(
           IUnitOfWork unitOfWork,
           IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ActionResult<List<SkinColorModel>>> GetSkinColorsAsync()
        {
            return await _unitOfWork.GetRepository<SkinColorModel>()
                                    .All()
                                    .ToListAsync();
        }

        public async Task<ActionResult<List<RegionModel>>> GetRegionsAsync()
        {
            return await _unitOfWork.GetRepository<RegionModel>()
                                    .All()
                                    .ToListAsync();
        }
        public async Task<ActionResult<List<LocationModel>>> GetLocationsAsync()
        {
            return await _unitOfWork.GetRepository<LocationModel>()
                                    .All()
                                    .ToListAsync();
        }
        public async Task<ActionResult<List<KindAnimalModel>>> GetKindAnimalsAsync()
        {
            return await _unitOfWork.GetRepository<KindAnimalModel>()
                                    .All()
                                    .ToListAsync();
        }

        public async Task<ActionResult<AnimalModel>> GetAnimalsByIdAsync(int animalId)
        {
            var getCategoriesTypesQuery = from animal in _unitOfWork.GetRepository<AnimalModel>().All().AsQueryable()
                                          join kind in _unitOfWork.GetRepository<KindAnimalModel>().All().AsQueryable() on animal.KindAnimalId equals kind.Id
                                          join location in _unitOfWork.GetRepository<LocationModel>().All().AsQueryable() on animal.LocationId equals location.Id
                                          join region in _unitOfWork.GetRepository<RegionModel>().All().AsQueryable() on animal.RegionId equals region.Id
                                          join skin in _unitOfWork.GetRepository<SkinColorModel>().All().AsQueryable() on animal.SkinColorId equals skin.Id
                                          where animal.Id == animalId
                                          select new
                                          {
                                              AnimalId = animal.Id,
                                              AnimalName = animal.AnimalName,
                                              KindAnimalId = kind.Id,
                                              LocationId = location.Id,
                                              RegionId = region.Id,
                                              SkinColorId = skin.Id
                                          };

            var result = new AnimalModel();
            var getCategoriesTypes = getCategoriesTypesQuery.FirstOrDefault();

            result.Id = getCategoriesTypes.AnimalId;
            result.AnimalName = getCategoriesTypes.AnimalName;
            result.KindAnimalId = getCategoriesTypes.KindAnimalId;
            result.LocationId = getCategoriesTypes.LocationId;
            result.RegionId = getCategoriesTypes.RegionId;
            result.SkinColorId = getCategoriesTypes.SkinColorId;

            return result;
        }

        public async Task PostAnimalAsync(AnimalModel animal)
        {
            var getRepository = _unitOfWork.GetRepository<AnimalModel>();
            var entity = _mapper.Map<AnimalModel>(animal);
            getRepository.Add(entity);
            await _unitOfWork.CommitAsync();
        }

        public async Task PutAnimalAsync(AnimalModel animal)
        {
            var getRepository = _unitOfWork.GetRepository<AnimalModel>();
            var entity = _mapper.Map<AnimalModel>(animal);
            getRepository.Update(entity);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteAnimalAsync(int id)
        {
            _unitOfWork.GetRepository<AnimalModel>().Remove(id);
            await _unitOfWork.CommitAsync();
        }

        public async Task<List<AnimalsViewModel>> GetAnimalsAsync()
        {
            var getCategoriesTypesQuery = from animal in _unitOfWork.GetRepository<AnimalModel>().All().AsQueryable()
                                          join kind in _unitOfWork.GetRepository<KindAnimalModel>().All().AsQueryable() on animal.KindAnimalId equals kind.Id
                                          join location in _unitOfWork.GetRepository<LocationModel>().All().AsQueryable() on animal.LocationId equals location.Id
                                          join region in _unitOfWork.GetRepository<RegionModel>().All().AsQueryable() on animal.RegionId equals region.Id
                                          join skin in _unitOfWork.GetRepository<SkinColorModel>().All().AsQueryable() on animal.SkinColorId equals skin.Id
                                          select new
                                          {
                                              AnimalId = animal.Id,
                                              AnimalName = animal.AnimalName,
                                              KindAnimalName = kind.KindAnimalName,
                                              LocationName = location.LocationName,
                                              RegionName = region.RegionName,
                                              SkinColorName = skin.SkinColorName
                                          };

            var result = new List<AnimalsViewModel>();
            var getCategoriesTypes = await getCategoriesTypesQuery.ToListAsync();
            foreach (var item in getCategoriesTypes)
            {
                var helper = new AnimalsViewModel();
                helper.Id = item.AnimalId;
                helper.AnimalName = item.AnimalName;
                helper.KindAnimalName = item.KindAnimalName;
                helper.LocationName = item.LocationName;
                helper.RegionName = item.RegionName;
                helper.SkinColorName = item.SkinColorName;
                result.Add(helper);
            }
            return result;
        }

        //тут можно будет потом сделать кэширование т.к. данные не изменяются
        public async Task<HelpedTypesViewModel> GetCachingHelpedTypesAsync()
        {
            return await GetHelpedTypes();
        }


        private async Task<HelpedTypesViewModel> GetHelpedTypes()
        {
            HelpedTypesViewModel result = new HelpedTypesViewModel();
            var getKinds = await GetKindAnimalsAsync();
            var getRegions = await GetRegionsAsync();
            var getLocations = await GetLocationsAsync();
            var getSkinColors = await GetSkinColorsAsync();
            result.Kinds = getKinds.Value;
            result.Regions = getRegions.Value;
            result.Locations = getLocations.Value;
            result.SkinColors = getSkinColors.Value;

            return result;
        }
    }
}
