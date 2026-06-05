using Microsoft.EntityFrameworkCore;
using Phycocarbon.Application.Repositories;
using Phycocarbon.Domain.Entities;

namespace Phycocarbon.Infrastructure.Persistence.Repositories;

public sealed class UsuarioRepository(
    PhycocarbonContext context)
    : IUsuarioRepository
{
    public IEnumerable<Usuario> GetAll()
    {
        return context.Usuarios
            .AsNoTracking()
            .ToList();
    }

    public Usuario? GetById(long id)
    {
        return context.Usuarios
            .AsNoTracking()
            .FirstOrDefault(x => x.IdUsuario == id);
    }
}