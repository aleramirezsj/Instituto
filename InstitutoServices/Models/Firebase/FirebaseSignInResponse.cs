﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstitutoServices.Models.Firebase
{
    public class FirebaseSignInResponse
    {
        public string IdToken { get; set; }
        public string RefreshToken { get; set; }
        public string LocalId { get; set; }
        public string Email { get; set; }
        public bool EmailVerified { get; set; }
        public string DisplayName { get; set; }
    }
}
