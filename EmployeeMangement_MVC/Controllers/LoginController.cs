using EmployeeMangement_MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeMangement_MVC.Controllers
{

    public class LoginController : Controller
    {
        private readonly HttpClient _httpClient;
        public LoginController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("ApiClient");
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                var response = await _httpClient.PostAsJsonAsync("User/Login", loginModel);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    return RedirectToAction("Index", "Home");
                }

            }
            return View("Error");
        }
    }
    public class ApiResponse
    {
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public string Body { get; set; } = "";
    }
}
