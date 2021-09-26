using System.ComponentModel.DataAnnotations;

namespace MATC84.Domain.Model
{
    public class Pessoa
    {
        public int PessoaId { get; set; }
        
        [Required]
        public string Nome { get; set; }

        public int? Idade { get; set; }
        
        [Required]
        public string Matricula { get; set; }
        public int? Semestre { get; set; }
        public int SeminarioId { get; set; }
        public Seminario Seminario { get; set; }
    }
}