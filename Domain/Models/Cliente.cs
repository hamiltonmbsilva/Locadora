using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    [Table("cliente")]
    public class Cliente
    {
        #region Propriedades
        [Key]
        [Required, Column("id")]
        public int Id { get; set; }

        [Required, Column("nome"), MaxLength(200)]
        public string Nome { get; set; }

        [Required, Column("cpf"), MaxLength(11)]
        public string CPF { get; set; }

        [Required, Column("data_nascimento"), MaxLength(11)]
        public DateTime DataNascimento { get; set; }

        #endregion

        #region Relacionamentos

        public virtual List<Locacao> Locacaos { get; set; }

        #endregion

        #region Mapeamento

        public static void Map(ModelBuilder modelBuilder)
        {
            var map = modelBuilder.Entity<Cliente>();
            map.HasKey(x => x.Id);
            map.Property(x => x.Id).ValueGeneratedOnAdd();

            // 1:N
            map.HasMany(x => x.Locacaos).WithOne(x => x.Cliente).HasForeignKey(x => x.ClientId).OnDelete(DeleteBehavior.Cascade);            

        }

        #endregion
    }
}
