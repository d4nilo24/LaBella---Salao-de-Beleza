drop schema if exists LaBella;
create schema LaBella;
use LaBella;

set lc_time_names = 'pt_BR';

create table imagem (
    nm_imagem varchar(255),
    nm_pasta_imagem varchar(255),
    constraint pk_imagem primary key (nm_imagem , nm_pasta_imagem)
);

create table banner (
    nm_imagem_desktop varchar(255),
	nm_imagem_mobile varchar(255),
    nm_pasta_imagem varchar(255),
    nm_link_banner varchar(255),	
	constraint pk_banner primary key (nm_imagem_desktop, nm_imagem_mobile, nm_pasta_imagem),
	constraint fk2_imagem_desktop FOREIGN KEY (nm_imagem_desktop, nm_pasta_imagem)
        REFERENCES imagem(nm_imagem, nm_pasta_imagem),
    constraint fk2_imagem_mobile FOREIGN KEY (nm_imagem_mobile, nm_pasta_imagem)
        REFERENCES imagem(nm_imagem, nm_pasta_imagem)
);

create table categoriaDeServico (
	cd_categoria_servico int, 
	nm_categoria_servico varchar(45),
	nm_imagem varchar(255),
	nm_pasta_imagem varchar(255),
	constraint pk_categoriadeservico primary key(cd_categoria_servico),
	constraint fk_categoriadeservico foreign key (nm_imagem, nm_pasta_imagem)
	references imagem (nm_imagem, nm_pasta_imagem)
);

create table servico (
    cd_servico int,
    nm_servico varchar(45),
    ds_servico varchar(255),
    vl_servico double,
    hr_tempo_duracao time,
    cd_categoria_servico int,
	qt_pontos int,
	ic_ativado bool,
    constraint pk_servico primary key (cd_servico, ic_ativado),
    constraint fk_servico foreign key (cd_categoria_servico)
        references categoriadeservico (cd_categoria_servico)
);

create table servicoImagem (
    nm_imagem varchar(255),
    nm_pasta_imagem varchar(255),
    cd_servico int,
    ic_principal boolean,
    constraint pk_categoriaDeServico primary key (nm_imagem , nm_pasta_imagem , cd_servico),
    constraint fk_servicoImagemImagem foreign key (nm_imagem , nm_pasta_imagem)
        references imagem (nm_imagem , nm_pasta_imagem),
    constraint fk_servicoimagemservico foreign key (cd_servico)
        references servico (cd_servico)
);

create table cupomDesconto (
    cd_cupom_desconto int,
    vl_porcentagem_de_desconto int,
    constraint pk_cupomDesconto primary key (cd_cupom_desconto)
);

create table cupomServico (
    cd_cupom_desconto int,
    cd_servico int,
    constraint pk_cupomServico primary key (cd_cupom_desconto , cd_servico),
    constraint fk_cupomServico foreign key (cd_servico)
        references servico (cd_servico),
    constraint fk2_cupomServico foreign key (cd_cupom_desconto)
        references cupomDesconto (cd_cupom_desconto)
);

create table cupomCategoriaDeServico (
    cd_cupom_desconto int,
    cd_categoria_servico int,
    constraint pk_cupomCategoriaDeServico primary key (cd_cupom_desconto , cd_categoria_servico),
    constraint fk_cupomCategoriaDeServico foreign key (cd_categoria_servico)
        references categoriaDeServico (cd_categoria_servico),
    constraint fk2_cupomCategoriaDeServico foreign key (cd_cupom_desconto)
        references cupomDesconto (cd_cupom_desconto)
);

create table tipoDeProduto (
    cd_tipo_produto int,
    nm_tipo_produto varchar(45),
    constraint pk_tipoDeProduto primary key (cd_tipo_produto)
);

create table produto (
    cd_produto int,
    nm_produto varchar(45),
    qt_produto int,
    ds_produto varchar(255),
    cd_tipo_produto int,
	ic_ativado bool,
    constraint pk_produto primary key (cd_produto),
    constraint fk_produto foreign key (cd_tipo_produto)
        references tipoDeProduto (cd_tipo_produto)
);

create table temporada (
    cd_temporada int,
    dt_inicio_temporada date,
    dt_termino_temporada date,
    constraint pk_temporada primary key (cd_temporada)
);

create table tipoPremio (
    cd_tipo_premio int,
    nm_tipo_premio varchar(45),
    constraint pk_tipoPremio primary key (cd_tipo_premio)
);

create table premio (
    cd_premio int,
    cd_tipo_Premio int,
    cd_cupom_desconto int,
    cd_servico int,
	cd_categoria_servico int,
    cd_produto int,
    nm_premio varchar(45),
    qt_pontos_premio int,
	ds_premio varchar(45),
	nm_imagem varchar(255),
    nm_pasta_imagem varchar(255),
	ic_ativado boolean,
    constraint pk_premio primary key (cd_premio , cd_tipo_premio),
    constraint fk_premio foreign key (cd_tipo_premio)
        references tipoPremio (cd_tipo_premio),
    constraint fk2_premio foreign key (cd_cupom_desconto , cd_servico)
        references cupomServico (cd_cupom_desconto , cd_servico),
	constraint fk3_premio foreign key (cd_cupom_desconto , cd_categoria_servico)
        references cupomCategoriaDeServico (cd_cupom_desconto , cd_categoria_servico),
    constraint fk4_premio foreign key (cd_produto)
        references produto (cd_produto),
	constraint fk5_premio foreign key (nm_imagem, nm_pasta_imagem)
		references imagem (nm_imagem, nm_pasta_imagem)
);

create table cliente (
    nm_email_cliente varchar(255),
    nm_usuario_cliente varchar(45),
    nm_senha_cliente varchar(45),
    qt_pontos_cliente varchar(45),
    constraint pk_cliente primary key (nm_email_cliente)
);

select nm_senha_cliente from cliente;

create table premioCliente (
    cd_premio int,
    nm_email_cliente varchar(45),
	ic_resgatado bool,
    constraint pk_premioCliente primary key (cd_premio, nm_email_cliente),
    constraint fk_premioCliente foreign key (cd_premio)
        references premio (cd_premio),
    constraint fk2_premioCliente foreign key (nm_email_cliente)
        references cliente (nm_email_cliente)
);


create table tipoDeFuncionario (
    cd_tipo_funcionario int,
    nm_tipo_funcionario varchar(45),
    constraint pk_tipoDeFuncionario primary key (cd_tipo_funcionario)
);

create table funcionario (
    cd_funcionario int,
    cd_tipo_funcionario int,
    nm_funcionario varchar(45),
    nm_email_funcionario varchar(255),
    nm_senha_funcionario varchar(45),
	nm_imagem varchar(255),
	nm_pasta_imagem varchar(255),
	ic_ativado bool,
	constraint fk_funcionarioimagem foreign key (nm_imagem, nm_pasta_imagem)
	references imagem (nm_imagem, nm_pasta_imagem),
    constraint pk_funcionario primary key (cd_funcionario),
    constraint fk_funcionario foreign key (cd_tipo_funcionario)
        references tipoDeFuncionario (cd_tipo_funcionario)
);

create table funcionarioServico (
    cd_funcionario int,
    cd_servico int,
	ic_ativado bool,
    constraint pk_funcionarioServico primary key (cd_funcionario , cd_servico, ic_ativado),
    constraint fk_funcionarioServico foreign key (cd_funcionario)
        references funcionario (cd_funcionario),
    constraint fk2_funcionarioServico foreign key (cd_servico)
        references servico (cd_servico)
);

create table diaDeTrabalho (
    cd_dia_trabalho int,
    nm_dia_de_trabalho varchar(45),
    constraint pk_diaDeTrabalho primary key (cd_dia_trabalho)
);

create table funcionarioServicoDiaDeTrabalho (
    cd_dia_trabalho int,
    hr_funcionario_serviço_dia_de_trabalho time,
    cd_funcionario int,
    cd_servico int,
	ic_ativado bool,
    constraint pk_funcionarioServicoDiaDeTrabalho primary key (cd_dia_trabalho , cd_funcionario , cd_servico , hr_funcionario_serviço_dia_de_trabalho, ic_ativado),
    constraint fk_funcionarioServicoDiaDeTrabalho foreign key (cd_funcionario , cd_servico)
        references funcionarioServico (cd_funcionario , cd_servico),
    constraint fk2_funcionarioServicoDiaDeTrabalho foreign key (cd_dia_trabalho)
        references diaDeTrabalho (cd_dia_trabalho)
);

create table agendamento (
	cd_agendamento varchar(45),
	dt_agendamento date,
	ic_presenca_funcionario_agendamento bool,
	ic_presenca_cliente_agendamento bool,
	nm_email_cliente varchar(45),
	cd_funcionario int,
	cd_servico int,
	hr_funcionario_serviço_dia_de_trabalho time,
	cd_dia_trabalho int,
	-- cd_cupom_desconto int,
	cd_premio int,
	constraint pk_agendamento primary key(cd_agendamento),
	constraint fk_agendamento foreign key (nm_email_cliente)
	references cliente (nm_email_cliente),
	constraint fk2_agendamento foreign key (cd_dia_trabalho, cd_funcionario, cd_servico,hr_funcionario_serviço_dia_de_trabalho)
	references funcionarioServicoDiaDeTrabalho(cd_dia_trabalho, cd_funcionario, cd_servico,hr_funcionario_serviço_dia_de_trabalho),
	/*constraint fk3_agendamento foreign key (cd_cupom_desconto)
	references cupomDesconto(cd_cupom_desconto)*/
	constraint fk3_agendamento foreign key (cd_premio)
	references premioCliente(cd_premio)
);

create table avaliacao (
		cd_agendamento varchar(45),
		nm_email_cliente varchar(255),
		vl_avaliacao int,
		ds_avaliacao varchar(450), 
		dt_avaliacao date,
		constraint pk_avaliação primary key (cd_agendamento),
		constraint fk_avaliacao foreign key (cd_agendamento)
		references agendamento (cd_agendamento),
		constraint fk2_avaliacao foreign key (nm_email_cliente)
		references cliente (nm_email_cliente)
);

create table produtoAgendamento (
    cd_produto int,
    cd_agendamento varchar(45),
	qt_produto int,
    constraint pk_produtoAgendamento primary key (cd_produto , cd_agendamento),
    constraint fk_produtoAgendamento foreign key (cd_produto)
        references produto (cd_produto),
    constraint fk2_produtoAgendamento foreign key (cd_agendamento)
        references agendamento (cd_agendamento)
);

create table tipoDeOcorrencia (
    cd_tipo_ocorrencia int,
    nm_ocorrencia varchar(45),
    constraint pk_tipoDeOcorrencia primary key (cd_tipo_ocorrencia)
);

create table Ocorrencia (
    cd_agendamento int,
    cd_tipo_ocorrencia int,
    ds_ocorrencia varchar(255),
    constraint pk_Ocorrencia primary key (cd_tipo_ocorrencia , cd_agendamento),
    constraint fk_Ocorrencia foreign key (cd_tipo_ocorrencia)
        references tipoDeOcorrencia (cd_tipo_ocorrencia)
);

create table token (
    cd_token varchar(30),
	nm_email_cliente varchar(255),
    constraint pk_token primary key (cd_token),
	constraint fk_token foreign key (nm_email_cliente)
		references cliente (nm_email_cliente)
);

select * from Cliente;
select * from servico;

select * from Cliente;
/*insert into funcionarioServicoDiaDeTrabalho values(2, "13:40:00", 'cpfB', 2, 1); ver o problema*/
Delimiter $$

/*PROCEDURES*/

/* Início das telas do Cliente*/

-- Listar categorias
drop procedure if exists ListarCategorias$$ 
create procedure ListarCategorias()
begin
	Select * from categoriadeservico 
	order by nm_categoria_servico;
end$$

drop procedure if exists ListarCategoriasNomeECodigo$$ 
create procedure ListarCategoriasNomeECodigo()
begin
	Select cd_categoria_servico, nm_categoria_servico 
	from categoriadeservico 
	order by nm_categoria_servico;
end$$


-- Listar três avaliações populares
drop procedure if exists AvaliacoesPopulares$$
create procedure AvaliacoesPopulares()
begin
	declare Qtavaliacao int default 3;

	select  distinct (c.nm_usuario_cliente), av.vl_avaliacao, av.ds_avaliacao, date_format(av.dt_avaliacao, '%d/%m/%Y') 
	from Avaliacao av 
	inner join Cliente c
	on (av.nm_email_cliente = c.nm_email_cliente) 
	where vl_avaliacao >= 3 
	order by vl_avaliacao desc
	limit 3
	 ; 
end$$


-- Identificar o tipo de usuário
-- 1 - Funcionário
-- 2 - Gerente
-- 3 - Cliente
-- 4 - Indefinido
drop function if exists TipoDeUsuario$$
create function TipoDeUSuario(vEmail varchar(255), vSenha varchar(45)) returns int
begin
	declare tipoUsuario int default 0;
	if  exists (select * from Cliente where nm_email_cliente = vEmail and nm_senha_cliente = md5(vSenha)) then
		set tipoUsuario = 3;
		return tipoUsuario;
	elseif exists (select f.*, tf.* from Funcionario f inner join tipoDeFuncionario tf on (f.cd_tipo_funcionario = tf.cd_tipo_funcionario) 
	where f.nm_email_funcionario = vEmail and f.nm_senha_funcionario = md5(vSenha)) then
	    select tf.cd_tipo_funcionario from Funcionario f inner join tipoDeFuncionario tf on (f.cd_tipo_funcionario = tf.cd_tipo_funcionario) 
		where f.nm_email_funcionario = vEmail and f.nm_senha_funcionario = md5(vSenha) into tipoUsuario; 
        return tipoUsuario; 
	else
		set tipoUsuario = 4;
		return tipoUsuario;  
	end if;
end$$

-- Logar o usuário
drop procedure if exists LogarUsuario$$
create procedure LogarUsuario(vEmail varchar(255), vSenha varchar(45))
begin
	if  TipoDeUSuario(vEmail,vSenha) = 3 then
		select nm_email_cliente, nm_usuario_cliente, TipoDeUSuario(vEmail,vSenha) 
		from Cliente 
		where nm_email_cliente = vEmail and 
		nm_senha_cliente = md5(vSenha);
	else if  TipoDeUSuario(vEmail,vSenha) = 1 then
		select f.cd_funcionario,f.nm_funcionario ,tf.cd_tipo_funcionario 
		from Funcionario f 
		inner join tipoDeFuncionario tf on (f.cd_tipo_funcionario = tf.cd_tipo_funcionario) 
		where f.nm_email_funcionario = vEmail 
		and f.nm_senha_funcionario = md5(vSenha);
	else if  TipoDeUSuario(vEmail,vSenha) = 2 then
        select f.cd_funcionario,f.nm_funcionario ,tf.cd_tipo_funcionario
		from Funcionario f 
		inner join tipoDeFuncionario tf on (f.cd_tipo_funcionario = tf.cd_tipo_funcionario) 
		where f.nm_email_funcionario = vEmail 
		and f.nm_senha_funcionario = md5(vSenha);
	else
		Signal sqlstate '45000' set message_text = 'Usuario não encontrado';
        end if;
	end if;
 end if;
end$$

-- Cadastro de cliente
drop procedure if exists CadastrarCliente$$ 
create procedure CadastrarCliente(vEmailCliente varchar(255),vNomeCliente varchar(45), vSenhaCliente varchar(45))
begin
	Insert into Cliente values(vEmailCliente,vNomeCliente,md5(vSenhaCliente), 0);
end$$

-- Recuperação de senha
drop procedure if exists SalvarToken$$ 
create procedure SalvarToken(vToken varchar(30), vEmail varchar(255))
begin
	Insert into token values (vToken, vEmail);
end$$

drop procedure if exists VerificarToken$$ 
create procedure VerificarToken(vToken varchar(30))
begin
	if exists (select 1 from token where cd_token = vToken)
	then
		select true;
	else
		select false;
	end if;
end$$

-- Exibir dados mínimos do usuário 
drop procedure if exists ExibirDadosMinimosDoUsuario$$
create procedure ExibirDadosMinimosDoUsuario(vEmail varchar(45))
begin
	select nm_usuario_cliente, nm_email_cliente from Cliente where nm_email_cliente = vEmail;
end$$

-- Verificar existencia de cliente
drop procedure if exists VerificarExistenciaCliente$$
create procedure VerificarExistenciaCliente(vEmail varchar(45))
begin
	select 1 from Cliente where nm_email_cliente = vEmail;
end$$

-- Alterar senha
drop procedure if exists AlterarSenha$$
create procedure AlterarSenha(vToken varchar(30), vSenhaNova varchar(45))
begin
	Update cliente 
	set nm_senha_cliente = md5(vSenhaNova)
	where nm_email_cliente = (Select nm_email_cliente from token where cd_token = vToken);

	Delete from token 
	where cd_token = vToken;
end$$


-- Procedures de paginação da tela de serviços
drop function if exists OffsetAtual$$
create function OffsetAtual (vPaginaAtual int, vLimite int) returns int 
begin
	return ((vPaginaAtual - 1) * vLimite);
end$$
drop function if exists PaginaAtual$$
create function PaginaAtual (vQuantidade int, vLimite int, vOffset int) returns int 
begin
	return ceil((vOffset + 1)/vLimite);
end$$
drop function if exists PaginaTotal$$
create function PaginaTotal (vQuantidade int, vLimite int) returns int
begin
	declare vTotal int;
    set vTotal = vQuantidade;
    return ceil(vTotal / vLimite);
end$$

