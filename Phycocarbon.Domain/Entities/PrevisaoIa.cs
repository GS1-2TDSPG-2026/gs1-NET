namespace Phycocarbon.Domain.Entities;

public sealed class PrevisaoIa
{
    public Guid IdPrevisao { get; private set; }

    public Guid IdTanque { get; private set; }

    public Guid IdDadoOrbital { get; private set; }

    public DateTime DtPrevisao { get; private set; }

    public decimal BiomassaGL { get; private set; }

    public DateTime DtPicoPrevisto { get; private set; }

    public decimal ConfiancaPct { get; private set; }

    public string ModeloUtilizado { get; private set; }

    public Tanque Tanque { get; private set; } = null!;

    public DadoOrbital DadoOrbital { get; private set; } = null!;

    private PrevisaoIa()
    {
    }

    public PrevisaoIa(
        Guid idTanque,
        Guid idDadoOrbital,
        decimal biomassaGL,
        DateTime dtPicoPrevisto,
        decimal confiancaPct,
        string modeloUtilizado)
    {
        IdPrevisao = Guid.NewGuid();
        IdTanque = idTanque;
        IdDadoOrbital = idDadoOrbital;
        BiomassaGL = biomassaGL;
        DtPicoPrevisto = dtPicoPrevisto;
        ConfiancaPct = confiancaPct;
        ModeloUtilizado = modeloUtilizado;
        DtPrevisao = DateTime.UtcNow;
    }
}