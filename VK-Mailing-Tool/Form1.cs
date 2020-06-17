using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Threading;
using VkNet;
using VkNet.Exception;
using VkNet.Model;
using VkNet.Model.RequestParams;

namespace VK_Mailing_Tool
{
    public partial class Form1 : Form
    {

        Thread senderThread;
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
            progressBar.Style = ProgressBarStyle.Marquee;

            senderThread = new Thread(Sender);
            senderThread.Start(args);
        }

        public void Sender(object args)
        {
            SenderParams @params = (SenderParams)args;
            int sendedMessagesCount = 0;

            VkApi vk = new VkApi();
            vk.Authorize(new ApiAuthParams
                {
                    AccessToken = @params.token
                }
            );

            GetConversationsResult conv;
            var getConvParams = new GetConversationsParams();
            List<Conversation> conversations = new List<Conversation>();

            Invoke(new Action(() => { statusLabel.Text = "Получение списка диалогов: 0"; }));

            if (@params.messagesCount <= 200)
            {
                getConvParams.Count = (ulong) @params.messagesCount;
                foreach(var conversation in vk.Messages.GetConversations(getConvParams).Items)
                    conversations.Add(conversation.Conversation);
                Invoke(new Action(() => { statusLabel.Text = $"Получение списка диалогов: {@params.messagesCount}"; }));
            }
            else
            {
                getConvParams.Count = 200;
                conv = vk.Messages.GetConversations(getConvParams);
                @params.messagesCount -= 200;
                getConvParams.Offset = 200;

                while (@params.messagesCount >= 200)
                {
                    int last_count = conversations.Count;
                    foreach (var conversation in vk.Messages.GetConversations(getConvParams).Items)
                        conversations.Add(conversation.Conversation);
                    if (conversations.Count == last_count)
                        break;
                    @params.messagesCount -= 200;
                    getConvParams.Offset += 200;
                    Invoke(new Action(() => { statusLabel.Text = $"Получение списка диалогов: {conversations.Count}"; }));
                }
                if (@params.messagesCount != 0)
                {
                    getConvParams.Count = (ulong)@params.messagesCount;
                    foreach (var conversation in vk.Messages.GetConversations(getConvParams).Items)
                        conversations.Add(conversation.Conversation);
                }
                Invoke(new Action(() => { statusLabel.Text = $"Получение списка диалогов: {conversations.Count}"; }));
            }

            MessageBox.Show(conversations.Count.ToString());

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
