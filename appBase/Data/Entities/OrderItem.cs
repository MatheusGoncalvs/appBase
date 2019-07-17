namespace DutchTreat.Data.Entities
{
  public class OrderItem
  {
    public int Id { get; set; }
    //Relacionamento entre OrderItem + Product - Entity framework criará
    public Product Product { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    //Relacionamento entre OrderItem + order
    public Order Order { get; set; }
  }
}