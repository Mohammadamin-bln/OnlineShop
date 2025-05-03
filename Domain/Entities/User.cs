using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Common;
using Domain.Enums;

namespace Domain.Entities
{
    public class User : BaseEntity<Guid>
    {
        public string Username { get; set; }
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string PasswordHash { get; set; }

        public string? Address { get; set; }

        public string? PostalCode { get; set; }

        public City? City { get; set; }

        public UserRole Role { get; set; } = UserRole.Customer;
    }
}
