const pastaImgServico = "imagens/Servicos/";
const pastaImgFuncionario = "imagens/Funcionarios/";

const servico = new URLSearchParams(window.location.search).get("servico");


function iniciar() {
    const img_servico = document.querySelector("#img_servico_agendamento");
    const nome_servico = document.querySelector("#nome_servico");
    const preco_servico = document.querySelector("#preco_servico");
    const duracao_servico = document.querySelector("#duracao_servico");
    const data_agendamento = document.querySelector("#data_agendamento");
    const funcionario_servico = document.querySelector("#funcionario_servico");

    fetch("ra_dados_minimos.aspx?servico=" + servico)
        .then(function (resposta) {
            return resposta.json();
        }).then(function (dados) {

            let date = new Date();
            const hoje =

                arData(date);
            date.setFullYear(date.getFullYear() + 1);
            const limite = formatarData(date);

            img_servico.src = pastaImgServico + dados["Imagem"][0]["Nome"];
            nome_servico.innerHTML = dados["Nome"];
            preco_servico.innerHTML = "R$ " + dados["Valor"];
            duracao_servico.innerHTML = dados["Duracao"];
            data_agendamento.value = hoje;
            data_agendamento.setAttribute("min", hoje);
            data_agendamento.setAttribute("max", limite);
            for (let i = 0; i < dados["Funcionario"].length; i++) {
                funcionario_servico.innerHTML += "<option value=" + dados["Funcionario"][i]["Codigo"] + ">" + dados["Funcionario"][i]["Nome"] + "</option>"
            }
        });
}

function listarHorarioFuncionario() {

}

function formatarData(data) {
    let novaData = new Date();
    let dia = data.getDate();
    let mes = data.getMonth() + 1;
    let ano = data.getFullYear();

    if (dia < 10) {
        dia = "0" + dia;
    }
    if (mes < 10) {
        mes = "0" + mes;
    }

    novaData = ano + "-" + mes + "-" + dia;
    return novaData;
}

iniciar();