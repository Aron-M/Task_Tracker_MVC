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
            var viewModel = new UserListCreateViewModel
            {
                Users = users,
                NewUser = new UserModel() // Initialize with a new UserModel if necessary
            };
            return View(viewModel);
        }

        // Other action methods remain unchanged...

        // POST: Users/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UserListCreateViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                await _userAPIService.CreateUserAsync(viewModel.NewUser);
                return RedirectToAction(nameof(Index));
            }
            // If we get here, something went wrong
            viewModel.Users = await _userAPIService.GetAllUsersAsync();
            return View(viewModel);
        }

        // Other action methods remain unchanged...
    }
}