namespace Hogwarts.Domain.Entities
{
    using Hogwarts.Core.Model;
    using System.ComponentModel.DataAnnotations;

    public class Student : BaseEntity<Student, int>
    {
        [Required(ErrorMessage = "Nombre es Requerido.")]
        [MaxLength(20, ErrorMessage = "Nombre no puede tener más de 20 digitos.")]
        [RegularExpression(@"[A-Za-z]$", ErrorMessage = "sólo puede contener letras.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Apellido es Requerido")]
        [MaxLength(20, ErrorMessage = "Apellido no puede tener más de 20 digitos.")]
        [RegularExpression(@"[A-Za-z]$", ErrorMessage = "Apellido sólo puede contener letras.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Identificación es Requerido")]
        [MaxLength(10, ErrorMessage = "Identificación no puede tener más de 10 digitos.")]
        [RegularExpression(@"[0-9]$", ErrorMessage = "Identificación sólo puede contener números.")]
        public string Identification { get; set; }

        [Required(ErrorMessage = "Edad es Requerida")]
        [Range(0, 99, ErrorMessage = "Edad no puede tener más de 2 digitos.")]
        [RegularExpression(@"[0-9]$", ErrorMessage = "Edad sólo puede contener números.")]
        public int Age { get; set; }

        [Required(ErrorMessage = "La Casa es Requerida.")]
        public virtual House House { get; set; }
    }
}
