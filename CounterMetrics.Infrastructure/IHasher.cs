﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CounterMetrics.Infrastructure
{
    public interface IHasher
    {
        string Hash(string source);
    }
}