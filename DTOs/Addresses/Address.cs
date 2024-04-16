namespace easyeat.DTOs.Addresses
{
    public class Address
    {
        public int Id { get; set; }

        public string CountryCode { get; set; }

        public string CountryName { get; set; }

        public string Street { get; set; }

        public string City { get; set; }
        
        public int PostalCode { get; set; }
    }
}