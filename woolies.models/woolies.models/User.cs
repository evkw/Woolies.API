namespace woolies.models
{
    public class User
    {

        public string Name { get; set; }

        public string Token { get; set; }

        public User( string name, string token)
        {
            this.Name = name;
            this.Token = token;
        }
    }
}
