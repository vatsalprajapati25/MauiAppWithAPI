using MauiAppWithAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppWithAPI.Services
{
    public interface IUserRepository
    {
        Task<ApiPostResponse<LoginResponseModel>> Login(UserModel user);
    }
}
