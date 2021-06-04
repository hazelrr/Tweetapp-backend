using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TweetWebApplication.Models
{
    public partial class ReplyTweetInfo
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ReplyTweetId { get; set; }
        public string TweetId { get; set; }
        public string TweetUserId { get; set; }
        public string ReplyUserId { get; set; }
        public string ReplyTweetMessage { get; set; }        
        public DateTime? CreatedOn { get; set; }

    }
}
