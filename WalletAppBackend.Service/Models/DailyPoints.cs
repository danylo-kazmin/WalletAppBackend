﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalletAppBackend.Service.Models
{
    public class DailyPoints
    {
        public Guid Id { get; set; }
        public string Points { get; set; }
        public int DayOfSeasone { get; set; }
    }
}
