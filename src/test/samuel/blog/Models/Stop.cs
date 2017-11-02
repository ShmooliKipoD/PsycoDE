using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace blog.Models
{
    public class Stop
    {
        public Stop() { }

        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        
        public string Name { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public int Order { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]        
        public DateTime Arrival { get; set; }
    }
}