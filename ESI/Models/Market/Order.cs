using Newtonsoft.Json;

namespace ESI.Models
{
    /// <summary>
    /// Order class
    /// </summary>
    public class Order
    {
        /// <summary>
        /// Gets or sets the order ID
        /// </summary>
        [JsonProperty("order_id")]
        public long ID { get; set; }

        /// <summary>
        /// Gets or sets the order duration
        /// </summary>
        [JsonProperty("duration")]
        public int Duration { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this is a buy order
        /// </summary>
        [JsonProperty("is_buy_order")]
        public bool IsBuyOrder { get; set; }

        /// <summary>
        /// Gets or sets the date this order was issued
        /// </summary>
        [JsonProperty("issued")]
        public string Issued { get; set; }
        
        /// <summary>
        /// Gets or sets the station in which this order was placed
        /// </summary>
        [JsonProperty("location_id")]
        public long LocationID { get; set; }

        /// <summary>
        /// Gets or sets the minimum volume of the order
        /// </summary>
        [JsonProperty("min_volume")]
        public int MinVolume { get; set; }

        /// <summary>
        /// Gets or sets the pice of the order
        /// </summary>
        [JsonProperty("price")]
        public double Price { get; set; }

        /// <summary>
        /// Gets or sets the range of the order
        /// </summary>
        [JsonProperty("range")]
        public string Range { get; set; }

        /// <summary>
        /// Gets or sets the solar system this order was placed in
        /// </summary>
        [JsonProperty("system_id")]
        public int SystemID { get; set; }

        /// <summary>
        /// Gets or sets the type id
        /// </summary>
        [JsonProperty("type_id")]
        public int TypeID { get; set; }

        /// <summary>
        /// Gets or sets the quantity remaining
        /// </summary>
        [JsonProperty("volume_remain")]
        public int VolumeRemain { get; set; }

        /// <summary>
        /// Gets or sets the total quantity
        /// </summary>
        [JsonProperty("volume_total")]
        public int VolumeTotal { get; set; }
    }
}
