using SockItToeMe.Entities.Interfaces;

namespace SockItToeMe.Entities
{
    public class SockEntity : ISockEntity
    {
        public int SockId { get; set; }

        public string Description { get; set; }

        public string Colour { get; set; }

        public int SizeId { get; set; }

        public int ThicknessId { get; set; }

        public int MaterialId { get; set; }
    }
}
