using SockItToeMe.Models.Interfaces;

namespace SockItToeMe.Models
{
    public class SockProfileModel : IModel
    {
        public string Description { get; set; }
        public string Colour { get; set; }
        public SockProfileSizeModel Size { get; set; }
        public SockProfileMaterialModel Material { get; set; }
        public SockProfileThicknessModel Thickness { get; set; }
    }
}