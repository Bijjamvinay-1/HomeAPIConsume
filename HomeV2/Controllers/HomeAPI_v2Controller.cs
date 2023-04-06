using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using System.Text.Json.Serialization;

namespace ConsumeAPI.Controllers
{
    [Route("CallAPI")]
    [ApiController]

    public class HomeAPI_v2Controller : Controller
    {
        [HttpPost]
        public async Task<IActionResult> CallAPI()
        {
            //Call Get API
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7187/");
                using (HttpResponseMessage response = await client.GetAsync("api/HomeAPI"))
                {
                    var reponseContent = response.Content.ReadAsStringAsync().Result;
                    response.EnsureSuccessStatusCode();
                    return Ok(reponseContent);

                }

            }

        }
    }
}
