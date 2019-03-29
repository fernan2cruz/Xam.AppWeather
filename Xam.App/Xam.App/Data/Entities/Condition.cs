namespace Xam.App.Entities
{
    using System;
    public class Condition
    {
        public string text { get; set; }
        public string icon { get; set; }
        public string IconUrl
        {
            get
            {
                return $"http:{icon}";
            }
        }
    }
}
