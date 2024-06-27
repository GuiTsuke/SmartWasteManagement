using Fiap.Web.SmartWasteManagement.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace Fiap.Web.SmartWasteManagement.ViewModels
{
    public class CaminhaoViewModel
    {
        [Required]
        public int Codigo { get; set; }

        [Required]
        [StringLength(10)]
        [Display(Name = "Placa do Caminhão")]
        public string Placa { get; set; }

        [Required]
        [Range(0.000, double.MaxValue, ErrorMessage = "Capacidade de carga deve ser um valor positivo.")]
        [Display(Name = "Capacidade de Carga")]
        public decimal CapacidadeCarga { get; set; }

        [Required]
        [Display(Name = "Status do Caminhão")]
        public CaminhaoStatus Status { get; set; }

        [Display(Name = "Localização Atual")]
        public string LocalizacaoAtual { get; set; }
    }
}
