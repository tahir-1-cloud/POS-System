using System;
using System.Net.Mail;

namespace ABC.Customer.API.ViewModel
{
    public class EmailService
    {


        public bool SendEmail(string toEmail, string user, string url = "")
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("lydiacms00@gmail.com");
                mail.To.Add(toEmail);
                if (string.IsNullOrEmpty(user))
                {
                    mail.Subject = "Reset password on ABC";
                    mail.Body = ConvertHtmlToStringForResetPassword(url);
                }
                else
                {
                    mail.Subject = "Invitation to sign up on ABC";
                    mail.Body = ConvertHtmlToString(user, url);
                }
                mail.IsBodyHtml = true;

                SmtpServer.Port = 587;
                SmtpServer.UseDefaultCredentials = false;
                SmtpServer.Credentials = new System.Net.NetworkCredential("lydiacms00@gmail.com", "Cms@firm00");
                SmtpServer.EnableSsl = true;
                SmtpServer.Send(mail);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }



        public bool OrderEmail(string toEmail, string user, string url = "")
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("lydiacms00@gmail.com");
                mail.To.Add(toEmail);
                if (string.IsNullOrEmpty(user))
                {
                    mail.Subject = "Order mail on ABC";
                    mail.Body = ConvertHtmlToStringOrdermail(url);
                }
                else
                {
                    mail.Subject = "Invitation to sign up on ABC";
                    mail.Body = ConvertHtmlToString(user, url);
                }
                mail.IsBodyHtml = true;

                SmtpServer.Port = 587;
                SmtpServer.UseDefaultCredentials = false;
                SmtpServer.Credentials = new System.Net.NetworkCredential("lydiacms00@gmail.com", "Cms@firm00");
                SmtpServer.EnableSsl = true;
                SmtpServer.Send(mail);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool OrderEmailReminder(string toEmail, string user, string url = "")
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("lydiacms00@gmail.com");
                mail.To.Add(toEmail);
                if (string.IsNullOrEmpty(user))
                {
                    mail.Subject = "Order mail  Reminder on ABC";
                    mail.Body = ConvertHtmlToStringOrdermail(url);
                }
                else
                {
                    mail.Subject = "Invitation to sign up on ABC";
                    mail.Body = ConvertHtmlToString(user, url);
                }
                mail.IsBodyHtml = true;

                SmtpServer.Port = 587;
                SmtpServer.UseDefaultCredentials = false;
                SmtpServer.Credentials = new System.Net.NetworkCredential("lydiacms00@gmail.com", "Cms@firm00");
                SmtpServer.EnableSsl = true;
                SmtpServer.Send(mail);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private string ConvertHtmlToString(string user, string url)
        {
            string html = string.Empty;
            html += "<style>body { margin-top: 20px;} </style>";
            html += "<table class='body-wrap' style='width:100%;'><tbody><tr><td></td><td>";
            html += "<div style='box-sizing:border-box;max-width:600px;margin:0 auto;padding:20px;'><table><tbody><tr>";
            html += "<td style='padding:30px;border:3px solid #67a8e4;border-radius:7px;'><meta><table><tbody><tr>";
            html += "<td style='font-family:Helvetica Neue,Helvetica,Arial,sans-serif;font-size:14px;padding: 0 0 20px;'>";
            html += $"Congratulations!! Your Order Has been placed. Thank u for shopping from our ABC store.</td></tr><tr>";
            html += "<td style='font-family:Helvetica Neue,Helvetica,Arial,sans-serif;font-size:14px;padding: 0 0 20px;'>";
            html += "</td></tr><tr><td style ='padding: 0 0 20px;'><a href=";
            html += $"{url}' class='btn-primary' itemprop='url' style='font-family:Helvetica Neue,Helvetica,Arial,sans-serif;font-size: 14px; color: #FFF; text-decoration: none; line-height: 2em; font-weight: bold;cursor: pointer; display: inline-block; border-radius: 5px;background-color: #f06292;border-color: #f06292; border-style: solid; border-width: 8px 16px;'>";

            html += "<td class='content-block' style='font-family:Helvetica Neue,Helvetica,Arial,sans-serif;font-size:14px;padding: 0 0 20px;'>";
            html += "<p>Support Team</p></td></tr><tr>";
            html += "<td style='text-align:center;font-family:Helvetica Neue,Helvetica,Arial,sans-serif;font-size:14px;'>&copy; ABC Discounts";
            html += "</td></tr></tbody></table></td></tr></tbody></table></div></td></tr></tbody></table>";
            return html;
        }
        private string ConvertHtmlToStringForResetPassword(string url)
        {
            string html = string.Empty;
            html += "<style>body { margin-top: 20px;} </style>";
            html += "<table class='body-wrap' style='width:100%;'><tbody><tr><td></td><td>";
            html += "<div style='box-sizing:border-box;max-width:600px;margin:0 auto;padding:20px;'><table><tbody><tr>";
            html += "<td style='padding:30px;border:3px solid #67a8e4;border-radius:7px;'><meta><table><tbody><tr>";
            html += "<td style='font-family:Helvetica Neue,Helvetica,Arial,sans-serif;font-size:14px;padding: 0 0 20px;'>";
            html += $"If you want to reset your password please click the button below to set up a new password for your account. If you did not require it, simply ignore this email. This is confidential email, Please don't share it with anyone.</td></tr><tr>";
            html += "<td style='font-family:Helvetica Neue,Helvetica,Arial,sans-serif;font-size:14px;padding: 0 0 20px;'>";
            html += "Please reset your password by clicking Reset Password.";
            html += "</td></tr><tr><td style ='padding: 0 0 20px;'><a href=";
            html += $"{url}' class='btn-primary' itemprop='url' style='font-family:Helvetica Neue,Helvetica,Arial,sans-serif;font-size: 14px; color: #FFF; text-decoration: none; line-height: 2em; font-weight: bold;cursor: pointer; display: inline-block; border-radius: 5px;background-color: #f06292;border-color: #f06292; border-style: solid; border-width: 8px 16px;'>";
            html += "Reset Password</a></td></tr><tr>";
            html += "<td class='content-block' style='font-family:Helvetica Neue,Helvetica,Arial,sans-serif;font-size:14px;padding: 0 0 20px;'>";
            html += "<p>Support Team</p></td></tr><tr>";
            html += "<td style='text-align:center;font-family:Helvetica Neue,Helvetica,Arial,sans-serif;font-size:14px;'>&copy; ABC Discounts";
            html += "</td></tr></tbody></table></td></tr></tbody></table></div></td></tr></tbody></table>";
            return html;
        }


