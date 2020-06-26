using WebApi.TaxaDeJuros.Services;

namespace WebApi.TaxaDeJuros.Tests.Fixtures
{
    public sealed class DefaultFixtures
    {
        public TaxaJurosService TaxaJurosService { get; private set; }

        public DefaultFixtures()
        {
            this.TaxaJurosService = new TaxaJurosService();
        }
    }
}
