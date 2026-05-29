using Phycocarbon.Domain.Common;

namespace Phycocarbon.Domain.Entities;

public class DadoOrbital : BaseEntity
{
    public Guid FazendaId { get; set; }

    public string Fonte { get; set; } = string.Empty;

    public DateTime DtColeta { get; set; }

    public decimal IrradianciaPar { get; set; }

    public decimal Nebulosidade { get; set; }

    public decimal TemperaturaAmbiente { get; set; }

    public decimal Latitude { get; set; }

    public decimal Longitude { get; set; }

    public virtual Fazenda Fazenda { get; set; } = null!;

    public virtual ICollection<PrevisaoIa> Previsoes { get; set; }
        = new List<PrevisaoIa>();
}