        private string ConvertHtmlToStringOrdermail(string url)
        {
            string html = string.Empty;
            var f1 = "OrderAmount";
            var date = "OrderDate";
            //var price=""
            html += "<div style='margin:0px!important;padding:0px!important;box-sizing:border-box'>";
            html += "<div style='display:none;font-size:1px;color:rgb(254,254,254);line-height:1px;font-family:Helvetica,Arial,sans-serif;max-height:0px;max-width:0px;opacity:0;overflow:hidden;box-sizing:border-box'>";
            html += "" + f1 + "";
            html += "</div>";
            html += "<span id='m_7273872973732431438x_j_id0:emailTemplate:j_id7:j_id8:j_id11:j_id12:j_id19' style='box-sizing:border-box'>";
            html += "<table border='0' cellpadding='0' cellspacing='0' style='box-sizing:border-box;border:none;border-collapse:collapse;empty-cells:show;max-width:100%' width='100%'>";
            html += "<tbody style='box-sizing:border-box'>";
            html += "<tr style='box-sizing:border-box'>";
            html += "<td align='center' bgcolor='#ededed' style='box-sizing:border-box;min-width:5px;border:none'>";
            html += "<table border='0' cellpadding='0' cellspacing='0' style='max-width:500px;box-sizing:border-box;border:none;border-collapse:collapse;empty-cells:show' width='100%'>";
            html += "<tbody style='box-sizing:border-box'>";
            html += "<tr style='box-sizing:border-box'>";
            html += "<td height='15' style='font-size:15px;line-height:15px;box-sizing:border-box;min-width:5px;border:0px solid rgb(221,221,221)'>";
            html += "</td>";
            html += "</tr>";
            html += "<tr style='box-sizing:border-box'>";
            html += "<td align='center' bgcolor='#ededed' style='padding:20px 0px 0px;border-top-right-radius:15px;border-top-left-radius:15px;background:rgb(237,237,237);box-sizing:border-box;min-width:5px;border:none' valign='top'>";
            html += "<a href='' style='text-decoration:none;box-sizing:border-box;color:rgb(0,102,147)'>";
            html += "<img src='/images/ABC-Logo-removebg-preview.png' style='height:10rem;'>";
            html += "</a>";
            html += "</td>";
            html += "</tr>";
            html += "<tr style='box-sizing:border-box'>";
            html += "<td height='20' style='font-size:20px;line-height:20px;box-sizing:border-box;min-width:5px;border:0px solid rgb(221,221,221)'>";
            html += "</td>";
            html += "</tr>";
            html += "</tbody>";
            html += "</table>";
            html += "</td>";
            html += "</tr>";
            html += "<tr style='box-sizing:border-box'>";
            html += "<td align='center' bgcolor='#ededed' style='padding:0px;box-sizing:border-box;min-width:5px;border:none'>";
            html += "<table border='0' cellpadding='0' cellspacing='0' style='max-width:500px;box-sizing:border-box;border:none;border-collapse:collapse;empty-cells:show' width='100%'>";
            html += "<tbody style='box-sizing:border-box'>";
            html += "<tr style='box-sizing:border-box'>";
            html += "<td bgcolor='#ffffff' style='border-top-right-radius:15px;border-top-left-radius:15px;box-sizing:border-box;min-width:5px;border:none'>";
            html += "<table border='0' cellpadding='0' cellspacing='0' style='box-sizing:border-box;border:none;border-collapse:collapse;empty-cells:show;max-width:100%' width='100%'>";
            html += "<tbody style='box-sizing:border-box'>";
            html += "<tr style='box-sizing:border-box'>";
            html += "<td style='box-sizing:border-box;min-width:5px;border:0px solid rgb(221,221,221)'>";
            html += "<table border='0' cellpadding='0' cellspacing='0' style='box-sizing:border-box;border:none;border-collapse:collapse;empty-cells:show;max-width:100%' width='100%'>";
            html += "<tbody style='box-sizing:border-box'>";
            html += "<tr style='box-sizing:border-box'>";
            html += "<td height='30' style='font-size:15px;line-height:15px;border-top-right-radius:15px;border-top-left-radius:15px;box-sizing:border-box;min-width:5px;border:none'>";
            html += "</td>";
            html += "</tr>";
            html += "<tr style='box-sizing:border-box'>";
            html += "<td align='center' style='font-size:36px;font-family:Helvetica,Arial,sans-serif;color:rgb(51,51,51);box-sizing:border-box;min-width:5px;border:none'>";
            html += "Order Confirmation";
            html += "</td>";
            html += "</tr>";
            html += "<tr style='box-sizing:border-box'>";
            html += "<td height='20' style='font-size:20px;line-height:20px;box-sizing:border-box;min-width:5px;border:0px solid rgb(221,221,221)'>";
            html += "</td>";
            html += "</tr>";
            html += "<tr style='box-sizing:border-box'>";
            html += "<td align='left' style='padding:0px 20px;font-size:18px;line-height:25px;font-family:Helvetica,Arial,sans-serif;color:rgb(80,80,80);box-sizing:border-box;min-width:5px;border:none'>";
            html += "Hello Dear Customer";
            html += ",";
            html += "<br style='box-sizing:border-box'>";
            html += "<br style='box-sizing:border-box'>";
            html += "<br style='box-sizing:border-box'>";
            html += "Thank you for placing your order with ABC Discounts. Your order and payment details are indicated below. If you would like to view additional details of your order, please visit order history.";
            html += "</td>";
            html += "</tr>";
            html += "<tr style='box-sizing:border-box'>";
            html += "<td height='40' style='font-size:20px;line-height:20px;box-sizing:border-box;min-width:5px;border:0px solid rgb(221,221,221)'>&nbsp;</td>";
            html += "</tr>";
            html += "<tr style='box-sizing:border-box'>";
            html += "<td align='center' style='padding:0px 20px;font-size:28px;font-family:Helvetica,Arial,sans-serif;color:rgb(51,51,51);box-sizing:border-box;min-width:5px;border:none'>";
            html += "Your Order";
            html += "</td>";
            html += "</tr>";
            html += "<tr style='box-sizing:border-box'>";
            html += "<td height='20' style='font-size:20px;line-height:20px;box-sizing:border-box;min-width:5px;border:0px solid rgb(221,221,221)'>";
            html += "</td>";
            html += "</tr>";
            html += "</tbody>";
            html += "</table>";
            html += "</td>";
            html += "</tr>";
            html += "</tbody>";
            html += "</table>";
            html += "</td>";
            html += "</tr>";
            html += "</tbody>";
            html += "</table>";
            html += "</td>";
            html += "</tr>";
            html += "<tr style='box-sizing:border-box'>";
            html += "<td align='center' bgcolor='#ededed' style='padding:0px;box-sizing:border-box;min-width:5px;border:none'>";
            html += "<table border='0' cellpadding='0' cellspacing='0' style='max-width:500px;box-sizing:border-box;border:none;border-collapse:collapse;empty-cells:show' width='100'>";
            html += "<tbody style='box-sizing:border-box'>";
            html += "<tr style='box-sizing:border-box'>";
            html += "<td bgcolor='#ffffff' style='box-sizing:border-box;min-width:5px;border:0px solid rgb(221,221,221)'>";
            html += "<table border='0' cellpadding='0' cellspacing='0' style='box-sizing:border-box;border:none;border-collapse:collapse;empty-cells:show;max-width:100%' width='100%'>";
            html += "<tbody style='box-sizing:border-box'>";
            html += "<tr style='box-sizing:border-box'>";
            html += "<td style='box-sizing:border-box;min-width:5px;border:0px solid rgb(221,221,221)'>";
            html += "<table border='0' cellpadding='0' cellspacing='0' style='box-sizing:border-box;border:none;border-collapse:collapse;empty-cells:show;max-width:100%' width='100%'>";
            html += "<tbody style='box-sizing:border-box'>";
            html += "<tr style='box-sizing:border-box'>";
            html += "<td align='left' style='padding:0px 20px;font-size:18px;line-height:25px;font-family:Helvetica,Arial,sans-serif;color:rgb(80,80,80);box-sizing:border-box;min-width:5px;border:none'>";
            html += "Order Date: 04/12/2022";
            html += "<br style='box-sizing:border-box'>Transaction ID: 2192895899";
            html += "<br style='box-sizing:border-box'>Web Order ID: O-0023682354";
            html += "<br style='box-sizing:border-box'>";
            html += "<br style='box-sizing:border-box'>";
            html += "<br style='box-sizing:border-box'>";
            html += "</td>";
            html += "</tr>";
            html += "</tbody>";
            html += "</table>";
            html += "</td>";
            html += "</tr>";
            html += "<tr style='box-sizing:border-box'>";
            html += "<td height='20' style='font-size:20px;line-height:20px;box-sizing:border-box;min-width:5px;border:0px solid rgb(221,221,221)'>&nbsp;</td>";
            html += "</tr>";
            html += "</tbody>";
            html += "</table>";
            html += "</td>";
            html += "</tr>";
            html += "</tbody>";
            html += "</table>";
            html += "</td>";
            html += "</tr>";
            html += "<tr style='box-sizing:border-box'>";
            html += "<td align='center' bgcolor='#ededed' style='padding:0px;box-sizing:border-box;min-width:5px;border:none'>";
            html += "<table border='0' cellpadding='0' cellspacing='0' style='box-sizing:border-box;border:none;border-collapse:collapse;empty-cells:show;max-width:100%' width='500'>";
            html += "<thead style='box-sizing:border-box'>";
            html += "<tr style='box-sizing:border-box'>";
            html += "<th align='left' bgcolor='#ffffff' style='box-sizing:border-box;background:rgb(236,236,236);border:0px solid rgb(221,221,221)' valign='top'' width=''50%''>";
            html += "<table cellpadding='0' cellspacing='0' style='box-sizing:border-box;border:none;border-collapse:collapse;empty-cells:show;max-width:100%'>";
            html += "<tbody style='box-sizing:border-box'>";
            html += "<tr style='box-sizing:border-box'>";
            html += "<td align='center' style='box-sizing:border-box;min-width:5px;border:none' width='500'>";
            html += "<table cellpadding='0' cellspacing='0' style='box-sizing:border-box;border:none;border-collapse:collapse;empty-cells:show;max-width:100%'>";
            html += "<tbody style='box-sizing:border-box'>";
            html += "<tr style='box-sizing:border-box'>";
            html += "<td height='10' style='font-size:10px;line-height:10px;box-sizing:border-box;min-width:5px;border:0px solid rgb(221,221,221)'>";
            html += "<table align='center' border='0' cellpadding='0' cellspacing='0' style='box-sizing:border-box;border:none;border-collapse:collapse;empty-cells:show;max-width:100%' width='500'>";
            html += "<tbody style='box-sizing:border-box'>";
            html += "<tr style='box-sizing:border-box'>";
            html += "<td align='left' style='padding:0px 20px;font-size:22px;line-height:26px;font-family:Arial,sans-serif;font-weight:normal;color:rgb(51,51,51);width:250px;box-sizing:border-box;min-width:5px;border:1px solid rgb(221,221,221)'>";
            html += "Delivery Date:";
            html += "</td>";
            html += "<td align='left' style='padding:0px 20px;font-size:22px;line-height:26px;font-family:Arial,sans-serif;font-weight:normal;color:rgb(51,51,51);width:250px;box-sizing:border-box;min-width:5px;border:1px solid rgb(221,221,221)'>";
            html += "div style='text-align:left;box-sizing:border-box'>Payment Details</div>";
            html += "</td>";
            html += "</tr>";
            html += "<tr style='box-sizing:border-box'>";
            html += "<td height='5' style='font-size:5px;line-height:5px;box-sizing:border-box;min-width:5px;border:0px solid rgb(221,221,221)'>&nbsp;</td>";
            html += "</tr>";
            html += "<tr style='box-sizing:border-box'>";
            html += "<td align='left' style='padding:0px 20px;font-size:18px;line-height:24px;font-family:Arial,sans-serif;font-weight:bold;color:rgb(255,0,0);box-sizing:border-box;min-width:5px;border:1px solid rgb(221,221,221)'>";
            html += ""+date+ "";
            html += "</td>";
            html += "<td align='left' style='padding:0px 20px;font-size:18px;line-height:24px;font-family:Arial,sans-serif;font-weight:normal;color:rgb(80,80,80);box-sizing:border-box;min-width:5px;border:1px solid rgb(221,221,221)'>";
            html += "<div style='text-align:left;box-sizing:border-box'>";
            html += "Payment on Delivery";
            html += "</div>";
            html += "</td>";
            html += "</tr>";
            html += "</tbody>";
            html += "</table>";
            html += "</td>";
            html += "</tr>";
            html += "</tbody>";
            html += "</table>";
            html += "</td>";
            html += "</tr>";
            html += "</tbody>";
            html += "</table>";
            html += "</th>";
            html += "</tr>";
            html += "</thead>";
            html += "</table>";
            html += "</td>";
            html += "</tr>";
            html += "<tr style='box-sizing:border-box'>";
            html += "<td align='center' bgcolor='#ededed' style='padding:0px;box-sizing:border-box;min-width:5px;border:none'>";
            html += "<table border='0' cellpadding='0' cellspacing='0' style='max-width:500px;box-sizing:border-box;border:none;border-collapse:collapse;empty-cells:show' width='100%'>";
            html += "<tbody style='box-sizing:border-box'>";
            html += "<tr style='box-sizing:border-box'>";
            html += "<td bgcolor='#ffffff' style='box-sizing:border-box;min-width:5px;border:0px solid rgb(221,221,221)'>";
            html += "<table border='0' cellpadding='0' cellspacing='0' style='box-sizing:border-box;border:none;border-collapse:collapse;empty-cells:show;max-width:100%' width='100%'>";
            html += "<tbody style='box-sizing:border-box'>";
            html += "<tr style='box-sizing:border-box'>";
            html += "<td style='box-sizing:border-box;min-width:5px;border:0px solid rgb(221,221,221)'>";
            html += "<table border='0' cellpadding='0' cellspacing='0' style='box-sizing:border-box;border:none;border-collapse:collapse;empty-cells:show;max-width:100%' width='100%'>";
            html += "<tbody style='box-sizing:border-box'>";
            html += "<tr style='box-sizing:border-box'>";
            html += "<td height='20' style='font-size:5px;line-height:5px;box-sizing:border-box;min-width:5px;border:0px solid rgb(221,221,221)'>&nbsp;</td>";
            html += "</tr>";
            html += "<tr style='box-sizing:border-box'>";
            html += "<td align='left' style='padding:0px 20px;font-size:22px;line-height:26px;font-family:Arial,sans-serif;font-weight:normal;color:rgb(51,51,51);box-sizing:border-box;min-width:5px;border:none'>";
            html += "Delivery Address:";
            html += "</td>";
            html += "</tr>";
            html += "<tr style='box-sizing:border-box'>";
            html += "<td height='5' style='font-size:5px;line-height:5px;box-sizing:border-box;min-width:5px;border:0px solid rgb(221,221,221)'>&nbsp;</td>";
            html += "</tr>";
            html += "<tr style='box-sizing:border-box'>";
            html += "<td align='left' style='padding:0px 20px;font-size:18px;line-height:25px;font-family:Helvetica,Arial,sans-serif;color:rgb(80,80,80);box-sizing:border-box;min-width:5px;border:1px solid rgb(221,221,221)'>";
            html += "<span id='' style='box-sizing:border-box'>";
            html += "ABC DISCOUNTS";
            html += "<br style='box-sizing:border-box'>";
            html += "</span>";
            html += "<br style='box-sizing:border-box'>ACCOUNT/OUTLET #&nbsp;0602404682";
            html += "<br style='box-sizing:border-box'>1055 GATEWOOD AVE";
            html += "<br style='box-sizing:border-box'>GREENSBORO 27405-7201";
            html += "</td>";
            html += "</tr>";
            html += "<tr style='box-sizing:border-box'>";
            html += "<td height='60' style='font-size:10px;line-height:10px;box-sizing:border-box;min-width:5px;border:0px solid rgb(221,221,221)'>&nbsp;</td>";
            html += "</tr>";
            html += "<tr style='box-sizing:border-box'>";
            html += "<td align='center' style='font-size:28px;font-family:Helvetica,Arial,sans-serif;color:rgb(51,51,51);box-sizing:border-box;min-width:5px;border:none'>Order Details</td>";
            html += "</tr>";
            html += "<tr style='box-sizing:border-box'><td height='20' style='font-size:20px;line-height:20px;box-sizing:border-box;min-width:5px;border:0px solid rgb(221,221,221)'>&nbsp;</td></tr>";
            html += "</tbody>";
            html += "</table>";
            html += "</td>";
            html += "</tr>";
            html += "</tbody>";
            html += "</table>";
            html += "</td>";
            html += "</tr>";
            html += "</tbody>";
            html += "</table>";
            html += "</td>";
            html += "</tr>";
            html += "<tr style='box-sizing:border-box'>";
            html += "<td align='center' bgcolor='#ededed' style='padding:0px;box-sizing:border-box;min-width:5px;border:none'>";
            html += "<table border='0' cellpadding='0' cellspacing='0' style='max-width:500px;box-sizing:border-box;border:none;border-collapse:collapse;empty-cells:show' width='100%'>";
            html += "<tbody style='box-sizing:border-box'>";
            html += "<tr style='box-sizing:border-box'>";
            html += "<td bgcolor='#ffffff' style='box-sizing:border-box;min-width:5px;border:0px solid rgb(221,221,221)'>";
            html += "<table border='0' cellpadding='0' cellspacing='0' style='box-sizing:border-box;border:none;border-collapse:collapse;empty-cells:show;max-width:100%' width='100%'>";
            html += "<tbody style='box-sizing:border-box'>";
            html += "<tr style='box-sizing:border-box'>";
            html += "<td height='10' style='font-size:10px;line-height:10px;box-sizing:border-box;min-width:5px;border:0px solid rgb(221,221,221)' >";
            html += "<table align='center' border ='0' cellpadding ='0' cellspacing ='0' style ='width:92%;box-sizing:border-box;border:none;border-collapse:collapse;empty-cells:show;max-width:100%' width ='500'>";
            html += "<tbody style='box -sizing:border-box' >";
            html += "<tr style='box -sizing:border-box' > ";
            html += "<td bgcolor='#ededed' style = 'padding:5px 20px;font-size:18px;line-height:25px;font-family:Helvetica,Arial,sans-serif;color:rgb(51,51,51);box-sizing:border-box;min-width:5px;border:0px solid rgb(221,221,221)' > Product</td>";
            html += "<td bgcolor='#ededed' style='padding:5px 20px;font-size:18px;line-height:25px;font-family:Helvetica,Arial,sans-serif;color:rgb(51,51,51);box-sizing:border-box;min-width:5px;border:0px solid rgb(221,221,221)'>";
            html += "<br style='box -sizing:border-box' > ";
            html += "</td>";
            html += "<td bgcolor='#ededed' style ='padding:5px 20px;font-size:18px;line-height:25px;font-family:Helvetica,Arial,sans-serif;color:rgb(51,51,51);width:20%;box-sizing:border-box;min-width:5px;border:0px solid rgb(221,221,221)' > ";
            html += "<div style='text -align:center;box-sizing:border-box' > Quantity</div>";
            html += "</td>";
            html += "<td bgcolor='#ededed' style ='padding:5px 20px;font-size:18px;line-height:25px;font-family:Helvetica,Arial,sans-serif;color:rgb(51,51,51);width:20%;box-sizing:border-box;min-width:5px;border:0px solid rgb(221,221,221)' > ";
            html += "<div style='text-align:center;box-sizing:border-box' > Price</div>";
            html += "</td>";
            html += "</tr>";
            html += "<tr style='box -sizing:border-box' ><td style='box -sizing:border-box;min-width:5px;border:0px solid rgb(221,221,221)' > &nbsp;</td><td style='box -sizing:border-box;min-width:5px;border:0px solid rgb(221,221,221)' > &nbsp;</td><td style='box -sizing:border-box;min-width:5px;border:0px solid rgb(221,221,221)' > &nbsp;</td></tr>";
            html += "<tr style='box -sizing:border-box'>";
            html += "<td style='padding:0px 20px 10px;font-size:18px;line-height:24px;font-family:Helvetica,Arial,sans-serif;color:rgb(80,80,80);box-sizing:border-box;min-width:5px;border:0px solid rgb(221,221,221)' > 125522 Coca-Cola Zero Sugar Cherry Bottles, 20 fl oz, 24 Pack</td>";
            html += "<td style='padding:0px 20px 10px;font-size:18px;line-height:24px;font-family:Helvetica,Arial,sans-serif;color:rgb(80,80,80);box-sizing:border-box;min-width:5px;border:0px solid rgb(221,221,221)' ><br style='box -sizing:border-box'></td>";
            html += "<td style='padding:0px 20px 10px;font-size:18px;line-height:24px;font-family:Helvetica,Arial,sans-serif;color:rgb(80,80,80);box-sizing:border-box;min-width:5px;border:0px solid rgb(221,221,221)'><div style='text -align:center;box-sizing:border-box'>3</div></td>";
            html += "<td style='padding:0px 20px 5px;font-size:18px;line-height:25px;font-family:Helvetica,Arial,sans-serif;color:rgb(80,80,80);text-align:right;vertical-align:top;box-sizing:border-box;min-width:5px;border:0px solid rgb(221,221,221)' > ";
            html += "<div style='box -sizing:border-box'>$64.80</div>";
            html += "<div style='font -size:12px;line-height:24px;color:rgb(244,0,0);white-space:nowrap;box-sizing:border-box'>You Saved: $74.16</div>";
            html += "</td>";
            html += "</tr>";
            html += "</tbody>";
            html += "</table>";
            html += "</td>";
            html += "</tr>";
            html += "<tr style='box -sizing:border-box' > ";
            html += "<td height='20' style ='font -size:20px;line-height:20px;box-sizing:border-box;min-width:5px;border:0px solid rgb(221,221,221)' > ";
            html += "<span style='box -sizing:border-box' > &nbsp;</span>";
            html += "<table align='center' border ='0' cellpadding='0' cellspacing ='0' style ='width:92%;box-sizing:border-box;border:none;border-collapse:collapse;empty-cells:show;max-width:100%' width = '500' > ";
            html += "<tbody style='box -sizing:border-box' > ";
            html += "<tr style='box -sizing:border-box'>";
            html += "<td style='padding:10px 20px 5px;font-size:18px;line-height:25px;font-family:Helvetica,Arial,sans-serif;color:rgb(80,80,80);width:15%;border-width:2px 0px 0px;border-color:rgb(218,218,218) rgb(221,221,221) rgb(221,221,221);border-style:solid;box-sizing:border-box;min-width:5px' > &nbsp;</td>";
            html += "<td style='padding:10px 20px 5px;font-size:18px;line-height:25px;font-family:Helvetica,Arial,sans-serif;color:rgb(80,80,80);width:60%;text-align:right;border-width:2px 0px 0px;border-color:rgb(218,218,218) rgb(221,221,221) rgb(221,221,221);border-style:solid;box-sizing:border-box;min-width:5px'>Subtotal:</td>";
            html += "<td style='padding:10px 20px 5px;font-size:18px;line-height:25px;font-family:Helvetica,Arial,sans-serif;color:rgb(80,80,80);width:25%;border-width:2px 0px 0px;border-color:rgb(218,218,218) rgb(221,221,221) rgb(221,221,221);border-style:solid;box-sizing:border-box;min-width:5px' > ";
            html += "<div style='text -align:right;box-sizing:border-box'>$64.80</div>";
            html += "</td>";
            html += "</tr>";
            html += "<tr style='box -sizing:border-box'>";
            html += "<td style='padding:5px 20px;font-size:18px;line-height:25px;font-family:Helvetica,Arial,sans-serif;color:rgb(80,80,80);width:15%;box-sizing:border-box;min-width:5px;border:0px solid rgb(221,221,221)' > &nbsp;</td>";
            html += "<td style='padding:5px 20px;font-size:18px;line-height:25px;font-family:Helvetica,Arial,sans-serif;color:rgb(80,80,80);width:60%;text-align:right;box-sizing:border-box;min-width:5px;border:0px solid rgb(221,221,221)'>Min. Order Charge:</td>";
            html += "<td style='padding:5px 20px;font-size:18px;line-height:25px;font-family:Helvetica,Arial,sans-serif;color:rgb(80,80,80);width:25%;box-sizing:border-box;min-width:5px;border:0px solid rgb(221,221,221)'>";
            html += "<div style='text -align:right;box-sizing:border-box' >$0.00</div>";
            html += "</td>";
            html += "</tr>";
            html += "<tr style='box -sizing:border-box' > ";
            html += "<td style='padding:5px 20px;font-size:18px;line-height:25px;font-family:Helvetica,Arial,sans-serif;color:rgb(80,80,80);width:15%;box-sizing:border-box;min-width:5px;border:0px solid rgb(221,221,221)' > &nbsp;</td>";
            html += "<td style='padding:5px 20px;font-size:18px;line-height:25px;font-family:Helvetica,Arial,sans-serif;color:rgb(80,80,80);width:60%;text-align:right;box-sizing:border-box;min-width:5px;border:0px solid rgb(221,221,221)' > Delivery Charge:</td>";
            html += "<td style='padding:5px 20px;font-size:18px;line-height:25px;font-family:Helvetica,Arial,sans-serif;color:rgb(80,80,80);width:25%;box-sizing:border-box;min-width:5px;border:0px solid rgb(221,221,221)' > ";
            html += "<div style='text-align:right;box-sizing:border-box' >$0.00</div>";
            html += "</td>";
            html += "</tr>";
            html += "<tr style='box -sizing:border-box' > ";
            html += "<td style=padding:5px 20px;font-size:18px;line-height:25px;font-family:Helvetica,Arial,sans-serif;color:rgb(80,80,80);width:15%;box-sizing:border-box;min-width:5px;border:0px solid rgb(221,221,221)'>&nbsp;</td>";
            html += "<td style='padding:5px 20px;font-size:18px;line-height:25px;font-family:Helvetica,Arial,sans-serif;color:rgb(80,80,80);width:60%;text-align:right;box-sizing:border-box;min-width:5px;border:0px solid rgb(221,221,221)'>Tax / Deposits:</td>";
            html += "<td style='padding:5px 20px;font-size:18px;line-height:25px;font-family:Helvetica,Arial,sans-serif;color:rgb(80,80,80);width:25%;box-sizing:border-box;min-width:5px;border:0px solid rgb(221,221,221)'>";
            html += "<div style='text-align:right;box-sizing:border-box'>$0.00</div>";
            html += "</td>";
            html += "</tr>";
            html += "<tr style='box-sizing:border-box'>";
            html += "<td style='padding:5px 20px;font-size:18px;line-height:25px;font-family:Helvetica,Arial,sans-serif;color:rgb(80,80,80);width:15%;box-sizing:border-box;min-width:5px;border:0px solid rgb(221,221,221)'>&nbsp;</td>";
            html += "<td bgcolor='#ededed' style='padding:5px 20px;font-size:18px;line-height:25px;font-family:Helvetica,Arial,sans-serif;color:rgb(80,80,80);width:60%;text-align:right;box-sizing:border-box;min-width:5px;border:0px solid rgb(221,221,221)'>";
            html += "<strong style='box-sizing:border-box;font-weight:700'>Order Total:</strong>";
            html += "</td>";
            html += "<td bgcolor='#ededed' style='padding:5px 20px;font-size:18px;line-height:25px;font-family:Helvetica,Arial,sans-serif;color:rgb(80,80,80);width:25%;box-sizing:border-box;min-width:5px;border:0px solid rgb(221,221,221)'>";
            html += "<div style='text-align:right;box-sizing:border-box'>";
            html += "<strong style='box-sizing:border-box;font-weight:700'>$64.80</strong>";
            html += "</div>";
            html += "</td>";
            html += "</tr>";
            html += "<tr style='box-sizing:border-box'>";
            html += "<td style='padding:10px 20px 5px;font-size:18px;line-height:25px;font-family:Helvetica,Arial,sans-serif;color:rgb(80,80,80);width:15%;box-sizing:border-box;min-width:5px;border:0px solid rgb(221,221,221)'>&nbsp;</td>";
            html += "<td style='padding:10px 20px 5px;font-size:18px;line-height:25px;font-family:Helvetica,Arial,sans-serif;color:rgb(80,80,80);width:60%;text-align:right;box-sizing:border-box;min-width:5px;border:0px solid rgb(221,221,221)'>Total Saved:</td>";
            html += "<td style='padding:10px 20px 5px;font-size:18px;line-height:25px;font-family:Helvetica,Arial,sans-serif;color:rgb(80,80,80);width:25%;box-sizing:border-box;min-width:5px;border:0px solid rgb(221,221,221)'>";
            html += "<div style='text-align:right;color:rgb(244,0,0);box-sizing:border-box'>$74.16</div>";
            html += "</td>";
            html += "</tr>";
            html += "</tbody>";
            html += "</table>";
            html += "</td>";
            html += "</tr>";
            html += "<tr style='box-sizing:border-box'>";
            html += "<td height='40' style='font-size:40px;line-height:40px;box-sizing:border-box;min-width:5px;border:0px solid rgb(221,221,221)'>&nbsp;</td>";
            html += "</tr>";
            html += "<tr style='box-sizing:border-box'><td style='padding:0px 20px;font-size:12px;line-height:16px;font-family:Helvetica,Arial,sans-serif;color:rgb(80,80,80);box-sizing:border-box;min-width:5px;border:0px solid rgb(221,221,221)'>*Final amount will be determined at delivery</td></tr>";
            html += "</tbody>";
            html += "</table>";
            html += "</td>";
            html += "</tr>";
            html += "</tbody>";
            html += "</table>";
            html += "</td>";
            html += "</tr>";
            html += "<tr style='box-sizing:border-box'>";
            html += "<td align='center' bgcolor='#ededed' style='box-sizing:border-box;min-width:5px;border:0px solid rgb(221,221,221)'>";
            html += "<table align='center' bgcolor='#424242' border='0' cellspacing='0' style='max-width:500px;padding:0px 10px;box-sizing:border-box;border:none;border-collapse:collapse;empty-cells:show' width='100%'>";
            html += "<tbody style='box-sizing:border-box'>";
            html += "<tr style='box-sizing:border-box'>";
            html += "<td bgcolor='#424242' height='10' style='font-size:10px;line-height:10px;box-sizing:border-box;min-width:5px;border:0px solid rgb(221,221,221)'>&nbsp;</td>";
            html += "</tr>";
            html += "<tr style='box-sizing:border-box'>";
            html += "<td align='center' bgcolor='#424242' style='padding:0px 5%;font-size:18px;line-height:25px;font-family:Helvetica,Arial,sans-serif;color:rgb(255,255,255);background:rgb(66,66,66);box-sizing:border-box;min-width:5px;border:none'>";
            html += "Questions? Chat with the ABC Discounts Support Team online or call us at";
            html += "<a style='color:rgb(255,255,255);text-decoration:none;box-sizing:border-box' rel='noopener noreferrer'>&nbsp;800-438-0686</a> from 8AM-6PM (ET).";
            html += "</td>";
            html += "</tr>";
            html += "<tr style='box-sizing:border-box'>";
            html += "<td bgcolor='#424242' height='10' style='font-size:10px;line-height:10px;border-bottom-right-radius:15px;border-bottom-left-radius:15px;box-sizing:border-box;min-width:5px;border:none'>&nbsp;</td>";
            html += "</tr>";
            html += "</tbody>";
            html += "</table>";
            html += "</td>";
            html += "</tr>";
            html += "<tr style='box-sizing:border-box'>";
            html += "<td align='center' bgcolor='#ededed' style='box-sizing:border-box;min-width:5px;border:0px solid rgb(221,221,221)'>";
            html += "<table border='0' cellpadding='0' cellspacing='0' style='max-width:500px;box-sizing:border-box;border:none;border-collapse:collapse;empty-cells:show' width='100%'>";
            html += "<tbody style='box-sizing:border-box'>";
            html += "<tr style='box-sizing:border-box'>";
            html += "<td align='center' style='background-color:rgb(220,220,220);padding:20px;border-bottom-right-radius:15px;border-bottom-left-radius:15px;box-sizing:border-box;min-width:5px;border:1px solid rgb(221,221,221)'>";
            html += "<table align='center' border='0' cellpadding='0' cellspacing='0' style='max-width:500px;box-sizing:border-box;border:none;border-collapse:collapse;empty-cells:show' width='100%'>";
            html += "<tbody style='box-sizing:border-box'>";
            html += "<tr style='box-sizing:border-box'>";
            html += "<td align='left' style='font-size:15px;line-height:18px;font-weight:bold;font-family:Arial,Helvetica,Montserrat,sans-serif;color:rgb(244,0,0)!important;text-decoration:none!important;box-sizing:border-box;min-width:5px;border:1px solid rgb(221,221,221)' valign='middle'>";
            html += "<a href='' shape='rect' style='color:rgb(244,0,0);text-decoration:none;box-sizing:border-box>";
            html += "TERMS &amp; CONDITIONS&nbsp;";
            html += "</a>";
            html += "<br style='box-sizing:border-box'>";
            html += "<br style='box-sizing:border-box'>";
            html += "<a href='' shape='rect' style='color:rgb(244,0,0);text-decoration:none;box-sizing:border-box'>PRIVACY POLICY</a>";
            html += "</td>";
            html += "<td align='center' style='font-size:12px;line-height:18px;font-family:Arial,Helvetica,Montserrat,sans-serif;color:rgb(102,102,102);box-sizing:border-box;min-width:5px;border:0px solid rgb(221,221,221)' valign='middle'>";
            html += "<img src='/images/ABC-Logo-removebg-preview.png' style='height:10rem;' />";
            html += "</td>";
            html += "</tr>";
            html += "</tbody>";
            html += "</table>";
            html += "</td>";
            html += "</tr>";
            html += "</tbody>";
            html += "</table>";
            html += "<div style='box-sizing:border-box'>";
            html += "<p style='padding:0px 0px 0px 20px;font-size:11px;font-weight:300;line-height:15px;margin-top:1px;margin-right:0px!important;margin-bottom:0px!important;margin-left:0px!important;box-sizing:border-box;color:rgb(68,68,68)'>© 2022 ABC Discounts, all rights reserved.</p>";
            html += "</div>";
            html += "</td>";
            html += "</tr>";
            html += "<tr style='box-sizing:border-box'>";
            html += "<td align='center' bgcolor='#ededed' style='padding:10px 0px;background:rgb(237,237,237);box-sizing:border-box;min-width:5px;border:0px solid rgb(221,221,221)'>";
            html += "<table align='center' border='0' cellpadding='0' cellspacing='0' style='max-width:500px;box-sizing:border-box;border:none;border-collapse:collapse;empty-cells:show' width='100%'>";
            html += "<tbody style='box-sizing:border-box'>";
            html += "<tr style='box-sizing:border-box'>";
            html += "</tr>";
            html += "</tbody>";
            html += "</table>";
            html += "</td>";
            html += "</tr>";
            html += "</tbody>";
            html += "</table>";
            html += "</span>";
            html += "</div>";    
                    return html;

        }
    }
}
