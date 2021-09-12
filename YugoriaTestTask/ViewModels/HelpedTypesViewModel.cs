using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YugoriaTestTask.Models;

namespace YugoriaTestTask.ViewModels
{
    public class HelpedTypesViewModel
    {
        public List<KindAnimalModel> Kinds {get;set;}
        public List<LocationModel> Locations { get; set; }
        public List<RegionModel> Regions { get; set; }
        public List<SkinColorModel> SkinColors { get; set; }
    }
}
