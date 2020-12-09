using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Address
    {
        public int ID { get; set; }

        public string Line1 { get; set; }
        
        public string Line2 { get; set; }

        public string PostalCode { get; set; }

        public string State { get; set; }
        
        public string Country { get; set; }
    }
}
