﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

namespace Myweb.Ef_model
{
    public partial class User
    {
        public User()
        {
            CoinHistory = new HashSet<CoinHistory>();
            Gaccount = new HashSet<Gaccount>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Account { get; set; }
        public string Password { get; set; }
        public int? Tokenvalue { get; set; }
        public string Addess { get; set; }

        public virtual ICollection<CoinHistory> CoinHistory { get; set; }
        public virtual ICollection<Gaccount> Gaccount { get; set; }
    }
}