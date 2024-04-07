using Microsoft.AspNetCore.Mvc;
using TaskTrackerMVC.Models;
using TaskTrackerMVC.Services;
using System.Threading.Tasks;

namespace TaskTrackerMVC.Controllers
{
    public class UsersController : Controller
    {
        private readonly UserAPIService _userAPIService;

        public UsersController(UserAPIService userAPIService)
        {
            _userAPIService = userAPIService;
        }

        // GET: Users
        public async Task<IActionResult> Index()
        {
            var users = await _userAPIService.GetAllUsersAsync();
            return View(users);
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var user = await _userAPIService.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserId,Username,Email")] UserModel user)
        {
            if (ModelState.IsValid)
            {
                await _userAPIService.CreateUserAsync(user);
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var user = await _userAPIService.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserId,Username,Email")] UserModel user)
        {
            if (id != user.UserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _userAPIService.UpdateUserAsync(user);
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var user = await _userAPIService.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _userAPIService.DeleteUserAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}