-- Listar serviços de uma categoria 
drop procedure if exists ListarServicosDaCategoria$$
create procedure ListarServicosDaCategoria(vCdCategoriaServico int, vPaginaAtual int)
begin
	declare vLimitePorPagina int default 12;
	declare offsetAtual int default OffsetAtual(vPaginaAtual, vLimitePorPagina);
	declare tamanhoTotal int default 0;

	if (vCdCategoriaServico = 0) then
		select count(*) into tamanhoTotal from servico as s inner join servicoimagem as si on (si.cd_servico = s.cd_servico) where si.ic_principal = true;

		Select s.cd_servico, s.nm_servico, s.vl_servico, round(time_to_sec(s.hr_tempo_duracao) / 60) ,si.nm_imagem, si.nm_pasta_imagem,
		PaginaTotal(tamanhoTotal, vLimitePorPagina)
		from servico as s inner join servicoimagem as si on (si.cd_servico = s.cd_servico)
		where si.ic_principal = true 
		and s.ic_ativado = true
		LIMIT vLimitePorPagina OFFSET offsetAtual;
	else
		select count(*) into tamanhoTotal 
		from servico as s 
		inner join servicoimagem as si on (si.cd_servico = s.cd_servico) 
		where s.cd_categoria_servico = vCdCategoriaServico 
		and si.ic_principal = true
		and s.ic_ativado = true;

		Select s.cd_servico, s.nm_servico, s.vl_servico, round(time_to_sec(s.hr_tempo_duracao) / 60) ,si.nm_imagem, si.nm_pasta_imagem,
		PaginaTotal(tamanhoTotal, vLimitePorPagina)
		from servico as s 
		inner join servicoimagem as si on (si.cd_servico = s.cd_servico)
		where  s.cd_categoria_servico = vCdCategoriaServico 
		and si.ic_principal = true 
		and s.ic_ativado = true
		LIMIT vLimitePorPagina OFFSET offsetAtual;
	end if;
end$$

-- Informações do serviço específico e informação de média de avaliação em serviço expandido 
-- Avaliação negativa: 1 ou 2 estrelas
-- Avaliação positiva: 3, 4 ou 5 estrelas
drop procedure if exists ServicoSelecionadoInformacoesDoServicoEAvaliacaoMedia$$
create procedure ServicoSelecionadoInformacoesDoServicoEAvaliacaoMedia(vCodigoServico int)
begin

	Select s.cd_servico, s.nm_servico, s.vl_servico, round(time_to_sec(s.hr_tempo_duracao) / 60), s.ds_servico,
	(SELECT GROUP_CONCAT(si.nm_imagem ORDER BY si.ic_principal DESC) FROM servicoimagem AS si WHERE si.cd_servico = s.cd_servico ORDER BY si.ic_principal DESC),
	(SELECT GROUP_CONCAT(si.nm_pasta_imagem ORDER BY si.ic_principal DESC) FROM servicoimagem AS si WHERE si.cd_servico = s.cd_servico ORDER BY si.ic_principal DESC),
	round(avg(a.vl_avaliacao)), count(distinct a.cd_agendamento)
	from servico as s 
	inner join servicoimagem as si on (si.cd_servico = s.cd_servico)
	left join agendamento as ag on (ag.cd_servico = s.cd_servico)
	left join avaliacao as a on (a.cd_agendamento = ag.cd_agendamento)
	where s.cd_servico = vCodigoServico
	ORDER BY si.ic_principal DESC;
end$$

-- Filtro de avaliação
-- Todas as avaliações
-- Avaliação positiva: 3, 4 ou 5 estrelas
-- Avaliação negativa: 1 ou 2 estrelas
drop procedure if exists ServicoSelecionadoTodasAsAvaliacaoEFiltro$$
create procedure ServicoSelecionadoTodasAsAvaliacaoEFiltro(vCodigoServico int, vFiltro int)
begin
 if (vFiltro) = 1 then 
	select distinct(a.cd_agendamento), date_format(a.dt_avaliacao, '%d/%m/%Y'), c.nm_usuario_cliente, a.vl_avaliacao, a.ds_avaliacao, f.nm_funcionario 
	from Avaliacao a 
	inner join agendamento ag on (ag.cd_servico = vCodigoServico)
	inner join Cliente c on (ag.nm_email_cliente = c.nm_email_cliente) 
	inner join funcionarioServico fs on (ag.cd_funcionario = fs.cd_funcionario) 
	inner join funcionario f on (fs.cd_funcionario = f.cd_funcionario)
	where a.cd_agendamento = ag.cd_agendamento and a.vl_avaliacao >= 3;
elseif (vFiltro) = 2 then 
	select distinct(a.cd_agendamento), date_format(a.dt_avaliacao, '%d/%m/%Y'), c.nm_usuario_cliente, a.vl_avaliacao, a.ds_avaliacao, f.nm_funcionario 
	from Avaliacao a 
	inner join agendamento ag on (ag.cd_servico = vCodigoServico)
	inner join Cliente c on (ag.nm_email_cliente = c.nm_email_cliente) 
	inner join funcionarioServico fs on (ag.cd_funcionario = fs.cd_funcionario) 
	inner join funcionario f on (fs.cd_funcionario = f.cd_funcionario)
	where a.cd_agendamento = ag.cd_agendamento and a.vl_avaliacao < 3;
else
	Select distinct(a.cd_agendamento), date_format(a.dt_avaliacao, '%d/%m/%Y'), c.nm_usuario_cliente, a.vl_avaliacao, a.ds_avaliacao, f.nm_funcionario 
	from Avaliacao a 
	inner join agendamento ag on (ag.cd_servico = vCodigoServico)
	inner join Cliente c on (ag.nm_email_cliente = c.nm_email_cliente) 
	inner join funcionarioServico fs on (ag.cd_funcionario = fs.cd_funcionario) 
	inner join funcionario f on (fs.cd_funcionario = f.cd_funcionario)
	where a.cd_agendamento = ag.cd_agendamento;
  end if;
end$$

-- Dados mínimos do servico selecionado
drop procedure if exists DadosMinimosDoServicoSelecionado$$
create procedure DadosMinimosDoServicoSelecionado(vCodigoServico int)
begin
	Select s.cd_servico, s.nm_servico, s.vl_servico, ROUND(TIME_TO_SEC(s.hr_tempo_duracao) / 60), s.ds_servico, si.nm_imagem, si.nm_pasta_imagem, 
		(Select GROUP_CONCAT(f.nm_funcionario)
		from funcionarioServico AS fs
		inner join funcionario AS f ON fs.cd_funcionario = f.cd_funcionario
		where fs.cd_servico = s.cd_servico),
		(Select GROUP_CONCAT(f.cd_funcionario)
		from funcionarioServico AS fs
		inner join funcionario AS f ON fs.cd_funcionario = f.cd_funcionario
		where fs.cd_servico = s.cd_servico)
	from servico AS s
	inner join servicoimagem AS si ON si.cd_servico = s.cd_servico
	where s.cd_servico = vCodigoServico 
	AND si.ic_principal = true;
end$$

-- Filtrar os funcionários na tela de agendamento
drop procedure if exists FiltroDeFuncionariosDoServico$$ 
create procedure FiltroDeFuncionariosDoServico(vCodigoServico int, vCodFunc int, vDataSelec date, vTempoSelec varchar(45)) 
begin
	declare tempo time default null;
	declare nomedata varchar(45) default '';

	set tempo = convert(vTempoSelec, time);
	set nomedata = date_format(vDataSelec,'%W');

	if  vCodFunc = 0 && vTempoSelec = '0:0' then
		select fsd.cd_funcionario,f.nm_funcionario, group_concat(distinct(fsd.hr_funcionario_serviço_dia_de_trabalho)), d.cd_dia_trabalho 
		from funcionarioServicoDiaDeTrabalho fsd 
		inner join funcionarioServico fs on (fsd.cd_servico = fs.cd_servico) 
		inner join Funcionario f on (fsd.cd_funcionario = f.cd_funcionario) 
		inner join diaDeTrabalho d on (fsd.cd_dia_trabalho = d.cd_dia_trabalho) 
		where fsd.cd_servico = vCodigoServico 
		and d.nm_dia_de_trabalho = nomedata;
	else if  vCodFunc = 0 then
		select fsd.cd_funcionario, f.nm_funcionario, group_concat(distinct(fsd.hr_funcionario_serviço_dia_de_trabalho)), d.cd_dia_trabalho 
		from funcionarioServicoDiaDeTrabalho fsd 
		inner join funcionarioServico fs on (fsd.cd_servico = fs.cd_servico) 
		inner join Funcionario f on (fsd.cd_funcionario = f.cd_funcionario) 
		inner join diaDeTrabalho d on (fsd.cd_dia_trabalho = d.cd_dia_trabalho) 
		where fsd.cd_servico = vCodigoServico 
		and d.nm_dia_de_trabalho = nomedata
		and fsd.hr_funcionario_serviço_dia_de_trabalho = tempo;
	else if vTempoSelec = '0:0' then
		select distinct(fsd.cd_funcionario),f.nm_funcionario, group_concat(distinct(fsd.hr_funcionario_serviço_dia_de_trabalho)), d.cd_dia_trabalho 
		from funcionarioServicoDiaDeTrabalho fsd 
		inner join funcionarioServico fs on (fsd.cd_servico = fs.cd_servico) 
		inner join Funcionario f on (fsd.cd_funcionario = f.cd_funcionario) 
		inner join diaDeTrabalho d on (fsd.cd_dia_trabalho = d.cd_dia_trabalho) 
		where fsd.cd_servico = vCodigoServico 
		and d.nm_dia_de_trabalho = nomedata
		and f.cd_funcionario = vCodFunc;
	else
		select distinct(fsd.cd_funcionario), f.nm_funcionario, group_concat(distinct(fsd.hr_funcionario_Serviço_dia_de_trabalho)), d.cd_dia_trabalho 
		from funcionarioServicoDiaDeTrabalho fsd 
		inner join funcionarioServico fs on (fsd.cd_servico = fs.cd_servico) 
		inner join Funcionario f on (fsd.cd_funcionario = f.cd_funcionario) 
		inner join diaDeTrabalho d on (fsd.cd_dia_trabalho = d.cd_dia_trabalho) 
		where fsd.cd_servico = vCodigoServico 
		and d.nm_dia_de_trabalho = nomedata
		and f.cd_funcionario = vCodFunc 
		and fsd.hr_funcionario_Serviço_dia_de_trabalho = tempo;
	end if;
	end if;
	end if;
end$$

-- Data mais próxima sem agendamento, de um funcionário
drop function if exists DataMaisProximaSemAgendamentoFuncionario$$
create function DataMaisProximaSemAgendamentoFuncionario (vCodigoFuncionario int, vCodigoDiaDeTrabalho int, vCodigoServico int, vDataSelec date) returns date
begin
	declare dataProxima date default vDataSelec;
	declare agendado text default '2';
	
	REPEAT
	
	if (agendado = '2') then
		set agendado = '0';
	else
		Set vDataSelec = DATE_ADD(vDataSelec, INTERVAL 1 WEEK);
	end if;
	
	if exists (Select 1 from funcionarioServicoDiaDeTrabalho where cd_funcionario = vCodigoFuncionario and cd_dia_trabalho = vCodigoDiaDeTrabalho)
	then
		SELECT IFNULL(
			(
			SELECT 
			IF(
				GROUP_CONCAT(
					DISTINCT 
					CASE 
						WHEN EXISTS (
							SELECT 1
							FROM AGENDAMENTO AS a
							WHERE a.cd_funcionario = vCodigoFuncionario
							AND a.cd_dia_trabalho = vCodigoDiaDeTrabalho
							-- AND a.cd_servico = vCodigoServico
							-- AND a.hr_funcionario_serviço_dia_de_trabalho = ft.hr_funcionario_serviço_dia_de_trabalho
							AND 
								(a.hr_funcionario_serviço_dia_de_trabalho = ft.hr_funcionario_serviço_dia_de_trabalho
	
								OR 
								(a.hr_funcionario_serviço_dia_de_trabalho > ft.hr_funcionario_serviço_dia_de_trabalho 
								AND a.hr_funcionario_serviço_dia_de_trabalho < ADDTIME(ft.hr_funcionario_serviço_dia_de_trabalho, (select hr_tempo_duracao from servico where cd_servico = vCodigoServico)))

								OR 
								(ADDTIME(a.hr_funcionario_serviço_dia_de_trabalho, (select hr_tempo_duracao from servico where cd_servico = a.cd_servico)) > ft.hr_funcionario_serviço_dia_de_trabalho 
								AND ADDTIME(a.hr_funcionario_serviço_dia_de_trabalho, (select hr_tempo_duracao from servico where cd_servico = a.cd_servico)) < ADDTIME(ft.hr_funcionario_serviço_dia_de_trabalho, (select hr_tempo_duracao from servico where cd_servico = vCodigoServico))))
							AND a.dt_agendamento = vDataSelec
						) THEN '1'
						ELSE '0'
					END
					ORDER BY ft.hr_funcionario_serviço_dia_de_trabalho ASC
				) = '1',
				'1',
				'0'
			) AS agendamento_existe
		),'0'
		)
		into agendado
		from funcionario as f
		inner join funcionarioServico as fs on (f.cd_funcionario = fs.cd_funcionario)
		left join funcionarioServicoDiaDeTrabalho as ft on (f.cd_funcionario = ft.cd_funcionario)
		where fs.cd_servico = vCodigoServico and ft.cd_servico = vCodigoServico and f.cd_funcionario = vCodigoFuncionario and ft.cd_dia_trabalho = vCodigoDiaDeTrabalho;
	else 
		set agendado = '0';
	end if;

	UNTIL agendado = '0' END REPEAT;

	return date_format(vDataSelec,'%Y-%m-%d');
end$$

-- Listar dados mínimos para o agendamento
drop procedure if exists ListarDadosMinimosParaAgendar$$
create procedure ListarDadosMinimosParaAgendar(vCodigoServico int, vCodigoFuncionario int, vCodigoDiaDeTrabalho int, vDataSelec date)
begin
	IF vDataSelec < curdate() THEN
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'A data selecionada é anterior à data atual.';
	ELSEIF vDataSelec > DATE_ADD(vDataSelec, INTERVAL 1 YEAR) THEN
		SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'A data selecionada é maior que a data limite.';
    END IF;
	
	if vCodigoFuncionario is null then
		SELECT f.cd_funcionario, f.nm_funcionario, f.nm_imagem, f.nm_pasta_imagem,
		(
			SELECT GROUP_CONCAT(
				TIME_FORMAT(ftt.hr_funcionario_serviço_dia_de_trabalho, '%H:%i') 
				ORDER BY ftt.hr_funcionario_serviço_dia_de_trabalho ASC
			) AS horario
			FROM funcionarioServicoDiaDeTrabalho AS ftt 
			WHERE ftt.cd_funcionario = f.cd_funcionario 
			AND ftt.cd_dia_trabalho = vCodigoDiaDeTrabalho
			AND ftt.cd_servico = vCodigoServico
			AND if (vDataSelec = curdate(), ftt.hr_funcionario_serviço_dia_de_trabalho > curtime(), ftt.hr_funcionario_serviço_dia_de_trabalho)
		) AS horarios,
		(
			SELECT GROUP_CONCAT(distinct d.nm_dia_de_trabalho) 
			FROM diaDeTrabalho as d 
			INNER JOIN funcionarioServicoDiaDeTrabalho as ftt 
			WHERE d.cd_dia_trabalho = ftt.cd_dia_trabalho and ftt.cd_funcionario = f.cd_funcionario and ftt.cd_servico = vCodigoServico
			Order by d.cd_dia_trabalho
		) AS dias_de_trabalho,
		(
			SELECT GROUP_CONCAT(
				CASE 
					WHEN EXISTS (
					SELECT 1
					FROM AGENDAMENTO AS a
					WHERE a.cd_funcionario = ftt.cd_funcionario
					AND a.cd_dia_trabalho = vCodigoDiaDeTrabalho
					AND 
						(a.hr_funcionario_serviço_dia_de_trabalho = ftt.hr_funcionario_serviço_dia_de_trabalho
						OR 
						(a.hr_funcionario_serviço_dia_de_trabalho > ftt.hr_funcionario_serviço_dia_de_trabalho 
						AND a.hr_funcionario_serviço_dia_de_trabalho < ADDTIME(ftt.hr_funcionario_serviço_dia_de_trabalho, (select hr_tempo_duracao from servico where cd_servico = vCodigoServico)))
						OR 
						(ADDTIME(a.hr_funcionario_serviço_dia_de_trabalho, (select hr_tempo_duracao from servico where cd_servico = a.cd_servico)) > ftt.hr_funcionario_serviço_dia_de_trabalho 
						AND ADDTIME(a.hr_funcionario_serviço_dia_de_trabalho, (select hr_tempo_duracao from servico where cd_servico = a.cd_servico)) < ADDTIME(ftt.hr_funcionario_serviço_dia_de_trabalho, (select hr_tempo_duracao from servico where cd_servico = vCodigoServico))))	
					AND a.dt_agendamento = vDataSelec
				) THEN '1'
				ELSE '0'
			END
			ORDER BY ft.hr_funcionario_serviço_dia_de_trabalho ASC, ftt.hr_funcionario_serviço_dia_de_trabalho ASC
		) from funcionarioServicoDiaDeTrabalho as ftt
					WHERE ftt.cd_funcionario = f.cd_funcionario 
					AND ftt.cd_dia_trabalho = vCodigoDiaDeTrabalho
					AND ftt.cd_servico = vCodigoServico 
	) AS agendamento_existe,
		DataMaisProximaSemAgendamentoFuncionario(f.cd_funcionario, vCodigoDiaDeTrabalho, vCodigoServico,vDataSelec)
		FROM funcionario AS f
		INNER JOIN funcionarioServico AS fs ON (f.cd_funcionario = fs.cd_funcionario and fs.cd_servico = vCodigoServico)
		LEFT JOIN funcionarioServicoDiaDeTrabalho AS ft ON (f.cd_funcionario = ft.cd_funcionario and ft.cd_servico = vCodigoServico)
		WHERE 
			(
				EXISTS (
					SELECT 1
					FROM funcionarioServicoDiaDeTrabalho AS ftt 
					WHERE ftt.cd_funcionario = f.cd_funcionario 
					AND ftt.cd_dia_trabalho = vCodigoDiaDeTrabalho
					AND ftt.cd_servico = vCodigoServico
				)
				OR
				NOT EXISTS (
					SELECT 1
					FROM funcionarioServicoDiaDeTrabalho AS ftt 
					WHERE ftt.cd_dia_trabalho = vCodigoDiaDeTrabalho
					AND ftt.cd_servico = vCodigoServico
				)
			)
		AND fs.cd_servico = vCodigoServico
		GROUP BY f.cd_funcionario
		ORDER BY f.nm_funcionario;

	else 
		Select f.cd_funcionario, f.nm_funcionario, f.nm_imagem, f.nm_pasta_imagem,
		(Select group_concat(time_format(ftt.hr_funcionario_serviço_dia_de_trabalho, '%H:%i') order by ftt.hr_funcionario_serviço_dia_de_trabalho asc) as horario
		From funcionarioServicoDiaDeTrabalho as ftt 
		where ftt.cd_funcionario = f.cd_funcionario and ftt.cd_dia_trabalho = vCodigoDiaDeTrabalho and ftt.cd_servico = vCodigoServico
		AND if (vDataSelec = curdate(), ftt.hr_funcionario_serviço_dia_de_trabalho > curtime(), ftt.hr_funcionario_serviço_dia_de_trabalho)),
		group_concat(distinct d.nm_dia_de_trabalho),
		(
			SELECT GROUP_CONCAT(
				CASE 
					WHEN EXISTS (
					SELECT 1
					FROM AGENDAMENTO AS a
					WHERE a.cd_funcionario = ftt.cd_funcionario
					AND a.cd_dia_trabalho = vCodigoDiaDeTrabalho
					AND 
						(a.hr_funcionario_serviço_dia_de_trabalho = ftt.hr_funcionario_serviço_dia_de_trabalho
						OR 
						(a.hr_funcionario_serviço_dia_de_trabalho > ftt.hr_funcionario_serviço_dia_de_trabalho 
						AND a.hr_funcionario_serviço_dia_de_trabalho < ADDTIME(ftt.hr_funcionario_serviço_dia_de_trabalho, (select hr_tempo_duracao from servico where cd_servico = vCodigoServico)))
						OR 
						(ADDTIME(a.hr_funcionario_serviço_dia_de_trabalho, (select hr_tempo_duracao from servico where cd_servico = a.cd_servico)) > ftt.hr_funcionario_serviço_dia_de_trabalho 
						AND ADDTIME(a.hr_funcionario_serviço_dia_de_trabalho, (select hr_tempo_duracao from servico where cd_servico = a.cd_servico)) < ADDTIME(ft.hr_funcionario_serviço_dia_de_trabalho, (select hr_tempo_duracao from servico where cd_servico = vCodigoServico))))
					AND a.dt_agendamento = vDataSelec
				) THEN '1'
				ELSE '0'
			END
			ORDER BY ft.hr_funcionario_serviço_dia_de_trabalho ASC, ftt.hr_funcionario_serviço_dia_de_trabalho ASC
		) from funcionarioServicoDiaDeTrabalho as ftt
					WHERE ftt.cd_funcionario = f.cd_funcionario 
					AND ftt.cd_dia_trabalho = vCodigoDiaDeTrabalho
					AND ftt.cd_servico = vCodigoServico 
	) AS agendamento_existe,
	DataMaisProximaSemAgendamentoFuncionario(f.cd_funcionario, vCodigoDiaDeTrabalho, vCodigoServico,vDataSelec)
		From funcionario as f
		inner join funcionarioServico as fs on (f.cd_funcionario = fs.cd_funcionario and fs.cd_servico = vCodigoServico)
		left join funcionarioServicoDiaDeTrabalho as ft on (f.cd_funcionario = ft.cd_funcionario and ft.cd_servico = vCodigoServico)
		left join diaDeTrabalho as d on (ft.cd_dia_trabalho = d.cd_dia_trabalho and ft.cd_servico = vCodigoServico)
		where 
		fs.cd_servico = vCodigoServico
		and f.cd_funcionario = vCodigoFuncionario
		group by f.cd_funcionario;
	end if;
