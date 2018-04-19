using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using BoardEnvy.Domain.Helpers;

namespace BoardEnvy.Domain.Models
{
    public class Collaborator
    {
        public Collaborator(string userKey, string displayName)
        {
            UserKey = userKey;
            DisplayName = displayName;
        }

        public Collaborator(MailAddress mailAddress)
        {
            UserKey = HashingUtil.CalculateMD5Hash(mailAddress.Address.ToLower());
            DisplayName = mailAddress.DisplayName ?? mailAddress.User;
        }

        public string UserKey
        {
            get;
        }

        public string DisplayName
        {
            get;
        }
    }
}
