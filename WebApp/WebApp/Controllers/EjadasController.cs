using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Net;
using System.Text;
using WebApp.Data;
using WebApp.Models;
using WebApp.SettingsData;
using WebApp.ViewModel;

namespace WebApp.Controllers
{
    [Authorize]
    public class EjadasController : Controller
    {
        private readonly ApplicationDbContext _context;

        private readonly Setting setting;

        public EjadasController(ApplicationDbContext context, IOptions<Setting> _setting)
        {
            _context = context;
            setting = _setting.Value;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Loans()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Loans(LoansMode loansMode)
        {
            LoansBank loans = new LoansBank
            {
                Address = loansMode.Address,
                Email = loansMode.Email,
                Money = loansMode.Money,
                Name = loansMode.Name,
                Phone = loansMode.Phone
            };

            _context.loansBanks.Add(loans);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public ActionResult TestApi2()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    string url = string.
                        Format(setting.api);
                    var OnlineCustRequest = new OnlineCustRequest
                    {
                        code = setting.code,
                        data = new OnlineCustRequestData
                        {
                            username = setting.username,
                            password = setting.password,
                            TargetAction = setting.TargetAction,
                            Language = setting.Language,
                            Redirecturl = setting.Redirecturl
                        }
                    };
                    HttpContent c = new StringContent(JsonConvert.SerializeObject(OnlineCustRequest),
                        Encoding.UTF8, "application/json");

                    var response = client.PostAsync(url, c).Result;

                    string responseAsString = response.Content.ReadAsStringAsync().Result;
                    var result = JsonConvert.DeserializeObject<OnlineCustRequest>(responseAsString);

                    return Redirect(result.data.url);
                }
            }

            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        public IActionResult GoToUrl()
        {
            return TestApi2();
        }

    }
}
