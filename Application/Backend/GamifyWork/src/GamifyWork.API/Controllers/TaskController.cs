using GamifyWork.ServiceLibrary.Interfaces;
using GamifyWork.ServiceLibrary.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySqlX.XDevAPI.Common;
using System.Collections.Generic;

namespace GamifyWork.API.Controllers
{
    [Route("api/task")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTasks()
        {
            var tasks = await _taskService.GetAllTasks();
            return tasks != null ? Ok(tasks) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> CreateTask(TaskModel taskModel)
        {
            if (ModelState.IsValid)
            {
                await _taskService.CreateTask(taskModel);
                return Ok();
            }
            else
            {
                string errorMsgs = string.Join("; ", ModelState.Values
                                        .SelectMany(x => x.Errors)
                                        .Select(x => x.ErrorMessage));
                return BadRequest(errorMsgs);
            }
        }
    }
}
