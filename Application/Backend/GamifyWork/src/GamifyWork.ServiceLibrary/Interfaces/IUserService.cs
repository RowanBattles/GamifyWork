﻿using GamifyWork.ServiceLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamifyWork.ServiceLibrary.Interfaces
{
    public interface IUserService
    {
        Task CreateUser(Guid id);
        Task<List<UserModel>> GetAllFriendsByUser(Guid Id);
        Task<UserModel> GetUserById(Guid Id);
    }
}
