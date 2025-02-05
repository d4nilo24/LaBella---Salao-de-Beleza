const estrelas = document.querySelectorAll(".fa-star");
const campoEstrela = document.getElementById("hfEstrela")
campoEstrela.value = 5;

function mudarEstrela(indice) {
    for (let i = 0; i < estrelas.length; i++) {
        if (i <= indice) {
            if (estrelas[i].classList.contains("fa-regular")) {
                estrelas[i].classList.remove("fa-regular");
                estrelas[i].classList.add("fa-solid");
            }
        }
        else {
            if (estrelas[i].classList.contains("fa-solid")) {
                estrelas[i].classList.remove("fa-solid");
                estrelas[i].classList.add("fa-regular");
            }
        }
    }
    campoEstrela.value = indice + 1;
}