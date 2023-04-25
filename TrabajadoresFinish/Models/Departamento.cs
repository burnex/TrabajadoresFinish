using System.ComponentModel.DataAnnotations;

namespace TrabajadoresFinish.Models
{
    public class Departamento
    {
        public int Id { get; set; }
        [Required]
        public string NombreDepartamento { get; set; } = string.Empty;
    }
}

