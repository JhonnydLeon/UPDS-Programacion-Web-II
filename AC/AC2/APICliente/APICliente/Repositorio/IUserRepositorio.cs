using APICliente.Modelos;
using APICliente.Modelos.Dto;
using System.Runtime.CompilerServices;

namespace APICliente.Repositorio
{
    public interface IUserRepositorio
    {
        Task<string> Register(User user, string password);
        Task<string> login(string userName, string password);
        Task<bool> UserExiste(string username);


    }
}
