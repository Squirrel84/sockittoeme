using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace SockItToeMe.API.Controllers.Interfaces
{
    public interface ISockController
    {
        Task<IActionResult> Get(int id);
    }
}