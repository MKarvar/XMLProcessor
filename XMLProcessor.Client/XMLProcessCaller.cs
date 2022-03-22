using System.Configuration;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using XMLProcessor.Client.Commands;

namespace XMLProcessor.Client
{
    public class XMLProcessCaller
    {
        private static HttpClient _httpClient;
        private static readonly object _syncLock = new object();

        private HttpClient GetHttpClientInstance()
        {

            if (_httpClient != null) return _httpClient;
            lock (_syncLock)
            {
                if (_httpClient != null) return _httpClient;
                _httpClient = new HttpClient { BaseAddress = new Uri(ConfigurationManager.AppSettings["XMLProcessorServiceUrl"]) };
            }

            return _httpClient;
        }

        public async Task<string> Process(string node, string content)
        {
            NodeProcessCommand command = new NodeProcessCommand() { NodeName = node, Content = content };
            try
            {
                HttpClient httpClient = GetHttpClientInstance();
                var requestData = JsonConvert.SerializeObject(command);
                var response = await httpClient.PostAsync("api/v1/XMLProcess/Process", new StringContent(requestData, Encoding.UTF8, "application/json"));
                using Stream responseStream = response.Content.ReadAsStreamAsync().Result;
                using StreamReader streamReader = new StreamReader(responseStream);
                using JsonTextReader jsonTextReader = new JsonTextReader(streamReader);

                if (response.StatusCode == HttpStatusCode.OK)
                    return string.Empty;

                return $"Processing Node {node} is failed.";
            }
            catch (Exception ex)
            {
                return $"Processing Node {node} is failed with exception.";
            }
        }
    }
}
