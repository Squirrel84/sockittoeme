using SockItToeMe.Models.Interfaces;

namespace SockItToeMe.Models
{
    public class SockProfileMaterialModel : IModel, IDescriptionModel
    {
        public SockProfileMaterialModel(int id, string description)
        {
            Id = id;
            Description = description;
        }

        public int Id { get; set; }
        public string Description { get; set; }
    }
}
