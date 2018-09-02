using Microsoft.Extensions.DependencyInjection;
using PetShop.Core.ApplicationService.Implementation;
using PetShop.Core.DomainService;
using PetShop.Infrastructure.Static.Data.Repositories;
using PetShop.Core.ApplicationService;
using PetShop.Infrastructure.Static.Data;

namespace PetShop
{
    class Program
    {
        static void Main()
        {
            FakeDb.InitData();

            var serviceCollection = new ServiceCollection();

            serviceCollection.AddScoped<IPetShopRepository, PetShopRepository>();
            serviceCollection.AddScoped<IPetShopService, PetShopService>();
            serviceCollection.AddScoped<IPrinter, Printer>();

            var serviceProvider = serviceCollection.BuildServiceProvider();
            var printer = serviceProvider.GetRequiredService<IPrinter>();

            printer.ChooseMenuItem();
        }
    }
}
