using System;
using System.ComponentModel.DataAnnotations.Schema;


namespace TestUser.Models
{
 
    public class User: Entity
    {
        public String Login { get; set; }
        public String Password { get; set; }
         public DateTime CreatedDate { get; set; }
        public int UserGroupId { get; set; }
        public int UserStateId { get; set; }
    }
}