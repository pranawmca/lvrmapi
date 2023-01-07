using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace LVRMWebAPI.Models
{
    public partial class TwilioOptOuts
    {
        public int Id { get; set; }
        public string PhoneNumber { get; set; }
        public int? DealerId { get; set; }
        public DateTime? DateOptedOut { get; set; }
        public int? UserId { get; set; }
        public int? CustomerId { get; set; }
    }
}
