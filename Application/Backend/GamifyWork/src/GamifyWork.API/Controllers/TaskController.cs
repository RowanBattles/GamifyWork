﻿using GamifyWork.ServiceLibrary.Models;
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


        [HttpPost]
        public async Task<IActionResult> CreateTask(TaskModel taskModel)
        {
            taskModel.CheckValidation();
            await _taskService.CreateTask(taskModel);
            return Ok(taskModel);
        }

        [HttpPatch("MarkTask")]
        public async Task<IActionResult> MarkTask(int Id)
        {
            await _taskService.MarkTask(Id);
            return Ok();
        }
    }
}
