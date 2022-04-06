using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroCaminhoneirosMVC.Models
{
    public class CaminhaoMotorista
    {
        
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo Marca é obrigatório")]
        public string Marca { get; set; }
        [Required(ErrorMessage = "O campo Modelo é obrigatório")]
        public string Modelo { get; set; }
        [Required(ErrorMessage = "O campo Placa é obrigatório")]
        public string Placa { get; set; }
        [Required(ErrorMessage = "O campo Eixos é obrigatório")]
        public int Eixos { get; set; }
        [Required(ErrorMessage = "O campo Motorista é obrigatório")]
        public int MotoristaId { get; set; }
        public Motorista Motorista { get; set; }
    }
}
