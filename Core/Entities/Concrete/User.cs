﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Concrete
{
    public class User: IEntity
    {
        public int Id{ get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public byte[] PasswordHash { get; set; }    
        public byte[] PasswordSalt { get; set;}
        public bool Status { get; set; }

    }
}
