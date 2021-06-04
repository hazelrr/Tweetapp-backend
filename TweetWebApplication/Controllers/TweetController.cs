using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TweetWebApplication.Interface;
using TweetWebApplication.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TweetWebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TweetController : ControllerBase
    {
        private readonly ITweetInfo itweetserviceInfo;

        public TweetController(ITweetInfo _itweetServiceInfo)
        {
            itweetserviceInfo = _itweetServiceInfo;
        }

        // GET: api/<TweetController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }


        [HttpGet]
        [Route("ViewAllTweets")]
        public async Task<IActionResult> ViewAllTweets()
        {
            try
            {

                var tweets = await itweetserviceInfo.ViewAllTweets();
                return new OkObjectResult(tweets);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }
        // GET api/<TweetController>/5
        [HttpGet]
        [Route("GetAllTweetByUserId/{UserId}")]
        public async Task<IActionResult> ViewAllTweetByUserId(string UserId)
        {
            try
            {

                var tweets = await itweetserviceInfo.ViewAllTweetsByUser(UserId);
                return new OkObjectResult(tweets);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }

        // POST api/<TweetController>
        [HttpPost]
        [Route("PostTweet")]
        public async Task<IActionResult> PostTweet([FromBody] TweetInfo tweetInfo)
        {
            try
            {
                var tweet = await itweetserviceInfo.PostTweet(tweetInfo);
                return new OkObjectResult(tweet);

            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }

        // POST api/<TweetController>
        [HttpPost]
        [Route("ReplyTweet")]
        public async Task<IActionResult> ReplyTweet([FromBody] ReplyTweetInfo replytweetInfo)
        {
            try
            {
                var tweet = await itweetserviceInfo.ReplyTweet(replytweetInfo);
                return new OkObjectResult(tweet);

            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }

        // GET api/<TweetController>/5
        [HttpGet]
        [Route("GetAllReplyTweetsByTweetId/{TweetId}")]
        public async Task<IActionResult> ViewAllReplyTweetsByTweetId(string TweetId)
        {
            try
            {

                var tweets = await itweetserviceInfo.ViewAllReplyTweetsByTweetId(TweetId);
                if (tweets != null)
                {
                    return new OkObjectResult(tweets);
                }
                else
                    return new BadRequestObjectResult("You have no replies yet");
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }

    }
}
