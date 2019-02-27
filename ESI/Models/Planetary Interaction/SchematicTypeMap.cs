using System.ComponentModel.DataAnnotations;

namespace ESI.Models
{
    /// <summary>
    /// Schematic Type Map class
    /// </summary>
    public class SchematicTypeMap
    {
        /// <summary>
        /// Gets or sets the schematic id
        /// </summary>
        [Key]
        public int SchematicID { get; set; }

        /// <summary>
        /// Gets or sets the type id
        /// </summary>
        [Key]
        public int TypeID { get; set; }

        /// <summary>
        /// Gets or sets the quantity
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this is an input
        /// </summary>
        public bool IsInput { get; set; }
    }
}
