﻿using System.ComponentModel.DataAnnotations;

namespace APICliente.Modelos
{
    public class User
    {
        
        public int Id { get; set; }
        public string?  UserName { get; set; }
        public byte[]? PasswordHash { get; set; }
        public byte[]? PasswordSalt { get; set; }
    }
}
