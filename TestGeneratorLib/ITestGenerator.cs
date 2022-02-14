using System.Collections.Generic;
using System.IO;

namespace TestGeneratorLib
{
    public interface ITestGenerator
    {
        public Dictionary<string, string> GenerateTests(FileInfo fileInfo);

    }
}