namespace Airlines.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("mydb.flights")]
    public partial class flights
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public flights()
        {
            stations = new HashSet<stations>();
            traveltime = new HashSet<traveltime>();
        }

        [Key]
        public int idFlights { get; set; }

        public int TravelTimeId { get; set; }

        public int FlightCrewId { get; set; }

        public int RouteId { get; set; }

        public virtual flightcrews flightcrews { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<stations> stations { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<traveltime> traveltime { get; set; }
    }
}
