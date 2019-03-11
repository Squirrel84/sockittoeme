using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace SockItToeMe.API.Controllers
{
    public interface ISockController
    {
        Task<ActionResult> Get(int id);
    }
}