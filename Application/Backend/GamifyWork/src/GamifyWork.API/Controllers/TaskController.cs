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
            try
            {
                return Ok(await _taskService.GetAllTasks());
            }
            catch (TaskException ex)
            {
                var error = new Error(ex.Message, ex.ErrorCode);
                return BadRequest(error);
            }
            catch (Exception)
            {
                throw;
            }
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
