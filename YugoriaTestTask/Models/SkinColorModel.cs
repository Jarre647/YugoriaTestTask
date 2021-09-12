using System.ComponentModel.DataAnnotations;

namespace YugoriaTestTask.Models
{
    public class SkinColorModel
    {
        [Key]
        public int Id { get; set; }
        public string SkinColorName { get; set; }
    }
}
