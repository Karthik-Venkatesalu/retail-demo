using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Product
    {
        /// <summary>
        /// Name of the product
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// Unique ID of the product
        /// </summary>
        public int? ID { get; set; }

        /// <summary>
        /// Describes the nature of the product
        /// </summary>
        public int Description { get; set; }

        /// <summary>
        /// Quantity in stock
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Base price of the product
        /// </summary>
        public int Price { get; set; }
    }
}
