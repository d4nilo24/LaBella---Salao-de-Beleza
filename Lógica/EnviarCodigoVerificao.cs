using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Net.Mail;
using System.Net;

namespace prjTCC.Lógica
{
    public class EnviarCodigoVerificao
    {
        private string codigo = null;
        string CodigoAleatorio (int quantidade)
        {
            const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%()_+-=[]{}|"; // Add more characters as needed
            StringBuilder randomString = new StringBuilder();

            Random random = new Random();

            for (int i = 0; i < quantidade; i++)
            {
                int index = random.Next(chars.Length);
                randomString.Append(chars[index]);
            }

            return randomString.ToString();
        }
        public void EnviaCodigo (string emailDestinatario, string link)
        {
            VerificarExistenciaToken verificarToken = new VerificarExistenciaToken();
            do
            {
                Random quantidadeAleatoria = new Random();
                string codigoVerificao = CodigoAleatorio(quantidadeAleatoria.Next(15, 30));
                codigo = codigoVerificao;
            } while (verificarToken.VerificarExistencia(codigo));

            #region Declaração de Variáveis
            string remetente = "";
            string senha = "";
            string destinatario = "";
            string assunto = "";
            string texto = @"<!doctype html><html xmlns='http://www.w3.org/1999/xhtml' xmlns:v='urn:schemas-microsoft-com:vml' xmlns:o='urn:schemas-microsoft-com:office:office'><head><title></title><!--[if !mso]><!--><meta http-equiv='X-UA-Compatible' content='IE=edge'><!--<![endif]--><meta http-equiv='Content-Type' content='text/html; charset=UTF-8'><meta name='viewport' content='width=device-width,initial-scale=1'><style type='text/css'>#outlook a { padding:0; }
          body { margin:0;padding:0;-webkit-text-size-adjust:100%;-ms-text-size-adjust:100%; }
          table, td { border-collapse:collapse;mso-table-lspace:0pt;mso-table-rspace:0pt; }
          img { border:0;height:auto;line-height:100%; outline:none;text-decoration:none;-ms-interpolation-mode:bicubic; }
          p { display:block;margin:13px 0; }</style><!--[if mso]>
        <noscript>
        <xml>
        <o:OfficeDocumentSettings>
          <o:AllowPNG/>
          <o:PixelsPerInch>96</o:PixelsPerInch>
        </o:OfficeDocumentSettings>
        </xml>
        </noscript>
        <![endif]--><!--[if lte mso 11]>
        <style type='text/css'>
          .mj-outlook-group-fix { width:100% !important; }
        </style>
        <![endif]--><!--[if !mso]><!--><link href='https://fonts.googleapis.com/css?family=Open+Sans:300,400,500,700' rel='stylesheet' type='text/css'><style type='text/css'>@import url(https://fonts.googleapis.com/css?family=Open+Sans:300,400,500,700);</style><!--<![endif]--><style type='text/css'>@media only screen and (min-width:480px) {
        .mj-column-per-100 { width:100% !important; max-width: 100%; }
.mj-column-per-33-333333333333336 { width:33.333333333333336% !important; max-width: 33.333333333333336%; }
      }</style><style media='screen and (min-width:480px)'>.moz-text-html .mj-column-per-100 { width:100% !important; max-width: 100%; }
.moz-text-html .mj-column-per-33-333333333333336 { width:33.333333333333336% !important; max-width: 33.333333333333336%; }</style><style type='text/css'>@media only screen and (max-width:480px) {
      table.mj-full-width-mobile { width: 100% !important; }
      td.mj-full-width-mobile { width: auto !important; }
    }</style></head><body style='word-spacing:normal;'><div><!--[if mso | IE]><table align='center' border='0' cellpadding='0' cellspacing='0' class='' style='width:10000px;' width='10000' ><tr><td style='line-height:0px;font-size:0px;mso-line-height-rule:exactly;'><![endif]--><div style='margin:0px auto;max-width:10000px;'><table align='center' border='0' cellpadding='0' cellspacing='0' role='presentation' style='width:100%;'><tbody><tr><td style='direction:ltr;font-size:0px;padding:20px 0;text-align:center;'><!--[if mso | IE]><table role='presentation' border='0' cellpadding='0' cellspacing='0'><tr><td class='' style='vertical-align:top;width:10000px;' ><![endif]--><div class='mj-column-per-100 mj-outlook-group-fix' style='font-size:0px;text-align:left;direction:ltr;display:inline-block;vertical-align:top;width:100%;'><table border='0' cellpadding='0' cellspacing='0' role='presentation' style='background-color:#b36684;vertical-align:top;' width='100%'><tbody><tr><td align='center' style='font-size:0px;padding:10px 25px;word-break:break-word;'><table border='0' cellpadding='0' cellspacing='0' role='presentation' style='border-collapse:collapse;border-spacing:0px;'><tbody><tr><td style='width:100px;'><img height='auto' src='https://uploaddeimagens.com.br/images/004/665/146/full/logotipo_branco.png?1700058367' style='border:0;display:block;outline:none;text-decoration:none;height:auto;width:100%;font-size:13px;' width='100'></td></tr></tbody></table></td></tr></tbody></table></div><!--[if mso | IE]></td></tr></table><![endif]--></td></tr></tbody></table></div><!--[if mso | IE]></td></tr></table><table align='center' border='0' cellpadding='0' cellspacing='0' class='' style='width:10000px;' width='10000' ><tr><td style='line-height:0px;font-size:0px;mso-line-height-rule:exactly;'><![endif]--><div style='margin:0px auto;max-width:10000px;'><table align='center' border='0' cellpadding='0' cellspacing='0' role='presentation' style='width:100%;'><tbody><tr><td style='direction:ltr;font-size:0px;padding:20px 0;text-align:center;'><!--[if mso | IE]><table role='presentation' border='0' cellpadding='0' cellspacing='0'><tr><td class='' style='vertical-align:top;width:10000px;' ><![endif]--><div class='mj-column-per-100 mj-outlook-group-fix' style='font-size:0px;text-align:left;direction:ltr;display:inline-block;vertical-align:top;width:100%;'><table border='0' cellpadding='0' cellspacing='0' role='presentation' style='vertical-align:top;' width='100%'><tbody><tr><td align='left' style='font-size:0px;padding:10px 25px;word-break:break-word;'><div style='font-family:Open sans;font-size:24px;font-weight:bold;line-height:1;text-align:left;color:#000000;'>Recuperação de senha</div></td></tr><tr><td align='left' style='font-size:0px;padding:10px 25px;word-break:break-word;'><div style='font-family:Open sans;font-size:16px;line-height:1;text-align:left;color:#000000;'>Link de verificação: "+"<a href='"+link+"?token="+codigo+ "'>Clique aqui para alterar sua senha.</a>"+ @"</div></td></tr></tbody></table></div><!--[if mso | IE]></td></tr></table><![endif]--></td></tr></tbody></table></div><!--[if mso | IE]></td></tr></table><table align='center' border='0' cellpadding='0' cellspacing='0' class='' style='width:10000px;' width='10000' bgcolor='#806E75' ><tr><td style='line-height:0px;font-size:0px;mso-line-height-rule:exactly;'><![endif]--><div style='background:#806E75;background-color:#806E75;margin:0px auto;max-width:10000px;'><table align='center' border='0' cellpadding='0' cellspacing='0' role='presentation' style='background:#806E75;background-color:#806E75;width:100%;'><tbody><tr><td style='direction:ltr;font-size:0px;padding:20px 0;text-align:center;'><!--[if mso | IE]><table role='presentation' border='0' cellpadding='0' cellspacing='0'><tr><td class='' style='vertical-align:top;width:3333.333333333334px;' ><![endif]--><div class='mj-column-per-33-333333333333336 mj-outlook-group-fix' style='font-size:0px;text-align:left;direction:ltr;display:inline-block;vertical-align:top;width:100%;'><table border='0' cellpadding='0' cellspacing='0' role='presentation' style='vertical-align:top;' width='100%'><tbody><tr><td align='left' style='font-size:0px;padding:10px 25px;word-break:break-word;'><div style='font-family:Open sans;font-size:16px;line-height:1;text-align:left;color:#ffffff;'>Av. Epitácio Pessoa, 466, Santos-SP</div></td></tr></tbody></table></div><!--[if mso | IE]></td><td class='' style='vertical-align:top;width:3333.333333333334px;' ><![endif]--><div class='mj-column-per-33-333333333333336 mj-outlook-group-fix' style='font-size:0px;text-align:left;direction:ltr;display:inline-block;vertical-align:top;width:100%;'><table border='0' cellpadding='0' cellspacing='0' role='presentation' style='vertical-align:top;' width='100%'><tbody><tr><td align='left' style='font-size:0px;padding:10px 25px;word-break:break-word;'><div style='font-family:Open sans;font-size:16px;line-height:1;text-align:left;color:#ffffff;'>De terça a sábado das 9 às 18</div></td></tr></tbody></table></div><!--[if mso | IE]></td><td class='' style='vertical-align:top;width:3333.333333333334px;' ><![endif]--><div class='mj-column-per-33-333333333333336 mj-outlook-group-fix' style='font-size:0px;text-align:left;direction:ltr;display:inline-block;vertical-align:top;width:100%;'><table border='0' cellpadding='0' cellspacing='0' role='presentation' style='vertical-align:top;' width='100%'><tbody><tr><td align='left' style='font-size:0px;padding:10px 25px;word-break:break-word;'><div style='font-family:Open sans;font-size:16px;line-height:1;text-align:left;color:#ffffff;'>(13) 99009-9625</div></td></tr></tbody></table></div><!--[if mso | IE]></td></tr></table><![endif]--></td></tr></tbody></table></div><!--[if mso | IE]></td></tr></table><![endif]--></div></body></html>
";
            #endregion

            #region Atribuição dos Valores
            remetente = "contato.la.bella@outlook.com";
            senha = "tcclabella3n";
            destinatario = emailDestinatario;
            assunto = "Recuperação de senha";
            #endregion

            #region Configurações do Remetente
            SmtpClient client = new SmtpClient();
            client.Credentials = new NetworkCredential(remetente, senha);
            client.Host = "smtp.office365.com";
            client.Port = 587;
            client.EnableSsl = true;
            #endregion

            #region Configuração do Email
            MailMessage mail = new MailMessage();

            try
            {
                mail.To.Add(destinatario);
            }
            catch
            {
                throw new Exception("Não foi possível adicionar o email como destinatário.");
            }

            mail.From = new MailAddress(remetente, "contato.la.bella@outlook.com", System.Text.Encoding.UTF8);
            mail.Subject = assunto;
            mail.SubjectEncoding = System.Text.Encoding.UTF8;
            //mail.Body = "<html><body>Código de acesso: " + codigoConfirmacao + "</body></html>";
            mail.Body = texto;
            mail.BodyEncoding = System.Text.Encoding.UTF8;
            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.High;
            #endregion

            #region Envio do Email
            try
            {
                client.Send(mail);
            }
            catch (Exception)
            {
                throw new Exception("Não foi possível enviar a esse email.");
            }
            #endregion
        }
        public string PegarCodigo ()
        {
            return codigo;
        }
    }
}