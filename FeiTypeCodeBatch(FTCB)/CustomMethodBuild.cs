using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Using;
using Array = System.Array;

namespace FeiTypeCodeBatch_FTCB_
{
    public class CustomMethodBuild
    {
        string varname;
        public string item {  get; set; }
        public CustomMethodBuild(string item)
        {
            this.item = item;
        }
        void PS(string command)
        {
            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = "powershell.exe",
                Arguments = $"-Command \"{command}\"",
                UseShellExecute = false,
                RedirectStandardOutput = true,
                CreateNoWindow = true
            };
            process.StartInfo = startInfo;
            process.Start();
            string output = process.StandardOutput.ReadToEnd();
            process.WaitForExit();
            MessageBox.Show(output);
        }
        void Cmd(string command)
        {
            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = $"/c {command}",
                UseShellExecute = false,
                RedirectStandardOutput = true,
                CreateNoWindow = true
            };
            process.StartInfo = startInfo;
            process.Start();
            string output = process.StandardOutput.ReadToEnd();
            process.WaitForExit();
            MessageBox.Show(output);
        }
        public void CreateMethod()
        {
            V.c.Add(item.Split('[')[1].Split(']')[0], item.Split('{')[1].Split('}')[0]);
            V.cn.Add(item.Split('[')[1].Split(']')[0]);
        }
        public void RunMethod(string cn)
        {
            string item1 = V.c[cn];
            string[] itemArr = item1.Split(':');
            new Form1().Run(itemArr);
        }
    }
}
