using SockItToeMe.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SockItToeMe.Application.Base
{
    public interface IProvider
    {

    }

    public interface IProvider<M> : IProvider where M : IModel
    {
        Task<M> GetByIdAsync(int id);
    }
}