end$$

-- Gerar código aleatório do agendamento
Drop Function if exists GerarCodigoAleatorioAgendamento$$
Create Function GerarCodigoAleatorioAgendamento () returns varchar(7)
begin
	declare caracteres varchar(62) default 'A0B1C2D3E4F5G6H7I8J9K0L1M2N3O4P5Q6R7S8T9U0V1W2X3Y4Z56789';
	declare codigo varchar(10) default '';
	declare tamanho int default 7;
	DECLARE codigo_existente BOOL;

	REPEAT
		SET codigo = '';

		WHILE (tamanho > 0) do
			set codigo = concat(codigo, SUBSTRING(caracteres, FLOOR( 1 + rand() * 56),1));
			set tamanho = tamanho - 1;
		end while;

		Select exists (select * from agendamento where cd_agendamento = codigo) into codigo_existente;
	Until not codigo_existente END REPEAT;

	return codigo;
end$$

-- Pegar a temporada atual
drop function if exists TemporadaAtual$$
create function TemporadaAtual () returns int
begin
	declare temporada int default (Select (cd_temporada) From temporada order by ABS(TIMESTAMPDIFF(second, dt_termino_temporada, curdate())), cd_temporada LIMIT 1);
	return temporada;
end$$

-- Listar cupons do cliente
drop procedure if exists listarCuponsDoCliente$$
create procedure listarCuponsDoCliente(vEmail varchar(255), vCodServico int)
begin
	/*select distinct p.cd_cupom_desconto, c.vl_porcentagem_de_desconto from premio p 
	inner join cupomServico cs on (p.cd_cupom_desconto = cs.cd_cupom_desconto)
	inner join cupomDesconto c on (cs.cd_cupom_desconto = c.cd_cupom_desconto) 
	inner join premioCliente pc on (p.cd_premio = pc.cd_premio) 
	inner join temporada on (p.cd_temporada = TemporadaAtual())
	where pc.nm_email_cliente = vEmail and cs.cd_servico = vCodServico and not exists (select cd_cupom_desconto from agendamento where nm_email_cliente = vEmail and cd_servico = vCodServico);*/

	select distinct p.cd_premio, c.vl_porcentagem_de_desconto from premio p 
	left join cupomServico cs on (p.cd_cupom_desconto = cs.cd_cupom_desconto and p.cd_servico = vCodServico )
	left join cupomCategoriaDeServico ccs on (p.cd_cupom_desconto = ccs.cd_cupom_desconto and p.cd_categoria_servico = (select cc.cd_categoria_servico 
																							   from servico as s 
																							   join categoriadeservico as cc on (s.cd_categoria_servico = cc.cd_categoria_servico) 
																							   where s.cd_servico = vCodServico))
	inner join cupomDesconto c on (cs.cd_cupom_desconto = c.cd_cupom_desconto or ccs.cd_cupom_desconto = c.cd_cupom_desconto) 
	inner join premioCliente pc on (p.cd_premio = pc.cd_premio) 
	where pc.nm_email_cliente = vEmail 
	and p.cd_tipo_premio = 1
	and pc.ic_resgatado = false
	and not exists (select pc.cd_premio from agendamento where nm_email_cliente = vEmail and cd_servico = vCodServico);
end$$

-- Verificar se é correto o cupom escolhido
drop function if exists verificarPremio$$
create function verificarPremio(vEmail varchar(255), vCodServico int, vCodPremio int) returns bool
begin
	declare cupomEncontrado int;
	
	select count(cd_premio) into cupomEncontrado from premiocliente 
	where cd_premio = vCodPremio
	and nm_email_cliente = vEmail
	and vCodServico = (select cd_servico from premio where cd_premio = vCodPremio);

	if cupomEncontrado > 0 then
		return true;
	else
		return false;
	end if;
end$$

-- Efetuar agendamento
drop procedure if exists EfetuarAgendamento$$
create procedure EfetuarAgendamento(vCodServico int, vHoraSelec time, vEmailCliente varchar(45), vDataSelec date, vCodigoFuncionario int, vCodDiaTrabalho int, vCodCupom int)
begin
	declare horarios_time time default null;
	declare duracao_time time default null;
	declare duracao_time_servico_atual time default null;
	declare ic_agendamento_realizado bool default null;
	declare codigo_agendamento varchar(7) default GerarCodigoAleatorioAgendamento();

	declare parar int default 0;	

	declare horario cursor
	for  
		select a.hr_funcionario_serviço_dia_de_trabalho, s.hr_tempo_duracao, a.ic_presenca_cliente_agendamento
		from agendamento as a inner join servico as s on (a.cd_servico = s.cd_servico) 
		where a.nm_email_cliente = vEmailCliente and a.dt_agendamento = vDataSelec; 

	declare continue handler for not found
	set parar = 1;

	select hr_tempo_duracao into duracao_time_servico_atual
	from servico where cd_servico = vCodServico;

	Open horario;

	todos:loop
		fetch horario into horarios_time, duracao_time, ic_agendamento_realizado;

		if (parar = 1) then
			leave todos;
		end if;

		if (ic_agendamento_realizado is null) then
			if (vHoraSelec >= horarios_time && vHoraSelec < ADDTIME(horarios_time, duracao_time)) then
				Signal sqlstate '45000' set message_text = 'O Cliente já possui um agendamento que se inicia durante o período desse serviço.';
			elseif (ADDTIME(vHoraSelec, duracao_time_servico_atual) > horarios_time && ADDTIME(vHoraSelec, duracao_time_servico_atual) < ADDTIME(horarios_time, duracao_time)) then
				Signal sqlstate '45000' set message_text = 'O Cliente já possui um agendamento que o fim está durante o período desse serviço.';
			elseif (vHoraSelec < horarios_time && ADDTIME(vHoraSelec, duracao_time_servico_atual) > ADDTIME(horarios_time, duracao_time)) then
				Signal sqlstate '45000' set message_text = 'O Cliente já possui um agendamento que seu período sobrepõe-se inteiramente ao desse serviço.';
			elseif (vHoraSelec > horarios_time && ADDTIME(vHoraSelec, duracao_time_servico_atual) < ADDTIME(horarios_time, duracao_time)) then
				Signal sqlstate '45000' set message_text = 'O Cliente já possui um agendamento que é sobreposto interamente pelo período desse serviço.';
			end if;
		end if;
	
	end loop todos;

	Close horario;

	if (vCodCupom is not null)then
		if (verificarPremio(vEmailCliente,vCodServico,vCodCupom)) then
			Insert into agendamento values (codigo_agendamento, vDataSelec, null, null, vEmailCliente, vCodigoFuncionario, vCodServico, vHoraSelec, vCodDiaTrabalho, vCodCupom);
			update premioCliente
			set ic_resgatado = true
			where cd_premio = vCodCupom
			and nm_email_cliente = vEmailCliente
			and ic_resgatado = false;
		else
			Signal sqlstate '45000' set message_text = 'O cupom selecionado não existe.';
		end if;
	else
		Insert into agendamento values (codigo_agendamento, vDataSelec, null, null, vEmailCliente, vCodigoFuncionario, vCodServico, vHoraSelec, vCodDiaTrabalho, null);
	end if;
end$$

-- Gerar código aleatório de avaliação
Drop function if exists gerarCodigoAvaliacao$$
Create function gerarCodigoAvaliacao() returns int
begin
	Declare cdAvaliacao int default 0;
	Select max(cd_avaliacao) + 1 into cdAvaliacao from avaliacao;

	return cdAvaliacao;
end$$

-- Gerar código aleatório de funcionario
Drop function if exists gerarCodigoFuncionario$$
Create function gerarCodigoFuncionario() returns int
begin
	Declare cdFuncionario int default 0;
	Select max(cd_funcionario) + 1 into cdFuncionario from funcionario;

	return cdFuncionario;
end$$

-- Gerar código aleatório de serviço
Drop function if exists gerarCodigoServico$$
Create function gerarCodigoServico() returns int
begin
	Declare cdServico int default 0;
	Select max(cd_servico) + 1 into cdServico from servico;

	return cdServico;
end$$

Drop function if exists gerarCodigoCupomDesconto$$
Create function gerarCodigoCupomDesconto() returns int
begin
	Declare cdCupom int default 0;
	Select max(cd_cupom_desconto) + 1 into cdCupom from cupomDesconto;

	return cdCupom;
end$$

Drop function if exists gerarCodigoProduto$$
Create function gerarCodigoProduto() returns int
begin
	Declare cdProduto int default 0;
	Select max(cd_produto) + 1 into cdProduto from produto;

	return cdProduto;
end$$

-- Listar tipo premio no filtro
drop procedure if exists ListarTipoPremio$$
create procedure ListarTipoPremio()
begin
	select * from tipoPremio;
end$$

-- Pegar a pontuação atual do cliente
drop procedure if exists PegarPontuacaoCliente$$
create procedure PegarPontuacaoCliente(vLogin varchar(255))
begin
	if (vLogin is null)
	then
		select 0;
	else
		select qt_pontos_cliente from cliente where nm_email_cliente = vLogin;
	end if;
end$$

-- Listar os prêmios por algum filtro
-- Cupom: 1
-- Produto: 2
drop procedure if exists ListarPremiosPorFiltro$$
create procedure ListarPremiosPorFiltro(vFiltro text, vLogin varchar(255))
begin
 if vFiltro = "2" then
	select distinct p.cd_premio, p.nm_premio, p.qt_pontos_premio, ds_premio, p.nm_pasta_imagem, p.nm_imagem,
	(select (case when (vLogin is not null)
	then
			case when p.qt_pontos_premio > (select qt_pontos_cliente from cliente where nm_email_cliente = vLogin)
			or exists (select 1 from premioCliente where cd_premio = p.cd_premio and nm_email_cliente = vLogin)
			then
				false
			else
				true
			end
	else 
		false
	end)),
(select (case when (vLogin is not null)
	then
			case when exists (select 1 from premioCliente where cd_premio = p.cd_premio and nm_email_cliente = vLogin)
			then
				'Você já o possui'
			when p.qt_pontos_premio > (select qt_pontos_cliente from cliente where nm_email_cliente = vLogin) 
			then
				'Pontos insuficientes'
			else
				'Resgatar'
			end
	else
		'Pontos insuficientes'
	end))
	from Premio p  
	inner join produto as pr on (p.cd_produto = pr.cd_produto)
	where -- curdate() < t.dt_termino_temporada and
	p.cd_tipo_Premio = 2
	and p.nm_imagem is not null
	and p.nm_pasta_imagem is not null
	and p.ic_ativado = true
	and pr.qt_produto > 0;
elseif vFiltro = "1" then
	select distinct p.cd_premio, p.nm_premio, p.qt_pontos_premio, ds_premio,p.nm_pasta_imagem, p.nm_imagem,
	(select (case when (vLogin is not null)
	then
			case when p.qt_pontos_premio > (select qt_pontos_cliente from cliente where nm_email_cliente = vLogin)
			or exists (select 1 from premioCliente where cd_premio = p.cd_premio and nm_email_cliente = vLogin)
			then
				false
			else
				true
			end
	else
		false
	end)),
(select (case when (vLogin is not null)
	then
			case when exists (select 1 from premioCliente where cd_premio = p.cd_premio and nm_email_cliente = vLogin)
			then
				'Você já o possui'
			when p.qt_pontos_premio > (select qt_pontos_cliente from cliente where nm_email_cliente = vLogin) 
			then
				'Pontos insuficientes'
			else
				'Resgatar'
			end
	else
		'Pontos insuficientes'
	end))
	from Premio p  
	where -- curdate() < t.dt_termino_temporada  and
	p.cd_tipo_Premio = 1
	and p.nm_imagem is not null
	and p.nm_pasta_imagem is not null
	and p.ic_ativado = true;
else
	select distinct p.cd_premio, p.nm_premio, p.qt_pontos_premio, ds_premio,p.nm_pasta_imagem, p.nm_imagem,
	(select (case when (vLogin is not null)
	then
			case when p.qt_pontos_premio > (select qt_pontos_cliente from cliente where nm_email_cliente = vLogin)
			or exists (select 1 from premioCliente where cd_premio = p.cd_premio and nm_email_cliente = vLogin)
			then
				false
			else
				true
			end
	else
		false
	end)),
	(select (case when (vLogin is not null)
	then
			case when exists (select 1 from premioCliente where cd_premio = p.cd_premio and nm_email_cliente = vLogin)
			then
				'Você já o possui'
			when p.qt_pontos_premio > (select qt_pontos_cliente from cliente where nm_email_cliente = vLogin) 
			then
				'Pontos insuficientes'
			else
				'Resgatar'
			end
	else
		'Pontos insuficientes'
	end))
	from Premio p
	where p.nm_imagem is not null
	and p.nm_pasta_imagem is not null
	and p.ic_ativado = true
	and (p.cd_produto is null or (select pr.qt_produto from produto as pr where pr.cd_produto = p.cd_produto) > 0);
	-- where curdate() < t.dt_termino_temporada;
end if;
end$$
-- Dados mínimos do serviço específico
drop procedure if exists DadosMinimosPremioEspecifico$$
create procedure DadosMinimosPremioEspecifico(vCodigoPremio int)
begin
	declare tipo int default null;

	select cd_tipo_premio into tipo 
	from premio 
	where cd_premio = vCodigoPremio;

	if tipo = 1
	then
		select distinct p.cd_premio, p.nm_premio, p.qt_pontos_premio, p.ds_premio, p.nm_pasta_imagem, p.nm_imagem, 
		p.cd_tipo_premio, tp.nm_tipo_premio, s.nm_servico, c.nm_categoria_servico
		from Premio p
		left join cupomDesconto as cd on (p.cd_cupom_desconto = p.cd_cupom_desconto)
		left join servico as s on (p.cd_servico = s.cd_servico)
		left join categoriaDeServico c on (p.cd_categoria_servico = c.cd_categoria_servico)
		inner join tipoPremio tp on (p.cd_tipo_premio = tp.cd_tipo_premio)

		-- inner join Temporada t on(t.cd_temporada = TemporadaAtual())
		where -- curdate() < t.dt_termino_temporada and
		p.cd_premio = vCodigoPremio 
		and p.ic_ativado = true;
	elseif tipo = 2 
	then
		select distinct p.cd_premio, p.nm_premio, p.qt_pontos_premio, p.ds_premio, p.nm_pasta_imagem, p.nm_imagem, 
		p.cd_tipo_premio, tp.nm_tipo_premio
		from Premio p  
		inner join tipoPremio tp on (p.cd_tipo_premio = tp.cd_tipo_premio)
		-- inner join Temporada t on(t.cd_temporada = TemporadaAtual())
		where -- curdate() < t.dt_termino_temporada and
		p.cd_premio = vCodigoPremio
		and p.ic_ativado = true;
	end if;

