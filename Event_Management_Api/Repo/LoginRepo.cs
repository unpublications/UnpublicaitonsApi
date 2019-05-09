using DataModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Event_Management_Api.Repo
{
    public class LoginRepo
    {

        public static async Task<UserProfile> LoginAsyc(UserProfile profile)
        {

            using (var db = new EventUNContext())
            {
                var user = await db.UserProfile.SingleOrDefaultAsync(o => o.Email == profile.Email && o.Password == profile.Password);
                return user;
            }
           
        }
    }
}
