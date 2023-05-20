using System.ComponentModel.DataAnnotations;

namespace JatraApplication.DataAccess.Context
{
    public class TUsers
    {
        private int? _userId;
        private string _userName;
        private string _fullName;
        private string _password;
        private string _vCode;
        private int _roles;

        [Key]
        public int? UserId
        {
            get { return _userId; }
            set { _userId = value; }
        }
        public int Roles
        {
            get { return _roles; }
            set { _roles = value; }
        }
        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }
        public string FullName
        {
            get { return _fullName; }
            set { _fullName = value; }
        }
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }
        public string VCode
        {
            get { return _vCode; }
            set { _vCode = value; }
        }
    }
}
