using Newtonsoft.Json;
using System;

namespace ESI.Models
{
    public class MarketStatistic
    {
        /// <summary>
        /// Gets or sets the average price
        /// </summary>
        [JsonProperty("average")]
        public decimal Average { get; set; }

        /// <summary>
        /// Gets or sets the date
        /// </summary>
        [JsonProperty("date")]
        public DateTime Date { get; set; }

        /// <summary>
        /// Gets or sets the highest price
        /// </summary>
        [JsonProperty("highest")]
        public decimal Highest { get; set; }

        /// <summary>
        /// Gets or sets the lowest price
        /// </summary>
        [JsonProperty("lowest")]
        public decimal Lowest { get; set; }

        /// <summary>
        /// Gets or sets the number of orders
        /// </summary>
        [JsonProperty("order_count")]
        public int OrderCount { get; set; }

        /// <summary>
        /// Gets or sets the volume
        /// </summary>
        [JsonProperty("volume")]
        public double Volume { get; set; }
    }
}
