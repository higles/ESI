using Newtonsoft.Json;

namespace ESI.Models
{
    /// <summary>
    /// Market prices
    /// </summary>
    public class MarketPrice
    {
        /// <summary>
        /// Gets or sets the adjusted price
        /// </summary>
        [JsonProperty("adjusted_price")]
        public decimal AdjustedPrice { get; set; }
        
        /// <summary>
        /// Gets or sets the average price
        /// </summary>
        [JsonProperty("average_price")]
        public decimal AveragePrice { get; set; }

        /// <summary>
        /// Gets or sets the market type id
        /// </summary>
        [JsonProperty("type_id")]
        public int TypeId { get; set; }
    }
}
