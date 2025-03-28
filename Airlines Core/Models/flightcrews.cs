namespace Airlines.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("mydb.flightcrews")]
    public partial class flightcrews
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public flightcrews()
        {
            flights = new HashSet<flights>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idFlightCrews { get; set; }

        public int PilotId { get; set; }

        public int NavigatorId { get; set; }

        public int RadioOperatorId { get; set; }

        public int FlightAttendantsId { get; set; }

        public virtual flightattendants flightattendants { get; set; }

        public virtual navigators navigators { get; set; }

        public virtual pilots pilots { get; set; }

        public virtual radiooperators radiooperators { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<flights> flights { get; set; }
    }
}
