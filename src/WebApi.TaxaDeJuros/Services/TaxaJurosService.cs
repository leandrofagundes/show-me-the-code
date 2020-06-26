using WebApi.TaxaDeJuros.Domain.ValueObjects;

namespace WebApi.TaxaDeJuros.Services
{
    public sealed class TaxaJurosService
    {
        public TaxaJuros ObterTaxaJuros()
        {
            return new TaxaJuros(0.01);
        }
    }
}
