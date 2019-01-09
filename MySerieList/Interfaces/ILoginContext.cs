using Models;

namespace Interfaces
{
    public interface ILoginContext
    {
        User GetUserByEMail(string eMail);
        bool LoginCheck(string eMail, string passWord);
    }
}