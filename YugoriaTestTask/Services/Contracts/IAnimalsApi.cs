using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YugoriaTestTask.Models;
using YugoriaTestTask.ViewModels;

namespace YugoriaTestTask.Services.Contracts
{
    public interface IAnimalsApi
    {
        Task<ActionResult<List<SkinColorModel>>> GetSkinColorsAsync();
        Task<ActionResult<List<RegionModel>>> GetRegionsAsync();
        Task<ActionResult<List<LocationModel>>> GetLocationsAsync();
        Task<ActionResult<List<KindAnimalModel>>> GetKindAnimalsAsync();
        Task<ActionResult<AnimalModel>> GetAnimalsByIdAsync(int animalId);
        Task PostAnimalAsync(AnimalModel animal);
        Task PutAnimalAsync(AnimalModel animal);
        Task DeleteAnimalAsync(int id);
        Task<List<AnimalsViewModel>> GetAnimalsAsync();
        Task<HelpedTypesViewModel> GetCachingHelpedTypesAsync();
        Task<List<AnimalModel>> GetFilteredAnimalsAsync(SearchViewModel searchView);
    }
}
