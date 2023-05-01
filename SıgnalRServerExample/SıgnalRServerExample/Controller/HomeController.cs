using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SıgnalRServerExample.Business;
using SıgnalRServerExample.Hubs;
using System.Threading.Tasks;

namespace SıgnalRServerExample.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        readonly MyBusiness _myBusiness;
        readonly IHubContext<MyHub> _myHub;


        public HomeController(MyBusiness myBusiness)
        {
            _myBusiness = myBusiness;
        }
        [HttpGet("{message}")]
        public async Task<IActionResult> Index(string message)
        {
            
            await _myBusiness.SendMessageAsync(message);
            return Ok();
        }
     
       
    }
}
