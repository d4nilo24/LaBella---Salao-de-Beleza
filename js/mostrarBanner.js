function mostrarBanner() {
    let url = "ra_banner.aspx";
    if (document.documentElement.clientWidth < 800)
    {
        url += "?banner=0"
    }
    else 
    {
        url += "?banner=1"
    }
          
    fetch(url)
        .then(function (resposta) {
            return resposta.json();
        }).then(function (dados) {
            let divContainer = document.getElementById("imagensBanner");
            let indice = 0;
            dados.forEach(function (dado) {
                let link = document.createElement("a");
                link.href = dado["link"];
                let imagem = document.createElement("img");
                imagem.src = "imagens/" + dado["Imagem"]["Pasta"] + "/" + dado["Imagem"]["Nome"];
                imagem.classList += "slide";
                imagem.alt = "Imagem do banner";
                imagem.style = "display:block";
                link.appendChild(imagem);
                divContainer.appendChild(link);

                if (dados.length > 1) {
                    let btnRadios = document.getElementById("btnRadios");
                    let radio = document.createElement("div");

                    if (indice == 0) {
                        radio.classList = "btnRadio btnPreenchido";
                    }
                    else {
                        radio.classList = "btnRadio btnContorno";
                    }
                    radio.setAttribute('onclick', 'currentDiv(' + indice + ')')
                    btnRadios.appendChild(radio);
                    indice++;

                    showDivs(0)
                }

                document.querySelector(".spinner").style.display = "none";
            }
            )
            
        });
}

mostrarBanner();