using JatraApplication.Models.DatabaseModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace JatraApplication.Repository
{
    public class Userrepo
    {


        User _user = new User();
      
        private readonly JatraDbContext context;
        public Userrepo()
        {
            context = new JatraDbContext();
        }
        public int UserId
        {
            get { return _user.Id; }
            set { _user.Id = value; }
        }

        public string Email
        {
            get { return _user.Email; }
            set { _user.Email = value; }
        }
        public string FirstName
        {
            get { return _user.FirstName; }
            set { _user.FirstName = value; }
        }
        public string LastName
        {
            get { return _user.LastName; }
            set { _user.LastName = value; }
        }
        public string Password
        {
            get { return _user.Password; }
            set { _user.Password = value; }
        }
        public string VCode
        {
            get { return _user.VCode; }
            set { _user.VCode = value; }
        }
        //public int? UserDataId
        //{
        //    get { return _userInfo.UserDataId; }
        //    set { _userInfo.UserDataId = value; }
        //}

        //public string FirstName
        //{
        //    get { return _userInfo.FirstName; }
        //    set { _userInfo.FirstName = value; }
        //}
        //public string LastName
        //{
        //    get { return _userInfo.LastName; }
        //    set { _userInfo.LastName = value; }
        //}
        //public string MiddleName
        //{
        //    get { return _userInfo.MiddleName; }
        //    set { _userInfo.MiddleName = value; }
        //}
        public int Roles
        {
            get { return _user.Roles; }
            set { _user.Roles = value; }
        }

        //public string Address
        //{
        //    get { return _userInfo.Address; }
        //    set { _userInfo.Address = value; }
        //}
        //public string Contact
        //{
        //    get { return _userInfo.Contact; }
        //    set { _userInfo.Contact = value; }
        //}
        //public string ImageLocation
        //{
        //    get { return _userInfo.ImageLocation; }
        //    set { _userInfo.ImageLocation = value; }
        //}
        //public string Description
        //{
        //    get { return _userInfo.Description; }
        //    set { _userInfo.Description = value; }
        //}
        //public int Gender
        //{
        //    get { return _userInfo.Gender; }
        //    set { _userInfo.Gender = value; }
        //}
        //public HttpPostedFileBase file { get; set; }
        public int AddUpdateUser()
        {
            if(UserId !=null)
            {
                 context.Users.Update(_user);
                context.SaveChanges();
                return UserId;
            }
           context.Users.Add(_user);
            context.SaveChanges();
            return _user.Id;
        }
        public User getUsername(string userName)
        {
            IQueryable<User> i = context.Users;
            var test = i.ToList().Where(u => u.Email == userName).FirstOrDefault();
            return test;
        }
        public User GetById(int UserId)
        {
            IQueryable<User> i = context.Users;
            var test = i.ToList().Where(u => u.Id == UserId).FirstOrDefault();
            return test;
        }
        public List<User> getList()
        {
            IQueryable<User> i = context.Users;
            var test = i.ToList();
            return test;
        }

     
        public bool ValidateUser(string userName, string password)
        {
            IQueryable<User> i = context.Users;
            var test = i.ToList().Where(u => u.Email == userName && u.Password == password).FirstOrDefault();
            if (test != null)
            {
                return true;
            }
            return false;
        }


        //public void updateUserData()
        //{
        //    _userInfo.UserId = _user.UserId;
        //    var entity = GetUserInfoById(_userInfo.UserId.Value);
        //    context.Entry(entity).State = EntityState.Detached;
        //    //_userInfo.UserDataId = 13;
        //    if (_userInfo.ImageLocation == null)
        //    {
        //        _userInfo.ImageLocation = entity.ImageLocation;
        //    }
        //    context.UsersInfo.Attach(_userInfo);
        //    context.Entry(_userInfo).State = EntityState.Modified;

        //    context.SaveChanges();
        //}
        public bool UpdateRole(int userId, int roles)
        {
            try
            {
                var data = context.Users.Where(a => a.Id == userId).FirstOrDefault();
                data.Roles = roles;
                context.Users.Update(data);
                return true;
            }
            catch(Exception)
            {
                return false;
            }           
           
        }

    }
}
