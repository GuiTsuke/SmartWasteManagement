using System.ComponentModel.DataAnnotations;

namespace Fiap.Web.SmartWasteManagement.ViewModels
{
    public class AgendamentoColetaViewModel
    {
        [Required]
        public int Codigo { get; set; }

        [Required]
        [Display(Name = "Data do Agendamento")]
        public DateTime DataAgendamento { get; set; }

        [Required]
        [Display(Name = "Código do Recipiente")]
        public int CodigoRecipiente { get; set; }

        [Required]
        [Display(Name = "Código da Rota")]
        public int CodigoRota { get; set; }
    }
}
