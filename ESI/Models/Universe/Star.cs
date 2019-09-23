using Newtonsoft.Json;

namespace ESI.Models
{
    /// <summary>
    /// Star class
    /// </summary>
    public class Star
    {
        /// <summary>
        /// Gets or sets the age of this star in years
        /// </summary>
        [JsonProperty("age")]
        public long Age { get; set; }

        /// <summary>
        /// Gets or sets the luminosity of this star
        /// </summary>
        [JsonProperty("luminosity")]
        public float Luminosity { get; set; }

        /// <summary>
        /// Gets or sets the star's name
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the radius
        /// </summary>
        [JsonProperty("radius")]
        public int Radius { get; set; }

        /// <summary>
        /// Gets or sets the star's system ID
        /// </summary>
        [JsonProperty("solar_system_id")]
        public int SolarSystemID { get; set; }

        /// <summary>
        /// Gets or sets the spectral class of the star
        /// </summary>
        [JsonProperty("spectral_class")]
        public string SpectralClass { get; set; }

        /// <summary>
        /// Gets or sets the temperature of the star
        /// </summary>
        [JsonProperty("temperature")]
        public int Temperature { get; set; }

        /// <summary>
        /// Gets or sets the type ID
        /// </summary>
        [JsonProperty("type_id")]
        public int TypeID { get; set; }
    }
}
