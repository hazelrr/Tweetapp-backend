using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Threading.Tasks;
using TweetWebApplication.Interface;
using TweetWebApplication.Models;

namespace TweetWebApplication.Repository
{
    public class SqlDataRepository :ISqlDataRepository
    {
        //private readonly DbContext db;
        //private readonly DbSet<TweetInfo> tweetDb;
        //private readonly DbSet<UserInfo> userDb;

        //public SqlDataRepository(TweetAppDbContext tweetAppDbContext)
        //{
        //    db = tweetAppDbContext;
        //    tweetDb = db.Set<TweetInfo>();
        //    userDb = db.Set<UserInfo>();
        //}

    
        private readonly IMongoCollection<UserInfo> userDb;
        private readonly IMongoCollection<TweetInfo> tweetDb;
        private readonly IMongoCollection<ReplyTweetInfo> replytweetDb;
        private readonly TweetAppConfig _settings;

        public SqlDataRepository(IOptions<TweetAppConfig> settings)
        {
            _settings = settings.Value;
            var client = new MongoClient(_settings.TweetAppDbConnectionString);
            var database = client.GetDatabase(_settings.DataBaseName);
            userDb = database.GetCollection<UserInfo>(_settings.UserCollectionName);
            tweetDb = database.GetCollection<TweetInfo>(_settings.TweetsCollectionName);
            replytweetDb = database.GetCollection<ReplyTweetInfo>(_settings.ReplyTweetsCollectionName);
        }




        public async Task<UserInfo> AddUser(UserInfo userInfo)
        {
            userInfo.CreatedOn = DateTime.Now;
            userInfo.UpdatedOn = DateTime.Now;
            //var user = userDb.Add(userInfo).Entity;
            await userDb.InsertOneAsync(userInfo);
            //await db.SaveChangesAsync();
            //return user;
            return userInfo;
        }

        public async Task<List<UserInfo>> GetAllUsers()
        {
            return await userDb.Find(x => true).ToListAsync();
        }

        public async Task<UserInfo> GetUserByEmailAddress(string emailId)
        {
            return userDb.Find<UserInfo>(x => x.EmailAddress == emailId).FirstOrDefault();
        }

        public async Task<UserInfo> GetUserByUserId(int userId)
        {
            return userDb.Find<UserInfo>(x => x.UserId == userId.ToString()).FirstOrDefault();
        }

        public async Task<UserInfo> ModifyUser(UserInfo userInfo)
        {
           await userDb.ReplaceOneAsync(c => c.UserId == userInfo.UserId, userInfo);
            //await db.SaveChangesAsync();
            // return user;
            return userInfo;
        }

        public async Task<TweetInfo> PostTweet(TweetInfo tweetInfo)
        {
            await tweetDb.InsertOneAsync(tweetInfo);
            //await db.SaveChangesAsync();
            return tweetInfo;

        }

        public async Task<ReplyTweetInfo> ReplyTweet(ReplyTweetInfo replytweetInfo)
        {
            await replytweetDb.InsertOneAsync(replytweetInfo);
            //await db.SaveChangesAsync();
            return replytweetInfo;

        }

        public async Task<List<ReplyTweetInfo>> ViewAllReplyTweetsByTweetId(string tweetid)
        {
            return await replytweetDb.Find<ReplyTweetInfo>(x => x.TweetId == tweetid).ToListAsync();
        }

        public Task<List<TweetInfo>> ViewAllTweets()
        {
            return tweetDb.Find(x => true).ToListAsync();
        }

        public async Task<List<TweetInfo>> ViewAllTweetsByUserId(string userId)
        {
            return await tweetDb.Find<TweetInfo>(x => x.UserId == userId).ToListAsync();
        }

    }
}
