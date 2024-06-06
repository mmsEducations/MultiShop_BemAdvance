namespace MultiShop.Data
{
    public class Customer : BaseEntity, IOrdered
    {
        public int CustomerID { get; set; }
        public string NameLastName { get; set; }
        public string Email { get; set; }
        public string MobileNumber { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public int? Order { get; set; }

        public List<Order> Orders { get; set; }
    }

}
