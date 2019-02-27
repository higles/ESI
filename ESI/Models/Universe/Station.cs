using ESI.Classes;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace ESI.Models
{
    /// <summary>
    /// Station class
    /// </summary>
    public class Station
    {
        /// <summary>
        /// Gets or sets the station ID
        /// </summary>
        [JsonProperty("station_id")]
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets the max dockable ship volume
        /// </summary>
        [JsonProperty("max_dockable_ship_volume")]
        public float MaxDockableShipVolume { get; set; }

        /// <summary>
        /// Gets or sets the station name
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the office rental cost
        /// </summary>
        [JsonProperty("office_rental_cost")]
        public float OfficeRentalCost { get; set; }

        /// <summary>
        /// Gets or sets the ID of the corporation that controls this station
        /// </summary>
        [JsonProperty("owner")]
        public int Owner { get; set; }

        /// <summary>
        /// Gets or sets the stellar position of this station
        /// </summary>
        [JsonProperty("position")]
        public StellarPosition Position { get; set; } = new StellarPosition();

        /// <summary>
        /// Gets or sets the race ID of this station
        /// </summary>
        [JsonProperty("race_id")]
        public int RaceID { get; set; }

        /// <summary>
        /// Gets or sets the station's reprocessing efficiency
        /// </summary>
        [JsonProperty("reprocessing_efficiency")]
        public float ReprocessingEfficiency { get; set; }

        /// <summary>
        /// Gets or sets the station's reprocessing take
        /// </summary>
        [JsonProperty("reprocessing_stations_take")]
        public float ReprocessingStationsTake { get; set; }

        /// <summary>
        /// Gets or sets the station's services
        /// </summary>
        [JsonProperty("services")]
        public List<string> Services { get; set; } = new List<string>();

        /// <summary>
        /// Gets or sets the solar system this station is in
        /// </summary>
        [JsonProperty("system_id")]
        public int SystemID { get; set; }

        /// <summary>
        /// Gets or sets the type ID
        /// </summary>
        [JsonProperty("type_id")]
        public int TypeID { get; set; }
    }
}
