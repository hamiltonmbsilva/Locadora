using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.DTO
{
    public class ClienteDTO
    {
        public string Nome { get; set; }        
        public string CPF { get; set; }        
        public DateTime DataNascimento { get; set; }
    }
}
