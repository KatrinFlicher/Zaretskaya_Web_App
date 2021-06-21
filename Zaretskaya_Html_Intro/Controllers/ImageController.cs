using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zaretskaya_Html_Intro.DAL.Entities;

namespace Zaretskaya_Html_Intro.Controllers
{
    public class ImageController : Controller
    {
        UserManager<ApplicationUser> _userManager;
        IWebHostEnvironment _env;

        const string IMAGE_CONTENT_TYPE = "image/...";

        public ImageController(UserManager<ApplicationUser> userManager, 
            IWebHostEnvironment env)
        {
            _userManager = userManager;
            _env = env;
        }

        public async Task<FileResult> GetAvatar()
        {
            var user = await _userManager.GetUserAsync(User);
            if(user.AvatarImage != null)
            {
                return File(user.AvatarImage, IMAGE_CONTENT_TYPE);
            }
            else
            {
                var avatarPath = "/images/anonymous.jpg";
                return File(_env.WebRootFileProvider
                    .GetFileInfo(avatarPath)
                    .CreateReadStream(), IMAGE_CONTENT_TYPE);
            }
        }
    }
}
