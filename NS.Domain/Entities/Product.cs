using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NS.Domain.Entities
{
    public class Product
    {
        public long Id { get; private set; }
        public string Name { get; private set; }
        public DateTime ProductDate { get; private set; }
        public string ManufacturePhone { get; private set; }
        public string ManufactureEmail { get; private set; }
        public bool IsAvailable { get; private set; }
        public string CreatedBy { get; private set; } 
        public Product(string name, DateTime productDate, string manufacturePhone, string manufactureEmail, bool isAvailable, string createdBy)
        {
            Name = name;
            ProductDate = productDate;
            ManufacturePhone = manufacturePhone;
            ManufactureEmail = manufactureEmail;
            IsAvailable = isAvailable;
            CreatedBy = createdBy ?? throw new ArgumentNullException(nameof(createdBy));
        }

        public void Edit(string name, DateTime productDate, string manufacturePhone, string manufactureEmail,
            bool isAvailable)
        {
            Name = name;
            ProductDate = productDate;
            ManufacturePhone = manufacturePhone;
            ManufactureEmail = manufactureEmail;
            IsAvailable = isAvailable;
        }
    }
}
