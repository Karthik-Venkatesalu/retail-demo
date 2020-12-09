using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Dto.Model
{
    public class Product
    {
        /// <summary>
        /// Name of the property
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Unique ID of the property
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
