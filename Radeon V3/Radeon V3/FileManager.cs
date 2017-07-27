using System;
using System.Diagnostics;
using System.IO;

namespace Radeon_V3
{
    class FileManager
    {
        //Create File:
        public void createFile(string path)
        {
            var f = File.Create(path);
            f.Dispose();
        }

        //Compile:
        public void execute(string code)
        {
            Process cmd = new Process();
            cmd.StartInfo.FileName = "cmd.exe";
            cmd.StartInfo.RedirectStandardInput = true;
            cmd.StartInfo.RedirectStandardOutput = true;
            cmd.StartInfo.CreateNoWindow = true;
            cmd.StartInfo.UseShellExecute = false;
            cmd.Start();
            cmd.StandardInput.WriteLine(code);
            cmd.StandardInput.Flush();
            cmd.StandardInput.Close();
            cmd.WaitForExit();
        }
    }
}