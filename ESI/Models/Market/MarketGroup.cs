using Newtonsoft.Json;
using System.Collections.Generic;

namespace ESI.Models
{
    /// <summary>
    /// Market Group Class
    /// </summary>
    public class MarketGroup
    {
        /// <summary>
        /// Gets or sets the market group id
        /// </summary>
        [JsonProperty("market_group_id")]
        public int ID { get; set; }
        
        /// <summary>
        /// Gets or sets the market group description
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the market group name
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the parent group ID
        /// </summary>
        [JsonProperty("parent_group_id")]
        public int ParentGroupID { get; set; }

        /// <summary>
        /// Gets or sets the types within this market group
        /// </summary>
        [JsonProperty("types")]
        public List<int> Types { get; set; } = new List<int>();
    }
}
