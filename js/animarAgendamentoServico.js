let animados = [];
let animacao = 0;

function fechar ()
{
    animados = document.querySelectorAll(".animar");

    for (let i = 0; i < animados.length; i++)
    {
        animados[i].style.height = "0";
        animados[i].style.overflow = "hidden";
    }
}


function animar (classe, indice)
{
    const elemento = document.querySelector(classe);
    
    if(!animados[indice].classList.contains('suaveAnimar'))
    animados[indice].classList.add("suaveAnimar")

    if (!elemento.classList.contains('abertoAnimar')) {
        // Adicione a classe .aberto para expandir o elemento
        elemento.style.overflow = 'visible';

        // Calcule a altura real do conteúdo e defina a altura

        //elemento.style.height = tamanhos[indice] + 'px';
        elemento.style.height = "auto"
        let heightElemento = window.getComputedStyle(elemento).height;
        elemento.style.height = "0";
        elemento.offsetHeight;

        elemento.style.height = heightElemento;

        elemento.classList.add('abertoAnimar');

       //elemento.style.height = heightElemento;
        elemento.style.overflow = 'hidden';
    } 
    else
    {
        elemento.style.overflow = 'visible';

        // Calcule a altura real do conteúdo e defina a altura

        //elemento.style.height = tamanhos[indice] + 'px';
        elemento.style.height = "auto"
        let heightElemento = window.getComputedStyle(elemento).height;
        elemento.style.height = "0";
        elemento.offsetHeight;

        elemento.style.height = heightElemento;
    }
    animacao = parseInt(indice) + 1;
}

fechar();


