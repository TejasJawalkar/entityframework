using DemoTask_New.Data;
using DemoTask_New.Models.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace DemoTask_New.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDBContext _dBContext;

        public HomeController(ApplicationDBContext dBContext)
        {
            _dBContext = dBContext;
        }

        [BindProperty]
        public DataEntityClass DataEntityClass { get; set; }

        
        public IActionResult Index()
        {
            var data=_dBContext.DataEntities.ToList();
            return View(data);
        }

        public IActionResult NewUser()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create()
        {
            if (ModelState.IsValid)
            {
                var dataEntityClass = DataEntityClass;
                _dBContext.DataEntities.Add(dataEntityClass);
                await _dBContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            else

            {
                return View("NewUser");
            }
        }

    }
}
