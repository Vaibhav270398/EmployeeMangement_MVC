using EmployeeMangement_MVC.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NuGet.Common;
using System.Security.Claims;

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
                    TokenResponse tokenData = JsonConvert.DeserializeObject<TokenResponse>(result);
                    if (!string.IsNullOrEmpty(tokenData.Token))
                    {
                        HttpContext.Session.SetString("JWTToken", tokenData.Token); // Store token in session

                        //var claims = new List<Claim> { new Claim(ClaimTypes.Name, loginModel.Username) };
                        //var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                        //var authProperties = new AuthenticationProperties { IsPersistent = true };

                        //await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                        //                              new ClaimsPrincipal(claimsIdentity), authProperties);

                        return RedirectToAction("Index", "Home");
                    }
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
