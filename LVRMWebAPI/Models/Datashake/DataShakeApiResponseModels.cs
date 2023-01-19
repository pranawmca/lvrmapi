using System.Collections.Generic;

namespace LVRMWebAPI.Models.Datashake
{
    public class DataShakeApiResponseModels
    {
    }
    public class Review
    {
        public object id { get; set; }
        public string name { get; set; }
        public string date { get; set; }
        public double rating_value { get; set; }
        public string review_text { get; set; }
        public string url { get; set; }
        public string profile_picture { get; set; }
        public object location { get; set; }
        public object review_title { get; set; }
        public bool verified_order { get; set; }
        public object reviewer_title { get; set; }
        public object language_code { get; set; }
        public string unique_id { get; set; }
        public string meta_data { get; set; }
    }

    public class DataShakeApiResponseModel
    {
        public bool success { get; set; }
        public int? status { get; set; }
        public int? job_id { get; set; }
        public string source_url { get; set; }
        public string source_name { get; set; }
        public string place_id { get; set; }
        public object external_identifier { get; set; }
        public string meta_data { get; set; }
        public string unique_id { get; set; }
        public int? review_count { get; set; }
        public double? average_rating { get; set; }
        public string last_crawl { get; set; }
        public string crawl_status { get; set; }
        public int? percentage_complete { get; set; }
        public int? result_count { get; set; }
        public int? credits_used { get; set; }
        public object from_date { get; set; }
        public object blocks { get; set; }
        public List<Review> reviews { get; set; }
    }

    public class DatashakeJobIDDetails
    {
        public string DealerId { get;set; }
        public string PlaceID { get; set; }
        public string JobID { get; set; }
        public string ReviewCount { get; set; }
        public string Status { get; set; }
    }
}
