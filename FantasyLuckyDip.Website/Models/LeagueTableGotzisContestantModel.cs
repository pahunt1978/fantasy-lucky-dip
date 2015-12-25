using System;

namespace FantasyLuckyDip.Website.Models
{
    public class LeagueTableGotzisContestantModel : IComparable
    {
        public long Id { get; set; }

        public int Position { get; set; }

        public string TwitterHandle { get; set; }

        public string Name { get; set; }

        public int TotalPoints { get; set; }

        public LeagueTableAthleteModel Decathlete1 { get; set; }

        public LeagueTableAthleteModel Decathlete2 { get; set; }

        public LeagueTableAthleteModel Heptahlete1 { get; set; }

        public LeagueTableAthleteModel Heptahlete2 { get; set; }       

        public string DisplayName => string.IsNullOrWhiteSpace(this.Name) ? this.TwitterHandle : $"{this.TwitterHandle} ({this.Name})";

        public int CompareTo(object obj)
        {
            if (obj == null)
            {
                return -1;
            }

            var otherContestant = obj as LeagueTableGotzisContestantModel;

            if (otherContestant != null)
            {
                if (this.TotalPoints > otherContestant.TotalPoints)
                {
                    return -1;
                }

                if (this.TotalPoints < otherContestant.TotalPoints)
                {
                    return 1;
                }                                

                return 0;
            }

            throw new ArgumentException("obj parameter is not of type LeagueTableGotzisContestantModel");
        }
    }
}