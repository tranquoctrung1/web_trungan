﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WcfLoggerData.Models
{
    public class LevelAlarmViewModel
    {
        string level;
        double? value;

        public string Level { get => level; set => level = value; }
        public double? Value { get => value; set => this.value = value; }
    }
}