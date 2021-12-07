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

        public List<Tag> TagsList { get; set; }

        public void FillTagsList()
        {
            TagsList = new List<Tag>();

            if (!string.IsNullOrEmpty(tags.amenity))
            {
                TagsList.Add(new Tag()
                {
                    Name = "Amenity",
                    Value = tags.amenity,
                    Order = 0
                });
            }


        if (!string.IsNullOrEmpty(tags.addrhousenumber ))
        {
            TagsList.Add(new Tag()
            {
                Name = "addrhousenumber",
                Value = tags.addrhousenumber,
                Order = 0
            });
        }
            if (!string.IsNullOrEmpty(tags.addrpostcode ))
            {
                TagsList.Add(new Tag()
                {
                    Name = "addrpostcode",
                    Value = tags.addrpostcode,
                    Order = 0
                });
            }
            if (!string.IsNullOrEmpty(tags.addrstreet ))
            {
                TagsList.Add(new Tag()
                {
                    Name = "addrstreet",
                    Value = tags.addrstreet,
                    Order = 0
                });
            }

            if (!string.IsNullOrEmpty(tags.name ))
            {
                TagsList.Add(new Tag()
                {
                    Name = "name",
                    Value = tags.name,
                    Order = 0
                });
            }
            if (!string.IsNullOrEmpty(tags.old_name ))
            {
                TagsList.Add(new Tag()
                {
                    Name = "old_name",
                    Value = tags.old_name,
                    Order = 0
                });
            }
            if (!string.IsNullOrEmpty(tags.addrcity ))
            {
                TagsList.Add(new Tag()
                {
                    Name = "addrcity",
                    Value = tags.addrcity,
                    Order = 0
                });
            }
            if (!string.IsNullOrEmpty(tags.fhrsid ))
            {
                TagsList.Add(new Tag()
                {
                    Name = "fhrsid",
                    Value = tags.fhrsid,
                    Order = 0
                });
            }
            if (!string.IsNullOrEmpty(tags.website ))
            {
                TagsList.Add(new Tag()
                {
                    IsLink = true,
                    Name = "website",
                    Value = tags.website,
                    Order = 0
                });
            }
            if (!string.IsNullOrEmpty(tags.cuisine ))
            {
                TagsList.Add(new Tag()
                {
                    Name = "cuisine",
                    Value = tags.cuisine,
                    Order = 0
                });
            }
            if (!string.IsNullOrEmpty(tags.dietvegan ))
            {
                TagsList.Add(new Tag()
                {
                    Name = "dietvegan",
                    Value = tags.dietvegan,
                    Order = 0
                });
            }
            if (!string.IsNullOrEmpty(tags.dietvegetarian ))
            {
                TagsList.Add(new Tag()
                {
                    Name = "dietvegetarian",
                    Value = tags.dietvegetarian,
                    Order = 0
                });
            }
            if (!string.IsNullOrEmpty(tags.internet_access ))
            {
                TagsList.Add(new Tag()
                {
                    Name = "internet_access",
                    Value = tags.internet_access,
                    Order = 0
                });
            }
            if (!string.IsNullOrEmpty(tags.note ))
            {
                TagsList.Add(new Tag()
                {
                    Name = "note",
                    Value = tags.note,
                    Order = 0
                });
            }
            if (!string.IsNullOrEmpty(tags.opening_hours ))
            {
                TagsList.Add(new Tag()
                {
                    Name = "opening_hours",
                    Value = tags.opening_hours,
                    Order = 0
                });
            }
            if (!string.IsNullOrEmpty(tags.phone ))
            {
                TagsList.Add(new Tag()
                {
                    Name = "phone",
                    Value = tags.phone,
                    Order = 0
                });
            }
            if (!string.IsNullOrEmpty(tags.smoking ))
            {
                TagsList.Add(new Tag()
                {
                    Name = "smoking",
                    Value = tags.smoking,
                    Order = 0
                });
            }
            if (!string.IsNullOrEmpty(tags.wheelchair ))
            {
                TagsList.Add(new Tag()
                {
                    Name = "wheelchair",
                    Value = tags.wheelchair,
                    Order = 0
                });
            }
            if (!string.IsNullOrEmpty(tags.brand ))
            {
                TagsList.Add(new Tag()
                {
                    Name = "brand",
                    Value = tags.brand,
                    Order = 0
                });
            }
            if (!string.IsNullOrEmpty(tags.brandwikidata ))
            {
                TagsList.Add(new Tag()
                {
                    Name = "brandwikidata",
                    Value = tags.brandwikidata,
                    Order = 0
                });
            }
            if (!string.IsNullOrEmpty(tags.brandwikipedia ))
            {
                TagsList.Add(new Tag()
                {
                    Name = "brandwikipedia",
                    Value = tags.brandwikipedia,
                    Order = 0
                });
            }
            if (!string.IsNullOrEmpty(tags.official_name ))
            {
                TagsList.Add(new Tag()
                {
                    Name = "official_name",
                    Value = tags.official_name,
                    Order = 0
                });
            }
            if (!string.IsNullOrEmpty(tags._operator ))
            {
                TagsList.Add(new Tag()
                {
                    Name = "_operator",
                    Value = tags._operator,
                    Order = 0
                });
            }
            if (!string.IsNullOrEmpty(tags.takeaway ))
            {
                TagsList.Add(new Tag()
                {
                    Name = "takeaway",
                    Value = tags.takeaway,
                    Order = 0
                });
            }
            if (!string.IsNullOrEmpty(tags.food ))
            {
                TagsList.Add(new Tag()
                {
                    Name = "food",
                    Value = tags.food,
                    Order = 0
                });
            }
            if (!string.IsNullOrEmpty(tags.sourceaddr ))
            {
                TagsList.Add(new Tag()
                {
                    Name = "sourceaddr",
                    Value = tags.sourceaddr,
                    Order = 0
                });
            }
            if (!string.IsNullOrEmpty(tags.toiletswheelchair ))
            {
                TagsList.Add(new Tag()
                {
                    Name = "toiletswheelchair",
                    Value = tags.toiletswheelchair,
                    Order = 0
                });
            }
            if (!string.IsNullOrEmpty(tags.url ))
            {
                TagsList.Add(new Tag()
                {
                    Name = "url",
                    Value = tags.url,
                    Order = 0
                });
            }
            if (!string.IsNullOrEmpty(tags.wikidata ))
            {
                TagsList.Add(new Tag()
                {
                    Name = "wikidata",
                    Value = tags.wikidata,
                    Order = 0
                });
            }
            if (!string.IsNullOrEmpty(tags.wikipedia ))
            {
                TagsList.Add(new Tag()
                {
                    Name = "wikipedia",
                    Value = tags.wikipedia,
                    Order = 0
                });
            }
            if (!string.IsNullOrEmpty(tags.outdoor_seating ))
            {
                TagsList.Add(new Tag()
                {
                    Name = "outdoor_seating",
                    Value = tags.outdoor_seating,
                    Order = 0
                });
            }
            if (!string.IsNullOrEmpty(tags.addrhousename ))
            {
                TagsList.Add(new Tag()
                {
                    Name = "addrhousename",
                    Value = tags.addrhousename,
                    Order = 0
                });
            }
            if (!string.IsNullOrEmpty(tags.level ))
            {
                TagsList.Add(new Tag()
                {
                    Name = "level",
                    Value = tags.level,
                    Order = 0
                });
            }
            if (!string.IsNullOrEmpty(tags.source ))
            {
                TagsList.Add(new Tag()
                {
                    Name = "source",
                    Value = tags.source,
                    Order = 0
                });
            }

            if (!string.IsNullOrEmpty(tags.entrance ))            {
                TagsList.Add(new Tag()
                {
                    Name = "entrance",
                    Value = tags.entrance,
                    Order = 0
                });
            }
            if (!string.IsNullOrEmpty(tags.costcoffee ))
            {
                TagsList.Add(new Tag()
                {
                    Name = "costcoffee",
                    Value = tags.costcoffee,
                    Order = 0
                });
            }
            if (!string.IsNullOrEmpty(tags.ele ))
            {
                TagsList.Add(new Tag()
                {
                    Name = "ele",
                    Value = tags.ele,
                    Order = 0
                });
            }
            if (!string.IsNullOrEmpty(tags.theme ))
            {
                TagsList.Add(new Tag()
                {
                    Name = "theme",
                    Value = tags.theme,
                    Order = 0
                });
            }
            if (!string.IsNullOrEmpty(tags.office ))
            {
                TagsList.Add(new Tag()
                {
                    Name = "office",
                    Value = tags.office,
                    Order = 0
                });
            }
            if (!string.IsNullOrEmpty(tags.check_dateopening_hours ))
            {
                TagsList.Add(new Tag()
                {
                    Name = "check_dateopening_hours",
                    Value = tags.check_dateopening_hours,
                    Order = 0
                });
            }
            if (!string.IsNullOrEmpty(tags.email ))
            {
                TagsList.Add(new Tag()
                {
                    Name = "email",
                    Value = tags.email,
                    Order = 0
                });
            }
            if (!string.IsNullOrEmpty(tags.shop ))
            {
                TagsList.Add(new Tag()
                {
                    Name = "shop",
                    Value = tags.shop,
                    Order = 0
                });
            }
            if (!string.IsNullOrEmpty(tags.addrplace ))
            {
                TagsList.Add(new Tag()
                {
                    Name = "addrplace",
                    Value = tags.addrplace,
                    Order = 0
                });
            }
            if (!string.IsNullOrEmpty(tags.addrfloor ))
            {
                TagsList.Add(new Tag()
                {
                    Name = "addrfloor",
                    Value = tags.addrfloor,
                    Order = 0
                });
            }
            if (!string.IsNullOrEmpty(tags.seasonal ))
            {
                TagsList.Add(new Tag()
                {
                    Name = "seasonal",
                    Value = tags.seasonal,
                    Order = 0
                });
            }
            if (!string.IsNullOrEmpty(tags.sourceaddress ))
            {
                TagsList.Add(new Tag()
                {
                    Name = "sourceaddress",
                    Value = tags.sourceaddress,
                    Order = 0
                });
            }
            if (!string.IsNullOrEmpty(tags.building ))
            {
                TagsList.Add(new Tag()
                {
                    Name = "building",
                    Value = tags.building,
                    Order = 0
                });
            }
            if (!string.IsNullOrEmpty(tags.sourcegeometry ))
            {
                TagsList.Add(new Tag()
                {
                    Name = "sourcegeometry",
                    Value = tags.sourcegeometry,
                    Order = 0
                });
            }
            if (!string.IsNullOrEmpty(tags.buildinglevels ))
            {
                TagsList.Add(new Tag()
                {
                    Name = "buildinglevels",
                    Value = tags.buildinglevels,
                    Order = 0
                });
            }
            if (!string.IsNullOrEmpty(tags.rooflevels ))
            {
                TagsList.Add(new Tag()
                {
                    Name = "rooflevels",
                    Value = tags.rooflevels,
                    Order = 0
                });
            }
            if (!string.IsNullOrEmpty(tags.roofshape ))
            {
                TagsList.Add(new Tag()
                {
                    Name = "roofshape",
                    Value = tags.roofshape,
                    Order = 0
                });
            }
            if (!string.IsNullOrEmpty(tags.wifi ))
            {
                TagsList.Add(new Tag()
                {
                    Name = "wifi",
                    Value = tags.wifi,
                    Order = 0
                });
            }
            if (!string.IsNullOrEmpty(tags.contactinstagram ))
            {
                TagsList.Add(new Tag()
                {
                    Name = "contactinstagram",
                    Value = tags.contactinstagram,
                    Order = 0
                });
            }
            if (!string.IsNullOrEmpty(tags.description ))
            {
                TagsList.Add(new Tag()
                {
                    Name = "description",
                    Value = tags.description,
                    Order = 0
                });
            }
            if (!string.IsNullOrEmpty(tags.facebook ))
            {
                TagsList.Add(new Tag()
                {
                    Name = "facebook",
                    Value = tags.facebook,
                    Order = 0
                });
            }
            if (!string.IsNullOrEmpty(tags.opening_date ))
            {
                TagsList.Add(new Tag()
                {
                    Name = "opening_date",
                    Value = tags.opening_date,
                    Order = 0
                });
            }
        }
    }

    public class Tag
    {
        public Tag()
        {
            IsLink = false;
        }
        public string Name { get; set; }
        public string Value { get; set; }
        public int Order { get; set; }

        public bool IsLink { get; set; }

    }



    public class Tags
    {
        public string addrhousenumber { get; set; }
        public string addrpostcode { get; set; }
        public string addrstreet { get; set; }
        public string amenity { get; set; }
        public string name { get; set; }
        public string old_name { get; set; }
        public string addrcity { get; set; }
        public string fhrsid { get; set; }
        public string website { get; set; }
        public string cuisine { get; set; }
        public string dietvegan { get; set; }
        public string dietvegetarian { get; set; }
        public string internet_access { get; set; }
        public string note { get; set; }
        public string opening_hours { get; set; }
        public string phone { get; set; }
        public string smoking { get; set; }
        public string wheelchair { get; set; }
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