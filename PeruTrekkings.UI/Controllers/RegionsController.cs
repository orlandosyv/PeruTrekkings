using Microsoft.AspNetCore.Mvc;

namespace PeruTrekkings.UI.Controllers
{
    public class RegionsController : Controller
    {
        private readonly IHttpClientFactory httpClientFactory;

        public RegionsController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                //Get all Regions from WebAPI
                var client = httpClientFactory.CreateClient();

                var httpResponseMessage = await client.GetAsync("https://localhost:7153/api/regions");

                httpResponseMessage.EnsureSuccessStatusCode(); //check status

                var stringResponseBody =  await httpResponseMessage.Content.ReadAsStringAsync();

                ViewBag.Response = stringResponseBody;
            }
            catch (Exception)
            {
                throw;
            }



            return View();
        }
    }
}
