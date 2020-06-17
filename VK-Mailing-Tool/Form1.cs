using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Threading;
using VkNet;
using VkNet.Exception;
using VkNet.Model;
using VkNet.Model.RequestParams;
using VkNet.Model.Attachments;
using System.Net;
using System.Net.Http;

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

            List<UserList> users = new List<UserList>();
            if (@params.supportVaribles)
            {
                Invoke(new Action(() => { statusLabel.Text = $"Получение пользователей: 0 из {conversations.Count}"; }));
                foreach (var conversation in conversations)
                {
                    var user = vk.Users.Get(new long[] { conversation.Peer.Id });
                    users.Add(new UserList((int) conversation.Peer.Id, user[0]));
                    Invoke(new Action(() => { statusLabel.Text = $"Получение пользователей: {users.Count} из {conversations.Count}"; }));
                }
            }

            Invoke(new Action(() => { statusLabel.Text = $"Отправлено {sendedMessagesCount} из {conversations.Count}"; }));

            string url = @"https://api.vk.com/method/messages.send?message={0}&user_id={1}&attachment={2}&access_token={3}&random_id=0&v=5.100";

            int procent = 100 / conversations.Count;
            Invoke(new Action(() => { progressBar.Style = ProgressBarStyle.Continuous; }));
            foreach (var conversation in conversations)
            {
                HttpWebRequest client = (HttpWebRequest)WebRequest.Create(String.Format(url, @params.text, conversation.Peer.Id, @params.attachments, @params.token));
                if (@params.supportVaribles)
                {
                    foreach (var user in users) 
                    {
                        if (user.id == conversation.Peer.Id)
                        {
                            string text = @params.text.Replace("{first_name}", user.user.FirstName);
                            text = text.Replace("{last_name}", user.user.LastName);
                            client = (HttpWebRequest)WebRequest.Create(String.Format(url, text, conversation.Peer.Id, @params.attachments, @params.token));
                        }
                    }
                }
                client.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:77.0) Gecko/20100101 Firefox/77.0";
                client.GetResponse();
                sendedMessagesCount += 1;
                Invoke(new Action(() => { statusLabel.Text = $"Отправлено {sendedMessagesCount} из {conversations.Count}"; }));
                client.Abort();
                if (progressBar.Value + procent > 100)
                    Invoke(new Action(() => { progressBar.Value = 100; }));
                else
                    Invoke(new Action(() => { progressBar.Value += procent; }));
            }     
            MessageBox.Show("Рассылка завершена!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Invoke(new Action(() => { activateGUI(); }));
            Thread.CurrentThread.Abort();
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            senderThread.Abort();
            activateGUI();
        }
        private void activateGUI()
        {
            startButton.Visible = true;
            textBox.Enabled = true;
            attachmentsBox.Enabled = true;
            variblesSupportBox.Enabled = true;
            tokenBox.Enabled = true;
            messagesCountBox.Enabled = true;
            stopButton.Visible = false;
            progressBar.Style = ProgressBarStyle.Continuous;
            progressBar.Value = 0;
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
    public class UserList
    {
        public int id;
        public User user;

        public UserList(int id, User user)
        {
            this.id = id;
            this.user = user;
        }
    }
}
