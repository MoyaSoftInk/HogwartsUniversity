namespace Hogwarts.Domain.Entities
{
    using Hogwarts.Core.Model;
    using System.ComponentModel.DataAnnotations;

    public class House : BaseEntity<House, int>
    {
        [Required(ErrorMessage = "Nombre de la Casa es Requerida.")]
        [MaxLength(10, ErrorMessage = "Nombre de la casa no debe contener más de 20 caracteres.")]
        public string Name { get; set; }
    }
}
