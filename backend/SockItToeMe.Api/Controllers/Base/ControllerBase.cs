using Microsoft.AspNetCore.Mvc;
using SockItToeMe.Application.Base;

namespace SockItToeMe.API.Controllers.Base
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