﻿using System.Collections.Generic;
using System.Threading.Tasks;
using EasyShop.Domain.ViewModels.User.UserProfile;
using Microsoft.AspNetCore.Http;

namespace EasyShop.Interfaces.Services.CP
{
    public interface IFileImageService
    {
        string GetUniqueFileName(string filename);

        IEnumerable<string> GetImageNames(string folder);

        Task<string?> SaveFile(UserProfileViewModel model, string folder);
    }
}