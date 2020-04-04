using bertoni.Common;
using bertoni.Proxies.Models.Albums;
using bertoni.Proxies.Models.Comments;
using bertoni.Proxies.Models.Photos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace bertoni.Proxies
{
    public interface ICommentProxy
    {
        Task<List<CommentDto>> Paged(int page);

    }

    public class CommentProxy : ICommentProxy
    {
        private readonly ProxyHttpClient _proxyHttpClient;

        public CommentProxy(ProxyHttpClient proxyHttpClient)
        {
            _proxyHttpClient = proxyHttpClient;
        }


        public async Task<List<CommentDto>> Paged(int id)
        {
            var client = _proxyHttpClient.Get(ProxyHttpClient.BertoniAPI);
            var response = await client.GetAsync($"comments?postId={id}");

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsAsync<List<CommentDto>>();
        }

    }
}