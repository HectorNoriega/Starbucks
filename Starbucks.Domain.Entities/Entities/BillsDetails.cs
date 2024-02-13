namespace Starbucks.Domain.Entities
{
    public class BillsDetails
    {
        public int Id { get; set; }
        public int IdBill { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
