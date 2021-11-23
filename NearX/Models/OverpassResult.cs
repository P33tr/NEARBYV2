namespace NearX.Models
{
    public class OverpassResult
    {
        public float version { get; set; }
        public string generator { get; set; }
        public Osm3s osm3s { get; set; }
        public Element[] elements { get; set; }
    }

    public class Osm3s
    {
        public DateTime timestamp_osm_base { get; set; }
        public string copyright { get; set; }
    }

    public class Element
    {
        public string type { get; set; }
        public long id { get; set; }
        public float lat { get; set; }
        public float lon { get; set; }
        public Tags tags { get; set; }
        public Center center { get; set; }
        public long[] nodes { get; set; }
    }

    public class Tags
    {
        //used
        public string addrhousenumber { get; set; }
        public string addrpostcode { get; set; }
        //used
        public string addrstreet { get; set; }
        public string amenity { get; set; }
        //used
        public string name { get; set; }
        public string old_name { get; set; }
        //used
        public string addrcity { get; set; }
        public string fhrsid { get; set; }
        // used
        public string website { get; set; }
        public string cuisine { get; set; }
        public string dietvegan { get; set; }
        public string dietvegetarian { get; set; }
        public string internet_access { get; set; }
        public string note { get; set; }
        //used
        public string opening_hours { get; set; }
        //used
        public string phone { get; set; }
        public string smoking { get; set; }
        public string wheelchair { get; set; }
        //used
        public string brand { get; set; }
        public string brandwikidata { get; set; }
        public string brandwikipedia { get; set; }
        public string official_name { get; set; }
        public string _operator { get; set; }
        public string takeaway { get; set; }
        public string food { get; set; }
        public string sourceaddr { get; set; }
        public string toiletswheelchair { get; set; }
        public string url { get; set; }
        public string wikidata { get; set; }
        public string wikipedia { get; set; }
        public string outdoor_seating { get; set; }
        public string addrhousename { get; set; }
        public string level { get; set; }
        public string source { get; set; }
        public string entrance { get; set; }
        public string costcoffee { get; set; }
        public string ele { get; set; }
        public string theme { get; set; }
        public string office { get; set; }
        public string check_dateopening_hours { get; set; }
        public string email { get; set; }
        public string shop { get; set; }
        public string addrplace { get; set; }
        public string addrfloor { get; set; }
        public string seasonal { get; set; }
        public string sourceaddress { get; set; }
        public string building { get; set; }
        public string sourcegeometry { get; set; }
        public string buildinglevels { get; set; }
        public string rooflevels { get; set; }
        public string roofshape { get; set; }
        public string wifi { get; set; }
        public string contactinstagram { get; set; }
        public string description { get; set; }
        public string facebook { get; set; }
        public string opening_date { get; set; }
    }

    public class Center
    {
        public float lat { get; set; }
        public float lon { get; set; }
    }

}