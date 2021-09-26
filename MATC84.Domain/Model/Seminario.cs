using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MATC84.Domain.Model
{
    public class Seminario
    {
        public int SeminarioId { get; set; }
        [Required]
        public string Tema { get; set; }
        public DateTime? Data { get; set; }
        public int? QtdPessoas { get; set; }
        public decimal? Nota { get; set; }
        public IEnumerable<Pessoa> Grupo { get; set; }
    }
}