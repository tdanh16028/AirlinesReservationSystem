//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ARSWebMVC.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Route
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Route()
        {
            this.FlightSchedules = new HashSet<FlightSchedule>();
        }
    
        public int ID { get; set; }
        public int CityAID { get; set; }
        public int CityBID { get; set; }
        public int SkyMiles { get; set; }
        public double BasePrice { get; set; }
    
        public virtual City City { get; set; }
        public virtual City City1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FlightSchedule> FlightSchedules { get; set; }
    }
}
