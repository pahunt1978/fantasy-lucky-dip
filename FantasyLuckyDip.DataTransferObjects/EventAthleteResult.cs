﻿namespace FantasyLuckyDip.DataTransferObjects
{
    public class EventAthleteResult
    {
        public long AthleteId { get; set; }        

        public long AthleteCountryId { get; set; }

        public long DisciplineId { get; set; }        

        public int Place { get; set; }

        public int Points
        {
            get
            {
                switch (this.Place)
                {
                    case 1:
                        return 8;
                    case 2:
                        return 7;
                    case 3:
                        return 6;
                    case 4:
                        return 5;
                    case 5:
                        return 4;
                    case 6:
                        return 3;
                    case 7:
                        return 2;
                    case 8:
                        return 1;
                    default:
                        return 0;
                }
            }
        }
    }
}