using Microsoft.AspNetCore.Mvc;
using PeruTrekkings.UI.Models.DTO;

namespace PeruTrekkings.UI.Controllers
{
    public class RegionsController : Controller
    {
        private readonly IHttpClientFactory httpClientFactory;

        public RegionsController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<RegionDto> response = new List<RegionDto>();

            try
            {
                //Get all Regions from WebAPI
                var client = httpClientFactory.CreateClient();

                var httpResponseMessage = await client.GetAsync("https://localhost:7153/api/regions");

                httpResponseMessage.EnsureSuccessStatusCode(); //check status

                response.AddRange(await httpResponseMessage.Content.ReadFromJsonAsync<IEnumerable<RegionDto>>());

                //ViewBag.Response = stringResponseBody;
            }
            catch (Exception)
            {
                throw;
            }



            return View(response);
        }
    }
}
