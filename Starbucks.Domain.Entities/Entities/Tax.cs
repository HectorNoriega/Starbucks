namespace Starbucks.Domain.Entities
{
    public sealed class Tax : Entity
    {
        public Tax(Guid id, int idProvince, string provinceName, double taxAmount) :base(id)
        {
            Id = id;
            IdProvince = idProvince;
            ProvinceName = provinceName;
            TaxAmount = taxAmount;
        }

        public int IdProvince { get; set; }
        public string ProvinceName { get; set; }
        public double TaxAmount { get; set; }
    }
}
