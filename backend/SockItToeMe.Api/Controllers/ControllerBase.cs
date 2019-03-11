using Microsoft.AspNetCore.Mvc;
using SockItToeMe.Application;
using SockItToeMe.Application.Base;
using SockItToeMe.Models;

namespace SockItToeMe.API.Controllers
{
    public abstract class ControllerBase<T> : ControllerBase where T : IProvider
    {
        protected T Provider { get; private set; }

        public ControllerBase(T provider)
        {
            this.Provider = provider;
        }
    }
}