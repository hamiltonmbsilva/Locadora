using Domain.Enum;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    [Table("filme")]
    public class Filme
    {
        #region Propriedades
        [Key]
        [Required, Column("id")]
        public int Id { get; set; }

        [Required, Column("titulo"), MaxLength(100)]
        public string Titulo { get; set; }

        [Required, Column("classificacao_indicativa")]
        public int ClassificacaoIndicativa { get; set; }

        [Required, Column("tipo")]
        public EnumTipo Tipo { get; set; }

        #endregion

        #region Relacionamentos

        public virtual List<Locacao> Locacaos { get; set; }

        #endregion

        #region Mapeamento

        public static void Map(ModelBuilder modelBuilder)
        {
            var map = modelBuilder.Entity<Filme>();
            map.HasKey(x => x.Id);
            map.Property(x => x.Id).ValueGeneratedOnAdd();

            // 1:N
            map.HasMany(x => x.Locacaos).WithOne(x => x.Filme).HasForeignKey(x => x.FilmeId).OnDelete(DeleteBehavior.Cascade);

        }

        #endregion


    }
}
