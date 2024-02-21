using Microsoft.EntityFrameworkCore;
using MakiYumpuSAC.Models;

namespace MakiYumpuSAC.Services.Contract
{
    public interface IUsuarioService
    {
        Task<Usuario> GetUsuario(string login, string password);
        Task<Usuario> CreateUsuario(Usuario modelo);
    }
}
