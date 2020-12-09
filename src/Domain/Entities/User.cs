using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class User
    {
        public string Name { get; set; }
        public int ID { get; set; }
        public string EmailID { get; set; }
        public string PrimaryContact { get; set; }
    }
}
