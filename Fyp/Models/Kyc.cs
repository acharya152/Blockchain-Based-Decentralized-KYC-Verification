using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace Fyp.Models
{
    public class Kyc
    {
        [Key]
        public int userID {  get; set; }

        [Required(ErrorMessage = "This field is required.")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "This field is required.")]

        public string LastName { get; set; }
        [Required(ErrorMessage = "This field is required.")]

        public string FatherFirstName { get; set; }
        [Required(ErrorMessage = "This field is required.")]

        public string FatherLastName { get; set; }
        public string? SpouseFirstName { get; set; }
        public string? SpouseLastName { get; set; }
        [Required(ErrorMessage = "This field is required.")]

        public string MaritialStatus { get; set; }
        [Required(ErrorMessage = "This field is required.")]

        public DateTime Dob {  get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public string Gender {  get; set; }
        [Required(ErrorMessage = "This field is required.")]

        public string Nationality {  get; set; }
        [Required(ErrorMessage = "This field is required.")]

        public string ResidentalStatus { get; set; }

        public string? pan {  get; set; }
        [Required(ErrorMessage = "This field is required.")]

        public string StreetAddress { get; set; }
        [Required(ErrorMessage = "This field is required.")]

        public string StreetAddress2 { get; set; }
        [Required(ErrorMessage = "This field is required.")]

        public string City { get; set; }
        [Required(ErrorMessage = "This field is required.")]

        public string State { get; set; }
        [Required(ErrorMessage = "This field is required.")]

        public string ZipCode { get; set; }
        [Required(ErrorMessage = "This field is required.")]

        public string Country { get; set; }
        [Required(ErrorMessage = "This field is required.")]

        public string Phone { get; set; }
        [Required(ErrorMessage = "This field is required.")]

        public string Email { get; set; }
        [Required(ErrorMessage = "This field is required.")]

        public string? PhotoProof { get; set; }











    }
}
