namespace FantasyLuckyDip.Website.Models
{
    public class LeagueTableCountryMedalModel
    {
        public string AthleteSurname { get; set; }

        public string DisciplineName { get; set; }

        public string AthleteDiscipline => $"{this.AthleteSurname} ({this.DisciplineName})";
    }
}