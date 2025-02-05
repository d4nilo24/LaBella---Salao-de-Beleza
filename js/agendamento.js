const pastaImgServico = "imagens/Servicos/";
const pastaImgFuncionario = "imagens/Funcionarios/";

const servico = new URLSearchParams(window.location.search).get("servico");

let funcionariosCodigo = [];

const funcionario_servico = document.querySelector("#funcionario_servico");
const data_agendamento = document.querySelector("#data_agendamento");
const btn_agendar = document.querySelector(".btn-agendamento-servico");
const aviso_erro = document.querySelector("#aviso_erro")
const loading = document.querySelector("#loading_spinner");

const cupom_drop = document.querySelector("#cupom");
let valor_preco_servico = null;
let codigoCupom = null;

let funcionarioServicoTrabalho = [];

verificarLogin();

function verificarLogin()
{
    fetch("ra_verificar_login.aspx")
        .then(function (resposta) {
            return resposta.json(); 
        }).then(function (dados) {
            if (!dados["logado"])
            {
                window.location.href = "login.aspx";
            }            
            else
            {
                if (dados["tipo"] < 3)
                {
                    window.location.href = "index.aspx";
                }
                else
                {
                    iniciar();
                }
            }
        });
}

function iniciar() {
    //const img_servico = document.querySelector("#img_servico_agendamento");
    const nome_servico = document.querySelector("#nome_servico");
    const preco_servico = document.querySelector("#preco_servico");
    const duracao_servico = document.querySelector("#duracao_servico");
    
        
    fetch("ra_dados_minimos.aspx?servico=" + servico)
        .then(function (resposta) {
            return resposta.json();
            loadingEstado(true);
        }).then(function (dados) {

            let date = new Date();
            const hoje = formatarData(date);
            date.setFullYear(date.getFullYear() + 1);
            const limite = formatarData(date);

            //img_servico.src = pastaImgServico + dados["Imagem"][0]["Nome"];
            nome_servico.innerHTML = dados["Nome"];
            preco_servico.innerHTML = "R$ " + dados["Valor"];
            valor_preco_servico = parseInt(dados["Valor"]);
            calcularCupom();
            duracao_servico.innerHTML = dados["Duracao"];
            data_agendamento.value = hoje;
            data_agendamento.setAttribute("min", hoje);
            data_agendamento.setAttribute("max", limite);
            for (let i = 0; i < dados["Funcionario"].length; i++) {
                funcionario_servico.innerHTML += "<option value=" + dados["Funcionario"][i]["Codigo"] + ">" + dados["Funcionario"][i]["Nome"] + "</option>"
                funcionariosCodigo.push(dados["Funcionario"][i]["Codigo"]);
            }
            loadingEstado(false);
        });

    listarCupom();
}

