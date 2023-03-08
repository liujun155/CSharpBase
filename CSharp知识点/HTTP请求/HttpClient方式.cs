using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

namespace CSharp知识点
{
    public sealed class HttpClientClass
    {
        private static HttpClientClass _instance = null;

        private static readonly object locker = new object();

        private HttpClient _httpClient;

        /// <summary>
        /// 定义公有静态方法Instance，用于获取类的实例
        /// </summary>
        public static HttpClientClass Instance
        {
            get
            {
                if(_instance == null)
                {
                    lock(locker)
                    {
                        if(_instance == null)
                        {
                            _instance = new HttpClientClass();
                        }
                    }
                }
                return _instance;
            }
        }

        private HttpClientClass()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.110 Safari/537.36");
        }

        // 定义同步Get请求方法，返回值为泛型T
        public T Get<T>(string url) where T : class
        {
            HttpResponseMessage response = _httpClient.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                // 获取响应结果并返回
                var jsonStr = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<T>(jsonStr);
            }
            else
            {
                // 如果请求失败，则抛出异常
                throw new Exception(response.ReasonPhrase);
            }
        }

        // 定义异步Get请求方法，返回值为泛型T
        public async Task<T> GetAsync<T>(string url) where T : class
        {
            HttpResponseMessage response = await _httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                // 获取响应结果并返回
                var jsonStr = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(jsonStr);
            }
            else
            {
                // 如果请求失败，则抛出异常
                throw new Exception(response.ReasonPhrase);
            }
        }

        // 定义同步Post请求方法，返回值为泛型T
        public T Post<T>(string url, IDictionary<string, string> data) where T : class
        {
            HttpContent content = new FormUrlEncodedContent(data);
            HttpResponseMessage response = _httpClient.PostAsync(url, content).Result;
            if (response.IsSuccessStatusCode)
            {
                // 获取响应结果并返回
                var jsonStr = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<T>(jsonStr);
            }
            else
            {
                // 如果请求失败，则抛出异常
                throw new Exception(response.ReasonPhrase);
            }
        }

        // 定义异步Post请求
        public async Task<T> PostAsync<T>(string url, IDictionary<string, string> data) where T : class
        {
            HttpContent content = new FormUrlEncodedContent(data);
            HttpResponseMessage response = await _httpClient.PostAsync(url, content);
            if (response.IsSuccessStatusCode)
            {
                // 获取响应结果并返回
                var jsonStr = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(jsonStr);
            }
            else
            {
                // 如果请求失败，则抛出异常
                throw new Exception(response.ReasonPhrase);
            }
        }
    }
}
