using System.Collections.Generic;

namespace TestGeneratorLib.Info
{
    public class FileInfo
    {
        public List<ClassInfo> Classes { get; private set; }

        public FileInfo(List<ClassInfo> classes)
        {
            this.Classes = classes;
        }
    }
}