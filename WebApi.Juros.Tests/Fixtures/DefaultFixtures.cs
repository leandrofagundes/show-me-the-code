using WebApi.Juros.Services;

namespace WebApi.Juros.Tests.Fixtures
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
