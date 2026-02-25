namespace MvvmTemplate.Models;

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