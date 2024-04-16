using System.ComponentModel.DataAnnotations;

namespace easyeat.Business.Model
{
    public class Address
    {
        [Key]
        public int Id { get; set; }

        public string CountryCode { get; set; }

        public string CountryName { get; set; }

        public string Street { get; set; }

        public string City { get; set; }
        
        public int PostalCode { get; set; }
    }
}