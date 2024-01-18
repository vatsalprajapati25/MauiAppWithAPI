using MauiAppWithAPI.Common;
using MauiAppWithAPI.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace MauiAppWithAPI.Services
{
    public class UserService : IUserRepository
    {
        public async Task<ApiPostResponse<LoginResponseModel>> Login(UserModel user)
        {
            ApiPostResponse<LoginResponseModel> apiResponse = new ApiPostResponse<LoginResponseModel>();
            string url = APIUrlHelper.baseUrl + APIUrlHelper.accountController + APIUrlHelper.login;

            var data = new
            {
                EmailId = user.EmailId,
                Password = user.Password
            };
            string jsonData = JsonConvert.SerializeObject(data);

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync(url, content);
            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var responseData = JsonConvert.DeserializeObject<ApiPostResponse<LoginResponseModel>>(responseContent);
                return responseData;
            }
            else
            {
                return apiResponse;
            }

        }
    }
}
