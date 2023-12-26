using Inventario.TI.BackEnd.DTO;
using Inventario.TI.BackEnd.Interfaces.FilaEMails;
using Inventario.TI.BackEnd.Models;
using Inventario.TI.Core.Extensions;
using Newtonsoft.Json;

namespace Inventario.TI.BackEnd.Services
{
    public class EmailService : IEmailService
    {
        public string MontarEmailCriacaoConta(Guid idExternoUsuario, string token)
        {
            var dados = new DtoAtivarConta()
            {
                IdExterno = idExternoUsuario,
                Token = token,
            };

            var key = StringExtension.Base64Encode(JsonConvert.SerializeObject(dados));
            var link = $"https://www.cshju.com.br?key={ key }";
            var mensagem = @$"Link para ativação da conta: { link }";

            return mensagem;
        }
    }
}
