﻿using System.Collections.Generic;

namespace TestingOnly.Application.Orchestration
{
    public class RequestResult
    {
        public bool Success { get; set; }
        public List<string> Messages { get; set; } = new List<string>();
        public object Data { get; set; }
    }
}
