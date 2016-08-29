using System.Collections.Generic;
using BookLib.Web.Models;

namespace BookLib.Web.Service
{
    public interface IApiService
    {
        #region GET METHOD

        IEnumerable<Book> GetAll();
        IEnumerable<Book> SeachBooks(string keyword, string searchType = null);
        User GetUser(string id);
        User GetUserByUsername(string username);

        #endregion




        #region POST METHOD

        Result PlaceDemand(string userID, string bookID);
        Result SaveUser(string username, string password);
        Result AuthenticateUser(string username, string password);
        Result ChangePassword(string id, string newPassword);

        #endregion

    }
}
