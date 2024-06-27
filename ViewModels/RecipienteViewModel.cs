using Fiap.Web.SmartWasteManagement.Models;
using Fiap.Web.SmartWasteManagement.Models.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Fiap.Web.SmartWasteManagement.ViewModels
{
    public class RecipienteViewModel
    {
        [Required]
        public int Codigo { get; set; }

        [Required]
        [Display(Name = "Endereço do Recipiente")]
        public string Endereco { get; set; }

        [Required]
        [Display(Name = "Tipo de Resíduo")]
        public TipoResiduo TipoResiduo { get; set; }

        [Required]
        [Range(0, 100, ErrorMessage = "Nível de ocupação deve ser entre 0 e 100.")]
        [Display(Name = "Nível de Ocupação")]
        public decimal NivelOcupacaoAtual { get; set; }

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Capacidade total deve ser um valor positivo.")]
        [Display(Name = "Capacidade Total")]
        public decimal CapacidadeTotal { get; set; }

        [Required]
        [Display(Name = "Código do Morador")]
        public int CodigoMorador { get; set; }
    }
}
