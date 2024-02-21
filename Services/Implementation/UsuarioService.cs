using Microsoft.EntityFrameworkCore;
using MakiYumpuSAC.Models;
using MakiYumpuSAC.Services.Contract;

namespace MakiYumpuSAC.Services.Implementation
{
    public class UsuarioService : IUsuarioService
    {
        private readonly MakiYumpuSacContext _dbContext;

        public UsuarioService(MakiYumpuSacContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Usuario> GetUsuario(string login, string password)
        {
            Usuario usuarioEncontrado = await _dbContext.Usuarios.Where(u => u.LoginUsuario == login && u.PasswordUsuario == password)
                .FirstOrDefaultAsync();

            return usuarioEncontrado;
        }

        public async Task<Usuario> CreateUsuario(Usuario modelo)
        {
            _dbContext.Usuarios.Add(modelo);

            await _dbContext.SaveChangesAsync();

            return modelo;
        }
    }
}
