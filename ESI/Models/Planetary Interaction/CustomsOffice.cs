using Newtonsoft.Json;

namespace ESI.Models
{
    /// <summary>
    /// Customs Office class
    /// </summary>
    public class CustomsOffice
    {
        /// <summary>
        /// Gets or sets the unique id of this customs office
        /// </summary>
        [JsonProperty("office_id")]
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets the alliance tax rate
        /// Only present if alliance access is allowed
        /// </summary>
        [JsonProperty("alliance_tax_rate")]
        public decimal AllianceTaxRate { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to allow access with standings
        /// standing_level and any standing related tax rate only present when this is true
        /// </summary>
        [JsonProperty("allow_access_with_standings")]
        public bool AllowAccessWithStandings { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to allow alliance access
        /// </summary>
        [JsonProperty("allow_alliance_access")]
        public bool AllowAllianceAccess { get; set; }

        /// <summary>
        /// Gets or sets the bad standing tax rate
        /// </summary>
        [JsonProperty("bad_standing_tax_rate")]
        public decimal BadStandingTaxRate { get; set; }

        /// <summary>
        /// Gets or sets the corporation tax rate
        /// </summary>
        [JsonProperty("corporation_tax_rate")]
        public decimal CorporationTaxRate { get; set; }

        /// <summary>
        /// Gets or sets the excellent standing tax rate
        /// </summary>
        [JsonProperty("excellent_standing_tax_rate")]
        public decimal ExcellentStandingTaxRate { get; set; }

        /// <summary>
        /// Gets or sets the good standing tax rate
        /// </summary>
        [JsonProperty("good_standing_tax_rate")]
        public decimal GoodStandingTaxRate { get; set; }

        /// <summary>
        /// Gets or sets the neutral standing tax rate
        /// </summary>
        [JsonProperty("neutral_standing_tax_rate")]
        public decimal NeutralStandingTaxRate { get; set; }

        /// <summary>
        /// Gets or sets the reinforcement exit end
        /// </summary>
        [JsonProperty("reinforce_exit_end")]
        public int ReinforceExitEnd { get; set; }

        /// <summary>
        /// Gets or sets the reinforcement exit start
        /// Together with reinforce_exit_end, marks a 2-hour period where this customs office could exit reinforcement mode during the day after initial attack
        /// </summary>
        [JsonProperty("reinforce_exit_start")]
        public int ReinforceExitStart { get; set; }

        /// <summary>
        /// Gets or sets the standing level allowed
        /// Access is allowed only for entities with this level of standing or better
        /// </summary>
        [JsonProperty("standing_level")]
        public string StandingLevel { get; set; }

        /// <summary>
        /// Gets or sets the ID of the solar system this customs office is located in
        /// </summary>
        [JsonProperty("system_id")]
        public int SystemID { get; set; }

        /// <summary>
        /// Gets or sets the terrible standing tax rate
        /// </summary>
        [JsonProperty("terrible_standing_tax_rate")]
        public decimal TerribleStandingTaxRate { get; set; }
    }
}
