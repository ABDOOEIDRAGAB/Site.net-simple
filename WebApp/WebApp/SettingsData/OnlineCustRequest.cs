namespace WebApp.SettingsData
{
    public class OnlineCustRequest
    {
            public string code { get; set; }
            public OnlineCustRequestData data { get; set; }
        }

        public class OnlineCustRequestData
        {
            public string username { get; set; }
            public string password { get; set; }
            public string TargetAction { get; set; }
            public string Redirecturl { get; set; }
            public string Language { get; set; }
            public string url { get; set; }
        }
}
