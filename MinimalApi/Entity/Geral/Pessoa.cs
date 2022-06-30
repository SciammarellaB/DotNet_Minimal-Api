using MinimalApi.Entity.Interface;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinimalApi.Entity.Geral
{
    [Table("Pessoa", Schema = "Geral")]
    public class Pessoa : IEntity
    {
        public long Id { get; set; }
        [Required, MaxLength(255)] public string Nome { get; set; } = "";
        public int Idade { get; set; }
        public string Sexo { get; set; } = "";
        public DateTime DataHoraCriacao { get; set; }

        public Pessoa()
        {
            DataHoraCriacao = DateTime.UtcNow;
        }
    }
}
