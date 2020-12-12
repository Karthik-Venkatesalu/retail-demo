using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Application.Dto.Model
{
    public class Order
    {
        /// <summary>
        /// Unique Order ID
        /// </summary>
        [JsonPropertyName("id")]
        public int? ID { get; set; }

        /// <summary>
        /// Time when order was created (UTC)
        /// </summary>
        [JsonPropertyName("createdTime")]
        public DateTime CreatedTime { get; set; }

        /// <summary>
        /// Time when order details were updated (UTC)
        /// </summary>
        [JsonPropertyName("updatedTime")]
        public DateTime? UpdatedTime { get; set; }

        /// <summary>
        /// Delivery Address
        /// </summary>
        [JsonPropertyName("addressId")]
        public int AddressID { get; set; }

        /// <summary>
        /// OrderStatus
        /// </summary>
        [JsonPropertyName("status")]
        public string Status { get; set; }

        /// <summary>
        /// List of products ordered
        /// </summary>
        [JsonPropertyName("items")]
        public List<OrderProduct> Items { get; set; }
    }
}
