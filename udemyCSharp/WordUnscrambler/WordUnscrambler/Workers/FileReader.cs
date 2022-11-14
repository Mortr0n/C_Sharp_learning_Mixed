using System;
using System.IO;

namespace WordUnscrambler
{
    class FileReader
    {
        public string[] Read(string filename)
        {
            string[] fileContents;
            try
            {
                 fileContents = File.ReadAllLines(filename);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return fileContents;
        }
    }
}