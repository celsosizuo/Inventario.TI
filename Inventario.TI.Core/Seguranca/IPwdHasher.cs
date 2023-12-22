namespace Inventario.TI.Core.Seguranca
{
    public interface IPwdHasher
    {
        Task<bool> VerifyHashAsync(string password, string passwordHash);
        Task<string> CreateHashAsync(string password);
    }
}
