﻿using System.Collections.Generic;

namespace TestGeneratorLib.Info
{
    public class MethodInfo
    {
        public string Name { get; private set; }
        public Dictionary<string, string> Parameters { get; private set; }
        public string ReturnType { get; private set; }

        public MethodInfo(Dictionary<string, string> parameters, string name, string returnType)
        {
            this.ReturnType = returnType;
            this.Name = name;
            this.Parameters = parameters;
        }
    }
}