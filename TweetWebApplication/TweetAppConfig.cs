﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TweetWebApplication
{
    public class TweetAppConfig
    {
        public string DataBaseName { get; set; }
        public string UserCollectionName { get; set; }
        public string TweetsCollectionName { get; set; }
        public string ReplyTweetsCollectionName { get; set; }
        public string TweetAppDbConnectionString { get; set; }
    }
}
