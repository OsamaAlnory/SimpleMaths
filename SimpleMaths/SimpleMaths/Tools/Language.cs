using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleMaths.Tools
{
    public class Language
    {

        public static readonly Language EN = new Language("en_US.txt");


        private string fileName;

        public Language(string fileName)
        {
            this.fileName = fileName;
        }

        public string getFileName()
        {
            return fileName;
        }

    }
}
