﻿using System.ComponentModel;

namespace TrabajadoresFinish.Models
{
    public class Distrito
    {
        public int Id { get; set; }
        [DisplayName("Provincia")]

        public int IdProvincia { get; set; }
        [DisplayName("Distrito")]

        public string NombreDistrito { get; set; } = string.Empty;
    }
}

