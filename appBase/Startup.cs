using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace appBase
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //Injeta o serviço do padrão Mvc
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //utiliza arquivos padrão como a index para ser página principal. (*A ordem da chamada dos métodos deve ser essa.)
            //app.UseDefaultFiles(); //Desabilitei para usar o padrao MVC e não utilizar a página default do WWWRoot.

            //Quando recebe uma requisição, ele utiliza arquivos estáticos como resposta.
            //Eles somente funcionam dentro da pasta: wwwroot(Que é a raiz para web no asp.net core)
            app.UseStaticFiles();

            //Adiciona a configuração do padrão MVC
            app.UseMvc(cfg => 
            {
                cfg.MapRoute("Default",
                    "{controller}/{action}/{id?}",
                    new { controller = "App", Action = "Index" });
            });
        }
    }
}
