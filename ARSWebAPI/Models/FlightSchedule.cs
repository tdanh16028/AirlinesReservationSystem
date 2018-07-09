//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ARSWebAPI.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class FlightSchedule
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FlightSchedule()
        {
            this.Tickets = new HashSet<Ticket>();
        }
    
        public long ID { get; set; }
        public string AirplaneCode { get; set; }
        public int RouteID { get; set; }
        public System.DateTime DepartureDate { get; set; }
        public int FirstSeatAvail { get; set; }
        public int BusinessSeatAvail { get; set; }
        public int ClubSeatAvail { get; set; }
        public bool IsActive { get; set; }
    
        public virtual Airplane Airplane { get; set; }
        public virtual Route Route { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
