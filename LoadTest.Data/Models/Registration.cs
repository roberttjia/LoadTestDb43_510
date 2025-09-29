using System;
using System.Collections.Generic;

namespace LoadTest.Data.Models
{
    public class Registration
    {
        public Registration()
        {
            Purchase = new HashSet<Purchase>();
            Selling = new HashSet<Selling>();
            Service = new HashSet<Service>();
        }

        public int RegistrationId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string PostalCode { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; } = string.Empty;
        public string Occupation { get; set; } = string.Empty;
        public string MaritalStatus { get; set; } = string.Empty;
        public string Nationality { get; set; } = string.Empty;
        public string Religion { get; set; } = string.Empty;
        public string BloodGroup { get; set; } = string.Empty;
        public string EmergencyContact { get; set; } = string.Empty;
        public string EmergencyPhone { get; set; } = string.Empty;
        public byte[]? Photo { get; set; }
        public bool IsActive { get; set; }
        public bool IsEmailVerified { get; set; }
        public bool IsPhoneVerified { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public string Role { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
        public decimal Salary { get; set; }
        public DateTime? HireDate { get; set; }

        public virtual ICollection<Purchase> Purchase { get; set; }
        public virtual ICollection<Selling> Selling { get; set; }
        public virtual ICollection<Service> Service { get; set; }
    }
}