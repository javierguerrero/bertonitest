using bertoni.Proxies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using System.Threading.Tasks;

namespace KodotiMvcClient.Controllers
{
    public class AlbumController : Controller
    {
        private readonly AlbumProxy _albumProxy;
        private readonly PhotoProxy _photoProxy;

        public AlbumController(AlbumProxy albumProxyy, PhotoProxy photoProxy)
        {
            _albumProxy = albumProxyy;
            _photoProxy = photoProxy;
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
   }
}



