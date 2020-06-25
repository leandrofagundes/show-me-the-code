using WebApi.Juros.Domain.ValueObjects;

namespace WebApi.Juros.Services
{
    public sealed class TaxaJurosService
    {
        public TaxaJuros ObterTaxaJuros()
        {
            return new TaxaJuros(0.01);
        }
    }
}
