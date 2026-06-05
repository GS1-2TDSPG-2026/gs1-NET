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
    
    private static void ValidarNome(
        string nome)
    {
        if (string.IsNullOrWhiteSpace(nome))
            throw new ArgumentException(
                "Nome é obrigatório.");
    }

    private static void ValidarEmail(
        string email)
    {
        if (string.IsNullOrWhiteSpace(email))
            throw new ArgumentException(
                "Email é obrigatório.");

        if (!email.Contains("@"))
            throw new ArgumentException(
                "Email inválido.");
    }

    private static void ValidarSenha(
        string senha)
    {
        if (string.IsNullOrWhiteSpace(senha))
            throw new ArgumentException(
                "Senha é obrigatória.");

        if (senha.Length < 8)
            throw new ArgumentException(
                "Senha deve possuir no mínimo 8 caracteres.");
    }
    
    public bool VerificarSenha(
        string senha)
    {
        return HashHelper.Verify(
            senha,
            SenhaHash);
    }
    
    public Usuario(
        long idPerfil,
        string nome,
        string email,
        string senha,
        string? telefone,
        string status)
    {
        ValidarNome(nome);
        ValidarEmail(email);
        ValidarSenha(senha);

        IdPerfil = idPerfil;
        Nome = nome;
        Email = email;
        Telefone = telefone;
        Status = status;

        SenhaHash = HashHelper.GenerateHash(senha);

        DtCriacao = DateTime.UtcNow;
    }
}