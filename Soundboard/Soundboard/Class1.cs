using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soundboard
{
    internal class SoundFile
    {
        string name;
        string path;
        public SoundFile(string fileName, string filePath)
        {
            name = fileName;
            path = filePath;
        }
    }


}
