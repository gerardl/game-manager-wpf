using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameManager.Lib.Models.Account
{
    /// <summary>
    /// I'm enforcing types at the account level
    /// instead of the player level so GMs can't have
    /// a normal account under the same user
    /// </summary>

    [Table("AccountType", Schema = "Account")]
    public class AccountType : Base.MasterData
    {
    }

    public enum AccountTypes
    {
        Player = 1,
        GM
    }
}
