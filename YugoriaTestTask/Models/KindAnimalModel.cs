using System.ComponentModel.DataAnnotations;

namespace YugoriaTestTask.Models
{
    public class KindAnimalModel
    {
        [Key]
        public int Id { get; set; }
        public string KindAnimalName { get; set; }
    }
}
