using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.DTO
{
    class LocacaoDTO
    {
        public DateTime DataLocacao { get; set; }        
        public DateTime DataDevolucao { get; set; }
        public FIlmeDTO Filme { get; set; }
        public ClienteDTO Cliente { get; set; }
    }
}