end$$


drop procedure if exists RegistrarRecolhimentoDePremio$$
create procedure RegistrarRecolhimentoDePremio(vCodPremio int, /*vCodTemporada int,*/ vEmailCliente varchar(255))
begin
	declare pontosPremio int default (select qt_pontos_premio from premio where cd_premio = vCodPremio);
	declare pontosCliente int default (select qt_pontos_cliente from cliente where nm_email_cliente = vEmailCliente);

	if (pontosPremio > pontosCliente) then
		Signal sqlstate '45000' set message_text = 'Os pontos são insuficientes';
	else
		insert into  premioCliente values(vCodPremio,
			vEmailCliente, false);

		update cliente 
		set qt_pontos_cliente = qt_pontos_cliente - pontosPremio 
		where nm_email_cliente = vEmailCliente;
	end if;
end$$


-- Alterar senha do cliente
drop procedure if exists alterarSenhaDoCliente$$
create procedure alterarSenhaDoCliente(vSenhaAntiga varchar(45),vSenhaNova varchar(45), vEmailCliente varchar(255))
begin
	if exists(select * from Cliente where nm_email_cliente = vEmailCliente and nm_senha_cliente = md5(vSenhaAntiga)) then
		update Cliente set
		nm_senha_cliente = md5(vSenhaNova) 
		where nm_email_cliente = vEmailCliente;
	else
		Signal sqlstate '45000' set message_text = 'Não existe um cliente com essa senha';
end if;
end$$
	
-- Tela conta_cliente (futuramente alterar para ter um verificador de usuario)
drop procedure if exists alterarDadosDoCliente$$
create procedure alterarDadosDoCliente(vNovoNomeCliente varchar(45), vEmailCliente varchar(255))
begin
	update Cliente set
	nm_usuario_cliente = vNovoNomeCliente
	where nm_email_cliente = vEmailCliente;
end$$

-- tela agendamentos
drop procedure if exists ListarAgendamentosCliente$$
create procedure ListarAgendamentosCliente(vEmailCliente varchar(255))
begin
select s.nm_servico, a.cd_funcionario, a.cd_agendamento, date_format(a.dt_agendamento,'%d/%m/%Y'), a.hr_funcionario_Serviço_dia_de_trabalho from Agendamento a inner join Servico s on(s.cd_servico = a.cd_servico) 
where nm_email_cliente = vEmailCliente order by a.dt_agendamento;
end$$

-- tela agendamento_mais_detalhes ver com o grupo
drop procedure if exists MaisDetalhesDoAgendamento$$
create procedure MaisDetalhesDoAgendamento(vcpfFuncionario varchar(45),vEmailCliente varchar(255), vCodAgendamento int)
begin
select s.nm_servico, f.nm_funcionario, a.cd_agendamento, date_format(a.dt_agendamento,'%d/%m/%Y'), a.hr_funcionario_Serviço_dia_de_trabalho from Agendamento a inner join Servico s on(s.cd_servico = a.cd_servico)
inner join Funcionario f on (f.cd_funcionario = a.cd_funcionario) where nm_email_cliente = vEmailCliente and a.cd_funcionario = vcpfFuncionario and a.cd_agendamento = vCodAgendamento;
end$$

-- tela recompensas_conta adcionar descriçao dos premios
drop procedure if exists listarPremiosResgatados$$
create procedure listarPremiosResgatados(vEmailCliente varchar(255))
begin
select distinct(pc.cd_premio), p.nm_premio from premioCliente pc inner join premio p on(p.cd_premio = pc.cd_premio) where nm_email_cliente = vEmailCliente;
end$$

drop procedure if exists listarPremiosResgatadosFiltrados$$
create procedure listarPremiosResgatadosFiltrados(vEmailCliente varchar(255), vProduto bool)
begin
if vProduto = true then
 select distinct(pc.cd_premio), p.nm_premio from  premioCliente pc inner join Premio p on(p.cd_premio = pc.cd_premio) where nm_email_cliente = vEmailCliente
and p.cd_tipo_Premio = 2;
else
select distinct(pc.cd_premio), p.nm_premio from  premioCliente pc inner join Premio p on(p.cd_premio = pc.cd_premio) where nm_email_cliente = vEmailCliente
and p.cd_tipo_Premio = 1;
end if;
end$$

-- tela redefinir senha
drop procedure if exists redefinirSenha$$
create procedure redefinirSenha(vEmailCliente varchar(255), vNovaSenhaCliente varchar(45))
begin
update Cliente set
nm_senha_cliente = vSenhaNova where
nm_email_cliente = vEmailCliente;
end$$

/*---Procedure da tela de agendamentos*/

Drop procedure if exists listarDadosMinimosAgendamentos$$
Create procedure listarDadosMinimosAgendamentos(pEmailCliente varchar (255), pFiltroAgendamento text)
begin
	if pFiltroAgendamento = 'todos' then
		select s.nm_servico, DATE_FORMAT(a.dt_agendamento, '%d/%m/%Y'), TIME_FORMAT(a.hr_funcionario_serviço_dia_de_trabalho, '%H:%i'),
		(select
			(case 
			when (ic_presenca_funcionario_agendamento is null and ic_presenca_cliente_agendamento is null) then
					'Em andamento'
			when (ic_presenca_funcionario_agendamento = false or ic_presenca_cliente_agendamento = false) then
					'Cancelado'
			when (ic_presenca_funcionario_agendamento = true and ic_presenca_cliente_agendamento = true) then
					'Concluído'
			else 'Erro ao mostrar agendamentos.'
			end
			)
		), sc.nm_pasta_imagem, sc.nm_imagem, a.cd_agendamento
		from agendamento as a inner join servico as s on (s.cd_servico = a.cd_servico) 
		inner join servicoimagem as sc on (sc.cd_servico = a.cd_servico)
		where a.nm_email_cliente = pEmailCliente and sc.ic_principal = true; 

		elseif pFiltroAgendamento = 'em andamento' then
			select s.nm_servico, DATE_FORMAT(a.dt_agendamento, '%d/%m/%Y'), TIME_FORMAT(a.hr_funcionario_serviço_dia_de_trabalho, '%H:%i'), 'Em andamento', sc.nm_pasta_imagem, sc.nm_imagem, a.cd_agendamento
			from agendamento as a inner join servico as s on (s.cd_servico = a.cd_servico)
			inner join servicoimagem as sc on (sc.cd_servico = a.cd_servico)
			where a.nm_email_cliente = pEmailCliente 
			and sc.ic_principal = true 
			and a.ic_presenca_funcionario_agendamento is null
			and a.ic_presenca_cliente_agendamento is null 
			and sc.ic_principal = true;

		elseif pFiltroAgendamento = 'cancelados' then
			select s.nm_servico, DATE_FORMAT(a.dt_agendamento, '%d/%m/%Y'), TIME_FORMAT(a.hr_funcionario_serviço_dia_de_trabalho, '%H:%i'), 'Cancelado', sc.nm_pasta_imagem, sc.nm_imagem, a.cd_agendamento
			from agendamento as a inner join servico as s on (s.cd_servico = a.cd_servico) 
			inner join servicoimagem as sc on (sc.cd_servico = a.cd_servico)
			where a.nm_email_cliente = pEmailCliente 
			and sc.ic_principal = true
			and a.ic_presenca_funcionario_agendamento = false
			or a.ic_presenca_cliente_agendamento = false
			and sc.ic_principal = true;

		elseif pFiltroAgendamento = 'concluidos' then
			select s.nm_servico, DATE_FORMAT(a.dt_agendamento, '%d/%m/%Y'), TIME_FORMAT(a.hr_funcionario_serviço_dia_de_trabalho, '%H:%i'), 'Concluído', sc.nm_pasta_imagem, sc.nm_imagem, a.cd_agendamento
			from agendamento as a inner join servico as s on (s.cd_servico = a.cd_servico)  
			inner join servicoimagem as sc on (sc.cd_servico = a.cd_servico)
			where a.nm_email_cliente = pEmailCliente 
			and sc.ic_principal = true
			and a.ic_presenca_funcionario_agendamento = true
			and a.ic_presenca_cliente_agendamento = true
			and sc.ic_principal = true;

		else
			Select 'Inválido';	
	end if;
end$$

drop function if exists verificarAvaliacaoCliente$$
create function verificarAvaliacaoCliente(vCodigoAgendamento varchar(45)) returns bool
begin
	if exists (select 1 from avaliacao where cd_agendamento = vCodigoAgendamento) then
		return true;
	else
		return false;
	end if;
end$$


drop function if exists verificarSituacaoAgendamento$$
create function verificarSituacaoAgendamento(vCodigoAgendamento varchar(45)) returns bool
begin
	if exists (select 1 from avaliacao where cd_agendamento = vCodigoAgendamento) then
		return true;
	else
		return false;
	end if;
end$$

Drop procedure if exists listarMaisDetalhesAgendamento$$
Create procedure listarMaisDetalhesAgendamento(pEmailCliente varchar (255), pCodigoAgendamento varchar (45))
begin
	Select s.nm_servico, DATE_FORMAT(a.dt_agendamento, '%d/%m/%Y'), TIME_FORMAT(a.hr_funcionario_serviço_dia_de_trabalho, '%H:%i'), 
	f.nm_funcionario, if (a.ic_presenca_funcionario_agendamento is null, '-', if (a.ic_presenca_funcionario_agendamento, 'Presente', 'Ausente')), 
	if (a.ic_presenca_cliente_agendamento is null, '-', if (a.ic_presenca_cliente_agendamento, 'Presente', 'Ausente')),
	sc.nm_pasta_imagem, sc.nm_imagem, a.cd_agendamento, verificarAvaliacaoCliente(pCodigoAgendamento),

	CASE
        WHEN a.ic_presenca_funcionario_agendamento IS NULL AND a.ic_presenca_cliente_agendamento IS NULL THEN 'Em andamento'
        WHEN a.ic_presenca_funcionario_agendamento = TRUE AND a.ic_presenca_cliente_agendamento = TRUE THEN 'Concluído'
        WHEN a.ic_presenca_funcionario_agendamento = FALSE OR a.ic_presenca_cliente_agendamento = FALSE THEN 'Cancelado'
    END AS situacao 

	from agendamento as a
	join servico s on (a.cd_servico = s.cd_Servico)
	join funcionario f on (a.cd_funcionario = f.cd_funcionario)
	join servicoimagem as sc on (sc.cd_servico = a.cd_servico)
	where a.cd_agendamento = pCodigoAgendamento and sc.ic_principal = true;
end$$

Drop procedure if exists listarProdutosDoAgendamento$$
Create procedure listarProdutosDoAgendamento(pCodigoAgendamento varchar (45))
begin
	select p.nm_produto as nmproduto, pa.qt_produto as qtproduto 
	from produtoagendamento as pa
	inner join produto as p on (p.cd_produto = pa.cd_produto) 
	where pa.cd_agendamento = pCodigoAgendamento;
end$$

Drop procedure if exists cancelarAgendamento$$
Create procedure cancelarAgendamento(pEmailCliente varchar(255), pCodAgendamento varchar (45))
begin
	Update agendamento 	
	set ic_presenca_funcionario_agendamento = false,
	ic_presenca_cliente_agendamento = false
	where cd_agendamento = pCodAgendamento
	and nm_email_cliente = pEmailCliente;
end$$

Drop procedure if exists AvaliarServico$$
Create procedure AvaliarServico(pCodAgendamento varchar(45), pEmailCliente varchar(45), 
	pQtdEstrelas int, pDescricao varchar(450))
begin
	Insert into avaliacao values (pCodAgendamento, pEmailCliente, pQtdEstrelas, pDescricao, curdate());
end$$

/*drop procedure if exists DeletarServico$$
create procedure DeletarServico (vCodServico int)
begin
	update servico 
	set ic_ativado = false
	where cd_servico = vCodServico;

	if not exists (select * from agendamento where cd_servico = vCodServico)
	then	
		
	end if;
end$$*/





/* Fim telas do Cliente*/

/*---------Início das procedures da dona---------*/

	/*Procedures da Sara*/
	drop procedure if exists listarProdutosEstoque$$
	create procedure listarProdutos(vCodigoP int)
	begin
	select cd_produto, nm_produto from Produto order by cd_produto;
	end$$
	
	drop procedure if exists cadastrarProdutoEstoque$$
	create procedure cadastrarProduto(vCodigo int, vNome varchar(45), vDescricao varchar(255))
	begin
	insert into produto values (gerarCodigoProduto(),vCodigo, vNome, vDescricao);
	end$$
	
	drop procedure if exists deletarProdutoEstoque$$
	create procedure deletarProduto(vCodigoProduto int)
	begin
	delete from produto where cd_produto = vCodigoProduto ;
	end$$

	drop procedure if exists buscarProdutoEstoque$$
	create procedure buscarProdutoEstoque(vNome varchar(45))
	begin
	select nm_produto from produto where nm_produto = vNome;
	end$$
	
	drop procedure if exists buscarProdutoEstoqueCod$$
	create procedure buscarProdutoEstoqueCod(vCodigo int)
	begin
	select cd_produto from produto where cd_produto = vCodigo;
	end$$


	drop procedure if exists dadosGeraisProduto$$
	create procedure dadosGeraisProduto()
	begin
	select * from produto order by cd_produto;
	end$$

	drop procedure if exists buscarFuncionario$$
	create procedure listarFuncionario(vCod int)
	begin
	select cd_funcionario, nm_funcionario, nm_email_funcionario from funcionario where nm_funcionario = vCod order by nm_funcionario;
	end$$

	drop procedure if exists listarTodosFuncionarios$$
	create procedure listarTodosFuncionarios()
	begin
	select * from funcionario order by cd_funcionario;
	end$$

	drop procedure if exists deletarFuncionario$$
	create procedure deletarFuncionario(vCod int)
	begin
	delete from funcionario where cd_funcionario = vCod;
	end$$

	drop procedure if exists dadosGeraisFuncionario$$
	create procedure dadosGeraisFuncionario(vCod varchar(11))
	begin
	select nm_funcionario, dt_nascimento_funcionario, cd_funcionario, nm_telefone_funcionario, nm_email_funcionario
	from funcionario where cd_funcionario = vCod order by cd_funcionario;
	end$$

	drop procedure if exists cadastrarFuncionario$$
	create procedure cadastrarFuncionario(vNome varchar(45), vTipo int, vEmail varchar(255), vSenha varchar(45), vNmImagem varchar(255))
	begin
		if vNmImagem is not null 
		then
			insert into imagem 
			values (vNmImagem,'Funcionarios');
		end if;

		insert into funcionario
		values (gerarCodigoFuncionario(), vTipo, vNome, vEmail, vSenha, vNmImagem, 'Funcionarios', true);
	end$$

	drop procedure if exists cadastrarProduto$$
	create procedure cadastrarProduto(vNome varchar(45), vQuantidade int,  vDescricao varchar(255), vCodigoTipoProduto int)
	begin
		insert into produto values (vCodigo, vNome, vQuantidade, vDescricao, vCodigoTipoProduto);
	end$$

	drop procedure if exists criarCupomDesconto$$
	create procedure criarCupomDesconto(vCodigo int)
	begin
	insert into cupom_desconto(cd_cupom_desconto) values (vCodigo);
	end$$

	drop procedure if exists cadastrarCategoria$$
	create procedure cadastrarCategoria(vCodigo int, vNome varchar(45))
	begin
	insert into categoriaservico (cd_categoria_servico, nm_categoria_servico) values (vCodigo, vNome);
	end$$

	drop procedure if exists adicionarServico$$
	create procedure adicionarServiço(vCodigoCategoria int, vNomeCategoria varchar(45))
	begin
	insert into categoriadeservico(cd_categoria_servico, nm_categoria_servico) values (vCodigoCategoria, vNomeCategoria);
	end$$

	drop procedure if exists dadosServicoPopUp$$
	create procedure dadosServicoPopUp(vCodigo int)
	begin
	select nm_servico, cd_categoria_servico, ds_servico, vl_servico, hr_tempo_duracao from servico where cd_servico = vCodigo;
	end$$

	drop procedure if exists dadosAgendamento$$
	create procedure dadosDescricaoAgendamento(vCodigo int)
	begin
	select cd_agendamento, dt_agendamento, nm_email_cliente, cd_funcionario, hr_funcionario_serviço_dia_de_trabalho, ic_presenca_funcionario_agendamento from agendamento where cd_agendamento = vCodigo;
	end$$

	drop procedure if exists listarAgendamentosCliente$$
	create procedure listarAgendamentosCliente()
	begin
	select * from agendamento;
	end$$
	/*Fim das procedures da Sara*/

/* Procedures das telas de DONA_AGENDA */

Drop procedure if exists listarNomeECodigoFuncionario$$
Create procedure listarNomeECodigoFuncionario()
begin
	select cd_funcionario, nm_funcionario 
	from funcionario
	order by nm_funcionario;
end$$

Drop procedure if exists listarAgendamentosPorSemana$$
Create procedure listarAgendamentosPorSemana(vDataSelec date, vCodFuncionario int)
begin
	select a.cd_agendamento, s.nm_servico, -- SUBSTRING_INDEX(c.nm_usuario_cliente, ' ', 1) as primeiro_nome, 
	TIME_FORMAT(a.hr_funcionario_serviço_dia_de_trabalho, '%H:%i'), 
	round(time_to_sec(s.hr_tempo_duracao) / 60),
	dt_agendamento,
	if (a.ic_presenca_funcionario_agendamento is not null 
	and a.ic_presenca_funcionario_agendamento is not null, 
	true, false)
	from agendamento as a
	inner join servico as s on (a.cd_servico = s.cd_servico)
	inner join cliente as c on (a.nm_email_cliente = c.nm_email_cliente)
	where dt_agendamento >= vDataSelec and dt_agendamento <= date_add(vDataSelec, interval 1 week) and cd_funcionario = vCodFuncionario
	order by dt_agendamento, a.hr_funcionario_serviço_dia_de_trabalho;
