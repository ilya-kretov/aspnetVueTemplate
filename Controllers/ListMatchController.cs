using System.Linq;
using Microsoft.AspNetCore.Mvc;
using aspnetVue.Providers;

namespace aspnetVue.Controllers
{
    [Route("api/[controller]")]
    public class ListMatchController : Controller
    {
        private readonly IListMatchProvider _listMatchProvider;

        public ListMatchController(IListMatchProvider listMatchProvider)
        {
            _listMatchProvider = listMatchProvider;
        }

        [HttpGet("[action]")]
        public IActionResult Rows([FromQuery(Name = "from")] int from = 0, [FromQuery(Name = "to")] int to = 4)
        {
            //System.Threading.Thread.Sleep(500); // Fake latency
            var quantity = to - from;

            // We should also avoid going too far in the list.
            if (quantity <= 0)
            {
                return BadRequest("You cannot have the 'to' parameter higher than 'from' parameter.");
            }

            if (from < 0)
            {
                return BadRequest("You cannot go in the negative with the 'from' parameter");
            }

            var allListMatchRows = _listMatchProvider.GetRows();
            var result = new
            {
                Total = allListMatchRows.Count,
                ListMatches = allListMatchRows.Skip(from).Take(quantity).ToArray()
            };

            return Ok(result);
        }
    }
}
