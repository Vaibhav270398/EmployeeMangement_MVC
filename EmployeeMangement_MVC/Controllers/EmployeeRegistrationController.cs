using EmployeeMangement_MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeMangement_MVC.Controllers
{
    public class EmployeeRegistrationController : Controller
    {
        public HttpClient _httpClient;
        public EmployeeRegistrationController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("ApiClient");
        }

        public IActionResult EmployeeRegistration()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> EmployeeRegistration(EmployeeRegistrationModel employeeModel)
        {
            if (ModelState.IsValid)
            {
                var response = await _httpClient.PostAsJsonAsync("EmployeeRegistration/EmployeeRegistration", employeeModel);
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    return RedirectToAction("Index", "Home");
                }
            }
            return View("Error");
        }
    }

}
