namespace MvvmTemplate;

public interface ILoginManager
{
    bool IsLogined{ get; }

    User? LoginUser{ get; }

    bool Login(string name, string password);
}

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

public class LoginManager : ILoginManager
{
    public bool IsLogined
    {
        get => is_logined;
        private set
        {
            is_logined = value;
        }
    }
    private bool is_logined = false;

    public User? LoginUser
    {
        get => login_user;
        private set
        {
            login_user = value;
        }
    }
    private User? login_user = null;

    public LoginManager()
    {
        
    }

    public bool Login(string name, string password)
    {
        MvvmTemplateContext dbContext = new MvvmTemplateContext();
        IEnumerable<User> users = dbContext.Users
            .Where(u => u.Name == name);
        if(users.Count() != 1)
        {
            return false;
        }
        else
        {
            User? user = users.FirstOrDefault();
            if(user?.Password == password)
            {
                IsLogined = true;
                LoginUser = user;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}