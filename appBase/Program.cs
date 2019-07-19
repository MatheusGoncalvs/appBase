using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using appBase.Data;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace appBase
{
    public class Program
    {
        //Este método fica escutando solicitações web na porta 80 ou qualquer outra porta web;
        public static void Main(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build();

            RunSeeding(host);

            host.Run();//Aqui ele cria o host e começa a "ouvir";
        }

        private static void RunSeeding(IWebHost host)
        {
            //Cria um escopo para o serviço
            var scopeFactory = host.Services.GetService<IServiceScopeFactory>();

            using (var scope = scopeFactory.CreateScope())
            {
                var seeder = scope.ServiceProvider.GetService<appBaseSeeder>();
                seeder.seed();
            }
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            //Cria um construtor padrão para o WebHost.. 
            WebHost.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration(SetupConfiguration)
                //... E então ele informa qual classe utilizará(startup.cs) para configurar como ouvir solicitações Web.
                .UseStartup<Startup>();

        private static void SetupConfiguration(WebHostBuilderContext context, IConfigurationBuilder builder)
        {
            //Removendo as opções de configuração padrão.
            builder.Sources.Clear();
            //Adiciona o arquivo json de configuração. false=não ser opcional, true=reloadOnChange
            builder.AddJsonFile("config.json", false, true);
        }
    }
}
