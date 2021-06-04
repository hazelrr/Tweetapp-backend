using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TweetWebApplication.Models;

namespace TweetWebApplication.Interface
{
    public interface ITweetInfo
    {
        public Task<List<TweetInfo>> ViewAllTweets();
        public Task<List<TweetInfo>> ViewAllTweetsByUser(string userId);
        public Task<TweetInfo> PostTweet(TweetInfo tweetInfo);
        public Task<ReplyTweetInfo> ReplyTweet(ReplyTweetInfo replytweetInfo);
        public Task<List<ReplyTweetInfo>> ViewAllReplyTweetsByTweetId(string tweetId);
    }
}
