using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using System.Text.Json;
using System.Net.Http;



namespace ConsumeAPI.Controllers
{
    [Route("api/CallAPI")]
    [ApiController]

    public class HomeAPI_v2Controller : Controller
    {
        [HttpGet]
        public async Task<IActionResult> GetApI()
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

        [HttpPost]
        public async Task<IActionResult> PostAPI()
        {
            //Call post API
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7187/");
                var postData = new
                {
                    Id = 0,
                    Name = "Sky View",
                    Sqft = 1000,
                    Occupancy = 5
                };



                var content = new StringContent(JsonConvert.SerializeObject(postData), Encoding.UTF8, "application/json");

                using (HttpResponseMessage response = await client.PostAsync("api/HomeAPI", content))
                {
                    var reponseContent = response.Content.ReadAsStringAsync().Result;
                    response.EnsureSuccessStatusCode();
                    return Ok(reponseContent);
                }

            }
        }
        [HttpPut]
        public async Task<IActionResult> PutAPI()
        {
            //Call post API
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7187/");
                var postData = new
                {
                    Id = 2,
                    Name = "Sky View",
                    Sqft = 1000,
                    Occupancy = 5
                };



                var content = new StringContent(JsonConvert.SerializeObject(postData), Encoding.UTF8, "application/json");

                using (HttpResponseMessage response = await client.PutAsync("api/HomeAPI/2", content))
                {
                    var reponseContent = response.Content.ReadAsStringAsync().Result;
                    response.EnsureSuccessStatusCode();
                    return Ok(reponseContent);
                }

            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAPI()
        {
            //Call post API
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7187/");


                using (HttpResponseMessage response = await client.DeleteAsync("api/HomeAPI/1"))
                {
                    var reponseContent = response.Content.ReadAsStringAsync().Result;
                    response.EnsureSuccessStatusCode();
                    return Ok(reponseContent);
                }

            }
        }

    }
}