end$$

drop procedure if exists ListarTodosAgendamentosPorDia$$
create procedure ListarTodosAgendamentosPorDia (vDataSelec date)
begin
			select f.nm_funcionario, group_concat(a.cd_agendamento order by a.hr_funcionario_serviço_dia_de_trabalho), group_concat(s.nm_servico order by a.hr_funcionario_serviço_dia_de_trabalho), -- SUBSTRING_INDEX(cnm_usuario_cliente, ' ', 1) as primeiro_nome, 
	group_concat(TIME_FORMAT(a.hr_funcionario_serviço_dia_de_trabalho, '%H:%i') order by a.hr_funcionario_serviço_dia_de_trabalho), 
	group_concat(round(time_to_sec(s.hr_tempo_duracao) / 60) order by a.hr_funcionario_serviço_dia_de_trabalho),
	group_concat(if (a.ic_presenca_funcionario_agendamento is not null 
	and a.ic_presenca_funcionario_agendamento is not null, 
	true, false) order by a.hr_funcionario_serviço_dia_de_trabalho)
	from agendamento as a
	inner join servico as s on (a.cd_servico = s.cd_servico)
	inner join funcionario as f on (a.cd_funcionario = f.cd_funcionario)
	-- inner join cliente as c on (a.nm_email_cliente = c.nm_email_cliente)
	where dt_agendamento = vDataSelec
	or timestamp(a.dt_agendamento, a.hr_funcionario_serviço_dia_de_trabalho) + interval TIME_TO_SEC(s.hr_tempo_duracao) SECOND
        = vDataSelec
	or (
        a.dt_agendamento >= vDataSelec
        and timestamp(a.dt_agendamento, a.hr_funcionario_serviço_dia_de_trabalho) + interval TIME_TO_SEC(s.hr_tempo_duracao) second <= vDataSelec
    )
    or (
        a.dt_agendamento <= vDataSelec
        and timestamp(a.dt_agendamento, a.hr_funcionario_serviço_dia_de_trabalho) + interval TIME_TO_SEC(s.hr_tempo_duracao) second >= vDataSelec
    )
	group by f.nm_funcionario
	order by f.nm_funcionario, a.hr_funcionario_serviço_dia_de_trabalho;
	
end$$

Drop procedure if exists DadosAgendamentoEspecifico$$
Create procedure DadosAgendamentoEspecifico(vCodAgendamento varchar(45))
begin
	select a.cd_agendamento, 
	DATE_FORMAT(a.dt_agendamento, '%Y-%m-%d'),
	TIME_FORMAT(a.hr_funcionario_serviço_dia_de_trabalho, '%H:%i'),
	c.nm_usuario_cliente, a.nm_email_cliente, 
	f.nm_funcionario, s.nm_servico,
	cp.vl_porcentagem_de_desconto,
	a.ic_presenca_cliente_agendamento,
	a.ic_presenca_funcionario_agendamento,
	if (a.ic_presenca_funcionario_agendamento is not null 
	and a.ic_presenca_funcionario_agendamento is not null, 
	true, false),
	s.vl_servico,
	if(cp.cd_cupom_desconto is not null,
          (s.vl_servico - (s.vl_servico * cp.vl_porcentagem_de_desconto / 100)),
          s.vl_servico),
	if (current_time() < a.hr_funcionario_serviço_dia_de_trabalho and curdate() <= a.dt_agendamento or curdate() < a.dt_agendamento, false, true) 
	from agendamento as a
	inner join cliente as c on (a.nm_email_cliente = c.nm_email_cliente)
	inner join funcionario as f on (a.cd_funcionario = f.cd_funcionario)
	inner join servico as s on (a.cd_servico = s.cd_servico)
	left join premio as p on (a.cd_premio = p.cd_premio)
	left join cupomdesconto as cp on (p.cd_cupom_desconto = cp.cd_cupom_desconto)
	where a.cd_agendamento = vCodAgendamento;
end$$

Drop procedure if exists ConfirmarAgendamento$$
Create procedure ConfirmarAgendamento(vCodAgendamento varchar(45),vPresencaFuncionario bool, vPresencaCliente bool)
begin
	declare vPontosServico int default null;

	update agendamento
	set ic_presenca_funcionario_agendamento = vPresencaFuncionario,
	ic_presenca_cliente_agendamento = vPresencaCliente
	where cd_agendamento = vCodAgendamento;

	if (vPresencaFuncionario = true and vPresencaCliente = true)
	then 
		set vPontosServico = (select s.qt_pontos from agendamento as a inner join servico as s on (a.cd_servico = s.cd_servico) where a.cd_agendamento = vCodAgendamento);

		update cliente
		set qt_pontos_cliente = qt_pontos_cliente + vPontosServico
		where nm_email_cliente = (select nm_email_cliente from agendamento where cd_agendamento = vCodAgendamento);
	end if;
end$$

Drop procedure if exists VerificarProdutoAgendamento$$
Create procedure VerificarProdutoAgendamento(vCodProduto int, vCodAgendamento varchar(45), vQtProduto int)
begin
	if ((select qt_produto from produto where cd_produto = vCodProduto) - vQtProduto) < 1
	then
		Signal sqlstate '45000' set message_text = 'Há indisponibilidade de produtos, provavelmente houve um erro na contagem de estoque. Contate o gerente, por favor.';	
	end if;
end$$

Drop procedure if exists AdicionarProdutoAgendamento$$
Create procedure AdicionarProdutoAgendamento(vCodProduto int, vCodAgendamento varchar(45), vQtProduto int)
begin
	Insert into produtoagendamento values (vCodProduto, vCodAgendamento, vQtProduto);

	Update produto 
	set qt_produto = qt_produto - vQtProduto
	where cd_produto = vCodProduto;
end$$

Drop procedure if exists ConfirmarTipoProduto$$
Create procedure ConfirmarTipoProduto(vCodProduto int)
begin
	select cd_tipo_produto from produto where cd_produto = vCodProduto;
end$$

Drop procedure if exists excluirFuncionarioServicoDiaDeTrabalho$$
Create procedure excluirFuncionarioServicoDiaDeTrabalho(pCodFuncionario int, pCodServico int, pHora time,  pCodDiaTrabalho int)
begin
    if exists(select 1 from agendamento where 
                cd_funcionario = pCodFuncionario and
                cd_servico = pCodServico and
                hr_funcionario_serviço_dia_de_trabalho = pHora and
                cd_dia_trabalho = pCodDiaTrabalho
				and ic_presenca_funcionario_agendamento is not null 
				and ic_presenca_cliente_agendamento is not null)
    then	
        if exists (select 1 from funcionarioservicodiadetrabalho
                    where cd_funcionario = pCodFuncionario and
                    cd_servico = pCodServico and
                    hr_funcionario_serviço_dia_de_trabalho = pHora and
                    cd_dia_trabalho = pCodDiaTrabalho and
                    ic_ativado = false)
        then
            Delete from funcionarioservicodiadetrabalho 
            where cd_funcionario = pCodFuncionario and
            cd_servico = pCodServico and
            hr_funcionario_serviço_dia_de_trabalho = pHora and
            cd_dia_trabalho = pCodDiaTrabalho and
            ic_ativado = true;
        else
            update funcionarioservicodiadetrabalho set ic_ativado = false 
            where cd_funcionario = pCodFuncionario and
            cd_servico = pCodServico and
            hr_funcionario_serviço_dia_de_trabalho = pHora and
            cd_dia_trabalho = pCodDiaTrabalho;
        end if;
    else
		if exists (select 1 from premiocliente as pc inner join agendamento as a on (pc.cd_premio = a.cd_premio)
														where a.cd_funcionario = pCodFuncionario and
														a.cd_servico = pCodServico and
														a.hr_funcionario_serviço_dia_de_trabalho = pHora and
														a.cd_dia_trabalho = pCodDiaTrabalho
														and a.ic_presenca_funcionario_agendamento is null 
														and a.ic_presenca_cliente_agendamento is null)
		then
			update premiocliente 
			set ic_resgatado = false
			where cd_premio = (select a.cd_premio from agendamento as a
								where a.cd_funcionario = pCodFuncionario and
								a.cd_servico = pCodServico and
								a.hr_funcionario_serviço_dia_de_trabalho = pHora and
								a.cd_dia_trabalho = pCodDiaTrabalho
								and a.ic_presenca_funcionario_agendamento is null 
								and a.ic_presenca_cliente_agendamento is null);
		end if;

		Delete from agendamento 
        where cd_funcionario = pCodFuncionario and
        cd_servico = pCodServico and
        hr_funcionario_serviço_dia_de_trabalho = pHora and
        cd_dia_trabalho = pCodDiaTrabalho
		and ic_presenca_funcionario_agendamento is null 
		and ic_presenca_cliente_agendamento is null;

        Delete from funcionarioservicodiadetrabalho 
        where cd_funcionario = pCodFuncionario and
        cd_servico = pCodServico and
        hr_funcionario_serviço_dia_de_trabalho = pHora and
        cd_dia_trabalho = pCodDiaTrabalho;
    end if;
end$$


drop procedure if exists adicionarFuncionarioServicoDiaDeTrabalho$$
create procedure adicionarFuncionarioServicoDiaDeTrabalho (pCodFuncionario int, pCodServico int, pHora time,  pCodDiaTrabalho int)
begin
	
	if exists (Select 1 from funcionarioservicodiadetrabalho 
			  where cd_servico = pCodServico and
			  cd_funcionario = pCodFuncionario and
			  cd_dia_trabalho = pCodDiaTrabalho and
			  hr_funcionario_serviço_dia_de_trabalho = pHora and
			  ic_ativado = true)
	then
		Signal sqlstate '45000' set message_text = 'Já existe um horário como esse.';
	else
		if exists (Select 1 from funcionarioservicodiadetrabalho 
			  where cd_servico = pCodServico and
			  cd_funcionario = pCodFuncionario and
			  cd_dia_trabalho = pCodDiaTrabalho and
			  hr_funcionario_serviço_dia_de_trabalho = pHora and
			  ic_ativado = false)
		then
			update funcionarioservicodiadetrabalho 
			set ic_ativado = true 
			where cd_servico = pCodServico and 
			cd_funcionario = pCodFuncionario and
			cd_dia_trabalho = pCodDiaTrabalho and
			hr_funcionario_serviço_dia_de_trabalho = pHora and
			ic_ativado = false;
		else
			insert into funcionarioservicodiadetrabalho values (pCodDiaTrabalho, pHora, pCodFuncionario, pCodServico, true);
		end if;
	end if;
	/*declare duracaoServico time;
	select hr_tempo_duracao into duracaoServico from servico where cd_servico = pCodServico;

	if exists (Select hr_funcionario_serviço_dia_de_trabalho from funcionarioservicodiadetrabalho 
	where cd_servico = pCodServico and
	hr_funcionario_serviço_dia_de_trabalho between pHora and ADDTIME(pHora, duracaoServico))
	then
		Signal sqlstate '45000' set message_text = 'Já.';
	end if;*/
end$$ 

/* Procedures da tela de DONA_SERVICOS */

Drop procedure if exists listarDadosMinimosServicos$$
Create procedure listarDadosMinimosServicos()
begin
	Select s.cd_servico as cdservico, s.nm_servico as nmservico, cs.nm_categoria_servico as nmcategoria, 
	concat('R$', format(s.vl_servico, 2, 'de_DE')) as vlservico from servico s
	join categoriadeservico cs on (s.cd_categoria_servico = cs.cd_categoria_servico)
	order by cs.nm_categoria_servico, s.nm_servico; 
end$$

Drop procedure if exists filtrarServicos$$
Create procedure filtrarServicos(pFiltroServico varchar (50))
begin
	Select s.cd_servico as cdservico, s.nm_servico as nmservico, cs.nm_categoria_servico as nmcategoria, 
	concat('R$', format(s.vl_servico, 2, 'de_DE')) as vlservico, time_format(s.hr_tempo_duracao, '%H:%i') as duracao from servico s
	join categoriadeservico cs on (s.cd_categoria_servico = cs.cd_categoria_servico)
	where s.cd_servico = pFiltroServico or cs.nm_categoria_servico like pFiltroServico or s.nm_Servico like pFiltroServico;
end$$

Drop procedure if exists MostrarDadosServicoEspecifico$$
Create procedure MostrarDadosServicoEspecifico(pCodServico int)
begin
	Select s.cd_servico, s.nm_servico, cs.cd_categoria_servico, cs.nm_categoria_servico, 
	s.vl_servico, time_format(s.hr_tempo_duracao, '%H:%i'), s.ds_servico, s.qt_pontos,
	group_concat(si.nm_pasta_imagem order by si.ic_principal desc), group_concat(si.nm_imagem order by si.ic_principal desc) 
	from servico s
	join categoriadeservico cs on (s.cd_categoria_servico = cs.cd_categoria_servico)
	left join servicoimagem si on (si.cd_servico = s.cd_servico) 
	where s.cd_servico = pCodServico;
end$$

Drop procedure if exists DeletarServicoImagem$$
Create procedure DeletarServicoImagem (pCodServico int, pPastaImagem varchar(255), pNomeImagem varchar(255))
begin
    Delete from servicoimagem where nm_imagem = pNomeImagem and nm_pasta_imagem = pPastaImagem and pCodServico = cd_servico;
    Delete from imagem where nm_imagem = pNomeImagem and nm_pasta_imagem = pPastaImagem;
end$$

Drop procedure if exists DefinirImagemServicoPrincipal$$
Create procedure DefinirImagemServicoPrincipal (pCodServico int, pPastaImagem varchar(255), pNomeImagem varchar(255))
begin
    Update servicoimagem
    set ic_principal = false
    where ic_principal = true
    and cd_servico = pCodServico;

    Update servicoimagem 
    set ic_principal = true
    where nm_imagem = pNomeImagem and
    nm_pasta_imagem = pPastaImagem and
    cd_servico = pCodServico;
end$$

Drop procedure if exists AdicionarServicoImagem$$
Create procedure AdicionarServicoImagem(pCodServico int, pPastaImagem varchar(255), pNomeImagem varchar(255))
begin
	if not exists (select 1 from imagem where nm_pasta_imagem = pPastaImagem and nm_imagem = pNomeImagem)
	then
		Insert into imagem
		values (pNomeImagem, pPastaImagem);

		if not exists (select 1 from servicoimagem where cd_servico = pCodServico and ic_principal = true)
		then
			Insert into servicoimagem
			values (pNomeImagem, pPastaImagem, pCodServico, true);
		else
			Insert into servicoimagem
			values (pNomeImagem, pPastaImagem, pCodServico, false);
		end if;
	else
		Signal sqlstate '45000' set message_text = 'Já há uma imagem com o mesmo nome.';
	end if;
end$$

drop procedure if exists adicionarServico$$
create procedure adicionarServico (pNome varchar(45), pDescricao varchar(255), pValor double, pDuracao time, pCdCategoria int, pPontos int)
begin
	Declare codigoServico int default gerarCodigoServico();

	Insert into servico values (codigoServico, pNome, pDescricao,pValor,pDuracao,pCdCategoria,pPontos,true);

	Select codigoServico;
end$$

Drop procedure if exists EditarDadosServico$$
Create procedure EditarDadosServico(pCodServico int, pNomeServico varchar (255), pDescricao varchar(255), pValorServico double, pDuracaoServico time, pCodCategoria int, pPontosServico int)
begin
	Update servico 
	set nm_servico = pNomeServico, ds_servico = pDescricao, 
	vl_servico = pValorServico, hr_tempo_duracao = pDuracaoServico,
	cd_categoria_servico = pCodCategoria,
	qt_pontos = pPontosServico
	where cd_servico = pCodServico and ic_ativado = true;
end$$

Drop procedure if exists listarDadosServicosNaoAtribuidos$$
Create procedure listarDadosServicosNaoAtribuidos(pCodFuncionario int)
begin
	Select s.cd_servico, s.nm_servico
    from servico s
    left join funcionarioservico fs on s.cd_servico = fs.cd_servico and fs.cd_funcionario = pCodFuncionario
    where fs.cd_funcionario is null;
end$$


