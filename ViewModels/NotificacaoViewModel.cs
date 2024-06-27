using Fiap.Web.SmartWasteManagement.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace Fiap.Web.SmartWasteManagement.ViewModels
{
    public class NotificacaoViewModel
    {
        [Required]
        public int Codigo { get; set; }

        [Required]
        [Display(Name = "Data da Notificação")]
        public DateTime DataEnvio { get; set; }

        [Required]
        [Display(Name = "Tipo de Notificação")]
        public NotificacaoStatus Tipo { get; set; }

        [Required]
        [Display(Name = "Status de Leitura")]
        public LeituraStatus Leitura { get; set; }

        [Required]
        [Display(Name = "Código do Recipiente")]
        public int CodigoRecipiente { get; set; }

        [Required]
        [Display(Name = "Código do Morador")]
        public int CodigoMorador { get; set; }
    }
}
