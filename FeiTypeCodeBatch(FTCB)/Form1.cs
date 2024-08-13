using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Using;
using Array = System.Array;
namespace FeiTypeCodeBatch_FTCB_
{
    public partial class Form1 : Form
    {
        private string varname;
        public Form1()
        {
            InitializeComponent();
            label2.Visible = false;
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
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                bool isTwo = false;
                ReplaceAllText(textBox1.Text);
                foreach (var item in File.ReadLines("D:\\code.txt"))
                {
                    string itemStr = item;
                    CustomMethodBuild cm = new CustomMethodBuild(item);
                    if (item.Contains("for"))
                    {
                        for (global::System.Int32 i = item.Split(':')[0].Split('-')[1].Split('=')[1].Split(';')[0].ToInt32(); i < item.Split(':')[0].Split('-')[1].Split('<')[1].ToInt32(); i++)
                        {
                            List<string> list = new List<string>() {$"Int32(i)={i}" };
                            foreach(var codeI in item.Split(':')[1].Split('/'))
                            {
                                list.Add(codeI);
                            }
                            Run(list.ToArray());
                        }
                        continue;
                    }
                    if (item.Contains("if("))
                    {
                        foreach (var i in V.vn)
                        {
                            if (i == item.Split('(')[1].Split(')')[0])
                            {
                                if (V.v[i].ToBool())
                                {
                                    foreach (var s in V.cn)
                                    {
                                        if (item.Split('{')[1].Split('}')[0]==s)
                                        {
                                            cm.RunMethod(s);
                                            continue;
                                        }
                                    }
                                }
                            }
                        }
                        
                    }
                    if (item.ToUpperInvariant().Contains("CMDSTART-"))
                    {
                        if (File.Exists(item.Split('-')[1]) && (item.Split('-')[1].Contains(".bat") || item.Split('-')[1].Contains(".cmd")))
                        {
                           Process.Start(item.Split('-')[1]);
                        }  
                    }
                    if (item.ToUpperInvariant().Contains("FBPMSTART-"))
                    {
                        Run(File.ReadAllLines(item.Split('-')[1]));
                        continue;
                    }
                    if (item.ToUpper().Contains("CMD-"))
                    {
                        Cmd(item.Split('-')[1]);
                        continue;
                    }
                    if (item.ToUpper().Contains("PS-"))
                    {
                        PS(item.Split('-')[1]);
                        continue;
                    }
                    foreach (var func in V.MethodReturn)
                    {
                        if(item.Contains(func)){
                            isTwo = true;
                            Type type = Type.GetType($"Using.{func}", true, true);
                            object instance = Activator.CreateInstance(type);
                            var t = instance as BasicType;
                            string[] a = item.Split(func.ToCharArray()[func.ToCharArray().Length - 1])[1].Split(';').RemoveFirst();
                            if (func != "ArrayVal")
                            {
                                List<object> al = new List<object>(a);
                                foreach (var i in al)
                                {
                                    if (V.v.ContainsKey(i.ToString()))
                                    {
                                        a[Array.IndexOf(a, i)] = V.v[i.ToString()].ToString();
                                    }
                                }
                            }
                            object obj = t.MethodReturn(a);
                            itemStr = item.Replace(func+item.Split(func.ToCharArray()[func.ToCharArray().Length - 1])[1],obj.ToString());
                            try
                            {
                                V.v.Add(itemStr.Split('(')[1].Split(')')[0], obj);
                            }
                            catch (Exception ex)
                            {
                                label2.Text = "Error:" + ex.Source + ":" + ex.ToString() + "Stack:" + ex.StackTrace;

                            }
                            goto Judge;
                        }
                    }
                    Judge:
                    if (itemStr.Contains("method"))
                    {
                        label1.Text = "There is a better alternative to this keyword (fbpmStart).";
                        cm = new CustomMethodBuild(itemStr);
                        cm.CreateMethod();
                    }
                    if (itemStr.Contains("=") && !itemStr.Contains("method") && !isTwo)
                    {
                        varname = itemStr.Split('(')[1].Split(')')[0];
                        Type type = Type.GetType($"Using.{itemStr.Split('(')[0]}", true, true);
                        object instance = Activator.CreateInstance(type);
                        var t = instance as BasicType;
                        var vvv = t.GetVar(itemStr.Split('=')[1]);
                        try
                        {
                            V.v.Add(itemStr.Split('(')[1].Split(')')[0], vvv);
                            V.vn.Add(itemStr.Split('(')[1].Split(')')[0]);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }
                    }
                    if (!itemStr.Contains("method"))
                    {
                        foreach (string s in V.Methods)
                        {
                            if (itemStr.Contains(s))
                            {
                                Type type = Type.GetType("Using."+s, true, true);
                                object instance = Activator.CreateInstance(type);
                                var t = instance as BasicType;
                                object[] a = (object[])itemStr.Split(';').RemoveFirst();
                                if (s != "ArrayAss")
                                {
                                    List<object> al = new List<object>(a);
                                    foreach (var i in al)
                                    {
                                        if (V.v.ContainsKey(i.ToString()))
                                        {
                                            a[Array.IndexOf(a, i)] = (object)V.v[i.ToString()].ToString();
                                        }
                                    }
                                }
                                t.Method(a);
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                label2.Text = "Error:"+ex.Source+":"+ex.ToString()+"Stack:"+ex.StackTrace;
            }
        }
        public void Run(string[] code)
        {
            try
            {
                bool isTwo = false;
                foreach (var item in code)
                {
                    string itemStr = item;
                    CustomMethodBuild cm = new CustomMethodBuild(item);
                    if (item.Contains("for"))
                    {
                        for (global::System.Int32 i = item.Split(':')[0].Split('-')[1].Split('=')[1].Split(';')[0].ToInt32(); i < item.Split(':')[0].Split('-')[1].Split('<')[1].ToInt32(); i++)
                        {
                            List<string> list = new List<string>() { $"Int32(i)={i}" };
                            foreach (var codeI in item.Split(':')[1].Split('/'))
                            {
                                list.Add(codeI);
                            }
                            Run(list.ToArray());
                        }
                        continue;
                    }
                    if (item.Contains("if("))
                    {
                        foreach (var i in V.vn)
                        {
                            if (i == item.Split('(')[1].Split(')')[0])
                            {
                                if (V.v[i].ToBool())
                                {
                                    foreach (var s in V.cn)
                                    {
                                        if (item.Split('{')[1].Split('}')[0] == s)
                                        {
                                            cm.RunMethod(s);
                                            continue;
                                        }
                                    }
                                }
                            }
                        }

                    }
                    if (item.ToUpperInvariant().Contains("CMDSTART-"))
                    {
                        if (File.Exists(item.Split('-')[1]) && (item.Split('-')[1].Contains(".bat") || item.Split('-')[1].Contains(".cmd")))
                        {
                            Process.Start(item.Split('-')[1]);
                        }
                    }
                    if (item.ToUpperInvariant().Contains("FBPMSTART-"))
                    {
                        Run(File.ReadAllLines(item.Split('-')[1]));
                        continue;
                    }
                    if (item.ToUpper().Contains("CMD-"))
                    {
                        Cmd(item.Split('-')[1]);
                        continue;
                    }
                    if (item.ToUpper().Contains("PS-"))
                    {
                        PS(item.Split('-')[1]);
                        continue;
                    }
                    foreach (var func in V.MethodReturn)
                    {
                        if (item.Contains(func))
                        {
                            isTwo = true;
                            Type type = Type.GetType($"Using.{func}", true, true);
                            object instance = Activator.CreateInstance(type);
                            var t = instance as BasicType;
                            string[] a = item.Split(func.ToCharArray()[func.ToCharArray().Length - 1])[1].Split(';').RemoveFirst();
                            if (func != "ArrayVal")
                            {
                                List<object> al = new List<object>(a);
                                foreach (var i in al)
                                {
                                    if (V.v.ContainsKey(i.ToString()))
                                    {
                                        a[Array.IndexOf(a, i)] = V.v[i.ToString()].ToString();
                                    }
                                }
                            }
                            object obj = t.MethodReturn(a);
                            itemStr = item.Replace(func + item.Split(func.ToCharArray()[func.ToCharArray().Length - 1])[1], obj.ToString());
                            try
                            {
                                V.v.Add(itemStr.Split('(')[1].Split(')')[0], obj);
                            }
                            catch (Exception ex)
                            {
                                label2.Text = "Error:" + ex.Source + ":" + ex.ToString() + "Stack:" + ex.StackTrace;
                                V.v[itemStr.Split('(')[1].Split(')')[0]] = obj;
                            }
                            goto Judge;
                        }
                    }
                Judge:
                    if (itemStr.Contains("method"))
                    {
                        label1.Text = "There is a better alternative to this keyword (fbpmStart).";
                        cm = new CustomMethodBuild(itemStr);
                        cm.CreateMethod();
                    }
                    if (itemStr.Contains("=") && !itemStr.Contains("method") && !isTwo)
                    {
                        varname = itemStr.Split('(')[1].Split(')')[0];
                        Type type = Type.GetType($"Using.{itemStr.Split('(')[0]}", true, true);
                        object instance = Activator.CreateInstance(type);
                        var t = instance as BasicType;
                        var vvv = t.GetVar(itemStr.Split('=')[1]);
                        try
                        {
                            V.v.Add(itemStr.Split('(')[1].Split(')')[0], vvv);
                            V.vn.Add(itemStr.Split('(')[1].Split(')')[0]);
                        }
                        catch (Exception ex)
                        {
                            label2.Text = "Error:" + ex.Source + ":" + ex.ToString() + "Stack:" + ex.StackTrace;
                            V.v[itemStr.Split('(')[1].Split(')')[0]] = vvv;
                        }
                    }
                    if (!itemStr.Contains("method"))
                    {
                        foreach (string s in V.Methods)
                        {
                            if (itemStr.Contains(s))
                            {
                                Type type = Type.GetType("Using." + s, true, true);
                                object instance = Activator.CreateInstance(type);
                                var t = instance as BasicType;
                                object[] a = (object[])itemStr.Split(';').RemoveFirst();
                                if (s != "ArrayAss")
                                {
                                    List<object> al = new List<object>(a);
                                    foreach (var i in al)
                                    {
                                        if (V.v.ContainsKey(i.ToString()))
                                        {
                                            a[Array.IndexOf(a, i)] = (object)V.v[i.ToString()].ToString();
                                        }
                                    }
                                }
                                t.Method(a);
                            }
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                label2.Text = "Error:" + ex.Source + ":" + ex.ToString() + "Stack:" + ex.StackTrace;
            }
        }
        public void ReplaceAllText(string text)
        {
            using (StreamWriter s = new StreamWriter("D:\\code.txt", false, Encoding.UTF8))
            {
                s.Write(text);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog openFileDialog = new SaveFileDialog();
            openFileDialog.Filter = "Windows Batch File|*.bat";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    writer.Write(textBox1.Text);
                }
            }
        }

        private void SaveCmd_Click(object sender, EventArgs e)
        {
            SaveFileDialog openFileDialog = new SaveFileDialog();
            openFileDialog.Filter = "Windows Cmd File|*.cmd";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    writer.Write(textBox1.Text);
                }
            }
        }

        private void SaveFb_Click(object sender, EventArgs e)
        {
            SaveFileDialog openFileDialog = new SaveFileDialog();
            openFileDialog.Filter = "Feifei Type Batch Plus Method File|*.fbpm";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    writer.Write(textBox1.Text);
                }
            }
        }

        
    }

    public static class U
    {
        public static string[] RemoveFirst(this string[] str)
        {
            string[] result = new string[str.Length - 1];
            int a = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (i != 0)
                {
                    result[a] = str[i];
                    a++;
                }
            }
            return result;
        }
        public static string NewReplace(this string s, string o, string n)
        {
            return string.Concat(s.Split(o.ToCharArray()).Select(a => a == "" ? n : a));
        }
    }

    public class V
    {
        public static Dictionary<string, object> v = new Dictionary<string, object>();
        public static List<string> Methods = new List<string>()
        {
            "Print",
            "FileStreamWriter",
            "ArrayAss"
        };
        public static List<string> MethodReturn = new List<string>()
        {
            "Plus",
            "Sub",
            "Times",
            "Div",
            "Squa",
            "Pow",
            "SquRoot",
            "NRoot",
            "And",
            "Or",
            "Equals",
            "Gtr",
            "Lss",
            "ArrayVal"
        };
        public static Dictionary<string, string> c = new Dictionary<string, string>();
        public static List<string> cn = new List<string>();
        public static List<string> vn = new List<string>();
    }
}
