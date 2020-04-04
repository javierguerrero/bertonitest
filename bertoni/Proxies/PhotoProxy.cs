using bertoni.Common;
using bertoni.Proxies.Models.Albums;
using bertoni.Proxies.Models.Photos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace bertoni.Proxies
{
    public interface IPhotoProxy
    {
        Task<List<PhotoDto>> Paged(int page);

    }

    public class PhotoProxy : IPhotoProxy
    {
        private readonly ProxyHttpClient _proxyHttpClient;

        public PhotoProxy(ProxyHttpClient proxyHttpClient)
        {
            _proxyHttpClient = proxyHttpClient;
        }


        public async Task<List<PhotoDto>> Paged(int id)
        {
            var client = _proxyHttpClient.Get(ProxyHttpClient.BertoniAPI);
            var response = await client.GetAsync($"photos?albumId={id}");

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsAsync<List<PhotoDto>>();
        }
    }
}