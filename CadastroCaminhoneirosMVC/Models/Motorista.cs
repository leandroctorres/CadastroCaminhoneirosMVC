using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroCaminhoneirosMVC.Models
{
    public class Motorista
    {
        public int Id { get; set; }
        [Display(Name = "Primeiro Nome")]
        [Required(ErrorMessage = "O campo Primeiro Nome é obrigatório")]
        public string PrimeiroNome { get; set; }
        [Display(Name = "Último Nome")]
        [Required(ErrorMessage = "O campo Último Nome é obrigatório")]
        public string UltimoNome { get; set; }

        public List<CaminhaoMotorista> CaminhaoMotorista { get; set; }
        public List<EnderecoMotorista> EnderecoMotorista { get; set; }
    }
}
