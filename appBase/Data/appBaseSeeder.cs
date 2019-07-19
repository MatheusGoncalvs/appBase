using DutchTreat.Data.Entities;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appBase.Data
{
    public class appBaseSeeder
    {
        private readonly appBaseContext context;
        private readonly IHostingEnvironment hosting;

        public appBaseSeeder(appBaseContext context, IHostingEnvironment hosting)
        {
            this.context = context;
            this.hosting = hosting;
        }

        public void seed()
        {
            //Certifica que o bd existe antes de qualquer coisa: Senão irá criá-lo.
            context.Database.EnsureCreated();

            if(!context.Products.Any())
            {
                //Precisa inserir dados
                //Pega um arquivo json e convert em objetos
                var filePath = Path.Combine(hosting.ContentRootPath,"Data/art.json");
                var json = File.ReadAllText(filePath);
                var products = JsonConvert.DeserializeObject<IEnumerable<Product>>(json);

                //Adiciona a collection de products no banco
                context.AddRange(products);
                context.SaveChanges();

                //Pega a ordem já cadastrada pela migrations e cria uma orderItem
                var order = context.Orders.Where(o => o.Id == 1).FirstOrDefault();
                if(order != null)
                {
                    order.Items = new List<OrderItem>()
                    {
                        new OrderItem()
                        {
                            Product = products.First(),
                            Quantity = 5,
                            UnitPrice = products.First().Price
                        }
                    };
                }
            }
        }
    }
}
