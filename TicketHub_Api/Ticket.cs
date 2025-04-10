using System.ComponentModel.DataAnnotations;

namespace TicketHub_Api
{
    public class Ticket
    {
        [Required(ErrorMessage = "Concert Id is required")]
        public int ConcertId { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Name is required")]
        [MaxLength(200)]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Phone Number is required")]
        [Phone(ErrorMessage = "Input should be in Phone Number format")]
        public string  Phone {  get; set; } = string.Empty;

        [Required(ErrorMessage = "Tickets quantity is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Value should be greater than or equal to 1")]
        public int Quantity {  get; set; }

        [CreditCard (ErrorMessage = "Invalid Credit Card Number")]
        [Required(ErrorMessage = "Credit Card Number is required")]
        public string CreditCard {  get; set; } = string.Empty;

        [Required(ErrorMessage = "Expiration is required")]
        [RegularExpression(@"^(0[1-9]|1[0-2])(\/?)([0-9]{2}|[0-9]{4})$",
            ErrorMessage = "Expiration must be in MM/YY or MM/YYYY format")]
        public string Expiration { get; set; } = string.Empty;

        [Required(ErrorMessage = "Security code is required")]
        [RegularExpression(@"^[0-9]{3,4}$",
            ErrorMessage = "Security code must be 3 or 4 digits")]
        public string SecurityCode { get; set; } = string.Empty;

        [Required(ErrorMessage = "Address is required")]
        [MaxLength(200)]
        public string Address { get; set; } = string.Empty;

        [Required(ErrorMessage = "City is required")]
        [MaxLength(80)]
        public string City { get; set; } =string.Empty;

        [Required(ErrorMessage = "Province is required")]
        public string Province { get; set; } = string.Empty;

        [Required(ErrorMessage = "Postal Code is required")]
        public string PostalCode { get; set; } = string.Empty;

        [Required(ErrorMessage = "Country is required")]
        [MaxLength(60)]
        public string Country { get; set; } = string.Empty;
    }
}
