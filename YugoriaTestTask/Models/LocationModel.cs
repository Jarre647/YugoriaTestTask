using System.ComponentModel.DataAnnotations;

namespace YugoriaTestTask.Models
{
    public class LocationModel
    {
        [Key]
        public int Id { get; set; }
        public string LocationName { get; set; }
    }
}
