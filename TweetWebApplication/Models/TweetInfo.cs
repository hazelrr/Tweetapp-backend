using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

#nullable disable

namespace TweetWebApplication.Models
{
    public partial class TweetInfo
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string TweetId { get; set; }
        public string TweetMessage { get; set; }
        public string UserId { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }

        public virtual UserInfo User { get; set; }
    }
}
