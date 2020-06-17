using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VK_Mailing_Tool
{
    public partial class Form1 : Form
    {

        Thread senderThread = new Thread(Sender);

        public Form1()
        {
            InitializeComponent();
        }

        private void variblesSupportHelp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void startButton_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(tokenBox.Text))
            {
                MessageBox.Show("Вам нужно указать токен группы!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (String.IsNullOrWhiteSpace(textBox.Text))
            {
                MessageBox.Show("Вам нужно заполнить текст сообщения!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Regex regex = new Regex(@"\{\w+\}");
            if(regex.IsMatch(textBox.Text) && !variblesSupportBox.Checked)
                if (MessageBox.Show("Похоже, что в тексте для рассылки используются переменные, отднако их поддержка отключена, хотите продолжить?", "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No) return; 

            SenderParams args = new SenderParams();

            args.attachments = attachmentsBox.Text.Trim().Replace('\n', ',').Replace(' ', ',');
            args.token = tokenBox.Text.Trim();
            args.text = textBox.Text;
            args.messagesCount = -1;
            if (messagesCountBox.Text != "Все")
                args.messagesCount = Int32.Parse(messagesCountBox.Text);
            args.supportVaribles = variblesSupportBox.Checked;

            startButton.Visible = false;
            textBox.Enabled = false;
            attachmentsBox.Enabled = false;
            variblesSupportBox.Enabled = false;
            tokenBox.Enabled = false;
            messagesCountBox.Enabled = false;
            stopButton.Visible = true;

            
            senderThread.Start(args);
        }

        public static void Sender(object args)
        {
            SenderParams @params = (SenderParams)args;
            int sendedMessagesCount = 0;
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            senderThread.Abort();

            startButton.Visible = true;
            textBox.Enabled = true;
            attachmentsBox.Enabled = true;
            variblesSupportBox.Enabled = true;
            tokenBox.Enabled = true;
            messagesCountBox.Enabled = true;
            stopButton.Visible = false;
        }
    }
    public class SenderParams
    {
        public string attachments;
        public string token;
        public string text;
        public int messagesCount;
        public bool supportVaribles;

        public SenderParams() { }
    }
}
