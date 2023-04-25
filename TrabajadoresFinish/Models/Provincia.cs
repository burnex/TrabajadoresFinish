using System.ComponentModel.DataAnnotations.Schema;

namespace TrabajadoresFinish.Models
{
    public class Provincia
    {
        public int Id { get; set; }
        [ForeignKey("Departamento")]
        public int IdDepartamento { get; set; }
        public string NombreProvincia { get; set; }

        public Departamento Departamento { get; set; }
    }
}

