namespace Phycocarbon.Domain.Entities;

public sealed class DadoOrbital
{
    public Guid IdDadoOrbital { get; private set; }

    public Guid IdFazenda { get; private set; }

    public string Fonte { get; private set; }

    public DateTime DtColeta { get; private set; }

    public decimal? IrradianciaPar { get; private set; }

    public decimal? Nebulosidade { get; private set; }

    public decimal? TemperaturaAmbiente { get; private set; }

    public decimal? Latitude { get; private set; }

    public decimal? Longitude { get; private set; }

    public Fazenda Fazenda { get; private set; } = null!;

    public ICollection<PrevisaoIa> Previsoes { get; private set; } = [];

    private DadoOrbital()
    {
    }

    public DadoOrbital(
        Guid idFazenda,
        string fonte,
        DateTime dtColeta,
        decimal? irradianciaPar,
        decimal? nebulosidade,
        decimal? temperaturaAmbiente,
        decimal? latitude,
        decimal? longitude)
    {
        IdDadoOrbital = Guid.NewGuid();
        IdFazenda = idFazenda;
        Fonte = fonte;
        DtColeta = dtColeta;
        IrradianciaPar = irradianciaPar;
        Nebulosidade = nebulosidade;
        TemperaturaAmbiente = temperaturaAmbiente;
        Latitude = latitude;
        Longitude = longitude;
    }
}