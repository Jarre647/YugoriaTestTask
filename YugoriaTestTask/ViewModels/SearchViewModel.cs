using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YugoriaTestTask.ViewModels
{
    public class SearchViewModel
    {
        public List<int> KindAnimalId { get; set; }
        public List<int> RegionId { get; set; }
        public List<int> SkinColorId { get; set; }
    }
}
