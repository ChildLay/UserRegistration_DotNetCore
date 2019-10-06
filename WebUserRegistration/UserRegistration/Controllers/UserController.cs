using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using UserRegistration.Models;

namespace UserRegistration.Controllers
{
    public class UserController : Controller
    {
        IConfiguration configuration;
        public UserController(IConfiguration iConfig)
        {
            configuration = iConfig;
        }
        static HttpClient _client = new HttpClient();
        public IActionResult Index()
        {
            return View();
        }

        
      

        private async Task<List<User>> GetUsers()
        {
            try
            {
                List<User> users = new List<User>();
                HttpRequestMessage getMessage = new HttpRequestMessage(HttpMethod.Get, configuration.GetValue<string>("UserApiURL"));
                var getResponse = await _client.SendAsync(getMessage);
                var resultString = await getResponse.Content.ReadAsStringAsync();
                if (CheckStatusCode(getResponse))
                {
                    users = JsonConvert.DeserializeObject<List<User>>(resultString);
                }
                else
                {
                    //logger.Info($"Get Status error response {getResponse}.");
                }

                return users;
            }
            catch (Exception ex)
            {
                return null;
                //logger.Error(ex, $"{Name} has GetStatus error.");
            }
        }

        private async Task<bool> SaveUser(User user)
        {
            try
            {
                HttpRequestMessage postMessage = new HttpRequestMessage(HttpMethod.Post, configuration.GetValue<string>("UserApiURL"));
                var reqString = JsonConvert.SerializeObject(user);
                postMessage.Content = new StringContent(reqString);
                postMessage.Content.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");
                var response = await _client.SendAsync(postMessage);

                if (CheckStatusCode(response))
                {
                    return true;
                }
                else
                {
                    //logger.Info($"Get Status error response {getResponse}.");
                }

                return false;
            }
            catch (Exception ex)
            {
                return false;
                //logger.Error(ex, $"{Name} has GetStatus error.");
            }
        }

        public async Task<IActionResult> UserListing()
        {
            var _models = await GetUsers();

            return View(_models);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UserRegisterViewModel viewModel)   
        {
            if (ModelState.IsValid)
            {
                var user = new User()
                {
                    Name = viewModel.Name,
                    Email = viewModel.Email,
                    Gender = viewModel.Gender,
                    AdditionalRequest = viewModel.AdditionalRequest,
                    RegisteredDate = viewModel.RegisteredDate.Value.ToString("dd/MM/yyyy")
                };

                List<string> days = new List<string>();
                if (viewModel.Day1)
                    days.Add("Day 1");
                if (viewModel.Day2)
                    days.Add("Day 2");
                if (viewModel.Day3)
                    days.Add("Day 3");

                user.EventDate = string.Join(",", days.ToArray());

               await SaveUser(user);
                Response.Redirect("UserListing");
            }

            return View();
        }

        private bool CheckStatusCode(HttpResponseMessage message)
        {
            var _result = message.EnsureSuccessStatusCode();
            return _result.IsSuccessStatusCode;
        }
    }

    public class ValuesController : Controller
    {
        private readonly string _myConfiguration;

        public ValuesController(string myConfiguration)
        {
            _myConfiguration = myConfiguration;
        }
    }


}
