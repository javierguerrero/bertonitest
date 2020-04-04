using bertoni.Proxies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Linq;
using System.Threading.Tasks;

namespace KodotiMvcClient.Controllers
{
    public class AlbumController : Controller
    {
        private readonly AlbumProxy _albumProxy;
        private readonly PhotoProxy _photoProxy;
        private readonly CommentProxy _commentProxy;

        public AlbumController(AlbumProxy albumProxyy, PhotoProxy photoProxy, CommentProxy commentProxy)
        {
            _albumProxy = albumProxyy;
            _photoProxy = photoProxy;
            _commentProxy = commentProxy;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            var result = await _albumProxy.Paged(page);
            return View(result);
        }

        public async Task<IActionResult> Detail(int id)
        {
            var result = await _photoProxy.Paged(id);
            return View(result);
        }

        public async Task<IActionResult> Comments(int id)
        {
            var result = await _commentProxy.Paged(id);
            //return result;
            return Json(result);
        }
    }
}



