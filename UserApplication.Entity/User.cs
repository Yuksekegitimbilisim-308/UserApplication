﻿namespace UserApplication.Entity
{
    public class User : BaseEntity
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string SecretKey { get; set; }
    }
}
