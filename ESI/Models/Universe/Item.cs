using ESI.Classes;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ESI.Models
{
    /// <summary>
    /// Item type class
    /// </summary>
    public class Item
    {
        /// <summary>
        /// Gets or sets the type id
        /// </summary>
        [JsonProperty("type_id")]
        [Key]
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets the capacity
        /// </summary>
        [JsonProperty("capacity")]
        public double Capacity { get; set; }

        /// <summary>
        /// Gets or sets the description
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the item's attributes
        /// </summary>
        [JsonProperty("dogma_attributes")]
        [NotMapped]
        public List<Attribute> DogmaAttributes { get; set; } = new List<Attribute>();

        /// <summary>
        /// Gets or sets the item's effects
        /// </summary>
        [JsonProperty("dogma_effects")]
        [NotMapped]
        public List<Effect> DogmaEffects { get; set; } = new List<Effect>();

        /// <summary>
        /// Gets or sets the graphic id
        /// </summary>
        [JsonProperty("graphic_id")]
        public int GraphicID { get; set; }

        /// <summary>
        /// Gets or sets the group id
        /// </summary>
        [JsonProperty("group_id")]
        public int GroupID { get; set; }

        /// <summary>
        /// Gets or sets the icon id
        /// </summary>
        [JsonProperty("icon_id")]
        public int IconID { get; set; }

        /// <summary>
        /// Gets or sets the market group id
        /// </summary>
        [JsonProperty("market_group_id")]
        public int MarketGroupID { get; set; }

        /// <summary>
        /// Gets or sets the mass
        /// </summary>
        [JsonProperty("mass")]
        public double Mass { get; set; }

        /// <summary>
        /// Gets or sets the name
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the packaged volume
        /// </summary>
        [JsonProperty("packaged_volume")]
        public double PackagedVolume { get; set; }

        /// <summary>
        /// Gets or sets the portion size
        /// </summary>
        [JsonProperty("portion_size")]
        public int PortionSize { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the item is published
        /// </summary>
        [JsonProperty("published")]
        public bool Published { get; set; }

        /// <summary>
        /// Gets or sets the radius
        /// </summary>
        [JsonProperty("radius")]
        public double Radius { get; set; }

        /// <summary>
        /// Gets or sets the volume
        /// </summary>
        [JsonProperty("volume")]
        public double Volume { get; set; }
    }
}
