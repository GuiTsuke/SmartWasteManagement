namespace Fiap.Web.SmartWasteManagement.Models
{
    public class MoradorModel
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }
        public List<RecipienteModel> Recipientes { get; set; }
        public List<NotificacaoModel> Notificacoes { get; set; }

    }
}
