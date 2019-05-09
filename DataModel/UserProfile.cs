using System;
using System.Collections.Generic;

namespace DataModel
{
    public partial class UserProfile
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string MobileNo { get; set; }
    }
}
