namespace MultiShop.Business
{
    public class CustomerDto
    {
        public int CustomerID { get; set; }
        public string NameLastName { get; set; }
        public string Email { get; set; }
        public string MobileNumber { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public bool? IsActive { get; set; }
        public DateTime CrationDate { get; set; }
    }
}
