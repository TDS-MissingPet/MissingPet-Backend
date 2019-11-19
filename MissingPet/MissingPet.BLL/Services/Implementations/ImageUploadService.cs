using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MissingPet.BLL.Services.Implementations
{
    public class ImageUploadService : IImageUploadService
    {
        public async Task<string> Upload(byte[] image)
        {
            using(var httpClient = new HttpClient())
            {
                var base64StringContent = Convert.ToBase64String(image);

                var content = new MultipartFormDataContent();
                content.Add(new StringContent(base64StringContent), "image");

                var response = await httpClient.PostAsync("https://api.imgbb.com/1/upload?key=5bcf856d836b56a22049997f4b0e30a7", content);

                if(response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    var errorResponseMessage = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Image was not uploaded. Message from server: {errorResponseMessage}");
                }

                var stringResponse = await response.Content.ReadAsStringAsync();
                var responseObject = JObject.Parse(stringResponse);

                if(responseObject["data"]?["url"] == null)
                {
                    throw new Exception("Response from server is not valid.");
                }

                return responseObject["data"]["url"].ToString();
            }
        }
    }
}
