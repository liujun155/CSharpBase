using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CSharp知识点
{
    public static class HttpWebRequestClass
    {
        private const int DEFAULT_TIMEOUT_MS = 10000; // 默认超时时间10秒
        private const int DEFAULT_BUFFER_SIZE = 4096; // 默认缓冲区大小

        /// <summary>
        /// 发送Get请求，返回响应的字符串结果
        /// </summary>
        /// <typeparam name="T">响应结果的类型</typeparam>
        /// <param name="url">请求的url</param>
        /// <param name="timeoutMs">请求超时时间，单位毫秒</param>
        /// <returns>响应结果</returns>
        public static T Get<T>(string url, int timeoutMs = DEFAULT_TIMEOUT_MS)
        {
            HttpWebRequest request = CreateRequest(url, "GET", null, timeoutMs);

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                return ParseResponse<T>(response);
            }
        }

        /// <summary>
        /// 发送Get请求，返回响应的字符串结果
        /// </summary>
        /// <typeparam name="T">响应结果的类型</typeparam>
        /// <param name="url">请求的url</param>
        /// <param name="timeoutMs">请求超时时间，单位毫秒</param>
        /// <returns>响应结果</returns>
        public static async Task<T> GetAsync<T>(string url, int timeoutMs = DEFAULT_TIMEOUT_MS)
        {
            HttpWebRequest request = CreateRequest(url, "GET", null, timeoutMs);

            using (HttpWebResponse response = (HttpWebResponse)await request.GetResponseAsync())
            {
                return ParseResponse<T>(response);
            }
        }

        /// <summary>
        /// 发送Post请求，返回响应的字符串结果
        /// </summary>
        /// <typeparam name="T">响应结果的类型</typeparam>
        /// <param name="url">请求的url</param>
        /// <param name="data">Post请求的数据</param>
        /// <param name="contentType">Post请求的数据类型，默认为"application/x-www-form-urlencoded"</param>
        /// <param name="timeoutMs">请求超时时间，单位毫秒</param>
        /// <returns>响应结果</returns>
        public static T Post<T>(string url, T data, string contentType = "application/x-www-form-urlencoded", int timeoutMs = DEFAULT_TIMEOUT_MS)
        {
            HttpWebRequest request = CreateRequest(url, "POST", contentType, timeoutMs);

            byte[] postData = Encoding.UTF8.GetBytes(data.ToString());
            using (Stream requestStream = request.GetRequestStream())
            {
                requestStream.Write(postData, 0, postData.Length);
            }

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                return ParseResponse<T>(response);
            }
        }

        /// <summary>
        /// 发送Post请求，返回响应的字符串结果
        /// </summary>
        /// <typeparam name="T">响应结果的类型</typeparam>
        /// <param name="url">请求的url</param>
        /// <param name="data">Post请求的数据</param>
        /// <param name="contentType">Post请求的数据类型，默认为"application/x-www-form-urlencoded"</param>
        /// <param name="timeoutMs">请求超时时间，单位毫秒</param>
        /// <returns>响应结果</returns>
        public static async Task<T> PostAsync<T>(string url, T data, string contentType = "application/x-www-form-urlencoded", int timeoutMs = DEFAULT_TIMEOUT_MS)
        {
            HttpWebRequest request = CreateRequest(url, "POST", contentType, timeoutMs);

            byte[] postData = Encoding.UTF8.GetBytes(data.ToString());
            using (Stream requestStream = await request.GetRequestStreamAsync())
            {
                await requestStream.WriteAsync(postData, 0, postData.Length);
            }

            using (HttpWebResponse response = (HttpWebResponse)await request.GetResponseAsync())
            {
                return ParseResponse<T>(response);
            }
        }

        /// <summary>
        /// 创建HttpWebRequest对象
        /// </summary>
        /// <param name="url">请求的url</param>
        /// <param name="method">请求方法</param>
        /// <param name="contentType">请求的数据类型</param>
        /// <param name="timeoutMs">请求超时时间，单位毫秒</param>
        /// <returns>创建的HttpWebRequest对象</returns>
        private static HttpWebRequest CreateRequest(string url, string method, string contentType, int timeoutMs)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = method;
            request.Timeout = timeoutMs;

            if (!string.IsNullOrEmpty(contentType))
            {
                request.ContentType = contentType;
            }

            return request;
        }

        /// <summary>
        /// 从响应中解析出响应结果
        /// </summary>
        /// <typeparam name="T">响应结果的类型</typeparam>
        /// <param name="response">HttpWebResponse对象</param>
        /// <returns>响应结果</returns>
        private static T ParseResponse<T>(HttpWebResponse response)
        {
            using (Stream responseStream = response.GetResponseStream())
            {
                MemoryStream memoryStream = new MemoryStream();
                byte[] buffer = new byte[DEFAULT_BUFFER_SIZE];
                int bytesRead = 0;

                while ((bytesRead = responseStream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    memoryStream.Write(buffer, 0, bytesRead);
                }

                string responseString = Encoding.UTF8.GetString(memoryStream.ToArray());
                return (T)Convert.ChangeType(responseString, typeof(T));
            }
        }
    }
}
