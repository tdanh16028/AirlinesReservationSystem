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
    
    public partial class AirplaneInfo
    {
        public int AirplaneTypeID { get; set; }
        public int ClassID { get; set; }
        public int SeatCount { get; set; }
    
        public virtual AirplaneClass AirplaneClass { get; set; }
        public virtual AirplaneType AirplaneType { get; set; }
    }
}
