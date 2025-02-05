const ultimaUrl = new URLSearchParams(window.location.search).get("url");
if (ultimaUrl != "login.aspx")
{
    document.cookie = "ultimaUrl=" + ultimaUrl + "; path=/";
    window.location.href = "login.aspx";
}