using Microsoft.AspNetCore.Mvc;
using Users.NewFolder;
namespace Users.Controllers

{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase

    {
        private static int count=1;
        private static readonly List<User> user = new List<User>();
        [HttpPost("create")]
      
        public string Create(string usersName,int usersId,string usersSurname,string usersMail, string usersAdress) {
            User users = new User()
            {
                Id = count++


            };
            user.Add(users);
            //user.Add(usersSurname);        
            //user.Add(usersMail);       
            //user.Add(usersAdress);
            //user.Add(usersId);
            return $"\"{usersName},{usersAdress},{usersId},{usersSurname},{usersMail}\"created";
           
        }

        [HttpGet("getById")]
        public User GetUserId(int Id)
        {
            var users = user.FirstOrDefault(user => user.Id == Id);
            if (user == null)
            {
                return null;
            }
            return users;
        }
        [HttpPatch("update Surname")]
        public User UpdateUsersSurname(int Id,string surname)
        {
            var users = user.FirstOrDefault(user => user.Id == Id);
            if (user == null)
            {
                return null;
            }
            users.surname = surname;
            return users;
        }
        [HttpDelete("deleted email")]
        public string DeleteUsersEmail(string email)
        {
            var users = user.FirstOrDefault(user => user.email==email);
            if (user == null)
            {
                return null;
            }
            user.Remove(users);
            return "Deleted";
        }
        [HttpGet("Get all books")]
        public IEnumerable<User>GetAll()
        {
            
            return user;
        }
    }
}
