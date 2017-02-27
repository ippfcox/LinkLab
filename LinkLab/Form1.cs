﻿using System;
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
        private bool isInited = false;
        private Canvas canvas = null;

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
        //输出提示
        private void OutputNote(string note, Color foreColor) {
            richTextBox_cmd.SelectionColor = foreColor;
            richTextBox_cmd.AppendText(note);
            richTextBox_cmd.SelectionColor = Color.Black;
        }
        //初始化新的命令
        private void InitializeCMD() {
            OutputNote(CMDHead, Color.Blue);
        }
        //检测回车，进入下个命令
        private void richTextBox_cmd_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                richTextBox_cmd.AppendText("\r\n");
                e.Handled = true;
                CMD newCMD = new CMD(richTextBox_cmd.Text);
                CMD.CMDStruct newCMDStruct = newCMD.GetCMDStruct();
                if (newCMDStruct.isBroken) {
                    OutputNote("命令错误，无法执行.\r\n", Color.Red);
                } else {
                    switch (newCMDStruct.head) { 
                        case CMD.CMDStruct.CMDHead.init:
                            if (isInited == true) {
                                OutputNote("不能重复初始化.\r\n", Color.Red);
                            } else if (newCMDStruct.bitmapSize.Width <= 0 || newCMDStruct.bitmapSize.Height <= 0) {
                                OutputNote("初始化参数错误", Color.Red);
                            } else {
                                //考虑计算窗口大小变化来执行这块，修改panel和picturebox并不会对窗口产生影响
                                panel_output.Size = newCMDStruct.bitmapSize;
                                pictureBox_output.Size = newCMDStruct.bitmapSize;
                                Color foreColor = Color.Black;
                                if (newCMDStruct.color == CMD.CMDStruct.CMDOption.S) {
                                    foreColor = newCMDStruct.currentColor;
                                }
                                canvas = new Canvas(newCMDStruct.bitmapSize, foreColor);
                                isInited = true;
                            }
                            break;
                        case CMD.CMDStruct.CMDHead.link:
                            //具体画图操作
                            break;
                    }
                    CMDHistory.Add(newCMD);
                }
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

        private void cMDSTructToolStripMenuItem_Click(object sender, EventArgs e) {
            //获取最新的CMDStruct并显示，我去吃饭了
            CMD lastCMD = CMDHistory[CMDHistory.Count() - 1];
            CMD.CMDStruct lastCMDStruct = lastCMD.GetCMDStruct();
            string CMDStructContent = lastCMDStruct.head.ToString() + "\r\n" +
                                        lastCMDStruct.isBroken.ToString() + "\r\n" +
                                        lastCMDStruct.point1.ToString() + "\r\n" +
                                        lastCMDStruct.point2.ToString() + "\r\n" +
                                        lastCMDStruct.points.ToString() + "\r\n" +
                                        lastCMDStruct.color.ToString() + "\r\n" +
                                        lastCMDStruct.currentColor.ToString();
            MessageBox.Show(CMDStructContent);
        }

        private void cAnvasToolStripMenuItem_Click(object sender, EventArgs e) {
            MessageBox.Show(canvas.GetCanvasInfo());
        }
    }
    //命令内容相关的类
    public class CMD {
        //一个用于保存命令内容的结构体，通过这个结构体就可以完全绘图了
        public struct CMDStruct {
            public enum CMDHead { link, init, NS };
            public enum CMDOption { S, NS };

            public bool isBroken;
            public CMDHead head;

            public CMDOption points;
            public Point point1;
            public Point point2;

            public CMDOption color;
            public Color currentColor;

            public CMDOption size;
            public Size bitmapSize;

            public CMDStruct(Color customColor) {
                isBroken = false;
                head = CMDHead.NS;
                points = CMDOption.NS;
                color = CMDOption.NS;
                currentColor = customColor;
                point1 = new Point(0, 0);
                point2 = new Point(0, 0);
                size = CMDOption.S;
                bitmapSize = new Size(0, 0);
            }
        }
        private string currentCMD = "";//当前命令的string
        private CMDStruct currentCMDStruct = new CMDStruct(Color.Black);//当前命令的结构体

        //构造函数，从窗口中获得命令本身，并转换为小写
        public CMD(string allCMD) {
            string[] CMDLines = allCMD.Split(new string[] { "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);
            string currentLine = CMDLines[CMDLines.Count() - 1];
            currentCMD = currentLine.Split(new char[] { '>' }, 2)[1].ToLower();
            SplitCMD();
        }

        //返回具体命令内容
        public string GetCMD() {
            return currentCMD;
        }
        public CMDStruct GetCMDStruct() {
            return currentCMDStruct;
        }

        //拆分命令
        private void SplitCMD() {
            //将命令以-分开，若没东西则标记命令损坏
            string[] CMDSegments = currentCMD.Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
            if (CMDSegments.Count() <= 0) {
                currentCMDStruct.isBroken = true;
                return;
            }
            //将所有的命令去前后空格
            for (int i = 0; i < CMDSegments.Count(); i++) {
                CMDSegments[i] = CMDSegments[i].Trim();
            }
            //分析命令头，这个后面可能会重写
            switch (CMDSegments[0]) {
                case "link": 
                    currentCMDStruct.head = CMDStruct.CMDHead.link;
                    break;
                case "init":
                    currentCMDStruct.head = CMDStruct.CMDHead.init;
                    break;
                default:
                    currentCMDStruct.isBroken = true;
                    return;
            }
            //分析后面的具体命令，从头的后面开始
            //有哪个命令就把哪个命令的标志设置为S（默认的为NS），然后根据命令设置好参数，真正执行命令的时候就遍历标志位，为S的再去找参数
            for (int i = 1; i < CMDSegments.Count(); i++) {
                string[] options = CMDSegments[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                try {
                    switch (options[0]) {
                        case "p":
                            currentCMDStruct.points = CMDStruct.CMDOption.S;
                            currentCMDStruct.point1 = new Point(int.Parse(options[1]), int.Parse(options[2]));
                            currentCMDStruct.point2 = new Point(int.Parse(options[3]), int.Parse(options[4]));
                            break;
                        case "c":
                            currentCMDStruct.color = CMDStruct.CMDOption.S;
                            break;
                        case "s":
                            currentCMDStruct.size = CMDStruct.CMDOption.S;
                            currentCMDStruct.bitmapSize = new Size(int.Parse(options[1]), int.Parse(options[2]));
                            break;
                    }
                } catch {
                    currentCMDStruct.isBroken = true;
                }
            }
        }
    }
    public class Canvas { 
        private Bitmap bitmapOutput;
        private Color foreColor;

        public Canvas(Size bmSize, Color fColor) {
            bitmapOutput = new Bitmap(bmSize.Width, bmSize.Height);
            foreColor = fColor;
        }
        public string GetCanvasInfo() {
            string info = bitmapOutput.Size.ToString() + "\r\n" +
                            foreColor.ToString();
            return info;
        }
    }
}
