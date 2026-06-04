namespace Phycocarbon.Domain.Entities;

public sealed class Usuario
{
    public long IdUsuario { get; private set; }

    public long IdPerfil { get; private set; }

    public string Nome { get; private set; }

    public string Email { get; private set; }

    public string SenhaHash { get; private set; }

    public string? Telefone { get; private set; }

    public string Status { get; private set; }

    public DateTime DtCriacao { get; private set; }

    public Perfil Perfil { get; private set; } = null!;

    public ICollection<Fazenda> Fazendas { get; private set; } = [];

    private Usuario()
    {
    }

    public Usuario(
        long idPerfil,
        string nome,
        string email,
        string senhaHash,
        string? telefone,
        string status)
    {
        IdPerfil = idPerfil;
        Nome = nome;
        Email = email;
        SenhaHash = senhaHash;
        Telefone = telefone;
        Status = status;
        DtCriacao = DateTime.UtcNow;
    }
}