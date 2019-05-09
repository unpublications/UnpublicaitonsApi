using DataModel;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Event_Management_Api.Repo
{
    public class BaseRepo
    {
        protected bool SafeRun(Action objAction)
        {

            try
            {
                objAction();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        protected T SafeRun<T>(Func<T> objAction)
        {
            try
            {
                return objAction();
            }
            catch (Exception ex)
            {
                return default(T);
            }
        }


    }
}
