﻿using System.ComponentModel;

namespace TrabajadoresFinish.Models
{
    public class Trabajadores
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
        [DisplayName("Departamento")]

        public int IdDepartamento { get; set; }
        [DisplayName("Provincia")]

        public int IdProvincia { get; set; }
        [DisplayName("Distrito")]

        public int IdDistrito { get; set; }
    }
}