Drop procedure if exists desatribuirServicoFuncionarioPorServico$$
Create procedure desatribuirServicoFuncionarioPorServico(pCodServico int)
begin
	SET SQL_SAFE_UPDATES = 0;


	if exists (select 1 from funcionarioservico 
			   where cd_servico = pCodServico
				and ic_ativado = false)
	then
		Update funcionarioservico
		set ic_ativado = false
		where cd_servico = pCodServico 
		and cd_funcionario in (select * from (select fs.cd_funcionario from funcionarioservico as fs
								where fs.cd_servico = pCodServico
								and fs.ic_ativado = false) as tmp) 
		and ic_ativado = true;
	end if;
	-- else

		if exists (select 1 from agendamento where cd_servico = pCodServico)
		then
			

			Update funcionarioservico
			set ic_ativado = false
			where cd_servico = pCodServico 
			and cd_funcionario in (select a.cd_funcionario from agendamento as a where a.cd_servico = pCodServico)
			and ic_ativado = true;

			/*if exists (Select 1 from funcionarioservicodiadetrabalho as fsd 
							where cd_funcionario in (select cd_funcionario from agendamento where cd_servico = pCodServico) 
							and cd_servico = pCodServico
							and ic_ativado = false
							and exists (Select 1 from agendamento as a
							where cd_servico = pCodServico 
							and cd_dia_trabalho = fsd.cd_dia_trabalho
		d					and hr_funcionario_serviço_dia_de_trabalho = fsd.hr_funcionario_serviço_dia_de_trabalho))
			then*/
				

				Delete fsd 
				from funcionarioservicodiadetrabalho as fsd
				where cd_funcionario in (select aa.cd_funcionario from agendamento as aa where aa.cd_servico = pCodServico)
				and cd_servico = pCodServico
				and ic_ativado = true
				and exists  (Select 1 from agendamento as a
							where a.cd_servico = pCodServico 
							and a.cd_funcionario = fsd.cd_funcionario
							and a.cd_dia_trabalho = fsd.cd_dia_trabalho
							and a.hr_funcionario_serviço_dia_de_trabalho = fsd.hr_funcionario_serviço_dia_de_trabalho)
				and exists (select * from (Select 1 from funcionarioservicodiadetrabalho as fsdd
							where fsdd.cd_funcionario in (select a.cd_funcionario from agendamento as a where a.cd_servico = pCodServico) 
							and fsdd.cd_servico = pCodServico
							and fsdd.ic_ativado = false) as tmp);
			-- else
				

				Update funcionarioservicodiadetrabalho as fsd
				join agendamento as a on fsd.cd_servico = pCodServico 
					  and fsd.cd_funcionario = a.cd_funcionario
                      and fsd.cd_dia_trabalho = a.cd_dia_trabalho
                      and fsd.hr_funcionario_serviço_dia_de_trabalho = a.hr_funcionario_serviço_dia_de_trabalho
				set fsd.ic_ativado = false
				where fsd.cd_funcionario in (select aa.cd_funcionario from agendamento as aa where aa.cd_servico = pCodServico)
				and fsd.cd_servico = pCodServico
				and not exists (Select * from (Select 1 from funcionarioservicodiadetrabalho as fsdd
							where fsdd.cd_funcionario in (select a.cd_funcionario from agendamento as a where a.cd_servico = pCodServico)
							and fsdd.cd_servico = pCodServico
							and fsdd.ic_ativado = false) as tmp)
				and ic_ativado = true;

				Delete fsd 
				from funcionarioservicodiadetrabalho as fsd
				where cd_funcionario in (select a.cd_funcionario from agendamento as a where a.cd_servico = pCodServico)
				and cd_servico = pCodServico
				and not exists (Select 1 from agendamento as a
							where a.cd_servico = pCodServico 
							and a.cd_funcionario = fsd.cd_funcionario
							and a.cd_dia_trabalho = fsd.cd_dia_trabalho
							and a.hr_funcionario_serviço_dia_de_trabalho = fsd.hr_funcionario_serviço_dia_de_trabalho)
				and not exists (Select * from (Select 1 from funcionarioservicodiadetrabalho fsdd
							where fsdd.cd_funcionario in (select a.cd_funcionario from agendamento as a where a.cd_servico = pCodServico)
							and fsdd.cd_servico = pCodServico
							and fsdd.ic_ativado = false) as tmp);
			 end if;
		-- else
			

			Delete fsd from funcionarioservicodiadetrabalho as fsd
			where cd_servico = pCodServico
			and cd_funcionario not in (select a.cd_funcionario from agendamento as a where a.cd_servico = pCodServico)
			and not exists (Select 1 from agendamento as a
							where cd_servico = pCodServico 
							and cd_funcionario = fsd.cd_funcionario
							and cd_dia_trabalho = fsd.cd_dia_trabalho
							and hr_funcionario_serviço_dia_de_trabalho = fsd.hr_funcionario_serviço_dia_de_trabalho)
			and ic_ativado = true;

			Delete from funcionarioservico
			where cd_funcionario not in (select a.cd_funcionario from agendamento as a where a.cd_servico = pCodServico)
			and cd_servico = pCodServico 
			and ic_ativado = true;
		-- end if;
	-- end if;

	SET SQL_SAFE_UPDATES = 1;
end$$

Drop procedure if exists excluirServico$$
Create procedure excluirServico(pCodServico int)
begin

	declare verificacaoCupom bool default false;
	declare verificacaoAgendamento bool default false;

	SET SQL_SAFE_UPDATES = 0;

	delete from agendamento 
	where cd_servico = pCodServico
	and ic_presenca_funcionario_agendamento is null
	and ic_presenca_cliente_agendamento is null;

	if exists (select 1 from cupomServico where cd_servico = pCodServico)
	then	
		if exists (select 1 from premioCliente as pc where exists (select 1 from premio p where p.cd_servico = pc.cd_premio and p.cd_servico = pCodServico))
		then 
			update servico 
			set ic_ativado = false
			where cd_servico = pCodServico
			and ic_ativado = true;
		else
			update premio 
			set cd_servico = null
			where cd_servico = pCodServico;
		
			delete from cupomServico
			where cd_servico = pCodServico;

			set verificacaoCupom = true;
		end if;
	else	
		set verificacaoCupom = true;
	end if;

	if exists (select 1 from funcionarioservico where cd_servico = pCodServico)
	then
		call desatribuirServicoFuncionarioPorServico(pCodServico);
	end if;

	if exists (select 1 from agendamento 
				where cd_servico = pCodServico
				and ic_presenca_funcionario_agendamento is not null
				and ic_presenca_cliente_agendamento is not null)
	then
		if exists (select 1 from servico where cd_servico = pCodServico and ic_ativado = false)
		then
			delete from servico 
			where cd_servico = pCodServico
			and ic_ativado = true;
		else
			update servico 
			set ic_ativado = false
			where cd_servico = pCodServico
			and ic_ativado = true;
		end if;
	else 
		set verificacaoAgendamento = true;
	end if;

	Select nm_pasta_imagem, nm_imagem
	from servicoimagem
	where cd_servico = pCodServico;

	if (verificacaoAgendamento = true and verificacaoCupom = true)
	then
		Delete from servicoimagem 
		where cd_servico = pCodServico;

		Delete from imagem
		where nm_pasta_imagem = (select sc.nm_pasta_imagem from servicoimagem as sc where sc.cd_servico = pCodServico)
		and nm_imagem = (select sc.nm_imagem from servicoimagem as sc where sc.cd_servico = pCodServico);

		delete from servico 
			where cd_servico = pCodServico
		and ic_ativado = true;
	end if;

	SET SQL_SAFE_UPDATES = 1;
end$$

/* Procedures das telas de DONA_FUNCIONARIO */

Drop procedure if exists listarDadosMinimosFuncionarios$$
Create procedure listarDadosMinimosFuncionarios()
begin
	Select cd_funcionario as cdfuncionario, nm_funcionario as nmfuncionario, nm_email_funcionario as emailfuncionario,
	case when cd_tipo_funcionario = 2
	then 'Gerente'
	else 'Funcionário'
	end as tipofuncionario
	from funcionario 
	order by cd_funcionario;
end$$

Drop procedure if exists listarDadosMinimosProdutos$$
Create procedure listarDadosMinimosProdutos()
begin
	Select cd_produto as cdproduto, nm_produto as nmproduto, qt_produto as qtproduto, ds_produto as dsproduto
	from produto 
	order by nm_produto;
end$$

Drop procedure if exists filtrarFuncionarios$$
Create procedure filtrarFuncionarios(pFiltroFuncionario varchar (255))
begin
	Select tf.nm_tipo_funcionario as tipofuncionario, f.cd_funcionario as cdfuncionario, f.nm_funcionario as nmfuncionario, f.nm_email_funcionario as emailfuncionario from funcionario as f
	inner join tipodefuncionario as tf on (f.cd_tipo_funcionario = tf.cd_tipo_funcionario)
	where f.cd_funcionario = pFiltroFuncionario or f.nm_funcionario like pFiltroFuncionario or f.nm_email_funcionario like pFiltroFuncionario;
end$$

Drop procedure if exists filtrarProdutos$$
Create procedure filtrarProdutos(pFiltroProdutos varchar (50))
begin
	Select cd_produto as cdproduto, nm_produto as nmproduto, qt_produto as qtproduto, ds_produto as dsproduto
	from produto 
	where cd_produto = pFiltroProdutos or nm_produto like pFiltroProdutos or qt_produto = pFiltroProdutos;
end$$


Drop procedure if exists MostrarDadosFuncionarioEspecifico$$
Create procedure MostrarDadosFuncionarioEspecifico(pCodFuncionario int)
begin
	Select f.cd_funcionario, f.nm_funcionario, f.nm_email_funcionario, tf.cd_tipo_funcionario,
	i.nm_pasta_imagem, i.nm_imagem from funcionario f
	join tipodefuncionario tf on (f.cd_tipo_funcionario = tf.cd_tipo_funcionario)
	left join imagem i on (f.nm_imagem = i.nm_imagem)
	where f.cd_funcionario = pCodFuncionario;
end$$

Drop procedure if exists MostrarDadosProdutoEspecifico$$
Create procedure MostrarDadosProdutoEspecifico(pCodProduto int)
begin
	Select p.cd_Produto, p.nm_produto, p.qt_produto, p.ds_produto, p.cd_tipo_produto
	from produto p

	where p.cd_produto = pCodProduto;
end$$

Drop procedure if exists ListarServicosFuncionarios$$
Create procedure ListarServicosFuncionarios(pCodFuncionario int)
begin
	Select ft.cd_servico, s.nm_servico
	from funcionarioservico as ft
	inner join servico as s on (s.cd_servico = ft.cd_servico)
	where ft.cd_funcionario = pCodFuncionario;
end$$

Drop procedure if exists ListarFuncionarioServicoDiaDeTrabalho$$
Create procedure ListarFuncionarioServicoDiaDeTrabalho(pCodDiaTrabalho int, pCodFuncionario int, pCodServico int)
begin
	Select time_format(hr_funcionario_serviço_dia_de_trabalho, '%H:%i')
	from funcionarioservicodiadetrabalho

	where pCodFuncionario = cd_funcionario 
	and pCodDiaTrabalho = cd_dia_trabalho 
	and pCodServico = cd_servico
	and ic_ativado = true
	order by hr_funcionario_serviço_dia_de_trabalho;
end$$

Drop procedure if exists ListarTiposFuncionarioETipoEspecifico$$
Create procedure ListarTiposFuncionarioETipoEspecifico(pCodFuncionario int)
begin
	SELECT
	cd_tipo_funcionario, nm_tipo_funcionario AS nm_tipo_funcionario_pCodFuncionario,
	(
		SELECT tf.cd_tipo_funcionario
		FROM funcionario f2
		JOIN tipodefuncionario tf ON tf.cd_tipo_funcionario = f2.cd_tipo_funcionario
		WHERE f2.cd_funcionario = pCodFuncionario
	) AS nm_tipo_funcionario_pCodFuncionario
	FROM tipodefuncionario;
end$$

Drop procedure if exists ListarTipoFuncionario$$
Create procedure ListarTipoFuncionario()
begin
	Select * from tipodefuncionario;
end$$


Drop procedure if exists editarDadosFuncionario$$
Create procedure editarDadosFuncionario(pCodFuncionario int, pNomeFuncionario varchar (45), pEmailFuncionario varchar (255), pCodTipoFuncionario int)
begin
	Update funcionario
	set nm_funcionario = pNomeFuncionario,
	nm_email_funcionario = pEmailFuncionario,
	cd_tipo_funcionario = pCodTipoFuncionario 

	where cd_funcionario = pCodFuncionario;
end$$

Drop procedure if exists substituirImagemFuncionario$$
Create procedure substituirImagemFuncionario(pNomePasta varchar(255), pNomeImagem varchar(255), pCodFuncionario int)
begin
	declare nomeImagemAtual varchar(255);

    select nm_imagem into nomeImagemAtual from funcionario where cd_funcionario = pCodFuncionario;

    if nomeImagemAtual is not null then

		Insert into imagem (nm_imagem, nm_pasta_imagem) values (pNomeImagem, pNomePasta);

		update funcionario 
		set nm_imagem = pNomeImagem, nm_pasta_imagem = pNomePasta
		where cd_funcionario = pCodFuncionario;

		delete from imagem where nm_imagem = nomeImagemAtual and nm_pasta_imagem = pNomePasta;
		
    else

		Insert into imagem (nm_imagem, nm_pasta_imagem) values (pNomeImagem, pNomePasta);

        update funcionario 
		set nm_imagem = pNomeImagem, nm_pasta_imagem = pNomePasta
		where cd_funcionario = pCodFuncionario;
    end if;
end$$


Drop procedure if exists editarDadosProduto$$
Create procedure editarDadosProduto(pCodProduto int, pNomeProduto varchar (45), pQuantidadeProduto varchar (255), pDescricaoProduto varchar(255), pCodigoTipoProduto int)
begin
	Update produto
	set nm_produto = pNomeProduto,
	qt_produto = pQuantidadeProduto,
	ds_produto = pDescricaoProduto,
	cd_tipo_produto = pCodigoTipoProduto

	where cd_produto= pCodProduto;
end$$

Drop procedure if exists listarDadosServicosNaoAtribuidos$$
Create procedure listarDadosServicosNaoAtribuidos(pCodFuncionario int)
begin
	Select s.cd_servico, s.nm_servico
    from servico s
    left join funcionarioservico fs on s.cd_servico = fs.cd_servico and fs.cd_funcionario = pCodFuncionario and fs.ic_ativado = true
    where fs.cd_funcionario is null;
end$$


Drop procedure if exists listarDadosServicosAtribuidos$$
Create procedure listarDadosServicosAtribuidos(pCodFuncionario int)
begin
	Select fs.cd_servico as cdservico, s.nm_servico as nmservico, fs.cd_funcionario as cdfuncionario
    from servico s
    left join funcionarioservico fs on s.cd_servico = fs.cd_servico and fs.cd_funcionario = pCodFuncionario
    where fs.cd_funcionario is not null
	and fs.ic_ativado = true;
end$$



Drop procedure if exists desatribuirServicoFuncionario$$
Create procedure desatribuirServicoFuncionario(pCodFuncionario int, pCodServico int)
begin
	SET SQL_SAFE_UPDATES = 0;

	delete from agendamento 
	where cd_servico = pCodServico
	and ic_presenca_funcionario_agendamento is null
	and ic_presenca_cliente_agendamento is null;

	if exists (select 1 from funcionarioservico 
			   where cd_funcionario = pCodFuncionario
				and cd_servico = pCodServico
				and ic_ativado = false)
	then
		Update funcionarioservico
		set ic_ativado = false
		where cd_funcionario = pCodFuncionario 
		and cd_servico = pCodServico 
		and ic_ativado = true;

		Delete fsd 
			from funcionarioservicodiadetrabalho as fsd
			where cd_funcionario = pCodFuncionario 
			and cd_servico = pCodServico
			and not exists (Select 1 from agendamento as a
							where cd_funcionario = pCodFuncionario 
							and cd_servico = pCodServico 
							and cd_dia_trabalho = fsd.cd_dia_trabalho
							and hr_funcionario_serviço_dia_de_trabalho = fsd.hr_funcionario_serviço_dia_de_trabalho);

			if exists (Select 1 from funcionarioservicodiadetrabalho as fsd 
							where cd_funcionario = pCodFuncionario 
							and cd_servico = pCodServico
							and ic_ativado = false
							and exists (Select 1 from agendamento as a
							where cd_funcionario = pCodFuncionario 
							and cd_servico = pCodServico 
							and cd_dia_trabalho = fsd.cd_dia_trabalho
							and hr_funcionario_serviço_dia_de_trabalho = fsd.hr_funcionario_serviço_dia_de_trabalho))
			then
				Delete fsd 
				from funcionarioservicodiadetrabalho as fsd
				where cd_funcionario = pCodFuncionario 
				and cd_servico = pCodServico
				and ic_ativado = true
				and exists (Select 1 from agendamento as a
							where cd_funcionario = pCodFuncionario 
							and cd_servico = pCodServico 
							and cd_dia_trabalho = fsd.cd_dia_trabalho
							and hr_funcionario_serviço_dia_de_trabalho = fsd.hr_funcionario_serviço_dia_de_trabalho);
			else
				Update funcionarioservicodiadetrabalho as fsd
				set ic_ativado = false 
				where cd_funcionario = pCodFuncionario 
				and cd_servico = pCodServico
				and exists (Select 1 from agendamento as a
							where cd_funcionario = pCodFuncionario 
							and cd_servico = pCodServico 
							and cd_dia_trabalho = fsd.cd_dia_trabalho
							and hr_funcionario_serviço_dia_de_trabalho = fsd.hr_funcionario_serviço_dia_de_trabalho);
			end if;

	else
		if exists (select 1 from agendamento where cd_funcionario = pCodFuncionario and cd_servico = pCodServico)
		then
			Update funcionarioservico
			set ic_ativado = false
			where cd_funcionario = pCodFuncionario 
			and cd_servico = pCodServico 
			and ic_ativado = true;

			Delete fsd 
			from funcionarioservicodiadetrabalho as fsd
			where cd_funcionario = pCodFuncionario 
			and cd_servico = pCodServico
			and not exists (Select 1 from agendamento as a
							where cd_funcionario = pCodFuncionario 
							and cd_servico = pCodServico 
							and cd_dia_trabalho = fsd.cd_dia_trabalho
							and hr_funcionario_serviço_dia_de_trabalho = fsd.hr_funcionario_serviço_dia_de_trabalho);

			if exists (Select 1 from funcionarioservicodiadetrabalho as fsd 
							where cd_funcionario = pCodFuncionario 
							and cd_servico = pCodServico
							and ic_ativado = false
							and exists (Select 1 from agendamento as a
							where cd_funcionario = pCodFuncionario 
							and cd_servico = pCodServico 
							and cd_dia_trabalho = fsd.cd_dia_trabalho
							and hr_funcionario_serviço_dia_de_trabalho = fsd.hr_funcionario_serviço_dia_de_trabalho))
			then
				Delete fsd 
				from funcionarioservicodiadetrabalho as fsd
				where cd_funcionario = pCodFuncionario 
				and cd_servico = pCodServico
				and ic_ativado = true
				and exists (Select 1 from agendamento as a
							where cd_funcionario = pCodFuncionario 
							and cd_servico = pCodServico 
							and cd_dia_trabalho = fsd.cd_dia_trabalho
							and hr_funcionario_serviço_dia_de_trabalho = fsd.hr_funcionario_serviço_dia_de_trabalho);
			else
				Update funcionarioservicodiadetrabalho as fsd
				set ic_ativado = false 
				where cd_funcionario = pCodFuncionario 
				and cd_servico = pCodServico
				and exists (Select 1 from agendamento as a
							where cd_funcionario = pCodFuncionario 
							and cd_servico = pCodServico 
							and cd_dia_trabalho = fsd.cd_dia_trabalho
							and hr_funcionario_serviço_dia_de_trabalho = fsd.hr_funcionario_serviço_dia_de_trabalho);
			end if;
		else
			Delete from funcionarioservicodiadetrabalho 
			where cd_funcionario = pCodFuncionario
			and cd_servico = pCodServico;

			Delete from funcionarioservico
			where cd_funcionario = pCodFuncionario 
			and cd_servico = pCodServico 
			and ic_ativado = true;
		end if;
	end if;
	SET SQL_SAFE_UPDATES = 1;
