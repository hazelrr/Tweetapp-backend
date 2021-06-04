using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TweetWebApplication.Models;

namespace TweetWebApplication.Interface
{
    public interface ISqlDataRepository
    {
        public Task<UserInfo> GetUserByEmailAddress(string emailId);
        public Task<UserInfo> GetUserByUserId(int userId);
        public Task<List<UserInfo>> GetAllUsers();
        public Task<List<TweetInfo>> ViewAllTweets();
        public Task<List<TweetInfo>> ViewAllTweetsByUserId(string userId);
        public Task<TweetInfo> PostTweet(TweetInfo tweetInfo);
        public Task<ReplyTweetInfo> ReplyTweet(ReplyTweetInfo replytweetInfo);
        public Task<List<ReplyTweetInfo>> ViewAllReplyTweetsByTweetId(string tweetId);
        public Task<UserInfo> AddUser(UserInfo user);
        public Task<UserInfo> ModifyUser(UserInfo user);
       

    }
}
