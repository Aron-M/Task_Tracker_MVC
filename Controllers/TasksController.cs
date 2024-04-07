// Controllers/TasksController.cs
using Microsoft.AspNetCore.Mvc;
using TaskTrackerMVC.Models; // Use the correct namespace
using System.Threading.Tasks;
using TaskTrackerMVC.Services; 

public class TasksController : Controller
{
    private readonly TaskAPIService _taskAPIService;

    public TasksController(TaskAPIService taskAPIService)
    {
        _taskAPIService = taskAPIService;
    }

    public async Task<IActionResult> Index()
    {
        var tasks = await _taskAPIService.GetAllTasksAsync();
        return View(tasks);
    }

    // Add actions for Create, Edit, Delete, etc.
}