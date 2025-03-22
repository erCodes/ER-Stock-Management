namespace ER_Stock_Management_DataLibrary
{
    public class Store
    {
        public required string Id { get; set; }
        public required string Name { get; set; }
        public required string City { get; set; }
        public string? Address { get; set; }
        public string? Supervisor { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public required List<Product> Products { get; set; }

        public Store()
        {
            Products ??= [];
        }
    }
}
