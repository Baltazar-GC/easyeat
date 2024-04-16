namespace easyeat.DTOs.Addresses
{
    public class NewAddress
    {
        public string CountryCode { get; set; }

        public string CountryName { get; set; }

        public string Street { get; set; }

        public string City { get; set; }
        
        public int PostalCode { get; set; }
    }
}