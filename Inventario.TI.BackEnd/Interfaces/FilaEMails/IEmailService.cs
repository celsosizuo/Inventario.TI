using Inventario.TI.BackEnd.Models;

namespace Inventario.TI.BackEnd.Interfaces.FilaEMails
{
    public interface IEmailService
    {
        string MontarEmailCriacaoConta(Guid idExternoUsuario, string token);
    }
}
