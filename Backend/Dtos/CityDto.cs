using System.ComponentModel.DataAnnotations;

namespace HSPA.Dtos
{
    public class CityDto
    {
        public int Id { get; set; }
        [Required (ErrorMessage ="Name is a mandatory field.")]
        [StringLength(50, MinimumLength =3)]
        [RegularExpression(".*[a-zA-Z]+.*", ErrorMessage ="Numeric  are not allowed.")]
        public string Name { get; set; }
        [Required]
        public string Country { get; set; }
    
    }
}
