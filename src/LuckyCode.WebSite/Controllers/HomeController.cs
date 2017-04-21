using System.Threading.Tasks;
using LuckyCode.Data;
using LuckyCode.Entity.IdentityEntity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LuckyCode.WebSite.Controllers
{
    public class HomeController : Controller
    {
        private UserManager<SysUsers> _userManager;
        private SignInManager<SysUsers> _signIn;
        private ILiteCodeContext _context;
        public HomeController(UserManager<SysUsers> userManager, ILiteCodeContext context, SignInManager<SysUsers> signIn)
        {
            _userManager = userManager;
            _context = context;
            _signIn = signIn;
        }
        public async Task<IActionResult> Index()
        {
            //var l = await _userManager.CreateAsync(new SysUsers() { Id = SequenceQueue.NewIdGuid().ToString(), Email = "luckearth@luckearth.cn", UserName = "admin" }, "abc_123");
            //_context.SaveChanges();
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }
        
        public string Html { get; set; }
        public IActionResult Error()
        {
            return View();
        }
    }
}
