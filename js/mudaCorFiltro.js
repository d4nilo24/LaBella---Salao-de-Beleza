const urlAtual = window.location.href;
const query = new URLSearchParams(window.location.search);

if (query.has("categoria")) {
    let filtro = document.querySelector("#categoria" + query.get("categoria"));
    filtro.classList.add("botaoAtivo");
}
else
{
    if (urlAtual.includes("servicos.aspx"))
    {
        let filtro = document.querySelector("#categoria0");
        filtro.classList.add("botaoAtivo");
    }
}

if (query.has("tipo"))
{
    let filtro = document.querySelector("#tipo_premio" + query.get("tipo"));
    filtro.classList.add("botaoAtivo");
}
else
{
    if (urlAtual.includes("recompensas.aspx") || urlAtual.includes("minha_conta_recompensas.aspx"))
    {
        let filtro = document.querySelector("#tipo_premio0");
        filtro.classList.add("botaoAtivo");
    }
}