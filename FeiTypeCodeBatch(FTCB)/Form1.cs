#region FeiBatchCode
#region ProgarmGithubWebsite
//Github:https://github.com/Mars-FeiFei/FeiBatch/tree/main/FeiTypeCodeBatch(FTCB)
//User github:https://github.com/Mars-FeiFei
#endregion
#region Using
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Using;
using Array = System.Array;
#endregion
namespace FeiTypeCodeBatch_FTCB_
{
    [Serializable]
    [GithubInproductionable("https://github.com/Mars-FeiFei/FeiBatch/tree/main/FeiTypeCodeBatch(FTCB)")]
    public partial class Form1 : Form
    {
        private string varname;
        public Form1()
        {
            InitializeComponent();
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
                    itemStr = item;
                    CustomMethodBuild cm = new CustomMethodBuild(item);
                    if (item.ToLower() == "helper")
                    {
                        MessageBox.Show("Fei Batch Use:1.TypeName(varName)=value \r\n 2.Method ;arg1;arg2...... \r\n 3.TypeName(varName)=ReturnMethod ;arg1;arg2...... \r\n 4.if((bool)varName){CustomMethodName} \r\n 5.cmd/ps/fbpmStart-path(start the cmd/ps/fbpm file at the path.) \r\n 6.for-i=Int32 value;i<Int32 value:codes (for set i = Int32 value;i++;i<Int32 value)");
                    }
                    if (item.ToLower().Contains("show"))
                    {
                        if(item.Split(' ')[1] == "github"){
                            MessageBox.Show("github:https://github.com/Mars-FeiFei/FeiBatch/tree/main/FeiTypeCodeBatch(FTCB)  It's copyed your clipboard.");
                            Clipboard.SetText("https://github.com/Mars-FeiFei/FeiBatch/tree/main/FeiTypeCodeBatch(FTCB)");
                        }
                        else if (item.Split(' ')[1] == "user")
                        {
                            MessageBox.Show("github:https://github.com/Mars-FeiFei  It's copyed your clipboard.");
                            Clipboard.SetText("https://github.com/Mars-FeiFei");
                        }
                    }
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
                            if (func != "ArrayVal" && func != "Count")
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
                                V.v[itemStr.Split('(')[1].Split(')')[0]] = obj;
                            }
                            goto Judge;
                        }
                    }
                Judge:
                    if (itemStr.Contains("method"))
                    {
                        cm = new CustomMethodBuild(itemStr);
                        cm.CreateMethod();
                    }
                    if (itemStr.Contains("=") && !itemStr.Contains("method") && !isTwo)
                    {
                        varname = itemStr.Split('(')[1].Split(')')[0];
                        Type type = Type.GetType($"Using.{itemStr.Split('(')[0]}", true, true);
                        object instance = Activator.CreateInstance(type);
                        var t = instance as BasicType;
                        object vvv = new object();
                        if (itemStr.Split('=')[1] != "@input")
                        {
                            vvv = t.GetVar(itemStr.Split('=')[1]);
                        }
                        else
                        {
                            textBox2.Text = varname + ":";
                            textBox2.KeyDown += TextBox2_KeyDown;

                        }
                        try
                        {
                            V.v.Add(itemStr.Split('(')[1].Split(')')[0], vvv);
                            V.vn.Add(itemStr.Split('(')[1].Split(')')[0]);
                        }
                        catch (Exception ex)
                        {
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
            }
        }
        string itemStr = "";
        public void Run(string[] code)
        {
            try
            {
                bool isTwo = false;
                foreach (var item in code)
                {
                    itemStr = item;
                    CustomMethodBuild cm = new CustomMethodBuild(item);
                    if (item.ToLower() == "helper")
                    {
                        MessageBox.Show("Fei Batch Use:1.TypeName(varName)=value \r\n 2.Method ;arg1;arg2...... \r\n 3.TypeName(varName)=ReturnMethod ;arg1;arg2...... \r\n 4.if((bool)varName){CustomMethodName} \r\n 5.cmd/ps/fbpmStart-path(start the cmd/ps/fbpm file at the path.) \r\n 6.for-i=Int32 value;i<Int32 value:codes (for set i = Int32 value;i++;i<Int32 value)");
                    }
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
                            if (func != "ArrayVal" && func != "Count")
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
                                V.v[itemStr.Split('(')[1].Split(')')[0]] = obj;
                            }
                            goto Judge;
                        }
                    }
                Judge:
                    if (itemStr.Contains("method"))
                    {
                        cm = new CustomMethodBuild(itemStr);
                        cm.CreateMethod();
                    }
                    if (itemStr.Contains("=") && !itemStr.Contains("method") && !isTwo)
                    {
                        varname = itemStr.Split('(')[1].Split(')')[0];
                        Type type = Type.GetType($"Using.{itemStr.Split('(')[0]}", true, true);
                        object instance = Activator.CreateInstance(type);
                        var t = instance as BasicType;
                        object vvv = new object();
                        if (itemStr.Split('=')[1] != "@input")
                        {
                            vvv = t.GetVar(itemStr.Split('=')[1]);
                            try
                            {
                                V.v.Add(itemStr.Split('(')[1].Split(')')[0], vvv);
                                V.vn.Add(itemStr.Split('(')[1].Split(')')[0]);
                            }
                            catch (Exception ex)
                            {
                                V.v[itemStr.Split('(')[1].Split(')')[0]] = vvv;
                            }
                        }
                        else
                        {
                            textBox2.Text = varname + ":";
                            textBox2.KeyDown += TextBox2_KeyDown;

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
            }
        }

        private void TextBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AssVar(textBox2.Text, ref itemStr);
            }
        }
        void AssVar(string text, ref string itemStr)
        {
            itemStr = itemStr.Replace(itemStr.Split('=')[1], text.Split(':')[1]);
            AddVar(itemStr.Split('=')[1]);
        }
        void AddVar(object val)
        {
            try
            {
                V.v.Add(itemStr.Split('(')[1].Split(')')[0], val);
                V.vn.Add(itemStr.Split('(')[1].Split(')')[0]);
            }
            catch (Exception)
            {
                V.v[itemStr.Split('(')[1].Split(')')[0]] = val;
            }
        }
        /// <summary>
        /// Write all text.
        /// </summary>
        /// <param name="text"></param>
        public void ReplaceAllText(string text)
        {
            using (StreamWriter s = new StreamWriter("D:\\code.txt", false, Encoding.UTF8))
            {
                s.Write(text);
            }
        }
        /// <summary>
        /// Save as .bat file.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// Save as the .cmd file.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// Save as the .fbpm file.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

    public class DataAttribute : Attribute
    {
        public DataAttribute()
        {
        }
    }
    [Data]
    public class Data<T> : IEnumerable<T>
    {
        public List<T> data = new List<T>();
        public Data(IEnumerable<T> data)
        {
            this.data = new List<T>(data);
        }
        public Data()
        {
        }
        public void Add(T item)
        {
            data.Add(item);
        }
        public void Remove(T item)
        {
            _ = data.Remove(item);
        }
        public IEnumerator<T> GetEnumerator()
        {
            return (IEnumerator<T>)from item in data
                                   select item;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator<T>)from item in data
                                   select item;
        }
    }
    public abstract class UserAttribute : Attribute
    {
        public string Data {  get; set; }
        public UserAttribute()
        {
        }
        public abstract Data<string> GetUserData();
    }
    public class GithubInproductionable : UserAttribute
    {
        public string GithubWebsite { get; set; }
        public GithubInproductionable(string githubWebsite)
        {
            GithubWebsite = githubWebsite;
        }
        public string GetGithubUser()
        {
            return GithubWebsite.Split('/')[0] + GithubWebsite.Split('/')[1] + GithubWebsite.Split('/')[2];
        }
        public override Data<string> GetUserData()
        {
            return new Data<string>() { GithubWebsite.Split('/')[2], GetHtml(GetGithubUser()).Result};
        }
        private async Task<string> GetHtml(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync("https://www.example.com");

                    if (response.IsSuccessStatusCode)
                    {
                        string html = await response.Content.ReadAsStringAsync();
                        return html;
                    }
                    else
                    {
                        return "";
                    }
                }
                catch (Exception)
                {
                    return "";
                }
            }
        }
    }
    
    public static class U
    {
        /// <summary>
        /// Remove the first item in the string[].
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Use Linq to Replace(Has some bug, please don't use this method.)
        /// </summary>
        /// <param name="s"></param>
        /// <param name="o"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static string NewReplace(this string s, string o, string n)
        {
            return string.Concat(s.Split(o.ToCharArray()).Select(a => a == "" ? n : a));
        }
    }

    public class V
    {
        /// <summary>
        /// Varname and Var value. 
        /// </summary>
        public static Dictionary<string, object> v = new Dictionary<string, object>();
        /// <summary>
        /// Methods names.
        /// </summary>
        public static List<string> Methods = new List<string>()
        {
            "Print",
            "FileStreamWriter",
            "ArrayAss"
        };
        /// <summary>
        /// Return method name.
        /// </summary>
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
        /// <summary>
        /// Custom method name and code.
        /// </summary>
        public static Dictionary<string, string> c = new Dictionary<string, string>();
        /// <summary>
        /// Custom method name.
        /// </summary>
        public static List<string> cn = new List<string>();
        /// <summary>
        /// Custom varname.
        /// </summary>
        public static List<string> vn = new List<string>();
    }
}
#endregion