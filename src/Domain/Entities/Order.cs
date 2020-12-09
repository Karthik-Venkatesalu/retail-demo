using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Domain.Entities
{
    public class Order
    {
        /// <summary>
        /// Unique Order ID
        /// </summary>
        public int? ID { get; set; }

        /// <summary>
        /// Time when order was created (UTC)
        /// </summary>
        public DateTime CreatedTime { get; set; }

        /// <summary>
        /// Time when order details were updated (UTC)
        /// </summary>
        public DateTime UpdatedTime { get; set; }

        /// <summary>
        /// Delivery Address
        /// </summary>
        public int AddressID { get; set; }

        /// <summary>
        /// OrderStatus
        /// </summary>
        public OrderStatus OrderStatus { get; set; }
    }
}
