using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetChallenge.Helper
{
    public class GenHelper
    {
        public string reverseStringstring(string stringInput)
        {
            char[] charArray = stringInput.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
        public void saveData(string filename, string text)
        {
            string strPathDesktop = Environment.GetFolderPath(System.Environment.SpecialFolder.DesktopDirectory);
            string path = strPathDesktop + @"\" + filename;
            File.WriteAllText(path, text);
        }
    }

}
