using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LVRMWebAPI.Models.Datashake
{
    public class DatashakeReviewField
    {
        [Key]
        public string PlaceID { get; set; }
        public int JobID { get; set; }
        public int ReviewCount { get; set; }
        public string Source { get; set; }
        public string ReviewID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime ReviewDate { get; set; }
        public decimal Rating { get; set; }
        public string ReviewDesc { get; set; }
    }
}
