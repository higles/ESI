using System.ComponentModel.DataAnnotations;

namespace ESI.Models
{
    /// <summary>
    /// Schematic class
    /// </summary>
    public class Schematic
    {
        /// <summary>
        /// Gets or sets the schematic id
        /// </summary>
        [Key]
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets the cycle time
        /// </summary>
        public int CycleTime { get; set; }

        /// <summary>
        /// Gets or sets the schematic name
        /// </summary>
        public string Name { get; set; }
    }
}
