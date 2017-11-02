using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace blog.Models
{
    public class Trip
    {
        public Trip()
        {

        }
        
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Name { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime DateCreated { get; set; }    

        public string UserName { get; set; }   

        
        public ICollection<Stop>  Stops { get; set; }  
    }
}