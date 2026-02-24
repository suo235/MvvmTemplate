namespace MvvmTemplateTest;

using System.Net.Http.Headers;
using System.Reactive.Linq;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MvvmTemplate;
using MvvmTemplate.ViewModels;
using Reactive.Bindings;

public class LoginWindowViewModelTest
{
    [Fact]
    public void LoginEventInvoked()
    {
        ILoginManager loginManager = new MockLoginManager();
        bool isLogined = false;

        using(LoginWindowViewModel viewModel = new LoginWindowViewModel(loginManager))
        {
            viewModel.Username.Value = "Test User";
            viewModel.Password.Value = "testpassword";
            viewModel.LoginEvent += (result) =>
            {
                isLogined = true;
            };
            viewModel.LoginCommand.Execute();
        }

        Assert.True(isLogined);
    }
}