using Domain.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.DTO
{
    public class FIlmeDTO
    {
        public string Titulo { get; set; }       
        public int ClassificacaoIndicativa { get; set; }       
        public EnumTipo Tipo { get; set; }
    }
}
