using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameManager.Lib.Models.Account
{
    [Table("User", Schema = "Account")]
    public class User : Base.EntityBase
    {
        [MaxLength(100)]
        public string FirstName { get; set; }
        [MaxLength(100)]
        public string LastName { get; set; }
        public string PasswordHash { get; set; }
        [MaxLength(255)]
        public string Email { get; set; }
        public int GameTime { get; set; }
        public int AccountTypeId { get; set; }
        public AccountType AccountType { get; set; }

        public List<Game.Player> Characters { get; set; } = new List<Game.Player>();
    }
}
