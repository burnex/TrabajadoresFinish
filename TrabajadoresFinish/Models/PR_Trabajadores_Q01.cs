using System.ComponentModel;

namespace TrabajadoresFinish.Models
{
    public class PR_Trabajadores_Q01
    {
        public int Id { get; set; }
        [DisplayName("Tipo Documento")]

        public string TipoDocumento { get; set; } = string.Empty;
        [DisplayName("Número Documento")]

        public string NumeroDocumento { get; set; } = string.Empty;
        [DisplayName("Nombres")]

        public string Nombres { get; set; } = string.Empty;
        [DisplayName("Sexo")]

        public string Sexo { get; set; } = string.Empty;
        public string SexoDescripcion { get; set; } = string.Empty;

        
        [DisplayName("Departamento")]

        public int IdDepartamento { get; set; }
        public string NombreDepartamento { get; set; } = string.Empty;
        [DisplayName("Provincia")]

        public int IdProvincia { get; set; }
        public string NombreProvincia { get; set; } = string.Empty;
        [DisplayName("Distrito")]

        public int IdDistrito { get; set; }
        public string NombreDistrito { get; set; } = string.Empty;

        public string classSTR => Sexo.Equals("M") ? "primary" : "danger";
    }
}