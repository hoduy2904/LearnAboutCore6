using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LearnAboutNet6.Areas.admin.Controllers
{
    [Area("admin")]
    [Authorize(Roles ="Admin")]
    public class BaseController : Controller
    {
    }
}
