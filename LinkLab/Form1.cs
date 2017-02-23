using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LinkLab {
    public partial class Form1 : Form {
        private string CMDHead = "LinkLab>";
        private List<CMD> CMDHistory = new List<CMD>();

        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            richTextBox_cmd.Font = new System.Drawing.Font("consolas", 10f);
            InitializeCMD();//这个放在这里的原因是修改字体时将颜色给改了，也就是说，构造函数先于这个函数执行（这不废话么）
            //debug
            panel_output.BorderStyle = BorderStyle.FixedSingle;
            this.FormBorderStyle = FormBorderStyle.Sizable;
            panel_cmd.BorderStyle = BorderStyle.FixedSingle;
        }
        //初始化新的命令
        private void InitializeCMD() {
            richTextBox_cmd.SelectionColor = Color.Red;
            richTextBox_cmd.AppendText(CMDHead);
            richTextBox_cmd.SelectionColor = Color.Black;
        }
        //检测回车，进入下个命令
        private void richTextBox_cmd_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                richTextBox_cmd.AppendText("\r\n");
                e.Handled = true;
                CMD newCMD = new CMD(richTextBox_cmd.Text);
                CMDHistory.Add(newCMD);
                InitializeCMD();
            }
        }
        //输出点调试信息
        private void cMDToolStripMenuItem_Click(object sender, EventArgs e) {
            string allCMDs = "";
            foreach (CMD one in CMDHistory) {
                allCMDs += one.GetCMD() + "\r\n";
            }
            MessageBox.Show(allCMDs);
        }
    }
    //命令内容相关的类
    public class CMD {
        private string currentCMD = "";
        //构造函数，从窗口中获得命令本身
        public CMD(string allCMD) {
            string[] CMDLines = allCMD.Split(new string[] { "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);
            string currentLine = CMDLines[CMDLines.Count() - 1];
            currentCMD = currentLine.Split(new char[] { '>' }, 2)[1];
        }
        //返回具体命令内容
        public string GetCMD() {
            return currentCMD;
        }
    }
}
