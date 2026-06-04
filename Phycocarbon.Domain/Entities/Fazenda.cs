namespace Phycocarbon.Domain.Entities;

public sealed class Fazenda
{
    public long IdFazenda { get; private set; }

    public long IdUsuarioResponsavel { get; private set; }

    public string Nome { get; private set; }

    public string Cidade { get; private set; }

    public string Uf { get; private set; }

    public decimal? Latitude { get; private set; }

    public decimal? Longitude { get; private set; }

    public string Status { get; private set; }

    public DateTime DtCadastro { get; private set; }

    public Usuario UsuarioResponsavel { get; private set; } = null!;

    public ICollection<Tanque> Tanques { get; private set; } = [];

    public ICollection<DadoOrbital> DadosOrbitais { get; private set; } = [];

    private Fazenda()
    {
    }

    public Fazenda(
        long idUsuarioResponsavel,
        string nome,
        string cidade,
        string uf,
        decimal? latitude,
        decimal? longitude,
        string status)
    {
        IdUsuarioResponsavel = idUsuarioResponsavel;
        Nome = nome;
        Cidade = cidade;
        Uf = uf;
        Latitude = latitude;
        Longitude = longitude;
        Status = status;
        DtCadastro = DateTime.UtcNow;
    }
}