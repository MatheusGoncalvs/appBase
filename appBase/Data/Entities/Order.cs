using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DutchTreat.Data.Entities
{
  public class Order
  {
    //Id AutoIncrement
    public int Id { get; set; }
    
    public DateTime OrderDate { get; set; }
    public string OrderNumber { get; set; }
    //Relacionamento de duas entidades(Order + OrderItem) - Relacionamento um para muitos
    public ICollection<OrderItem> Items { get; set; }
  }
}
