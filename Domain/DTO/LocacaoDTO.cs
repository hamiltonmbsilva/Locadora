using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.DTO
{
    public class LocacaoDTO
    {
        public DateTime DataLocacao { get; set; }        
        public DateTime DataDevolucao { get; set; }
        public FIlmeDTO Filme { get; set; }
        public ClienteDTO Cliente { get; set; }
    }

    public class AtrasadoDTO
    {
        public int Id { get; set; }
        public DateTime DataDevolucao { get; set; }       
        public ClienteDTO Cliente { get; set; }
    }

    public class FilmesNaoAlugadosDTO
    {
        public int Id { get; set; }
        public FIlmeDTO Filme { get; set; }

    }

    public class SegundoDTO
    {
        public int Id { get; set; }        
        public ClienteDTO Cliente { get; set; }
    }


}
