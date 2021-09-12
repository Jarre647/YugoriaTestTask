using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YugoriaTestTask.Models
{
    public class AnimalModel
    {
        [Key]
        public int Id { get; set; }
        public string AnimalName { get; set; }
        [ForeignKey("KindAnimalIdKey")]
        public int KindAnimalId { get; set; }
        [ForeignKey("LocationIdKey")]
        public int LocationId { get; set; }
        [ForeignKey("RegionIdKey")]
        public int RegionId { get; set; }
        [ForeignKey("SkinColorKey")]
        public int SkinColorId { get; set; }
    }
}
