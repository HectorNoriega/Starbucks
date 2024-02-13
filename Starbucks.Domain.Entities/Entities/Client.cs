namespace Starbucks.Domain.Entities
{
    public class Client
    {
        public Client(int id, string name, string documentType, string documentNumber, string email)
        {
            Id = id;
            Name = name;
            DocumentType = documentType;
            DocumentNumber = documentNumber;
            Email = email;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string DocumentType { get; set; }
        public string DocumentNumber { get; set; }
        public string Email { get; set; }

    }
}
