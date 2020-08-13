using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    [Table("locacao")]
    public class Locacao
    {
        #region Propriedades
        [Key]
        [Required, Column("id")]
        public int Id { get; set; }

        [Required, Column("data_locacao")]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}")]
        public DateTime DataLocacao { get; set; }

        [Required, Column("data_devolucao")]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}")]
        public DateTime DataDevolucao { get; set; }

        #endregion

        #region Relacionamentos

        [Required, Column("cliente_id")]
        public int ClientId { get; set; }
        public Cliente Cliente { get; set; }

        [Required, Column("filme_id")]
        public int FilmeId { get; set; }
        public Filme Filme { get; set; }

        #endregion

        #region Mapeamento

        public static void Map(ModelBuilder modelBuilder)
        {
            var map = modelBuilder.Entity<Locacao>();
            map.HasKey(x => x.Id);
            map.Property(x => x.Id).ValueGeneratedOnAdd();

            // 1:N
            map.HasOne(x => x.Cliente).WithMany(x => x.Locacaos).HasForeignKey(x => x.ClientId).OnDelete(DeleteBehavior.Cascade);
            // 1:N
            map.HasOne(x => x.Filme).WithMany(x => x.Locacaos).HasForeignKey(x => x.FilmeId).OnDelete(DeleteBehavior.Restrict);
            
        }

        #endregion
    }
}
