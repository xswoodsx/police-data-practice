namespace policedata.Models
{
    public class CrimeDetails
    {
        public string category { get; set; }
        public string location_type { get; set; }
        public Location location { get; set; }
        public Location longitude { get; set; }
        public int id { get; set; }
        public string month { get; set; }
    }

    public class Location
    {
        public string latitude { get; set; }
        public string longitude { get; set; }
    }
}