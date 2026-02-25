namespace MvvmTemplate.Models;

public interface ILoginManager
{
    bool IsLogined{ get; }

    User? LoginUser{ get; }

    bool Login(string name, string password);
}