const urlAtual = window.location.href;

function mostrarImagem() {
    var input = null;
    if (urlAtual.includes("dona_recompensa_adicionar.aspx"))
    {
        input = document.querySelector(".fluImagem");
    }
    else
    {
        input = document.getElementById('fluImagem');
    }

    var imagemPreview = null;
    if (urlAtual.includes("dona_recompensa_adicionar.aspx")) {
        imagemPreview = document.querySelector('.imgPreview');
    }
    else {
        imagemPreview = document.getElementById('imgPreview');
    }
        if (input.files && input.files[0]) {
            var reader = new FileReader();

            reader.onload = function (e) {
                imagemPreview.src = e.target.result;
            };

            reader.readAsDataURL(input.files[0]);
            }
}

function mostrarImagens() {
    var input = document.getElementById('fluImagem');
    var imagemPreview = document.getElementById('divPreview');

    imagemPreview.innerHTML = "";

    if (input.files && input.files.length > 0) {
        for (var i = 0; i < input.files.length; i++) {
            (function (index) {
                var reader = new FileReader();
                var imagemDiv = document.createElement('div');
                imagemDiv.className = 'pnlImagensAdicionar';

                reader.onload = function (e) {
                    var imagem = document.createElement('img');
                    imagem.src = e.target.result;
                    imagemDiv.appendChild(imagem);
                };

                reader.readAsDataURL(input.files[index]);
                imagemPreview.appendChild(imagemDiv);
            })(i);
        }
    }
}

function mostrarImagemBanner()
{
    var inputDesktop = document.getElementById('fluImagemDesktop');
    var imagemPreviewDesktop = document.getElementById('imgPreviewDesktop');

    var inputMobile = document.getElementById('fluImagemMobile');
    var imagemPreviewMobile = document.getElementById('imgPreviewMobile');

    if (inputDesktop.files && inputDesktop.files[0]) {
        var reader = new FileReader();

        reader.onload = function (e) {
            imagemPreviewDesktop.src = e.target.result;
        };

        reader.readAsDataURL(inputDesktop.files[0]);
    }

    if (inputMobile.files && inputMobile.files[0]) {
        var reader = new FileReader();

        reader.onload = function (e) {
            imagemPreviewMobile.src = e.target.result;
        };

        reader.readAsDataURL(inputMobile.files[0]);
    }
}

