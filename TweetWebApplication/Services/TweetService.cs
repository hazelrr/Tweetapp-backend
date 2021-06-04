using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TweetWebApplication.Interface;
using TweetWebApplication.Models;

namespace TweetWebApplication.Services
{
    public class TweetService : ITweetInfo
    {
        private readonly ISqlDataRepository sqldataRepository;
        //dependency injection
        public TweetService(ISqlDataRepository _sqldataRepository)
        {
            sqldataRepository = _sqldataRepository;
        }

        public async Task<List<TweetInfo>> ViewAllTweets()
        {
            try
            {
                return await sqldataRepository.ViewAllTweets();
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public async Task<List<TweetInfo>> ViewAllTweetsByUser(string userId)
        {
            try
            {
                return await sqldataRepository.ViewAllTweetsByUserId(userId);
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public async Task<TweetInfo> PostTweet(TweetInfo tweetInfo)
        {
            try
            {
                tweetInfo.CreatedOn = DateTime.UtcNow;
                tweetInfo.UpdatedOn = DateTime.UtcNow;
                var tweet = await sqldataRepository.PostTweet(tweetInfo);

                return tweet;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public async Task<ReplyTweetInfo> ReplyTweet(ReplyTweetInfo replytweetInfo)
        {
            try
            {
                replytweetInfo.CreatedOn = DateTime.UtcNow;                
                var tweet = await sqldataRepository.ReplyTweet(replytweetInfo);

                return tweet;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public async Task<List<ReplyTweetInfo>> ViewAllReplyTweetsByTweetId(string tweetid)
        {
            try
            {
                return await sqldataRepository.ViewAllReplyTweetsByTweetId(tweetid);
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
    }
}
