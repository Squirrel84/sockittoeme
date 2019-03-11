namespace SockItToeMe.Models
{
    public class SockProfileModel : IModel
    {
        public string Description { get; set; }
        public string Colour { get; set; }
        public string Material { get; set; }
        public string Thickness { get; set; }
    }
}