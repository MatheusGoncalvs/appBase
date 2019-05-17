using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace appBase
{
    public class Program
    {
        //Este método fica escutando solicitações web na porta 80 ou qualquer outra porta web;
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();//Aqui ele cria o host e começa a "ouvir";
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args) //Cria um construtor padrão para o WebHost.. 
                .UseStartup<Startup>(); //... E então ele informa qual classe utilizará(startup.cs) para configurar como ouvir solicitações Web.
    }
}
