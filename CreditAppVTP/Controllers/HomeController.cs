using CreditAppVTP.Contexts;
using CreditAppVTP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CreditAppVTP.Controllers
{
    public class HomeController : Controller
    {
        private readonly CreditDbContext _context;

        public HomeController(CreditDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            if (TempData["Work"] != null)
            {
                ViewBag.Name = TempData["Work"];
            }
            var users = await _context.AppUsers.ToListAsync();
            return View(users);
        }

        #region Create

        public IActionResult Create()
        {
            return View(new AppUser());
        }
        [HttpPost]
        public async Task<IActionResult> Create(AppUser model)
        {
            if (!ModelState.IsValid) return View(model);

            await _context.AppUsers.AddAsync(model);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        #endregion

        #region Detail

        public async Task<IActionResult> Detail(int id)
        {

            var user = await _context.AppUsers.Include(x => x.Work).FirstOrDefaultAsync(x => x.Id == id);
            if (user == null) return View("Error");

            return View(user);
        }

        #endregion

        #region Work

        public async Task<IActionResult> WorkAdd(int id)
        {
            var user = await _context.AppUsers.FirstOrDefaultAsync(x => x.Id == id);
            if (user == null) return View("Error");

            return View((new Work(), user));
        }
        [HttpPost]
        public async Task<IActionResult> WorkAdd([Bind(Prefix = "Item1")] Work model)
        {
            if (!ModelState.IsValid) return View(model);

            await _context.Works.AddAsync(model);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        #endregion

        #region Delete

        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0) return View("Error");
            var user = await _context.AppUsers.FindAsync(id);

            if (user == null) return View("Error");

            _context.AppUsers.Remove(user);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
        #endregion


        #region Credit

        public async Task<IActionResult> Credit(int id)
        {
            var user = await _context.AppUsers.Include(x => x.Work).FirstOrDefaultAsync(x => x.Id == id);

            if (user == null) return View("Error");
            if (user.Work == null)
            {
                TempData["Work"] = user.Name;
                return RedirectToAction("Index");
            }

            var credit = await _context.Credits.OrderByDescending(x => x.Id).FirstOrDefaultAsync();

            return View((new Credit(), user, credit));
        }
        [HttpPost]
        public async Task<IActionResult> Credit([Bind(Prefix = "Item1")] Credit model)
        {
            var user = await _context.AppUsers.Include(x => x.Work).FirstOrDefaultAsync(x => x.Id == model.AppUserId);
            var credit = await _context.Credits.OrderByDescending(x => x.Id).FirstOrDefaultAsync();
            if (!ModelState.IsValid) return View((model, user, credit));

            await _context.Credits.AddAsync(model);
            await _context.SaveChangesAsync();

            return RedirectToAction("Credit");
        }
        #endregion
    }
}
