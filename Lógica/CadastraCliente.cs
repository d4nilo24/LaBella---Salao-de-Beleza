using prjTCC.Classe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Web; 

namespace prjTCC.Lógica
{
    public class CadastraCliente : Banco
    {
        public string codigoConfirmacao { get; set; }

        public void cadastrarCliente(string nomeCliente, string emailCliente, string senhaCliente)
        {
            Conectar();

            try
            {
                List<Parametro> parametros = new List<Parametro>();

                parametros.Add(new Parametro("vEmailCliente", emailCliente));
                parametros.Add(new Parametro("vNomeCliente", nomeCliente));
                parametros.Add(new Parametro("vSenhaCliente", senhaCliente));

                Executar("CadastrarCliente", parametros);
            }

            catch (Exception)
            {

                throw new Exception("Algo deu errado ao cadastrar-te. Tente novamente mais tarde.");
            }

            finally
            {
                Desconectar();
            }
        }

        public bool enviarCodigoVerificacao(string emailDestinatario)
        {
            Random numeroAleatorio = new Random();
            codigoConfirmacao = numeroAleatorio.Next(1000, 9999).ToString();

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
    }</style></head><body style='word-spacing:normal;'><div><!--[if mso | IE]><table align='center' border='0' cellpadding='0' cellspacing='0' class='' style='width:10000px;' width='10000' ><tr><td style='line-height:0px;font-size:0px;mso-line-height-rule:exactly;'><![endif]--><div style='margin:0px auto;max-width:10000px;'><table align='center' border='0' cellpadding='0' cellspacing='0' role='presentation' style='width:100%;'><tbody><tr><td style='direction:ltr;font-size:0px;padding:20px 0;text-align:center;'><!--[if mso | IE]><table role='presentation' border='0' cellpadding='0' cellspacing='0'><tr><td class='' style='vertical-align:top;width:10000px;' ><![endif]--><div class='mj-column-per-100 mj-outlook-group-fix' style='font-size:0px;text-align:left;direction:ltr;display:inline-block;vertical-align:top;width:100%;'><table border='0' cellpadding='0' cellspacing='0' role='presentation' style='background-color:#b36684;vertical-align:top;' width='100%'><tbody><tr><td align='center' style='font-size:0px;padding:10px 25px;word-break:break-word;'><table border='0' cellpadding='0' cellspacing='0' role='presentation' style='border-collapse:collapse;border-spacing:0px;'><tbody><tr><td style='width:100px;'><img height='auto' src='https://uploaddeimagens.com.br/images/004/665/146/full/logotipo_branco.png?1700058367' style='border:0;display:block;outline:none;text-decoration:none;height:auto;width:100%;font-size:13px;' width='100'></td></tr></tbody></table></td></tr></tbody></table></div><!--[if mso | IE]></td></tr></table><![endif]--></td></tr></tbody></table></div><!--[if mso | IE]></td></tr></table><table align='center' border='0' cellpadding='0' cellspacing='0' class='' style='width:10000px;' width='10000' ><tr><td style='line-height:0px;font-size:0px;mso-line-height-rule:exactly;'><![endif]--><div style='margin:0px auto;max-width:10000px;'><table align='center' border='0' cellpadding='0' cellspacing='0' role='presentation' style='width:100%;'><tbody><tr><td style='direction:ltr;font-size:0px;padding:20px 0;text-align:center;'><!--[if mso | IE]><table role='presentation' border='0' cellpadding='0' cellspacing='0'><tr><td class='' style='vertical-align:top;width:10000px;' ><![endif]--><div class='mj-column-per-100 mj-outlook-group-fix' style='font-size:0px;text-align:left;direction:ltr;display:inline-block;vertical-align:top;width:100%;'><table border='0' cellpadding='0' cellspacing='0' role='presentation' style='vertical-align:top;' width='100%'><tbody><tr><td align='left' style='font-size:0px;padding:10px 25px;word-break:break-word;'><div style='font-family:Open sans;font-size:24px;font-weight:bold;line-height:1;text-align:left;color:#000000;'>Cadastro de conta</div></td></tr><tr><td align='left' style='font-size:0px;padding:10px 25px;word-break:break-word;'><div style='font-family:Open sans;font-size:16px;line-height:1;text-align:left;color:#000000;'>Código de verificação: <mj-raw><span style='color: #b36684; font-weight:bold'>"+ codigoConfirmacao+@"</span></mj-raw></div></td></tr></tbody></table></div><!--[if mso | IE]></td></tr></table><![endif]--></td></tr></tbody></table></div><!--[if mso | IE]></td></tr></table><table align='center' border='0' cellpadding='0' cellspacing='0' class='' style='width:10000px;' width='10000' bgcolor='#806E75' ><tr><td style='line-height:0px;font-size:0px;mso-line-height-rule:exactly;'><![endif]--><div style='background:#806E75;background-color:#806E75;margin:0px auto;max-width:10000px;'><table align='center' border='0' cellpadding='0' cellspacing='0' role='presentation' style='background:#806E75;background-color:#806E75;width:100%;'><tbody><tr><td style='direction:ltr;font-size:0px;padding:20px 0;text-align:center;'><!--[if mso | IE]><table role='presentation' border='0' cellpadding='0' cellspacing='0'><tr><td class='' style='vertical-align:top;width:3333.333333333334px;' ><![endif]--><div class='mj-column-per-33-333333333333336 mj-outlook-group-fix' style='font-size:0px;text-align:left;direction:ltr;display:inline-block;vertical-align:top;width:100%;'><table border='0' cellpadding='0' cellspacing='0' role='presentation' style='vertical-align:top;' width='100%'><tbody><tr><td align='left' style='font-size:0px;padding:10px 25px;word-break:break-word;'><div style='font-family:Open sans;font-size:16px;line-height:1;text-align:left;color:#ffffff;'>Av. Epitácio Pessoa, 466, Santos-SP</div></td></tr></tbody></table></div><!--[if mso | IE]></td><td class='' style='vertical-align:top;width:3333.333333333334px;' ><![endif]--><div class='mj-column-per-33-333333333333336 mj-outlook-group-fix' style='font-size:0px;text-align:left;direction:ltr;display:inline-block;vertical-align:top;width:100%;'><table border='0' cellpadding='0' cellspacing='0' role='presentation' style='vertical-align:top;' width='100%'><tbody><tr><td align='left' style='font-size:0px;padding:10px 25px;word-break:break-word;'><div style='font-family:Open sans;font-size:16px;line-height:1;text-align:left;color:#ffffff;'>De terça a sábado das 9 às 18</div></td></tr></tbody></table></div><!--[if mso | IE]></td><td class='' style='vertical-align:top;width:3333.333333333334px;' ><![endif]--><div class='mj-column-per-33-333333333333336 mj-outlook-group-fix' style='font-size:0px;text-align:left;direction:ltr;display:inline-block;vertical-align:top;width:100%;'><table border='0' cellpadding='0' cellspacing='0' role='presentation' style='vertical-align:top;' width='100%'><tbody><tr><td align='left' style='font-size:0px;padding:10px 25px;word-break:break-word;'><div style='font-family:Open sans;font-size:16px;line-height:1;text-align:left;color:#ffffff;'>(13) 99009-9625</div></td></tr></tbody></table></div><!--[if mso | IE]></td></tr></table><![endif]--></td></tr></tbody></table></div><!--[if mso | IE]></td></tr></table><![endif]--></div></body></html>
";
            #endregion

            #region Atribuição dos Valores
            remetente = "contato.la.bella@outlook.com";
            senha = "tcclabella3n";
            destinatario = emailDestinatario;
            assunto = "Confirmação de Conta";
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

            catch (Exception)
            {
                return false;
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
                return true;
            }

            catch (Exception)
            {
                return false;
            }
            #endregion
        }

        public string pegarCodigo()
        {
            return codigoConfirmacao;
        }
    }
}