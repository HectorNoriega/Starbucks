namespace Starbucks.Domain.Entities
{
    public class Bills
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public Client Client { get; set; }
        public string Concept { get; set; }
        public string Description { get; set; }
        public double Amount { get; set; }
        public double TaxAmount { get; set; }
        public double TotalAmount { get; set; }
        public List<BillsDetails> Details { get; set; }
    }
}
