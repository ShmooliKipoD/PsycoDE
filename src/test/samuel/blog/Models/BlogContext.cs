using MongoDB.Driver;

namespace blog.Models
{
    public class BlogContext
    {
        private MongoClient _client;
        private IMongoDatabase _db;

        public BlogContext()
        {
            _client = new MongoClient("mongodb://localhost");
            _db = _client.GetDatabase("blog");
        }

        public IMongoCollection<Trip> Trips 
        { 
            get
            {
                return _db.GetCollection<Trip>("trips");
            } 
        }

        // public MongoCollection<Stop> Stops 
        // { 
        //     get
        //     {
        //         return _db.GetCollection<Stop>("stops");
        //     } 
        // }
    }
}