namespace Hogwarts.Application.DTOs
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class StudentDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nombre es Requerido.")]
        [MaxLength(20, ErrorMessage = "Nombre no puede tener más de 20 caracteres.")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,21}$",  ErrorMessage = "Nombre sólo puede contener letras.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Apellido es Requerido")]
        [MaxLength(20, ErrorMessage = "Apellido no puede tener más de 20 caracteres.")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,21}$", ErrorMessage = "Apellido sólo puede contener letras.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Identificación es Requerido")]
        [MaxLength(10, ErrorMessage = "Identificación no puede tener más de 10 caracteres.")]
        [RegularExpression(@"^[0-9''-']{1,11}$", ErrorMessage = "Identificación sólo puede contener letras.")]
        public string Identification { get; set; }

        [Required(ErrorMessage = "Edad es Requerida")]
        [Range(0, 99, ErrorMessage = "Edad no puede tener más de 2 dígitos.")]
        [RegularExpression(@"^[0-9''-']{1,3}$", ErrorMessage = "Edad sólo puede contener letras.")]
        public int Age { get; set; }

        [Required(ErrorMessage = "La Casa es Requerida.")]
        public string HouseName { get; set; }
    }
}
