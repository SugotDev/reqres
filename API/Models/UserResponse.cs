namespace API.Models
{
    public class UserResponse
    {
        public UserData Data { get; set; }
        public Support Support { get; set; }
        public Meta Meta { get; set; }
    }

    public class UserData
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Avatar { get; set; }
    }

    public class Support
    {
        public string Url { get; set; }
        public string Text { get; set; }
    }

    public class Meta
    {
        public string Powered_By { get; set; }
        public string Upgrade_Url { get; set; }
        public string Docs_Url { get; set; }
        public string Template_Gallery { get; set; }
        public string Message { get; set; }
        public List<string> Features { get; set; }
        public string Upgrade_Cta { get; set; }
    }
}
