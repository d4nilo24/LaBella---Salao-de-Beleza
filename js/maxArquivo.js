document.addEventListener('DOMContentLoaded', function () {
    let fileUpload = document.querySelector('#fluImagem');
    let aviso = document.querySelector('#lblObs');
    let divPreview = document.querySelector('#divPreview');

    fileUpload.addEventListener('change', function () {
        var limiteMaximo = 9; 
        var arquivosSelecionados = this.files.length;

        if (arquivosSelecionados > limiteMaximo) {
            aviso.innerHTML = "<div class='erro'><i class=\"fa-solid fa-triangle-exclamation\"></i> Você só pode enviar no máximo " + limiteMaximo + " arquivos de uma vez.";
            divPreview.innerHTML = '';
            this.value = "";
        }
        else if (arquivosSelecionados < 1) {
            aviso.innerHTML = '<i class=\"fa-solid fa-triangle-exclamation\"></i> Se não houver nenhuma imagem, o serviço não aparecerá ao cliente.';
        }
        else {
            aviso.innerHTML = '';
        }

    });
});