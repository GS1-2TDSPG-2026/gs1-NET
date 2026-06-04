namespace Phycocarbon.Domain.Entities;

public sealed class Perfil
{
    public long IdPerfil { get; private set; }

    public string NomePerfil { get; private set; }

    public string? Descricao { get; private set; }

    public ICollection<Usuario> Usuarios { get; private set; } = [];

    private Perfil()
    {
    }

    public Perfil(string nomePerfil, string? descricao)
    {
        NomePerfil = nomePerfil;
        Descricao = descricao;
    }
}