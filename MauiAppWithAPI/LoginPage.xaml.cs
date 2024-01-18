using MauiAppWithAPI.Models;
using MauiAppWithAPI.Pages;
using MauiAppWithAPI.Services;

namespace MauiAppWithAPI;

public partial class LoginPage : ContentPage
{
    public readonly IUserRepository _userRepository = new UserService();
    public LoginPage()
    {
        InitializeComponent();
    }

    private async void Login_Clicked(object sender, EventArgs e)
    {
        var activityIndicator = new ActivityIndicator
        {
            IsRunning = true,
            Color = Colors.Pink
        };
        string userName = UserName.Text;
        string password = Password.Text;
        if (userName == null || password == null)
        {
            await DisplayAlert("Error", "Please enter user name & password", "Close");
            activityIndicator.IsRunning = false;
            return;
        }
        else
        {
            UserModel userModel = new UserModel();
            userModel.EmailId = userName.ToString();
            userModel.Password = password.ToString();
            var result = await _userRepository.Login(userModel);
            if (result.Success)
            {
                Preferences.Set("authToken", result.Data.JWTToken.ToString());
                await Navigation.PushAsync(new HomePage());
            }
            else
            {
                await DisplayAlert("Error", "Invalid user name or password", "Close");
            }
            activityIndicator.IsRunning = false;
        }
        
        
    }
}