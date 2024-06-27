using System.ComponentModel.DataAnnotations;

namespace Fiap.Web.SmartWasteManagement.ViewModels
{
    public class MoradorViewModel
    {
        [Required]
        public int Codigo { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Nome do Morador")]
        public string Nome { get; set; }

        [Required]
        [Display(Name = "Endereço")]
        public string Endereco { get; set; }

        [Required]
        [Phone]
        [Display(Name = "Telefone")]
        public string Telefone { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
