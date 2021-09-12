using System.ComponentModel.DataAnnotations;

namespace YugoriaTestTask.Models
{
    public class RegionModel
    {
        [Key]
        public int Id { get; set; }
        public string RegionName {  get; set; }
    }
}