end$$


Drop procedure if exists funcionarioAtribuirServico$$
Create procedure funcionarioAtribuirServico(pCodFuncionario int, pCodServico int)
begin
	if exists (select 1 from funcionarioservico where cd_funcionario = pCodFuncionario and cd_servico = pCodServico and ic_ativado = false)
	then
		Update funcionarioservico 
		set ic_ativado = true
		where cd_funcionario = pCodFuncionario
		and cd_servico = pCodServico 
		and ic_ativado = false;
	else
		Insert into funcionarioservico values (pCodFuncionario, pCodServico, true);
	end if;
end$$

Drop procedure if exists excluirFuncionario$$
Create procedure excluirFuncionario(pCodFuncionario int)
begin
	
	declare codigoServico int default null;

	declare parar int default 0;	

	declare desatribuirServico cursor
	for  
		select cd_servico from funcionarioservico where cd_funcionario = pCodFuncionario;
	declare continue handler for not found
	set parar = 1;

	SET SQL_SAFE_UPDATES = 0;

	if (pCodFuncionario = 1)
	then 
		Signal sqlstate '45000' set message_text = 'Não se pode excluir o usuário padrão administrador.';
	end if;

	if exists (select 1 from funcionarioservico where cd_funcionario = pCodFuncionario)
	then
		Open desatribuirServico;

		todos:loop
			fetch desatribuirServico into codigoServico;

			if (parar = 1) then
				leave todos;
			end if;

			call desatribuirServicoFuncionario (pCodFuncionario, codigoServico);
	
		end loop todos;

		Close desatribuirServico;
	end if;
		
	if exists (select 1 from agendamento where cd_funcionario = pCodFuncionario)
	then
		if exists (select 1 from funcionario where cd_funcionario = pCodFuncionario and ic_ativado = false)
		then
			delete from funcionario 
			where cd_funcionario = pCodFuncionario
			and ic_ativado = true;
		else
			update funcionario 
			set ic_ativado = false
			where cd_funcionario = pCodFuncionario
			and ic_ativado = true;
		end if;
	else

		select nm_pasta_imagem, nm_imagem 
		from funcionario
		where cd_funcionario = pCodFuncionario;

		update funcionario
		set nm_imagem = null,
		nm_pasta_imagem = null
		where cd_funcionario = pCodFuncionario;
		
	
		delete from imagem 
		where nm_imagem = (select nm_imagem from funcionario where cd_funcionario = pCodFuncionario)
		and nm_pasta_imagem = (select nm_pasta_imagem from funcionario where cd_funcionario = pCodFuncionario);
		
		delete from funcionario 
		where cd_funcionario = pCodFuncionario;
	end if;
	SET SQL_SAFE_UPDATES = 1;
end$$


Drop procedure if exists excluirProduto$$
Create procedure excluirProduto(pCodProduto int)
begin

	declare parar int default 0;	
	declare codigoPremio int default null;
	declare icAtivado bool default true;
	declare excluirRecompensa cursor
	for  
		select cd_premio from premio where cd_produto = pCodProduto;
	declare continue handler for not found
	set parar = 1;

	if exists (select 1 from premio where cd_produto = pCodProduto)
	then
		Open excluirRecompensa;

		todos:loop
			fetch excluirRecompensa into codigoPremio;

			if (parar = 1) then
				leave todos;
			end if;

			call excluirRecompensa (codigoPremio);
	
		end loop todos;

		Close excluirRecompensa;

		set icAtivado = false;
	end if;

	if exists (select 1 from produtoAgendamento where cd_produto = pCodProduto)
	then
		set icAtivado = false;
		
	
	end if;

	if (icAtivado = false)
	then
		Update produto 
		set ic_ativado = false
		where cd_produto = pCodProduto 
		and ic_ativado = true;
	else
		delete from produto 
		where cd_produto = pCodProduto;
	end if;

	
	
		
end$$

/* Procedures de DONA_RECOMPENSAS */

Drop procedure if exists listarDadosMinimosRecompensas$$
Create procedure listarDadosMinimosRecompensas()
begin
	select tp.nm_tipo_premio as nmtipopremio, p.nm_premio as nmpremio, p.qt_pontos_premio as qtpontos, p.cd_premio as cdpremio from premio p
	join tipopremio tp on (p.cd_tipo_premio = tp.cd_tipo_premio)
	where p.ic_ativado = true order by p.cd_premio;
end$$


Drop procedure if exists filtrarRecompensas$$
Create procedure filtrarRecompensas(pFiltroRecompensa varchar (50))
begin
	select tp.nm_tipo_premio as nmtipopremio, p.nm_premio as nmpremio, p.qt_pontos_premio as qtpontos, p.cd_premio as cdpremio from premio p
	join tipopremio tp on (p.cd_tipo_premio = tp.cd_tipo_premio)

	where p.nm_premio like pFiltroRecompensa or tp.nm_tipo_premio like pFiltroRecompensa and p.ic_ativado = true;
end$$

Drop procedure if exists MostrarDadosRecompensaEspecifica$$
Create procedure MostrarDadosRecompensaEspecifica(pCodPremio int)
begin
    declare tipoPremio int;

    select cd_tipo_Premio into tipoPremio from premio where cd_premio = pCodPremio;

    if tipoPremio = 1 then
		select p.cd_premio, tp.nm_tipo_premio, p.cd_cupom_desconto, cd.vl_porcentagem_de_desconto,
		s.cd_servico, cs.cd_categoria_servico, p.nm_premio, p.qt_pontos_premio, p.ds_premio, p.nm_pasta_imagem, p.nm_imagem
		from premio p
		
		join tipopremio tp on (p.cd_tipo_premio = tp.cd_tipo_premio)
		left join cupomdesconto cd on (p.cd_cupom_desconto = cd.cd_cupom_desconto)
		left join servico s on (p.cd_servico = s.cd_servico)
		left join categoriadeservico cs on (p.cd_categoria_servico = cs.cd_categoria_servico)
		where pCodPremio = p.cd_premio;


    elseif tipoPremio = 2 then
        select p.cd_premio, tp.nm_tipo_premio, p.nm_premio, 
		p.qt_pontos_premio, p.ds_premio, p.nm_pasta_imagem, p.nm_imagem
		from premio p
		
		join tipopremio tp on (p.cd_tipo_premio = tp.cd_tipo_premio)
		join produto pr on (p.cd_produto = pr.cd_produto)

		where pCodPremio = p.cd_premio;

    END IF;
end$$

Drop procedure if exists substituirImagemRecompensa$$
Create procedure substituirImagemRecompensa(pNomePasta varchar(255), pNomeImagem varchar(255), pCodPremio int)
begin
	declare nomeImagemAtual varchar(255);

    select nm_imagem into nomeImagemAtual from premio where cd_premio = pCodPremio;

    if nomeImagemAtual is not null then

		Insert into imagem (nm_imagem, nm_pasta_imagem) values (pNomeImagem, pNomePasta);

		update premio 
		set nm_imagem = pNomeImagem, nm_pasta_imagem = pNomePasta
		where cd_premio = pCodPremio;

		delete from imagem where nm_imagem = nomeImagemAtual and nm_pasta_imagem = pNomePasta;
		
    else

		Insert into imagem (nm_imagem, nm_pasta_imagem) values (pNomeImagem, pNomePasta);

        update premio 
		set nm_imagem = pNomeImagem, nm_pasta_imagem = pNomePasta
		where cd_premio = pCodPremio;
    end if;
end$$

Drop procedure if exists editarDadosRecompensaProdutoEspecifico$$
Create procedure editarDadosRecompensaProdutoEspecifico(pCodPremio int, vNomeRecompensa varchar(45), vQtPontosNecessarios int,
 vDescricao varchar (45))
begin
	Update premio
	set nm_premio = vNomeRecompensa, 
	qt_pontos_premio = vQtPontosNecessarios, 
	ds_premio = vDescricao
	where cd_premio = pCodPremio;
end$$


Drop procedure if exists editarDadosRecompensaCupomDescontoEspecifico$$
Create procedure editarDadosRecompensaCupomDescontoEspecifico(pCodPremio int, vNomeRecompensa varchar(45), 
vServicoAtrelado int, vCategoriaAtrelada int, vPorcentagemDesconto int, vQtPontosNecessarios int, vDescricao varchar(45))
begin
	declare codCupom int default null;
	declare codCupomAtual int default null;
	declare codCupomGerado int default null;
	declare servicoAtual int default null;
	declare categoriaAtual int default null;
	select cd_cupom_desconto into codCupom from cupomDesconto where vl_porcentagem_de_desconto = vPorcentagemDesconto;
	select cd_servico into servicoAtual from premio where cd_premio = pCodPremio;
	select cd_categoria_servico into categoriaAtual from premio where cd_premio = pCodPremio;
	
	Update premio
	set nm_premio = vNomeRecompensa, qt_pontos_premio = vQtPontosNecessarios, ds_premio = vDescricao
	where cd_premio = pCodPremio;

	select cd_cupom_desconto into codCupomAtual 
	from premio 
    where cd_premio = pCodPremio;







	if not exists (select 1 from cupomServico where cd_cupom_desconto = codCupomAtual) 
				and not exists (select 1 from cupomCategoriaDeServico where cd_cupom_desconto = codCupomAtual)
				and not exists(select 1 from premio where cd_cupom_desconto = codCupomAtual)
	then
		Delete from cupomdesconto 
		where cd_cupom_desconto = codCupomAtual;
	end if;



	if exists (select 1 from cupomServico where cd_cupom_desconto = codCupom and cd_servico = vServicoAtrelado) and exists
			  (select 1 from cupomCategoriaDeServico where cd_cupom_desconto = codCupom and cd_categoria_servico = vCategoriaAtrelada) 
	then
				Update premio
				set cd_cupom_desconto = codCupom,
				cd_servico = vServicoAtrelado,
				cd_categoria_servico = vCategoriaAtrelada
				where cd_premio = pCodPremio;
	else
		

		if exists (select 1 from cupomServico where cd_cupom_desconto = codCupom and cd_servico = vServicoAtrelado)
		then
			if (vCategoriaAtrelada is not null)
			then
				insert into cupomCategoriaDeServico values (codCupom, vCategoriaAtrelada);
			end if;
	
			Update premio
			set cd_cupom_desconto = codCupom,
			cd_servico = vServicoAtrelado,
			cd_categoria_servico = vCategoriaAtrelada
			where cd_premio = pCodPremio;
		elseif exists (select 1 from cupomCategoriaDeServico where cd_cupom_desconto = codCupom and cd_categoria_servico = vCategoriaAtrelada)
		then
			if (vServicoAtrelado is not null)
			then
				insert into cupomServico values (codCupom, vServicoAtrelado);
			end if;

			Update premio
			set cd_cupom_desconto = codCupom,
			cd_servico = vServicoAtrelado,
			cd_categoria_servico = vCategoriaAtrelada
			where cd_premio = pCodPremio;
		else
			if (codCupom is null)
			then
				select gerarCodigoCupomDesconto() into codCupom;
				insert into cupomDesconto values (codCupom, vPorcentagemDesconto);
			end if;

			if (vServicoAtrelado is not null)
			then
				insert into cupomServico values (codCupom, vServicoAtrelado);
			end if;
			if (vCategoriaAtrelada is not null)
			then
				insert into cupomCategoriaDeServico values (codCupom, vCategoriaAtrelada);
			end if;
	
			Update premio
			set cd_cupom_desconto = codCupom,
			cd_servico = vServicoAtrelado,
			cd_categoria_servico = vCategoriaAtrelada
			where cd_premio = pCodPremio;
		end if;
	end if;




if (vServicoAtrelado is null)
	then
		if  (select count(*) from cupomServico where cd_cupom_desconto = codCupomAtual and cd_servico = servicoAtual) > 1
			then
				if not exists (select 1 from cupomServico where cd_cupom_desconto = codCupomAtual) 
				and not exists (select 1 from cupomCategoriaDeServico where cd_cupom_desconto = codCupomAtual)
				and not exists(select 1 from premio where cd_cupom_desconto = codCupomAtual)
				then
					Delete from cupomdesconto 
					where cd_cupom_desconto = codCupomAtual;
				end if;
		elseif (select count(*) from cupomServico where cd_cupom_desconto = codCupomAtual and cd_servico = servicoAtual) = 1
		then
				if not exists (select 1 from cupomServico where cd_cupom_desconto = codCupomAtual) 
				and not exists (select 1 from cupomCategoriaDeServico where cd_cupom_desconto = codCupomAtual)
				and not exists(select 1 from premio where cd_cupom_desconto = codCupomAtual)
				then
					Delete from cupomdesconto 
					where cd_cupom_desconto = codCupomAtual;
				end if;

				Delete from cupomServico
				where cd_cupom_desconto = codCupomAtual 
				and cd_servico = servicoAtual;
		end if;
	end if;

	if (vCategoriaAtrelada is null)
	then
		if  (select count(*) from cupomCategoriaDeServico where cd_cupom_desconto = codCupomAtual and cd_categoria_servico = vCategoriaAtrelada) > 1
			then
				if not exists (select 1 from cupomServico where cd_cupom_desconto = codCupomAtual) 
				and not exists (select 1 from cupomCategoriaDeServico where cd_cupom_desconto = codCupomAtual)
				and not exists(select 1 from premio where cd_cupom_desconto = codCupomAtual)
				then
					Delete from cupomdesconto 
					where cd_cupom_desconto = codCupomAtual;
				end if;
		elseif (select count(*) from cupomCategoriaDeServico where cd_cupom_desconto = codCupomAtual and cd_categoria_servico = vCategoriaAtrelada) = 1
		then
				if not exists (select 1 from cupomServico where cd_cupom_desconto = codCupomAtual) 
				and not exists (select 1 from cupomCategoriaDeServico where cd_cupom_desconto = codCupomAtual)
				and not exists(select 1 from premio where cd_cupom_desconto = codCupomAtual)
				then
					Delete from cupomdesconto 
					where cd_cupom_desconto = codCupomAtual;
				end if;

				Delete from cupomCategoriaDeServico
				where cd_cupom_desconto = codCupomAtual 
				and cd_categoria_servico = categoriaAtual;
		end if;
	end if;

	

		/*if (vServicoAtrelado is not null)
		then
			if exists (select 1 from cupomServico where cd_cupom_desconto = codCupom and cd_servico = vServicoAtrelado)
			then
				

				if not exists (select 1 from cupomServico where cd_cupom_desconto = codCupomAtual) 
				and not exists (select 1 from cupomCategoriaDeServico where cd_cupom_desconto = codCupomAtual)
				and not exists(select 1 from premio where cd_cupom_desconto = codCupomAtual)
				then
					Delete from cupomdesconto 
					where cd_cupom_desconto = codCupomAtual;
				end if;

				-- Update cupomdesconto 
	-- set vl_porcentagem_de_desconto = vPorcentagemDesconto
	-- where cd_cupom_desconto = codCupomAtual;

				Update premio
				set cd_cupom_desconto = codCupom,
				cd_servico = vServicoAtrelado
				where cd_premio = pCodPremio;
				
			else 

				

				if not exists (select 1 from cupomServico where cd_cupom_desconto = codCupomAtual) 
				and not exists (select 1 from cupomCategoriaDeServico where cd_cupom_desconto = codCupomAtual)
				and not exists(select 1 from premio where cd_cupom_desconto = codCupomAtual)
				then
					Delete from cupomdesconto 
					where cd_cupom_desconto = codCupomAtual;
				end if;

				if (codCupom is not null)
				then
					select gerarCodigoCupomDesconto() into codCupom;
					insert into cupomDesconto values (codCupom, vPorcentagemDesconto);
				end if;

				insert into cupomServico values (codCupom, vServicoAtrelado);
				
				Update premio
				set cd_cupom_desconto = codCupom,
				cd_servico = vServicoAtreladod
				where cd_premio = pCodPremio;

				select null into codCupom;
			end if;
		else 
			if  (select count(*) from cupomServico where cd_cupom_desconto = codCupomAtual and cd_servico = servicoAtual) > 1
			then
				if not exists (select 1 from cupomServico where cd_cupom_desconto = codCupomAtual) 
				and not exists (select 1 from cupomCategoriaDeServico where cd_cupom_desconto = codCupomAtual)
				and not exists(select 1 from premio where cd_cupom_desconto = codCupomAtual)
				then
					Delete from cupomdesconto 
					where cd_cupom_desconto = codCupomAtual;
				end if;
			else if (select count(*) from cupomServico where cd_cupom_desconto = codCupomAtual and cd_servico = servicoAtual) = 1
			then
				if not exists (select 1 from cupomServico where cd_cupom_desconto = codCupomAtual) 
				and not exists (select 1 from cupomCategoriaDeServico where cd_cupom_desconto = codCupomAtual)
				and not exists(select 1 from premio where cd_cupom_desconto = codCupomAtual)
				then
					Delete from cupomdesconto 
					where cd_cupom_desconto = codCupomAtual;
				end if;

				Delete from cupomServico
				where cd_cupom_desconto = codCupomAtual 
				and cd_servico = servicoAtual;
			end if;
		end if;
		end if;

		

		
		if (vCategoriaAtrelada is not null)
		then
			if exists (select 1 from cupomCategoriaDeServico where cd_cupom_desconto = codCupom and cd_categoria_servico = vCategoriaAtrelada)
			then

				if not exists (select 1 from cupomServico where cd_cupom_desconto = codCupomAtual) 
				and not exists (select 1 from cupomCategoriaDeServico where cd_cupom_desconto = codCupomAtual)
				and not exists(select 1 from premio where cd_cupom_desconto = codCupomAtual)
				then
					Delete from cupomdesconto 
					where cd_cupom_desconto = codCupomAtual;
				end if;

				-- Update cupomdesconto 
				-- set vl_porcentagem_de_desconto = vPorcentagemDesconto
				-- where cd_cupom_desconto = codCupomAtual;

				Update premio
				set cd_cupom_desconto = codCupom,
				cd_categoria_servico = vCategoriaAtrelada
				where cd_premio = pCodPremio;
				
			else 

				if not exists (select 1 from cupomServico where cd_cupom_desconto = codCupomAtual) 
				and not exists (select 1 from cupomCategoriaDeServico where cd_cupom_desconto = codCupomAtual)
				and not exists(select 1 from premio where cd_cupom_desconto = codCupomAtual)
				then
					Delete from cupomdesconto 
					where cd_cupom_desconto = codCupomAtual;
				end if;

				if (codCupom is not null)
				then
					select gerarCodigoCupomDesconto() into codCupom;
					insert into cupomDesconto values (codCupom, vPorcentagemDesconto);
				end if;

				insert into cupomCategoriaDeServico values (codCupom, vCategoriaAtrelada);
				
				Update premio
				set cd_cupom_desconto = codCupom,
				cd_categoria_servico = vCategoriaAtrelada
				where cd_premio = pCodPremio;

				select null into codCupom;
			end if;
		else 
			if  (select count(*) from cupomCategoriaDeServico where cd_cupom_desconto = codCupomAtual and cd_categoria_servico = vCategoriaAtrelada) > 1
			then
				if not exists (select 1 from cupomServico where cd_cupom_desconto = codCupomAtual) 
				and not exists (select 1 from cupomCategoriaDeServico where cd_cupom_desconto = codCupomAtual)
				and not exists(select 1 from premio where cd_cupom_desconto = codCupomAtual)
				then
					Delete from cupomdesconto 
					where cd_cupom_desconto = codCupomAtual;
				end if;
			else if (select count(*) from cupomCategoriaDeServico where cd_cupom_desconto = codCupomAtual and cd_categoria_servico = vCategoriaAtrelada) = 1
			then
				if not exists (select 1 from cupomServico where cd_cupom_desconto = codCupomAtual) 
				and not exists (select 1 from cupomCategoriaDeServico where cd_cupom_desconto = codCupomAtual)
				and not exists(select 1 from premio where cd_cupom_desconto = codCupomAtual)
				then
					Delete from cupomdesconto 
					where cd_cupom_desconto = codCupomAtual;
				end if;

				Delete from cupomCategoriaDeServico
				where cd_cupom_desconto = codCupomAtual 
				and cd_categoria_servico = categoriaAtual;
			end if;
		end if;
		end if;*/

		/*if (vCategoriaAtrelada is not null)
		then
			
		end if;*/
