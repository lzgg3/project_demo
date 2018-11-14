using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cloud_demo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (FontFamily font in FontFamily.Families)      //窗体打开时加载系统安装字体名称并输入到ComboBox控件中去  

            {
                this.toolStripComboBox2.Items.Add(font.Name);           //加载  
            }
            this.toolStripComboBox2.SelectedItem = "Consolas";
           

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            
        }

        private void 退出XToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text == "")
            {
                this.Close();
            }
            else
            {
                // MessageBox.Show("文件未保存，您确定要退出吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (MessageBox.Show("文件未保存，您确定要退出吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    this.Close();
                }
            }
        }
        // 退出
        private void toolStripButton15_Click_1(object sender, EventArgs e)
        {

        }

        private void 新建NToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            label3.Text = DateTime.Now.ToString();
            Form f1 = new Form1();
            f1.Show();
        }

        private void 打开OToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(this.openFileDialog1.ShowDialog()==DialogResult.OK)
            {
                openFileDialog1.Filter = "文本文档.TXT|*.txt|.rtf文档|*.rtf";  // Filter 文件筛选器
                String fileName = this.openFileDialog1.FileName;

                System.IO.StreamReader reader = new System.IO.StreamReader(fileName, Encoding.Default);
                this.richTextBox1.Text = reader.ReadToEnd();
                reader.Close();
            }
           
           
        }

        private void 保存SToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlm = new SaveFileDialog();
            dlm.InitialDirectory = Application.StartupPath;
            if(dlm.ShowDialog()==DialogResult.OK)
            {
                dlm.Filter = "文本文档.TXT|*.txt|.rtf文档|*.rtf";

                String fileName = this.saveFileDialog1.FileName;

                
            }

        }

        private void 另存为AToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.InitialDirectory = "d:\\";
            saveFileDialog1.Filter = "文本文件(*.txt)|*.txt|所有文件(*.*)|*.*";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;
            DialogResult dirs = saveFileDialog1.ShowDialog();
            if (dirs == DialogResult.OK)
            {
                String fileName = saveFileDialog1.FileName;
                richTextBox1.SaveFile(fileName, RichTextBoxStreamType.RichText);
            }
        }

        private void 打印PToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 撤销UToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.CanUndo)
            {
                richTextBox1.Undo();
            }
        }

        private void 剪切TToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectedText != null)
            {
                richTextBox1.Cut();
            }
        }

        private void 复制CToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectedText != null)
            {
                richTextBox1.Copy();
            }
        }

        private void 粘贴PToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void 删除LToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectedText != null)
            {
                richTextBox1.SelectedText = "";
            }
        }

        private void 全选AToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
        }

        bool beginMove = false;
        int currentXPosition;
        int currentYPosition;

        private void Form1_MouseLeave(object sender, EventArgs e)
        {
            //设置初始状态
            currentXPosition = 0;
            currentYPosition = 0;
            beginMove = false;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (beginMove)
            {
                //根据鼠标X坐标确定窗体X坐标
                this.Left += MousePosition.X - currentXPosition;
                //根据鼠标Y坐标确定窗体Y坐标
                this.Top += MousePosition.Y - currentYPosition;
                currentXPosition = MousePosition.X;
                currentYPosition = MousePosition.Y;
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            beginMove = false;
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            //将鼠标坐标赋给窗体左上角坐标
            beginMove = true;
            currentXPosition = MousePosition.X;
            currentYPosition = MousePosition.Y;
            this.Refresh();
        }

        //  字体下拉框
        private void toolStripComboBox2_Click(object sender, EventArgs e)
        {
            /*
            try
            {
                this.toolStripComboBox2.SelectionFont = new Font(this.toolStripComboBox2.Text.Trim(), this.toolStripComboBox2.SelectionFont.Size, this.toolStripComboBox2.SelectionFont.Style);
                toolStripComboBox2.Focus();
            }
            catch (Exception)
            {
                SetFontName(this.toolStripComboBox2.Text.Trim());
            }*/

        }
        //  字号下拉框
        private void toolStripComboBox3_Click(object sender, EventArgs e)
        {

        }

        private void 字体FToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog font = new FontDialog();
            font.Font = richTextBox1.Font;
            if (font.ShowDialog() == DialogResult.OK)
            {
                this.richTextBox1.SelectionFont = font.Font;
            }
        }

        private void 颜色YToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog color = new ColorDialog();
            if(color.ShowDialog()==DialogResult.OK)
            {
                this.richTextBox1.SelectionColor = color.Color;
            }
        }

        // 左对齐
        private void toolStripButton12_Click(object sender, EventArgs e)
        {
            this.richTextBox1.SelectionAlignment = HorizontalAlignment.Left;
        }

        private void toolStripButton13_Click(object sender, EventArgs e)
        {
            this.richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
        }

        private void toolStripButton14_Click(object sender, EventArgs e)
        {
            this.richTextBox1.SelectionAlignment = HorizontalAlignment.Right;
        }

        // 字体加粗
        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            if (this.BackColor != SystemColors.ControlDark)
            {
                this.BackColor = SystemColors.ControlDark;
            }
            if(!(this.Font.Bold))
            {
                this.Font = new Font(this.Font, FontStyle.Bold);
            }
        }

        // 打印预览
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //  printDocument1 为打印控件
            //  设置打印用的纸张 当设置为Custom的时候，可以自定义纸张的大小，还可以选择A4,A5等常用纸型
            this.printDocument1.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("Cutum", 500, 300);

            //  将写好的格式给打印预览控件以便预览
            printPreviewDialog1.Document = printDocument1;

            //  显示打印预览
            DialogResult result = printPreviewDialog1.ShowDialog();
            
            //  if(result==DialogResult.OK)
            //  this.MyPrintDocument.Print();`
        }

        private void 日历RToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void 关于云笔记BToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("云笔记---作者：栗子哥哥，联系邮箱：1696471976@qq.com");
        }

        private void 页面设置UToolStripMenuItem_Click(object sender, EventArgs e)
        {

            // PageSetupDialog psd = new PageSetupDialog();
            // psd.ShowDialog();
        }

        // 查找
        private void toolStripButton15_Click(object sender, EventArgs e)
        {
            
        }

        private void label3_Click(object sender, EventArgs e)
        {
            
        }
        //有问题
        private void toolStripComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
           
           // this.richTextBox1.SelectionFont = new Font(this.richTextBox1.SelectionFont.FontFamily, FontSize[this.toolStripComboBox2.SelectedIndex], this.richTextBox1.SelectionFont.Style);
            richTextBox1.Focus();
            
        }


        //toolStripComboBox2的TextChanged事件
        private void toolStripComboBox2_TextChanged(object sender, EventArgs e)
        {
            if (richTextBox1.Text.Trim() != "")
            {
                try
                {
                    this.richTextBox1.SelectionFont = new Font(this.richTextBox1.SelectionFont.FontFamily, float.Parse(toolStripComboBox2.Text.Trim()), this.richTextBox1.SelectionFont.Style);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("别捣蛋...格式有误!!!");
                    return;
                }
            }

        }
    }
}
