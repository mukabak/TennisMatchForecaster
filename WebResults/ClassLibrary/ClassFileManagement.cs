using System;
using System.IO;

namespace WebResults
{
    public class ClassFileManagement
    {
        public static void createFile(string path, string name, string content)
        {
            string fullPath = path + name;
            StreamWriter sw = new StreamWriter(fullPath);
            sw.Write(content);
            sw.Close();
        }

        public static void writeToFile(string path, string content, Boolean mode)
        {
            StreamWriter sw = new StreamWriter(path, mode);
            sw.Write(content);
            sw.Close();
        }

        public static string readFile(string path)
        {
            StreamReader sr = new StreamReader(path);
            string content = sr.ReadToEnd();
            sr.Close();
            return content;
        }

        public static string getLastLine(string path)
        {
            StreamReader sr = new StreamReader(path);
            string lastLine = "";
            while (!sr.EndOfStream)
            {
                lastLine = sr.ReadLine();
            }
            sr.Close();
            return lastLine;
        }

        public static void replaceFile(string mainFile, string tempFile) {
            File.Delete(mainFile);
            File.Move(tempFile, mainFile);
        }
    }
}
