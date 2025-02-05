window.onload = function () {
    const urlAtual = window.location.href;
    let elementos = null;
    let maiorTamanho = 0;

    function iconesCarregados() {
        var icones = document.querySelectorAll(".icone");
        for (var i = 0; i < icones.length; i++) {
            if (icones[i].offsetWidth == 0) {
                return false;
            }
        }
        return true;
    }
    function imagensCarregadas() {
        var imagens = document.querySelectorAll("img");
        for (var i = 0; i < imagens.length; i++) {
            if (!imagens[i].complete) {
                return false;
            }
        }
        return true;
    }

    if (urlAtual.includes("index.aspx")) {

        if (iconesCarregados())
        {
            inicio();
        }
        else
        {
            let interval = setInterval(function () {
                if (iconesCarregados()) {
                    clearInterval(interval);
                    inicio();
                }
            }, 100);
        }
    }
    else if (urlAtual.includes("recompensas.aspx"))
    {
        if (imagensCarregadas())
        {
            inicio();
        }
        else
        {
            var interval = setInterval(function () {
                if (imagensCarregadas()) {
                    clearInterval(interval);
                    inicio();
                }
            }, 100);
        }
    }
    else if (urlAtual.includes("servicos.aspx")) {
        if (imagensCarregadas() && iconesCarregados()) {
            inicio();
        }
        else {
            var interval = setInterval(function () {
                if (imagensCarregadas() && iconesCarregados()) {
                    clearInterval(interval);
                    inicio();
                }
            }, 100);
        }
    }
    else if (urlAtual.includes("dona_banner.aspx")) {
        if (imagensCarregadas() && iconesCarregados()) {
            inicio();
        }
        else {
            var interval = setInterval(function () {
                if (imagensCarregadas() && iconesCarregados()) {
                    clearInterval(interval);
                    inicio();
                }
            }, 100);
        }
    }

    function inicio () {

        if (urlAtual.includes("index.aspx")) {
            elementos = document.querySelectorAll(".depoimento-container");
            alterarTamanho();
        }
        else if (urlAtual.includes("recompensas.aspx")) {
            elementos = document.querySelectorAll(".recompensa-container-informacoes-textos p");
            alterarTamanho();
            elementos = document.querySelectorAll(".recompensa-container-informacoes-textos-titulo");
            alterarTamanho();
            elementos = document.querySelectorAll(".recompensa-imagem");
            alterarTamanho();
            //elementos = document.querySelectorAll(".recompensa-container-informacoes");
            //alterarTamanho();
            elementos = document.querySelectorAll(".recompensa-container");
            alterarTamanho();

            
        }
        else if (urlAtual.includes("servicos.aspx")) {
            //elementos = document.querySelectorAll(".servico-container");
            //alterarTamanho();
            elementos = document.querySelectorAll(".servico-titulo");
            alterarTamanho();
            elementos = document.querySelectorAll(".info-servico");
            alterarTamanho();
        }
        else if (urlAtual.includes("dona_banner.aspx")) {
            //elementos = document.querySelectorAll(".servico-container");
            //alterarTamanho();
            elementos = document.querySelectorAll(".banner-imagem");
            alterarTamanho();
            elementos = document.querySelectorAll(".recompensa-container");
            alterarTamanho();
            
        }


        function alterarTamanho() {
            if (elementos.length > 0) {
                elementos.forEach(elemento => {
                    const tamanho = elemento.clientHeight;
                    if (tamanho > maiorTamanho) {
                        maiorTamanho = tamanho;
                    }
                });

                elementos.forEach(elemento => {
                    elemento.style.height = maiorTamanho + "px";
                })
            }
        }
    }

    function esconderLoading()
    {
        let loading = document.querySelector("#loading_spinner");
        if (loading != null)
        {
            loading.style = "display:none";
        }
    }
    esconderLoading();
}