using GamifyWork.ServiceLibrary.Models;
using GamifyWork.ServiceLibrary.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySqlX.XDevAPI.Common;
using System.Collections.Generic;
using GamifyWork.ServiceLibrary.Exceptions;
using GamifyWork.API.Middleware;
using Newtonsoft.Json;
using Microsoft.VisualBasic;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace GamifyWork.API.Controllers
{
    [Route("api/[controller]")]
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
            return Ok(await _taskService.GetAllTasks());
        }

        [HttpGet("{user}")]
        public async Task<IActionResult> GetTasksByUser(Guid user)
        {
            return Ok(await _taskService.GetTasksByUser(user));
        }


        [HttpPost]
        public async Task<IActionResult> CreateTask(TaskModel taskModel)
        {
            taskModel.CheckValidation();
            await _taskService.CreateTask(taskModel);
            return Ok(taskModel);
        }

        [HttpDelete("{Id}")]
        [Authorize]
        public async Task<IActionResult> DeleteTask(int Id)
        {
            var task = await _taskService.GetTaskById(Id);

            var userSubject = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (userSubject == task.User.ToString())
            {
                await _taskService.DeleteTask(Id);
                return Ok();
            }
            else
            {
                return Unauthorized();
            }
        }

        [HttpPatch("MarkTask/{id}")]
        public async Task<IActionResult> MarkTask(int id)
        {
            await _taskService.MarkTask(id);
            return Ok();
        }
    }
}
