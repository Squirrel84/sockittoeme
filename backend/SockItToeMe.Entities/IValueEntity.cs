using System;
using System.Collections.Generic;
using System.Text;

namespace SockItToeMe.Entities
{
    public interface IValueEntity
    {
        int Id { get; }
        string Description { get; }
    }
}
