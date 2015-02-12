using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using Footinder.Models;

namespace Footinder.BuisnessLogic
{
    public class LunchGroupsDecider
    {
        public List<KeyValuePair<Restaurant, List<User>>> Decide(List<Vote> votes)
        {
            var unPlacedUsers = votes.Select(x => x.User).Distinct().ToList();
            var positiveVotes = votes.Where(x => x.Decision);
            var votesForRestaurants = TransformToVotesForRestaurants(positiveVotes);
                
            var groupsForLaunch = GetUserRestruantGroupsFor(votesForRestaurants, unPlacedUsers, 3);

            if (unPlacedUsers.Count > 0)
            {
                groupsForLaunch.AddRange(GetUserRestruantGroupsFor(votesForRestaurants, unPlacedUsers, 1));
            }

            return groupsForLaunch;
        }

        private static List<KeyValuePair<Restaurant, List<User>>> GetUserRestruantGroupsFor(
            Dictionary<Restaurant, List<Vote>> votesForRestaurants, 
            List<User> unPlacedUsers, int groupMinThreshold)
        {
            var groupsForLaunch = new List<KeyValuePair<Restaurant, List<User>>>();
            foreach (var restaurantVotes in votesForRestaurants.OrderByDescending(x => x.Value.Count))
            {
                var votedForThisRestaurantUsers = restaurantVotes.Value.Select(x => x.User);

                var candidateUserForThisRestaurant = votedForThisRestaurantUsers.Intersect(unPlacedUsers).ToList();

                if (candidateUserForThisRestaurant.Count() < groupMinThreshold) continue;

                groupsForLaunch.Add(new KeyValuePair<Restaurant, List<User>>(restaurantVotes.Key, candidateUserForThisRestaurant));
                foreach (var candidate in candidateUserForThisRestaurant)
                {
                    unPlacedUsers.Remove(candidate);
                }
                votesForRestaurants.Remove(restaurantVotes.Key);
            }

            return groupsForLaunch;
        }

        private static Dictionary<Restaurant, List<Vote>> TransformToVotesForRestaurants(IEnumerable<Vote> positiveVotes)
        {
            return positiveVotes
                .GroupBy(x => x.Restaurant.Id)
                .ToDictionary(x => x.Key, y => y.ToList())
                .Values
                .ToDictionary(x => x.First().Restaurant, x => x);
        }
    }
}