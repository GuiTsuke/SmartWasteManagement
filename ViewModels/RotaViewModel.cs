using System.ComponentModel.DataAnnotations;

namespace Fiap.Web.SmartWasteManagement.ViewModels
{
    public class RotaViewModel
    {
        [Required]
        public int Codigo { get; set; }

        [Required]
        [Display(Name = "Data da Coleta")]
        public DateTime DataColeta { get; set; }

        [Required]
        [Display(Name = "Data e Hora de Início")]
        public DateTime HoraInicio { get; set; }

        [Required]
        [Display(Name = "Data e Hora de Fim")]
        public DateTime HoraFim { get; set; }

        [Required]
        [Display(Name = "Pontos de Coleta")]
        public string PontosColeta { get; set; }

        [Required]
        [Display(Name = "Código do Caminhão")]
        public int CodigoCaminhao { get; set; }
    }
}
