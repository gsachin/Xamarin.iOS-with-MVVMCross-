using SQLite.Net.Attributes;
using System.ComponentModel;
namespace Users.Core.Model
{
    
    [Table("User")]
    public class User: BaseModel
    {
        [PrimaryKey, AutoIncrement]
        public int DatabaseId { get; set; }
        public string Email { get; set; }
        public int UserId { get; set; }

        public string UserName { get; set; }

       
       // [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{5,}$", ErrorMessage = "Min 5 and max 12 characters, at least one letter and one number:")]
        //[Required]
        //[StringLength(12, MinimumLength = 5, ErrorMessage = "minimum 5 to 12 character are required")]
        public string Password { get; set; }
        public User(){
            
        }
        public User(int userId,string userName,string password){
            UserName = userName;
            UserId = userId;
            Password = password;
        }

           
    }

}