end$$

Drop procedure if exists ListarServicos$$
Create procedure ListarServicos()
begin
	Select cd_servico, nm_servico 
	from servico
	order by nm_servico;
end$$

Drop procedure if exists excluirRecompensa$$
Create procedure excluirRecompensa(pCodPremio int)
begin
	if not exists (select 1 from agendamento where cd_premio = pCodPremio)
	then 
		if not exists (select 1 from premiocliente where cd_premio = pCodPremio)
		then
			if not exists (select 1 from premio where cd_servico = (select cd_servico from premio where cd_premio = pCodPremio)
				and cd_cupom_desconto = (select cd_cupom_desconto from premio where cd_premio = pCodPremio))
			then
				delete from cupomservico where cd_servico = (select cd_servico from premio where cd_premio = pCodPremio)
				and cd_cupom_desconto = (select cd_cupom_desconto from premio where cd_premio = pCodPremio);
			end if;

			if not exists (select 1 from premio where cd_categoria = (select cd_categoria_servico_servico from premio where cd_premio = pCodPremio)
				and cd_cupom_desconto = (select cd_cupom_desconto from premio where cd_premio = pCodPremio))
			then
				delete from cupomservicocupomcategoriadeservico where cd_categoria_servico = (select cd_categoria_servico from premio where cd_premio = pCodPremio)
				and cd_cupom_desconto = (select cd_cupom_desconto from premio where cd_premio = pCodPremio);
			end if;

			if not exists (select 1 from cupomServico where cd_cupom_desconto = (select cd_cupom_desconto from premio where cd_premio = pCodPremio)) 
				and not exists (select 1 from cupomCategoriaDeServico where cd_cupom_desconto = (select cd_cupom_desconto from premio where cd_premio = pCodPremio))
				and not exists(select 1 from premio where cd_cupom_desconto = (select cd_cupom_desconto from premio where cd_premio = pCodPremio))
			then
				delete from cupomdesconto 
				where cd_cupom_desconto = (select cd_cupom_desconto from premio where cd_premio = pCodPremio);
			end if;

			delete from premio 
			where cd_premio = pCodPremio;

			select nm_pasta_imagem, nm_imagem
	from premio where cd_premio = pCodPremio;

	delete from imagem 
	where nm_pasta_imagem = (select nm_pasta_imagem from premio where cd_premio = pCodPremio)
	and nm_imagem = (select nm_imagem from premio where cd_premio = pCodPremio);
		else
			update premio
			set ic_ativado = false
			where cd_premio = pCodPremio
			and ic_ativado = true;
		end if;
	else
		update premio
		set ic_ativado = false
		where cd_premio = pCodPremio
		and ic_ativado = true;
	end if;

	
end$$

/*Procedures do funcionário*/

Drop procedure if exists funcionarioEditarDados$$
Create procedure funcionarioEditarDados(pCodFuncionario int, pNomeFuncionario varchar (45))
begin
	Update funcionario
	set nm_funcionario = pNomeFuncionario
	where cd_funcionario = pCodFuncionario;
end$$

/*Procedures de cliente_recompensas*/


Drop procedure if exists listarDadosMinimosPremios$$
Create procedure listarDadosMinimosPremios(pEmailCliente varchar(255), pTipoPremio text)
begin
	if pTipoPremio = '1' then
		select p.nm_premio, p.ds_premio, p.nm_pasta_imagem, p.nm_imagem, p.cd_premio, 'Não retirado', '' from premio p
		join premiocliente pc on (p.cd_premio = pc.cd_premio)
		/*left join imagem i on (i.nm_pasta_imagem = p.nm_pasta_imagem and i.nm_imagem = p.nm_imagem)*/
		where pc.nm_email_cliente = pEmailCliente and p.cd_tipo_premio = 1
		and p.ic_ativado = true and pc.ic_resgatado = false;

	elseif pTipoPremio = '2' then
		select p.nm_premio, p.ds_premio, p.nm_pasta_imagem, p.nm_imagem, p.cd_premio, 'Não retirado', if (pr.qt_produto < 1, 'Indisponível para retirar', 'Disponível para retirar') 
		from premio p
		join premiocliente pc on (p.cd_premio = pc.cd_premio)
		left join produto pr on (p.cd_produto = pr.cd_produto)
		/*left join imagem i on (i.nm_pasta_imagem = p.nm_pasta_imagem and i.nm_imagem = p.nm_imagem)*/
		where pc.nm_email_cliente = pEmailCliente and p.cd_tipo_premio = 2
		and p.ic_ativado = true and pc.ic_resgatado = false;
	elseif pTipoPremio = '3' then
		select p.nm_premio, p.ds_premio, p.nm_pasta_imagem, p.nm_imagem, p.cd_premio, 'Retirado', '' from premio p
		join premiocliente pc on (p.cd_premio = pc.cd_premio)
		/*left join imagem i on (i.nm_pasta_imagem = p.nm_pasta_imagem and i.nm_imagem = p.nm_imagem)*/
		where pc.nm_email_cliente = pEmailCliente
		and p.ic_ativado = true and pc.ic_resgatado = true;
	else 
		select p.nm_premio, p.ds_premio, p.nm_pasta_imagem, p.nm_imagem, p.cd_premio, if (pc.ic_resgatado = true, 'Retirado', 'Não retirado'),
		if (p.cd_tipo_premio = '2' and pc.ic_resgatado = false, (if (pr.qt_produto < 1, 'Indisponível para retirar', 'Disponível para retirar')), '')
		from premio p
		join premiocliente pc on (p.cd_premio = pc.cd_premio)
		left join produto pr on (p.cd_produto = pr.cd_produto)
		/*left join imagem i on (i.nm_pasta_imagem = p.nm_pasta_imagem and i.nm_imagem = p.nm_imagem)*/
		where pc.nm_email_cliente = pEmailCliente
		and p.ic_ativado = true 
		order by pc.ic_resgatado asc; -- and pc.ic_resgatado = false;
	end if;
end$$

Drop procedure if exists mostrarDadosRecompensaEspecificaCliente$$
Create procedure mostrarDadosRecompensaEspecificaCliente(pCodRecompensa int, pEmailCliente varchar(255))
begin
	Select p.nm_pasta_imagem, p.nm_imagem, p.nm_premio, p.ds_premio, p.cd_tipo_premio from premio p
	join premiocliente pc on (p.cd_premio = pc.cd_premio)
	where pc.cd_premio = pCodRecompensa and pc.nm_email_cliente = pEmailCliente;
end$$


Drop procedure if exists retirarRecompensaCliente$$
Create procedure retirarRecompensaCliente(pCodPremio int, pEmailCliente varchar (255))
begin
	Update premiocliente
	set ic_resgatado = true
	where cd_premio = pCodPremio and nm_email_cliente = pEmailCliente;
end$$

/*Procedures da DONA-Banner*/
drop procedure if exists listarBanners$$
create procedure listarBanners()
begin
select nm_pasta_imagem, nm_imagem_desktop, nm_imagem_mobile, nm_link_banner from banner;
end$$

-- DOTA
drop procedure if exists adicionarBanner$$
create procedure adicionarBanner(vLink varchar(255), vNomeImgDesktop varchar(255), vNomeImgMobile varchar(255))
begin

	insert into imagem values(vNomeImgDesktop,'Banners');
	insert into imagem values(vNomeImgMobile,'Banners');

	if vLink = '' or vLink is null then
		insert into banner values(vNomeImgDesktop, vNomeImgMobile,'Banners',null);
	else
		insert into banner values(vNomeImgDesktop, vNomeImgMobile,'Banners',vLink);
	end if;
end$$

drop procedure if exists DeletarBanner$$
create procedure DeletarBanner(vNomeDesktop varchar(255), vNomeMobile varchar(255))
begin
	delete from Banner where nm_imagem_desktop = vNomeDesktop and nm_imagem_mobile = vNomeMobile;
	delete from Imagem where nm_imagem = vNomeDesktop and nm_pasta_imagem = 'Banners';
	delete from Imagem where nm_imagem = vNomeMobile and nm_pasta_imagem = 'Banners';
end$$

/* PROCEDURE DE ADIÇÃO RECOMPENSA*/

Drop procedure if exists escolherTipoPremio$$
Create procedure escolherTipoPremio()
begin
	Select cd_tipo_premio, nm_tipo_premio from tipopremio;
end$$


Drop procedure if exists escolherProdutoRecompensa$$
Create procedure escolherProdutoRecompensa()
begin
	Select cd_produto, nm_produto from produto;
end$$


Drop procedure if exists escolherServicoRecompensa$$
Create procedure escolherServicoRecompensa()
begin
	Select cd_servico, nm_servico from servico;
end$$


Drop procedure if exists escolherCategoriaServicoRecompensa$$
Create procedure escolherCategoriaServicoRecompensa()
begin
	Select cd_categoria_servico, nm_categoria_servico from categoriadeservico;
end$$

Drop procedure if exists escolherCupomRecompensa$$
Create procedure escolherCupomRecompensa()
begin
	Select cd_cupom_desconto, vl_porcentagem_de_desconto from cupomdesconto;
end$$

Drop procedure if exists adicionarRecompensaProduto$$
Create procedure adicionarRecompensaProduto(pCodTipoPremio int, pCodProduto int, vNomePremio varchar(45),
vQtPontosPremio int, vDescricaoPremio varchar(45), pNomeImagem varchar(255), pNomePasta varchar (255))
begin
	declare cdPremio int;

	select max(cd_premio) + 1 into cdPremio from premio;

	Insert into imagem values(pNomeImagem, pNomePasta);

	Insert into premio (cd_premio, cd_tipo_premio, cd_produto, nm_premio, 
	qt_pontos_premio, ds_premio, ic_ativado)

	values (cdPremio, pCodTipoPremio, pCodProduto, vNomePremio, 
			vQtPontosPremio, vDescricaoPremio, true);

	Update premio
	set nm_imagem = pNomeImagem, nm_pasta_imagem = pNomePasta
	where cd_premio = cdPremio;

end$$


Drop procedure if exists adicionarRecompensaCupom$$
Create procedure adicionarRecompensaCupom(pCodTipoPremio int, pValorCupom int, vCodServico int,
vCodCategoriaServico int, vNomePremio varchar (45), vQtPontosPremio int, vDescricaoPremio varchar(45), 
pNomeImagem varchar(255), pNomePasta varchar (255))
begin
	declare cdPremio int;

	select max(cd_premio) + 1 into cdPremio from premio;

	Insert into imagem values(pNomeImagem, pNomePasta);

	if (vCodServico is not null)
	then
		if not exists (select 1 from cupomservico cs join cupomdesconto cd on (cd.cd_cupom_desconto = cs.cd_cupom_desconto)
						where cd.vl_porcentagem_de_desconto = pValorCupom and cs.cd_servico = vCodServico)
		then
			if not exists (select 1 from cupomdesconto where vl_porcentagem_de_desconto = pValorCupom)
			then
				insert into cupomdesconto values (gerarCodigoCupomDesconto(), pValorCupom);
			end if; 
			insert into cupomservico values ((select cd_cupom_desconto from cupomdesconto where vl_porcentagem_de_desconto = pValorCupom), vCodServico);
		end if;
	end if;

	if (vCodCategoriaServico is not null)
	then
		if not exists (select 1 from cupomservicocupomcategoriadeservico ccs join cupomdesconto cd on (cd.cd_cupom_desconto = ccs.cd_cupom_desconto)
						where cd.vl_porcentagem_de_desconto = pValorCupom and ccs.cd_categoria_servico = vCodCategoriaServico)
		then
			if not exists (select 1 from cupomdesconto where vl_porcentagem_de_desconto = pValorCupom)
			then
				insert into cupomdesconto values (gerarCodigoCupomDesconto(), pValorCupom);
			end if; 
			insert into cupomservicocupomcategoriadeservico values ((select cd_cupom_desconto from cupomdesconto where vl_porcentagem_de_desconto = pValorCupom), vCodCategoriaServico);
		end if;
	end if;


	Insert into premio (cd_premio, cd_tipo_premio, cd_cupom_desconto, cd_servico, cd_categoria_servico,
	nm_premio, qt_pontos_premio, ds_premio, nm_imagem, nm_pasta_imagem, ic_ativado)
	values 
	(cdPremio, pCodTipoPremio, pCodCupomDesconto, vCodServico, vCodCategoriaServico, vNomePremio,
	vQtPontosPremio, vDescricaoPremio, pNomeImagem, pNomePasta, true);

	Update premio
	set nm_imagem = pNomeImagem, nm_pasta_imagem = pNomePasta
	where cd_premio = cdPremio;

end$$

/*RESGATE RECOMPENSA*/

Drop procedure if exists listarPremiosClienteParaResgate$$
Create procedure listarPremiosClienteParaResgate()
begin
	Select pc.cd_premio as cdpremio, p.nm_premio as nmpremio, pc.nm_email_cliente as logincli from premiocliente pc
	join premio p on (pc.cd_premio = p.cd_premio) 
	where pc.ic_resgatado = false and p.cd_tipo_premio = 2 LIMIT 100;
end$$


Drop procedure if exists mostrarPremioDetalhes$$
Create procedure mostrarPremioDetalhes(pCodPremio int)
begin
	Select nm_premio, ds_premio, nm_pasta_imagem, nm_imagem from premio p
	where cd_premio = pCodPremio;
end$$

	
Drop procedure if exists registrarResgatePremiosCliente$$
Create procedure registrarResgatePremiosCliente(pCodPremio int, pEmailCliente varchar(255))
begin
	Update premiocliente 
	set ic_resgatado = true
	where cd_premio = pCodPremio and nm_email_cliente = pEmailCliente;
end$$


Drop procedure if exists filtrarPremiosCliente$$
Create procedure filtrarPremiosCliente(pFiltroPremioCliente text)
begin
	Select pc.cd_premio as cdpremio, p.nm_premio as nmpremio, pc.nm_email_cliente as logincli from premiocliente pc
	join premio p on (pc.cd_premio = p.cd_premio) 
	where pc.cd_premio like pFiltroPremioCliente or p.nm_premio like pFiltroPremioCliente 
	or nm_email_cliente like pFiltroPremioCliente and p.cd_tipo_premio = 2;
end$$


Delimiter ;

/*---------Fim procedures dona---------*/

/* Testagem das procedures*/

/*call ListarCategorias();
call AvaliacoesPopulares();
call CadastrarCliente('daniel.rendeiro@etec.sp.gov.br', 'Daniel','banana');
call ExibirDadosMinimosDoUsuario('daniel.rendeiro@etec.sp.gov.br');
call dadosServicoPopUp(1);
call listarTodosFuncionarios();
call FiltroDeFuncionariosDoServico(1,0,"2023-10-2", '3:0');
call FiltroDeFuncionariosDoServico(1,0,"2023-10-2", '0:0');
call FiltroDeFuncionariosDoServico(1,4,"2023-10-2", '3:0');
call ListarTodosOsPremios();
call ListarPremiosExpessificos(true);
call listarAgendamentosCliente();
call listarPremiosResgatados('saradasilvaspagnuolo2705@gmail.com');
call listarPremiosResgatadosFiltrados('saradasilvaspagnuolo2705@gmail.com', true);*/

/* Fim da testagem das procedures */