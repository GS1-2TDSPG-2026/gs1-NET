namespace Phycocarbon.Domain.Entities;

public sealed class PrevisaoIa
{
    public long IdPrevisao { get; private set; }

    public long IdTanque { get; private set; }

    public long IdDadoOrbital { get; private set; }

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
        long idTanque,
        long idDadoOrbital,
        decimal biomassaGL,
        DateTime dtPicoPrevisto,
        decimal confiancaPct,
        string modeloUtilizado)
    {
        
        IdTanque = idTanque;
        IdDadoOrbital = idDadoOrbital;
        BiomassaGL = biomassaGL;
        DtPicoPrevisto = dtPicoPrevisto;
        ConfiancaPct = confiancaPct;
        ModeloUtilizado = modeloUtilizado;
        DtPrevisao = DateTime.UtcNow;
    }
}