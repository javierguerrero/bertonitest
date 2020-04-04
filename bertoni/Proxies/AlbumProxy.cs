using bertoni.Common;
using bertoni.Proxies.Models.Albums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace bertoni.Proxies
{
    public interface IAlbumProxy
    {
        Task<List<AlbumDto>> Paged(int page);

    }

    public class AlbumProxy : IAlbumProxy
    {
        private readonly ProxyHttpClient _proxyHttpClient;

        public AlbumProxy(ProxyHttpClient proxyHttpClient)
        {
            _proxyHttpClient = proxyHttpClient;
        }


        public async Task<List<AlbumDto>> Paged(int page)
        {
            var client = _proxyHttpClient.Get(ProxyHttpClient.BertoniAPI);
            var response = await client.GetAsync($"albums");

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsAsync<List<AlbumDto>>();
        }




    }
}
