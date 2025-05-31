public class Twitter {

    List<int> tweets = new List<int>();
    List<int> postedBy = new List<int>();
    Dictionary<int, List<int>> follows = new Dictionary<int, List<int>>();

    public Twitter() {
        for (int i = 0; i < 10; i ++)
        {
            tweets.Add(-1);
            postedBy.Add(-1);
        }
    }
    
    public void PostTweet(int userId, int tweetId) {
        int i = 0;
        while (i < 10 && tweets[i] > tweetId)
            i++;		
        if (i < 10)
		{
			tweets.Insert(0, tweetId);
			postedBy.Insert(0, userId);
		}
    }
    
    public List<int> GetNewsFeed(int userId) {
        List<int> newsFeed = new List<int>();
        int origUserId = userId;
        int count = 0;
        for (int i = 0; i < tweets.Count; i++)
        {
            if (tweets[i] == -1)
                continue;
            if (count > 9)
                break;

            if (postedBy[i] == userId || (follows.ContainsKey(userId) &&
                follows[userId].Contains(postedBy[i])))
            {
                newsFeed.Add(tweets[i]);
                count++;
            }
            userId = origUserId;
        }
        return newsFeed;
    }
    
    public void Follow(int followerId, int followeeId) {
        if (!follows.ContainsKey(followerId))
        {
            List<int> followees = new List<int>();
            followees.Add(followeeId);
            follows.Add(followerId, followees);
        }
        else if (!follows[followerId].Contains(followeeId))
            follows[followerId].Add(followeeId);
    }
    
    public void Unfollow(int followerId, int followeeId) {
        follows[followerId].Remove(followeeId);        
    }
}