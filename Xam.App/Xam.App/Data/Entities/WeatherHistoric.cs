
namespace Xam.App.Data.Entities
{
    using SQLite;
    using System;
    public class WeatherHistoric
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public string City { get; set; }
        public string Country { get; set; }

        public string FullNameCity
        {
            get
            {
                if (this.City == null)
                {
                    return string.Empty;
                }
                else
                {
                    return $"{Country}, {City}";
                }
            }
        }
        public DateTime? LastConsultDate { get; set; }

    }
}
