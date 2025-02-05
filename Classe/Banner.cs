using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prjTCC.Classe
{
    public class Banner
    {
        public Imagem ImagemDesktop { get; set; }
        public Imagem ImagemMobile { get; set; }
        public string link { get; set; }
        #region Qualquer uma de ambas
        public Imagem Imagem { get; set; }
        #endregion

        public Banner() { }

        public Banner(string link, Imagem imagemDesktop, Imagem imagemMobile)
        {
            this.link = link;
            this.ImagemDesktop = imagemDesktop;
            this.ImagemDesktop = ImagemMobile;
        }
    }
}