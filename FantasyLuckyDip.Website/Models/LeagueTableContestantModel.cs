using System;
using System.Linq;

namespace FantasyLuckyDip.Website.Models
{
    public class LeagueTableContestantModel : IComparable
    {
        public long Id { get; set; }

        public int Position { get; set; }

        public string TwitterHandle { get; set; }

        public string Name { get; set; }

        public int TotalPoints { get; set; }        

        public LeagueTableAthleteModel MaleTrackAthlete { get; set; }        

        public LeagueTableAthleteModel MaleFieldAthlete { get; set; }

        public LeagueTableAthleteModel FemaleTrackAthlete { get; set; }

        public LeagueTableAthleteModel FemaleFieldAthlete { get; set; }

        public LeagueTableCountryModel Country { get; set; }

        public int AthletePoints => this.MaleTrackAthlete.Points + this.MaleFieldAthlete.Points + this.FemaleTrackAthlete.Points + this.FemaleFieldAthlete.Points;

        public int FirstPlaceCount
        {
            get
            {
                const int Place = 1;
                return this.MaleTrackAthlete.Disciplines.Count(x => x.Place == Place) + this.MaleFieldAthlete.Disciplines.Count(x => x.Place == Place) + this.FemaleTrackAthlete.Disciplines.Count(x => x.Place == Place) + this.FemaleFieldAthlete.Disciplines.Count(x => x.Place == Place);
            }
        }

        public int SecondPlaceCount
        {
            get
            {
                const int Place = 2;
                return this.MaleTrackAthlete.Disciplines.Count(x => x.Place == Place) + this.MaleFieldAthlete.Disciplines.Count(x => x.Place == Place) + this.FemaleTrackAthlete.Disciplines.Count(x => x.Place == Place) + this.FemaleFieldAthlete.Disciplines.Count(x => x.Place == Place);
            }
        }

        public int ThirdPlaceCount
        {
            get
            {
                const int Place = 3;
                return this.MaleTrackAthlete.Disciplines.Count(x => x.Place == Place) + this.MaleFieldAthlete.Disciplines.Count(x => x.Place == Place) + this.FemaleTrackAthlete.Disciplines.Count(x => x.Place == Place) + this.FemaleFieldAthlete.Disciplines.Count(x => x.Place == Place);
            }
        }

        public int FourthPlaceCount
        {
            get
            {
                const int Place = 4;
                return this.MaleTrackAthlete.Disciplines.Count(x => x.Place == Place) + this.MaleFieldAthlete.Disciplines.Count(x => x.Place == Place) + this.FemaleTrackAthlete.Disciplines.Count(x => x.Place == Place) + this.FemaleFieldAthlete.Disciplines.Count(x => x.Place == Place);
            }
        }

        public int FifthPlaceCount
        {
            get
            {
                const int Place = 5;
                return this.MaleTrackAthlete.Disciplines.Count(x => x.Place == Place) + this.MaleFieldAthlete.Disciplines.Count(x => x.Place == Place) + this.FemaleTrackAthlete.Disciplines.Count(x => x.Place == Place) + this.FemaleFieldAthlete.Disciplines.Count(x => x.Place == Place);
            }
        }

        public int SixthPlaceCount
        {
            get
            {
                const int Place = 6;
                return this.MaleTrackAthlete.Disciplines.Count(x => x.Place == Place) + this.MaleFieldAthlete.Disciplines.Count(x => x.Place == Place) + this.FemaleTrackAthlete.Disciplines.Count(x => x.Place == Place) + this.FemaleFieldAthlete.Disciplines.Count(x => x.Place == Place);
            }
        }

        public int SeventhPlaceCount
        {
            get
            {
                const int Place = 7;
                return this.MaleTrackAthlete.Disciplines.Count(x => x.Place == Place) + this.MaleFieldAthlete.Disciplines.Count(x => x.Place == Place) + this.FemaleTrackAthlete.Disciplines.Count(x => x.Place == Place) + this.FemaleFieldAthlete.Disciplines.Count(x => x.Place == Place);
            }
        }

        public int EigthPlaceCount
        {
            get
            {
                const int Place = 8;
                return this.MaleTrackAthlete.Disciplines.Count(x => x.Place == Place) + this.MaleFieldAthlete.Disciplines.Count(x => x.Place == Place) + this.FemaleTrackAthlete.Disciplines.Count(x => x.Place == Place) + this.FemaleFieldAthlete.Disciplines.Count(x => x.Place == Place);
            }
        }

        public string DisplayName => string.IsNullOrWhiteSpace(this.Name) ? this.TwitterHandle : $"{this.TwitterHandle} ({this.Name})";

        public int CompareTo(object obj)
        {
            if (obj == null)
            {
                return -1;
            }

            var otherContestant = obj as LeagueTableContestantModel;

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

                if (this.AthletePoints > otherContestant.AthletePoints)
                {
                    return -1;
                }

                if (this.AthletePoints < otherContestant.AthletePoints)
                {
                    return 1;
                }

                if (this.FirstPlaceCount > otherContestant.FirstPlaceCount)
                {
                    return -1;
                }

                if (this.FirstPlaceCount < otherContestant.FirstPlaceCount)
                {
                    return 1;
                }

                if (this.SecondPlaceCount > otherContestant.SecondPlaceCount)
                {
                    return -1;
                }

                if (this.SecondPlaceCount < otherContestant.SecondPlaceCount)
                {
                    return 1;
                }

                if (this.ThirdPlaceCount > otherContestant.ThirdPlaceCount)
                {
                    return -1;
                }

                if (this.ThirdPlaceCount < otherContestant.ThirdPlaceCount)
                {
                    return 1;
                }

                if (this.FourthPlaceCount > otherContestant.FourthPlaceCount)
                {
                    return -1;
                }

                if (this.FourthPlaceCount < otherContestant.FourthPlaceCount)
                {
                    return 1;
                }

                if (this.FifthPlaceCount > otherContestant.FifthPlaceCount)
                {
                    return -1;
                }

                if (this.FifthPlaceCount < otherContestant.FifthPlaceCount)
                {
                    return 1;
                }

                if (this.SixthPlaceCount > otherContestant.SixthPlaceCount)
                {
                    return -1;
                }

                if (this.SixthPlaceCount < otherContestant.SixthPlaceCount)
                {
                    return 1;
                }

                if (this.SeventhPlaceCount > otherContestant.SeventhPlaceCount)
                {
                    return -1;
                }

                if (this.SeventhPlaceCount < otherContestant.SeventhPlaceCount)
                {
                    return 1;
                }

                if (this.EigthPlaceCount > otherContestant.EigthPlaceCount)
                {
                    return -1;
                }

                if (this.EigthPlaceCount < otherContestant.EigthPlaceCount)
                {
                    return 1;
                }

                return 0;
            }
            
            throw new ArgumentException("obj parameter is not of type LeagueTableContestantModel");
        }
    }
}