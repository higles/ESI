using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ESI
{
    public static class ESI
    {
        /// <summary>
        /// Gets a response for the given request
        /// </summary>
        /// <param name="request">Request to make</param>
        /// <returns>An http response</returns>
        public static async Task<IEnumerable<HttpResponseMessage>> MakeEsiRequestsAsync(IEnumerable<string> urls)
        {
            var client = new HttpClient();

            // Start requests for the given urls
            var requests = urls.Select(url => client.GetAsync(url)).ToList();

            // Wait for all the requests to finish
            await Task.WhenAll(requests);

            // Get the responses
            var responses = requests.Select(task => task.Result).ToList();

            return responses;
        }

        /// <summary>
        /// Reads responses as arrays into a collection of a given type
        /// </summary>
        /// <typeparam name="T">Type of object</typeparam>
        /// <param name="responses">Http responses</param>
        /// <param name="errorMsg">Error message</param>
        /// <returns></returns>
        public static async Task<IEnumerable<T>> ReadResponsesAsArraysAsync<T>(IEnumerable<HttpResponseMessage> responses, string errorMsg = "")
        {
            List<T> list = new List<T>();
            foreach (var response in responses)
            {
                if (response.IsSuccessStatusCode)
                {
                    IEnumerable<T> temp = new List<T>();
                    temp = await response.Content.ReadAsAsync<IEnumerable<T>>();
                    list.AddRange(temp);
                }
                else
                {
                    throw new Exception(errorMsg);
                }
            }

            return list;
        }

        /// <summary>
        /// Reads responses as single objects into a collection of a given type
        /// </summary>
        /// <typeparam name="T">Type of object</typeparam>
        /// <param name="responses">Http responses</param>
        /// <param name="errorMsg">Error message</param>
        /// <returns></returns>
        public static async Task<IEnumerable<T>> ReadResponsesAsObjectsAsync<T>(IEnumerable<HttpResponseMessage> responses, string errorMsg = "")
        {
            List<T> list = new List<T>();
            foreach (var response in responses)
            {
                if (response.IsSuccessStatusCode)
                {
                    var temp = await response.Content.ReadAsAsync<T>();
                    list.Add(temp);
                }
                else
                {
                    throw new Exception(errorMsg);
                }
            }

            return list;
        }

        /// <summary>
        /// Reads a response as an array into a given type
        /// </summary>
        /// <typeparam name="T">Type of object</typeparam>
        /// <param name="response">Http response</param>
        /// <param name="errorMsg">Error message</param>
        /// <returns></returns>
        public static async Task<IEnumerable<T>> ReadResponseAsArrayAsync<T>(HttpResponseMessage response, string errorMsg = "")
        {
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<IEnumerable<T>>();
            }
            else
            {
                throw new Exception(errorMsg);
            }
        }

        /// <summary>
        /// Reads a response as a single object into a given type
        /// </summary>
        /// <typeparam name="T">Type of object</typeparam>
        /// <param name="response">Http response</param>
        /// <param name="errorMsg">Error message</param>
        /// <returns></returns>
        public static async Task<T> ReadResponseAsObjectAsync<T>(HttpResponseMessage response, string errorMsg = "")
        {
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<T>();
            }
            else
            {
                throw new Exception(errorMsg);
            }
        }

        #region Market

        #endregion

        #region Universe

        #endregion
    }
}
