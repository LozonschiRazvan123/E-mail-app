using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;


namespace E_mail_app
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textEmail_Enter(object sender, EventArgs e)
        {
            if(textEmail.Text == "Email")
            {
                textEmail.Clear();
                textEmail.ForeColor = Color.FromArgb(83, 179, 183);

            }
        }

        private void textEmail_Leave(object sender, EventArgs e)
        {
            if(textEmail.Text=="")
            {
                textEmail.ForeColor = Color.FromArgb(200, 200, 200);
                textEmail.Text = "Email";
            }
        }

        private void textSubject_Enter(object sender, EventArgs e)
        {
            if (textSubject.Text == "Subject")
            {
                textSubject.Clear();
                textSubject.ForeColor = Color.FromArgb(83, 179, 183);
            }
        }

        private void textSubject_Leave(object sender, EventArgs e)
        {
            if (textSubject.Text == "")
            {
                textSubject.ForeColor = Color.FromArgb(200, 200, 200);
                textSubject.Text = "Subject";
            }
        }

        private void textMessage_Enter(object sender, EventArgs e)
        {
            if (textMessage.Text == "Message")
            {
                textMessage.Clear();
                textMessage.ForeColor = Color.FromArgb(83, 179, 183);
            }
        }

        private void texMessage_Leave(object sender, EventArgs e)
        {
            if (textMessage.Text == "")
            {
                textMessage.ForeColor = Color.FromArgb(200, 200, 200);
                textMessage.Text = "Message";
            }
        }

        private void buttonEmail_Click(object sender, EventArgs e)
        {
            string to, from, pass, messageBody;
            MailMessage message=new MailMessage();
            to = textEmail.Text;
            from = "razvanlozonschi123@gmail.com";
            pass = "jkdvgrzeemddrhvd";
            messageBody = textMessage.Text;
            message.To.Add(to);
            message.From = new MailAddress(from);
            message.Body = "from: " + "<br>Message " + messageBody;
            message.Subject = textSubject.Text;
            message.IsBodyHtml = true;
            SmtpClient smtp= new SmtpClient("smtp.gmail.com");
            smtp.EnableSsl = true;
            smtp.Port = 587;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials=new NetworkCredential(from, pass);
            try 
            { 
                smtp.Send(message);
                DialogResult code = MessageBox.Show("Email sent successfully","Email sent", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if(code==DialogResult.OK)
                {
                    textEmail.Clear();
                    textSubject.Clear();
                    textMessage.Clear();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
