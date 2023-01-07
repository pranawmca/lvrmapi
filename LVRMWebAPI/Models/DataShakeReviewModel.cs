using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LVRMWebAPI.Models
{
    public class DataShakeReviewModel
    {
        [Key]
        public int id { get; set; }
        public string place_id { get; set; }
        public string job_id { get; set; }
        public string review_count { get; set; }
        public string Source { get; set; }
        public List<DatashakeReview> reviewlist { get; set; }
    }
    public class DatashakeReview
    {
        [Key]
        public int id { get; set; }
        public string ReviewID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ReviewDate { get; set; }
        public string Rating { get; set; }
        public string ReviewDesc { get; set; }
        public string Status { get; set; }
        public string Subject { get; set; }
        public string URL { get; set; }
        public string Profile_picture { get; set; }
        public string Location { get; set; }
        public string Review_title { get; set; }
        public string Verified_order { get; set; }
        public string Reviewer_title { get; set; }
        public string Language_code { get; set; }
        public string Unique_id { get; set; }
        public string Meta_data { get; set; }
    }
}
