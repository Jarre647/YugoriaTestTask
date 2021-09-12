using AutoMapper;
using YugoriaTestTask.Models;

namespace YugoriaTestTask.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AnimalModel, AnimalModel>();
        }
    }
}
