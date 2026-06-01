namespace Phycocarbon.Domain.Entities;

public sealed class Perfil
{
    public Guid IdPerfil { get; private set; }

    public string NomePerfil { get; private set; }

    public string? Descricao { get; private set; }

    public ICollection<Usuario> Usuarios { get; private set; } = [];

    private Perfil()
    {
    }

    public Perfil(string nomePerfil, string? descricao)
    {
        IdPerfil = Guid.NewGuid();
        NomePerfil = nomePerfil;
        Descricao = descricao;
    }
}