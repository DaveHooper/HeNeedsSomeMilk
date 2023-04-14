using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Soundboard
{
    internal class SoundButton: Button
    {
        public string path;

        //add winforms button
        //add image/color for generic button
        //properties
        /*  - start time/stop time
         *  - 
         */

        public SoundButton(string filePath)
        {
            path = filePath;
        }
    }
}
