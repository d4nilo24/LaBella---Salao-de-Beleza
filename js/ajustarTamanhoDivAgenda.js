window.onload = function()
{
    let horarios = document.querySelectorAll(".btnhorario");
    let tamanhos = [];
    let leftTamanhos = [];
    let linhas = [];
    let linhasDefinidas = false;

    horarios.forEach(function (elemento) {
        let largura = elemento.offsetWidth;
        let left = parseInt(elemento.style.left, 10);
        tamanhos.push(largura);
        leftTamanhos.push(left);
    });
    function mudarTamanhoTela() {

        let tamanhoTela = window.innerWidth;

        if (tamanhoTela < 670) {
            tamanhoTela = 670;
        }



        for (let i = 0; i < horarios.length; i++) {

            let cell = horarios[i].parentElement.offsetWidth;


            let novoTamanho = (cell * tamanhos[i]) / 60;
            let novoLeftTamanho = (cell * leftTamanhos[i]) / 60;
            horarios[i].style.width = novoTamanho + "px"
            horarios[i].style.left = novoLeftTamanho + "px"
            //horarios[i].setAttribute("style", "width:" + novoTamanho + "px");


            


            if (!linhasDefinidas) {
                let linhaNova = document.createElement("div");

                linhaNova.classList.add("linha_agenda")
                let tamanhoTop = calcularDistanciaVertical(horarios[i].parentElement.parentElement.parentElement, horarios[i].parentElement);
                linhaNova.style.height = tamanhoTop + horarios[i].parentElement.offsetHeight / 2 - 5 + "px";
                linhaNova.style.bottom = horarios[i].parentElement.offsetHeight / 2 + 5 + "px";
                linhaNova.style.width = novoTamanho + "px";
                if (!isNaN(novoLeftTamanho)) 
                {
                    linhaNova.style.left = novoLeftTamanho + "px";
                }
                else 
                {
                    linhaNova.style.left = 0 + "px";
                }

                linhaNova.style.position = "absolute";
                horarios[i].parentElement.appendChild(linhaNova);
                linhas.push(linhaNova);

            }
            else {
                let linhaNova = linhas[i];
                
                let tamanhoTop = calcularDistanciaVertical(horarios[i].parentElement.parentElement.parentElement, horarios[i].parentElement);
                linhaNova.style.height = tamanhoTop + horarios[i].parentElement.offsetHeight / 2 - 5 + "px";
                linhaNova.style.bottom = horarios[i].parentElement.offsetHeight / 2 + 5 + "px";
                linhaNova.style.width = novoTamanho + "px";
                linhaNova.style.left = novoLeftTamanho + "px";
            }
            

        }
        linhasDefinidas = true;
    }

    window.addEventListener('resize', function () { mudarTamanhoTela() })
    mudarTamanhoTela();



    function calcularDistanciaVertical(elemento1, elemento2) {
        var distanciaTotal = 0;

        var elementoAtual = elemento1;

        // Subir pela hierarquia do elemento1 até o documento
        while (elementoAtual) {
            distanciaTotal += elementoAtual.offsetTop;
            elementoAtual = elementoAtual.offsetParent;
        }

        // Resetar para o elemento2
        elementoAtual = elemento2;

        // Subir pela hierarquia do elemento2 até o documento
        while (elementoAtual) {
            distanciaTotal -= elementoAtual.offsetTop;
            elementoAtual = elementoAtual.offsetParent;
        }

        // O valor absoluto da distância total é a distância vertical entre os elementos
        var distanciaVertical = Math.abs(distanciaTotal);

        return distanciaVertical;
    }
}