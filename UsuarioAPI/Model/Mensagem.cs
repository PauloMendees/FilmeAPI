using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UsuariosAPI.Model
{
    public class Mensagem
    {
        public string Conteudo { get; set; }
        public string Assunto { get; set; }
        public List<MailboxAddress> Destinatario { get; set; }
        public Mensagem(IEnumerable<string> destinatario, string assunto, int usuarioId, string codigo)
        {
            Conteudo = "Clique no seguinte link para ativar sua conta:" + 
                $"http://localhost:6000/api/ativarConta?UserId={usuarioId}&CodigoDeAtivacao={codigo}";
            Assunto = assunto;
            Destinatario = new List<MailboxAddress>();
            Destinatario.AddRange(destinatario.Select(d => new MailboxAddress(d)));
        }

    }
}
