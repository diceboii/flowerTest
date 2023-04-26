using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Diagnostics;
using System.Net;
using System.Net.Mail;

namespace flowerTest
{
    /// <summary>
    /// Логика взаимодействия для AskHelp.xaml
    /// </summary>
    public partial class AskHelp : Window
    {
        public AskHelp()
        {
            InitializeComponent();
        }

        private void btnSend_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            string message = "", messageCheck = "", messageCheckEmail = "";

            messageCheck = txtMessage.Text;
            messageCheckEmail = txtEmail.Text;

            if ((messageCheck.Length == 0) && (messageCheckEmail.Length == 0))
                MessageBox.Show("Вы не указали сообщение и Ваш адрес электронной почты");
            else if (messageCheck.Length == 0)
                MessageBox.Show("Вы не указали сообщение");
            else if (messageCheckEmail.Length == 0)
                MessageBox.Show("Вы не указали Ваш адрес электронной почты");

            string subject = "Сообщение в поддержку от ";
            subject = subject + txtEmail.Text;

            if ((messageCheck.Length > 0) && (messageCheckEmail.Length > 0))
            {
                SmtpClient mySmtpClient = new SmtpClient("smtp.yandex.ru");
                mySmtpClient.UseDefaultCredentials = true;
                mySmtpClient.EnableSsl = true;

                System.Net.NetworkCredential networkCredential =
                    new System.Net.NetworkCredential("dammit.helen@yandex.ru", "Respect_Benz_Lololowka2014");

                MailAddress from = new MailAddress("dammit.helen@yandex.ru", "User");
                MailAddress to = new MailAddress("dammit.helen@yandex.ru", "Admin");
                MailMessage mail = new System.Net.Mail.MailMessage(from, to);

                MailAddress replyTo = new MailAddress("diiceboii@gmail.com");
                mail.ReplyToList.Add(replyTo);

                mail.Subject = subject;
                mail.SubjectEncoding = System.Text.Encoding.UTF8;

                mail.Body = txtMessage.Text;
                mail.BodyEncoding = System.Text.Encoding.UTF8;

                mail.IsBodyHtml = false;

                mySmtpClient.Send(mail);
            }

        }
    }
}
