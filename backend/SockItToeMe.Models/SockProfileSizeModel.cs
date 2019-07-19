using SockItToeMe.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SockItToeMe.Models
{
    public class SockProfileSizeModel : IModel, IDescriptionModel
    {
        public SockProfileSizeModel(int id, string description)
        {
            Id = id;
            Description = description;
        }

        public int Id { get; set; }
        public string Description { get; set; }
    }
}