function listarHorarioFuncionario()
{
    funcionarioServicoDiaDeTrabalho(null, null);
    btn_agendar.disabled = true;
    let codigoFuncionario = null;
    let codigoDiaDaSemanaDataAgendamento = new Date(data_agendamento.value + "T00:00").getDay() + 1;
    let fetchUrl = "ra_listar_horarios.aspx?servico=" + servico;

    if (funcionario_servico.selectedIndex > 0) {
        codigoFuncionario = funcionariosCodigo[funcionario_servico.selectedIndex - 1];
        fetchUrl += "&funcionario=" + codigoFuncionario;
    }

    fetchUrl += "&diadasemana=" + codigoDiaDaSemanaDataAgendamento + "&data="+data_agendamento.value;
    fetch(fetchUrl)
        .then(function (resposta) {
            return resposta.json();
            loadingEstado(true);
        }).then(function (dados) {
            const agendamento_funcionario = document.querySelector("#agendamentos_funcionario");
            agendamento_funcionario.innerHTML = "";
            if (dados.length == 0) {
                agendamento_funcionario.innerHTML += "Desculpe. Não há funcionários cadastrados para esse serviço ainda.";

                animar(".agendamentos-funcionario", "0");
                animar('.formulario', '1');
            }
            dados.forEach(function (dado) {
                let html = `
    <div class="agendamneto-funcionario-horario-container">
        <div class="agendamento-funcionario-imagem">
                   <img src=`;
                if (dado["Funcionario"]["Imagem"]["Pasta"] != null)
                {
                    html += `"imagens/${dado["Funcionario"]["Imagem"]["Pasta"]}/${dado["Funcionario"]["Imagem"]["Nome"]}"`;
                }
                else
                {
                    html += `"imagens/user.png"`
                }
                html +=` alt = "foto do(a) funcionário(a)">
            <div class="agendamento-nome-funcionario">
                <h3>${dado["Funcionario"]["Nome"]}</h3>
            </div>
        </div>

        

        <div class="agendamento-horarios-funcionario">`;
                if (dado["Horas"] != "") {
                    let semAgendamento = true;
                    for (let i = 0; i < dado["Horas"].length; i++) {
                        if (dado["HorarioAgendado"][i] == "0")
                        {
                            html += `<button onclick="funcionarioServicoDiaDeTrabalho(${dado["Funcionario"]["Codigo"]},'${dado["Horas"][i]}', this)"> ${dado["Horas"][i]} </button>`;
                            semAgendamento = false;
                        }
                    }
                    if (semAgendamento)
                    {
                        let dataProxima = new Date(dado["DataProxima"] + "T00:00");
                        let dataAtual = new Date();
                        const meses = ["Janeiro", "Fevereiro", "Março", "Abril", "Maio", "Junho", "Julho", "Agosto", "Setembro", "Outubro", "Novembro", "Dezembro"];
                        const diasDaSemana = ["Domingo", "Segunda", "Terça", "Quarta", "Quinta", "Sexta", "Sábado"];

                        html += "<p>Todos os horários disponíveis de " + dado["Funcionario"]["Nome"] + " já foram agendados nesse dia. Sua disponibilidade futura mais próxima, de <b>" + /*dado["DiaDeTrabalho"]["Nome"]*/ diasDaSemana[codigoDiaDaSemanaDataAgendamento] + "</b>, é para o dia <b>" + dataProxima.getDate() + "</b>"
                        if (dataProxima.getMonth() == dataAtual.getMonth())
                        {
                            html += " <b>desse mês</b>"
                        }
                        else if (dataProxima.getMonth() == dataAtual.getMonth() + 1)
                        {
                            html += " do <b>mês que vem</b>"
                        }
                        else
                        {
                            html += " de <b>" + meses[dataProxima.getMonth()]; "</b>"
                        }
                        html += ".</p>"
                    }
                }
                else
                {   
                    html += "<p>" + dado["Funcionario"]["Nome"];
                    if (dado["DiaDeTrabalho"]["Nome"] != "")
                        html +=  " não possui horários para esse dia, mas possui horários para <b>" + dado["DiaDeTrabalho"]["Nome"] + "</b>";
                    else 
                    {
                        html += " ainda não possui horários cadastrados para esse serviço";
                    }
                    
                    html += ". </p>";
                }
                html += `</div >
    </div>`;
                agendamento_funcionario.innerHTML += html;

                animar(".agendamentos-funcionario", "0");
                animar('.formulario', '1');
            });
            loadingEstado(false);
        });
   
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

function funcionarioServicoDiaDeTrabalho(codigoFuncionario, hrFuncionarioServico, botao)
{
    funcionarioServicoTrabalho = null;
    if (codigoFuncionario != null && hrFuncionarioServico != null) 
    {
        funcionarioServicoTrabalho = [codigoFuncionario, hrFuncionarioServico];
        animar('.formulario', '1');
    }
    btn_agendar.disabled = false;

    if (botao != null) {
        document.querySelectorAll(".botaoSelecionado").forEach(function (elemento) {
            elemento.classList.remove("botaoSelecionado");
        })
        botao.classList.add("botaoSelecionado");
    }

    if (aviso_erro.innerHTML != "")
    {
        aviso_erro.innerHTML = "";
        animar('.formulario', '1');
    }
}

function listarCupom()
{
    fetch("ra_cupom.aspx?servico=" + servico)
        .then(function (resposta) {
            return resposta.json();
            loadingEstado(true);
        }).then(function (dados) {
            
            dados.forEach(function (dado)
            {
                cupom_drop.innerHTML += "<option value="+ dado["Codigo"] +">" + dado["Valor"] + "% de desconto</option>";
            })
            loadingEstado(false);
        });
}

function calcularCupom()
{
    const subtotal = document.querySelector("#subtotal");
    const desconto = document.querySelector("#desconto");
    const preco_total = document.querySelector("#total");
    if (cupom_drop.selectedIndex > 0)
    {
        let optionHtml = cupom_drop.options[cupom_drop.selectedIndex].innerHTML
        let porcentagem = parseInt(optionHtml.replace(/[^0-9]/g, ''));

        if (porcentagem > 0 && porcentagem < 101)
        {
            subtotal.innerHTML = "Subtotal: R$" + valor_preco_servico;
            desconto.innerHTML = "Desconto: " + porcentagem + "%";
            let preto_total_desconto = ((valor_preco_servico - ((valor_preco_servico * porcentagem) / 100)));
            preco_total.innerHTML = "Total: " + preto_total_desconto.toLocaleString('pt-BR', { style: 'currency', currency: 'BRL' });
        }
        codigoCupom = cupom_drop.value;
    }
    else
    {
        subtotal.innerHTML = "Subtotal: R$" + valor_preco_servico;
        desconto.innerHTML = "";
        preco_total.innerHTML = "Total: R$" + valor_preco_servico;
        codigoCupom = null;
    }
    if (animacao != 0)
        animar('.formulario', '1');
}

function efetuarAgendamento()
{
    if (funcionarioServicoTrabalho == null)
    {
        btn_agendar.disabled = true;
        return;
    }
    else
    {
        btn_agendar.disabled = false;
    }

    let fetchUrl = `ra_agendar.aspx?servico=${servico}&hora=${funcionarioServicoTrabalho[1]}&data=${data_agendamento.value}&funcionario=${funcionarioServicoTrabalho[0]}&diadasemana=${(new Date(data_agendamento.value + "T00:00").getDay() + 1)}`
    if (codigoCupom != null)
    {
        fetchUrl += "&cupom=" +codigoCupom;
    }
    fetch(fetchUrl)
        .then(function (resposta) {
            return resposta.text()
            loadingEstado(true);
        }).then(function (resultado) {
            


            if (resultado.toString() == "Agendamento realizado com sucesso.") {
                aviso_erro.innerHTML = "<div class='acerto'><p><i class=\"fa-solid fa-check\"></i>" + resultado + "</p></div>";
                window.location.href = "minha_conta_agendamentos.aspx";
            }
            else {
                aviso_erro.innerHTML = "<div class='erro'><p><i class=\"fa-solid fa-triangle-exclamation\"></i>" + resultado + "</p></div>";
            }

            animar('.formulario', '1');
            loadingEstado(false);
        });
}

// Animação

let animados = [];
let animacao = 0;

function fechar() {
    animados = document.querySelectorAll(".animar");

    for (let i = 0; i < animados.length; i++) {
        animados[i].style.height = "0";
        animados[i].style.overflow = "hidden";
    }
}


function animar(classe, indice) {
    const elemento = document.querySelector(classe);

    if (!animados[indice].classList.contains('suaveAnimar'))
        animados[indice].classList.add("suaveAnimar")

    if (!elemento.classList.contains('abertoAnimar')) {
        // Adicione a classe .aberto para expandir o elemento
        //elemento.style.overflow = 'visible';
        // Calcule a altura real do conteúdo e defina a altura

        //elemento.style.height = tamanhos[indice] + 'px';

        elemento.style.height = "auto"
        let heightElemento = elemento.clientHeight + "px";
        // let heightElemento = window.getComputedStyle(elemento).height;
        elemento.style.height = "0";
        elemento.offsetHeight;

        elemento.style.height = heightElemento;

        elemento.classList.add('abertoAnimar');

        //elemento.style.overflow = 'hidden';
    }
    else {
        //elemento.style.overflow = 'hidden';

        // Calcule a altura real do conteúdo e defina a altura

        //elemento.style.height = tamanhos[indice] + 'px';
        elemento.style.height = "auto"
        let heightElemento = window.getComputedStyle(elemento).height;
        elemento.style.height = "0";

        elemento.style.height = heightElemento;
    }
    animacao = parseInt(indice) + 1;
}

function loadingEstado(estado)
{
    if (estado)
        loading.style = "display:flex";
    else
        loading.style = "display:none";
}

fechar();
