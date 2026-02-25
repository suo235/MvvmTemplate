namespace MvvmTemplate.Models;

public class MockLoginManager : ILoginManager
{
    public bool IsLogined
    {
        get => is_logined;
        set
        {
            is_logined = value;
        }
    }
    private bool is_logined = false;

    public User? LoginUser
    {
        get => login_user;
        set
        {
            login_user = value;
        }
    }
    private User? login_user = null;

    public MockLoginManager()
    {
        
    }

    public bool Login(string name, string password)
    {
        LoginUser = new User{Id = 1, Name = name, Password = password, IsAdmin = 0, IsDeleted = 0};
        return true;
    }
}