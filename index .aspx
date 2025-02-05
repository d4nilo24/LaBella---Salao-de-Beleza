<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="prjTCC.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>La Bella</title>
    <link rel="preconnect" href="https://fonts.googleapis.com">
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
    <link href="https://fonts.googleapis.com/css2?family=Open+Sans&display=swap" rel="stylesheet">
    <meta charset="utf-8">
    <link rel="stylesheet" type="text/css" href="css/estilo.css">
    <script src="https://kit.fontawesome.com/f9a95042e5.js" crossorigin="anonymous"></script>
    <meta name="viewport" content="width=device-width, initial-scale=1">
</head>
<body>
    <form id="form1" runat="server">
        <header>
        <div class="logo-container">
            <a href="index.html">
                <img src="imagens/logotipo.png" alt="logo do site">
            </a>
        </div>

        <nav>
            <ul>
                <li><a href="servicos.html">Serviços</a></li>
                <li><a href="recompensas.html">Recompensas</a></li>
            </ul>
        </nav>

        <div class="menu-sanduiche">
            <i class="fa-solid fa-bars"></i>
        </div>

        <div class="usuario-container">
            <a href="cadastro.html">
                <i class="fa-solid fa-circle-user"></i>
            </a>
        </div>

        <div class="dropdown">
            <li><a href="servicos.html">Serviços</a></li>
            <li><a href="recompensas.html">Recompensas</a></li>
            <li><a href="cadastro.html"><button>Fazer login</button></a></li>
        </div>
    </header>

    <section>
        <div class="banner-container">
            <img src="imagens/banner.jpg" alt="banner de destque">
        </div>

        <h1 class="centralizado">Serviços</h1>

        <div id="carrossel" class="section-content-largura">
            <div class="botoes-navegacao" id="left">
                <button><</button>
            </div>
            <div class="wrapper">
            <ul id="tipo-servicos-containers"> 
                
                
                <li class="tipo-servicos-container" draggable="false">
                    <img src="imagens/corte.png" alt="ícone do serviço" draggable="false">
                    <h3>Cabelo</h3>
                    <p>Veja mais ></p>
                </li>
    
                <li class="tipo-servicos-container" draggable="false">
                    <img src="imagens/cilios.png" alt="ícone do serviço" draggable="false">
                    <h3>Cílios</h3>
                    <p>Veja mais ></p>
                </li>
    
                <li class="tipo-servicos-container" draggable="false">
                    <img src="imagens/unha.png" alt="ícone do serviço" draggable="false">
                    <h3>Unhas</h3>
                    <p>Veja mais ></p>
                </li>
    
                <li class="tipo-servicos-container" draggable="false">
                    <img src="imagens/labio.png" alt="ícone do serviço" draggable="false">
                    <h3>Lábios</h3>
                    <p>Veja mais ></p>
                </li>
    
                <li class="tipo-servicos-container" draggable="false">
                    <img src="imagens/sombrancelha.png" alt="ícone do serviço" draggable="false">
                    <h3>Sobrancelhas</h3>
                    <p>Veja mais ></p>
                </li>
    
                <li class="tipo-servicos-container" draggable="false">
                    <img src="imagens/corte.png" alt="ícone do serviço" draggable="false">
                    <h3>Cabelo</h3>
                    <p>Veja mais ></p>
                </li>
    
                
            </ul>
        </div>
            <div class="botoes-navegacao" id="right">
                <button>></button>
            </div>
        </div>
    </section>

    <section class="section-depoimentos">
        <div class="section-content-largura">
            <h1 class="centralizado">Depoimentos</h1>
            <p>Veja o que nossos clientes dizem</p>

            <div class="depoimentos">
                <div class="depoimento-container">
                    <div>
                        <i class="fa-solid fa-quote-left aspas"></i>
                        <h3>Andréia Souza</h3>
                        <i class="fa-solid fa-star"></i><i class="fa-solid fa-star"></i><i class="fa-solid fa-star"></i><i class="fa-solid fa-star"></i><i class="fa-solid fa-star"></i>
                    </div>

                    <div>   
                        <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irureee</p>
                    </div>
                </div>

                <div class="depoimento-container">
                    <div>
                        <i class="fa-solid fa-quote-left aspas"></i>
                        <h3>Letícia López</h3>
                        <i class="fa-solid fa-star"></i><i class="fa-solid fa-star"></i><i class="fa-solid fa-star"></i><i class="fa-solid fa-star"></i><i class="fa-solid fa-star"></i>
                    </div>

                    <div>
                        <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irureee</p>
                    </div>
                </div>

                <div class="depoimento-container">
                    <div>
                        <i class="fa-solid fa-quote-left aspas"></i>
                        <h3>Fernanda Siqueira</h3>
                        <i class="fa-solid fa-star"></i><i class="fa-solid fa-star"></i><i class="fa-solid fa-star"></i><i class="fa-solid fa-star"></i><i class="fa-solid fa-star"></i>
                    </div>

                    <div>
                        <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irureee</p>
                    </div>
                </div>
            </div>
        </div>
    </section>

    <div class="fundo">
        <div class="login-form-container">
            <form class="login-form">
                <h1>Acessar conta</h1>
                <label for="e-mail">E-mail:</label>
                <input type="email">
    
                <label for="senha">Senha:</label>
                <input type="password">
    
                <button>Entrar</button>
                <h4><a href="">Esqueci a senha</a></h4>
                <h4>Ainda não tem conta? <a href="cadastro.html">Criar uma</a></h4>
            </form>
        </div>
    </div>
    
    <footer>
        <div class="footer-container">
            <div class="logo-container">
                <a href="index.html">
                    <img src="imagens/logotipo_branco.png">
                </a>
                <i class="fa-brands fa-whatsapp"></i>
                <i class="fa-brands fa-instagram"></i>
            </div>

            <div>
                <h1>Onde nos encontrar</h1>

                <ul>
                    <li>Av. Epitácio Pessoa, 466, Santos-SP</li>
                </ul>
            </div>

            <div>
                <h1>Horário</h1>

                <ul>
                    <li>De terça a sábado das 9 às 18</li>
                </ul>
            </div>

            <div class="footer-contato-container">
                <h1>Contato</h1>

                <ul>
                    <li>(13) 99009-9625</li>
                </ul>
            </div>
        </div> 
    </footer>
    <script type="text/javascript" src="js/carrossel.js"></script>
    <script type="text/javascript" src="js/menu_sanduiche.js"></script>
    </form>
</body>
</html>
