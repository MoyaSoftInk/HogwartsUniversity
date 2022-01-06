namespace Hogwarts.Application.DTOs
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class HouseDTO
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Nombre de la Casa es Requerida.")]
        public string Name { get; set; }
    }
}
