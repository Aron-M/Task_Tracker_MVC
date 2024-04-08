using Microsoft.AspNetCore.Mvc;
using TaskTrackerMVC.Services;
using TaskTrackerMVC.Models;
using System.Threading.Tasks;

namespace TaskTrackerMVC.Controllers
{
    public class TasksController : Controller
    {
        private readonly TaskAPIService _taskAPIService;

        public TasksController(TaskAPIService taskAPIService)
        {
            _taskAPIService = taskAPIService;
        }

        // GET: Tasks
        public async Task<IActionResult> Index()
        {
            var tasks = await _taskAPIService.GetAllTasksAsync();
            return View(tasks);
        }

        // GET: Tasks/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var task = await _taskAPIService.GetTaskByIdAsync(id);
            if (task == null)
            {
                return NotFound();
            }
            return View(task);
        }

        // GET: Tasks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tasks/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TaskModel task)
        {
            if (ModelState.IsValid)
            {
                await _taskAPIService.CreateTaskAsync(task);
                return RedirectToAction(nameof(Index));
            }
            return View(task);
        }

        // GET: Tasks/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var task = await _taskAPIService.GetTaskByIdAsync(id);
            if (task == null)
            {
                return NotFound();
            }
            return View(task);
        }

        // POST: Tasks/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, TaskModel task)
        {
            if (id != task.TaskId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _taskAPIService.UpdateTaskAsync(task);
                return RedirectToAction(nameof(Index));
            }
            return View(task);
        }

        // GET: Tasks/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var task = await _taskAPIService.GetTaskByIdAsync(id);
            if (task == null)
            {
                return NotFound();
            }
            return View(task);
        }

        // POST: Tasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _taskAPIService.DeleteTaskAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}