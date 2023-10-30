drop database dbtcc;

create database dbtcc;
use dbtcc;

create table tbl_Bairro(
idBairro int primary key auto_increment,
NomeBairro varchar(200) not null
);

create table tbl_Cidade(
IdCidade int primary key auto_increment,
NomeCidade varchar(200) not null
);

create table tbl_enderecoEntrega(
Cep bigint primary key,
Logradouro varchar(255) not null,
NumEnd int null,
CompleEnd varchar(50),
idBairro int not null,
foreign key (idBairro) references tbl_Bairro (IdBairro), 
IdCidade int not null,
foreign key (IdCidade) references tbl_Cidade (IdCidade)
);

create table tbl_login(
IdLogin bigint auto_increment primary key,
TipoAcesso varchar(50) not null,
Login varchar(55) not null,
Senha varchar(100) not null
);

create table tbl_cliente(
IdCli int auto_increment primary key,
NomeCli varchar(255) not null,
Cpf varchar(11) not null,
Telefone varchar(9) not null,
EmailCli varchar(250) not null,
Login bigint,
foreign key (Login) references tbl_login (IdLogin)
);

create table tbl_cor(
IdCor bigint auto_increment primary key,
Cor varchar(55)
);

create table tbl_tamanho(
IdTamanho bigint auto_increment primary key,
Tamanho varchar(2)
);

create table tbl_produto(
CodigoBarras bigint primary key,
NomeProd varchar(200) not null,
ValorUnitario decimal(8, 2) not null,
Qtd int not null,
Cor bigint,
foreign key (Cor) references tbl_cor (IdCor),
Tamanho bigint,
foreign key (Tamanho) references tbl_tamanho (IdTamanho)
);

create table tbl_carrinho(
IdCar bigint auto_increment primary key,
TotalCar decimal(7, 2) not null,
NomeCli int,
foreign key (NomeCli) references tbl_cliente (IdCli)
);

create table tbl_itemCarrinho(
ValorItem decimal(7, 2) not null,
Qtd bigint not null,
TotalProd decimal(7, 2) not null,
primary key(IdCar, CodigoBarras),
CodigoBarras bigint, 
foreign key (CodigoBarras) references tbl_produto (CodigoBarras),
IdCar bigint, 
foreign key (IdCar) references  tbl_carrinho (IdCar)
);

create table tbl_funcionario(
IdFunc int auto_increment primary key,
NomeFunc varchar(255) not null,
Cpf varchar(11) not null,
Telefone bigint not null,
EmailFunc varchar(250) not null,
Login bigint,
foreign key (Login) references tbl_login (IdLogin)
);

create table tbl_TipoDePagamento(
NumeroCartao bigint primary key not null,
DataValida date not null,
TipoCartao boolean,
IdTitular int,
foreign key (IdTitular) references tbl_cliente (IdCli)
);

create table tbl_pagamento(
NumPaga int primary key auto_increment,
FormPaga boolean,
NumCartao bigint,
foreign key (NumCartao) references tbl_TipoDePagamento (NumeroCartao)
);

create table tbl_NotaFiscal(
Nf int primary key auto_increment,
TotalNota decimal(7, 2) not null,
DataEmissao date not null
);

create table tbl_pedido(
NumeroPedido int primary key,
DataPedido date,
DataPrazo date,
TotalPedido decimal (7, 2) not null,
Frete decimal (5,2),
IdCliPed int,
foreign key (idCliPed) references tbl_cliente (IdCli),
Nf int,
foreign key (Nf) references tbl_notafiscal (Nf),
NumPaga int,
foreign key (NumPaga) references tbl_pagamento (NumPaga),
LocalEntrega bigint,
foreign key (LocalEntrega) references tbl_enderecoEntrega (Cep)
);

create table tbl_itemPedido(
ValorItem decimal(7, 2) not null,
Qtd bigint not null,
TotalProd decimal(7, 2) not null,
primary key(NumeroPedido, CodigoBarras),
CodigoBarras bigint, 
foreign key (CodigoBarras) references tbl_produto (CodigoBarras),
NumeroPedido int, 
foreign key (NumeroPedido) references  tbl_pedido (NumeroPedido)
);

delimiter $$
create procedure spInsertCid(vNomeCida varchar(200))
begin
insert into tbl_Cidade (NomeCidade) values (vNomeCida);
end $$

call spInsertCid ("Rio de Janeiro");
call spInsertCid ("São Carlos");
call spInsertCid ("Campinas");
call spInsertCid ("Franco da Rocha");
call spInsertCid ("Osasco");
call spInsertCid ("Pirituba");
call spInsertCid ("Lapa");
call spInsertCid ("Ponta Grossa");

delimiter $$
create procedure spInserBairro(vBairro varchar (200))
begin
insert into tbl_Bairro (Nomebairro) values (vBairro);
end $$

call spInserBairro ("Aclimação");
call spInserBairro ("Capão Redondo");
call spInserBairro ("Pirituba");
call spInserBairro ("Liberdade");

select * from tbl_Cidade union 
select * from tbl_Bairro union 
select * from tbl_Uf;

delimiter $$
create procedure spInserProd(vCodigoBarras bigint, vNomeProd varchar(200), VCor varchar(55), vTamanho char(2), vValorUnitario decimal(8, 2), vQtd int)
begin
	if not exists(select CodigoBarras from tbl_produto where CodigoBarras = vCodigoBarras) then
		if not exists(select IdCor from tbl_cor where Cor = vCor) then
			insert into tbl_cor(Cor) values (vCor);
		end if;
		if not exists(select IdTamanho from tbl_tamanho where Tamanho = vTamanho) then
			insert into tbl_tamanho(Tamanho) values (vTamanho);
		end if;
        insert into tbl_produto (CodigoBarras, NomeProd , Cor, Tamanho, ValorUnitario, Qtd) values 
					(vCodigoBarras, vNomeProd, (select IdCor from tbl_cor where Cor = vCor), (select IdTamanho from tbl_tamanho where Tamanho = vTamanho), vValorUnitario, vQtd);
        else
			select('Produto já resgistrado!')
		end;
    end if;
end $$

call spInserProd (12345678910111, "Caixa camisa", "Colorida", "G", 54.61, 120);
call spInserProd (12345678910112, "Caixa calça", "Neutra", "P", 100.61, 100);
call spInserProd (12345678910113, "Caixa doação", "Mista", "GG", 84.61, 50);
call spInserProd (12345678910114, "Caixa calça", "Colorida", "M", 100.61, 100);
call spInserProd (12345678910115, "Caixa doação", "Neutra", "G", 84.61, 2);

select * from tbl_produto;
select * from tbl_cor;
select * from tbl_tamanho;

/*delimiter $$
create procedure spInsertEnde(vCep int, vLogradouro varchar(200), vNomeBairro varchar(50), vNomeCidade varchar(50))
begin
	if not exists(select Cep from tbl_endereco where vCep = Cep) then
    if not exists(select IdBairro from tbl_Bairro where vNomeBairro = NomeBairro) then
		insert into tbl_Bairro(NomeBairro) values(vNomeBairro);
	end if;
	if not exists(select IdCidade from tbl_Cidade where vNomeCidade = NomeCidade) then
		insert into tbl_Cidade(NomeCidade) values(vNomeCidade);
	end if;
	insert into tbl_endereco (Cep, Logradouro, idBairro, IdCidade)
                values(vCep, vLogradouro, (select idBairro from tbl_Bairro where vNomeBairro = NomeBairro), (select idCidade from tbl_Cidade where vNomeCidade = NomeCidade));
    else
      select "Informaçoes já registradas";
    end if;
end$$

call spInsertEnde(12345050, 'Rua da Federal', 'Lapa', 'São Paulo');
call spInsertEnde(12345051, 'Av Brasil', 'Lapa', 'Campinas');
call spInsertEnde(12345052, 'Rua Liberdade', 'Consolação', 'São Paulo');
call spInsertEnde(12345053, 'Av Paulista', 'Penha', 'Rio de Janeiro');
call spInsertEnde(12345054, 'Rua Ximbú', 'Penha', 'Rio de Janeiro');
call spInsertEnde(12345055, 'Rua Piu XI', 'Penha', 'Campinas');
call spInsertEnde(12345056, 'Rua Chocolate', 'Aclimação', 'Barra Mansa');
call spInsertEnde(12345057, 'Rua Pão na Chapa', 'Barra Funda', 'Ponta Grossa');*/ 

select * from tbl_endereco;

create view vwEndereco as
select 
	tbl_endereco.cep,
    tbl_endereco.logradouro,
    tbl_Bairro.NomeBairro,
    tbl_Cidade.NomeCidade
from tbl_endereco inner join tbl_Cidade
    on (tbl_endereco.idcidade = tbl_cidade.idcidade)
    inner join tbl_Bairro
    on (tbl_endereco.Idbairro = tbl_Bairro.IdBairro);
    
select * from vwEndereco;

delimiter $$
create procedure spInsertCli(vNomeCLi varchar(200), vEmailCli varchar(250), vSenha varchar(100), vCpf varchar(11), vTelefone varchar(9))
begin
	if not exists(select Cpf from tbl_cliente where vCpf = Cpf) then
    if not exists(select EmailCli from tbl_cliente where vEmailCli = EmailCli) then
		insert into tbl_login(IdLogin, TipoAcesso, Login, Senha)
					value(default, 'Cliente', vEmailCli, vSenha);
		insert into tbl_cliente(NomeCli, Cpf, Telefone, EmailCli, Login)
                    values(vNomeCli, vCpf, vTelefone, vEmailCli, (select IdLogin from tbl_login where Login = vEmailCli));
	else
	    select "Email já foi utilizado";
    end if;
    else 
		select "Cliente já resgistrado";
    end if;
end$$

call spInsertCli('Felipe', 'Felipe@gmail.com', 'felipe1234', 12345678910, 234567890);
call spInsertCli('Alex', 'alex6789', 12345678911, 912341234, 05089001, 466, null, 'Rua Guaipá', 'Vila Lepoldina', 'São Paulo');

-- delete from tbl_cliente where IdCli = 1;

select * from tbl_cliente;
select * from tbl_login;

create view vwcliente as
select
	tbl_cliente.IdCli,
	tbl_cliente.NomeCli,
    tbl_cliente.EmailCli,
    tbl_cliente.Telefone,
    tbl_cliente.Cpf,
    tbl_login.Login,
    tbl_login.Senha
from tbl_login
inner join tbl_cliente on (tbl_login.IdLogin = tbl_cliente.Login);

select * from vwcliente;

delimiter $$
create procedure spSelectLogin(vEmail varchar(250))
begin
	select EmailCli from tbl_cliente where EmailCli = vEmail;
end$$

call spSelectLogin('Felipe@gmail.com');

delimiter $$
create procedure spSelectCli(vEmail varchar(50))
begin
	select * from vwcliente where Login = vEmail;
end$$

call spSelectCli('Felipe@gmail.com');

/* delimiter $$
create procedure spInsertFunci(vNomeFunc varchar(200), vTipoAcesso varchar(50), vSenha varchar(255), vCnpj decimal(14, 0), vTelefone bigint, vCep bigint, vNumEnd int, vCompleEnd varchar(50), vLogradouro varchar(200), vNomeBairro varchar(50), vNomeCidade varchar(50))
begin
	if not exists(select Cnpj from tbl_funcionario where vCnpj = Cnpj) then
       if not exists(select Cep from tbl_endereco where vCep = Cep) then
          if not exists(select IdBairro from tbl_Bairro where vNomeBairro = NomeBairro) then
		  insert into tbl_Bairro(NomeBairro) values(vNomeBairro);
          end if;
		  if not exists(select IdCidade from tbl_Cidade where vNomeCidade = NomeCidade) then
		  insert into tbl_Cidade(NomeCidade) values(vNomeCidade);
          end if;
          insert into tbl_endereco (Cep, Logradouro, idBairro, IdCidade)
                    values(vCep, vLogradouro, (select idBairro from tbl_Bairro where vNomeBairro = NomeBairro),
                       (select idCidade from tbl_Cidade where vNomeCidade = NomeCidade));
      end if;
		insert into tbl_login(IdLogin, TipoAcesso, Login, Senha)
					value(default, vTipoAcesso, vNomeFunc, vSenha);
		insert into tbl_funcionario(NomeFunc, NumEnd, CompleEnd, Cnpj, Telefone, CepFunc, Login)
                    values(vNomeFunc, vNumEnd, vCompleEnd, vCnpj, vTelefone, (select Cep from tbl_endereco where Cep = vCep), (select IdLogin from tbl_login where Login = vNomeFunc));
	else
	    select "informaçoes já resgistradas";
    end if;
end$$ */

/* call spInsertFunci('Lipe', 'Administrador', 'lipe2345', 12345678910, 234567890, 12345050, 456, null, 'Rua da Federal', 'Lapa', 'São Paulo');
call spInsertFunci('Diego', 'Administrador','diego5678', 12345678911, 912341234, 05089001, 466, null, 'Rua Guaipá', 'Vila Lepoldina', 'São Paulo'); */

select * from tbl_funcionario;
select * from tbl_login;

create drop view vwfuncionario as
select
	tbl_funcionario.IdFunc,
    tbl_funcionario.Cnpj,
    tbl_login.Login,
    tbl_login.Senha,
    tbl_login.TipoAcesso
from tbl_login
inner join tbl_funcionario on (tbl_login.IdLogin = tbl_funcionario.Login);

select * from vwfuncionario;

delimiter $$
create procedure spInsertCart(vNomeCli varchar(255), vNumCart bigint, vDataVali char(10), vTipoCart varchar(255))
begin
	declare TipoCart boolean;
	set @IdCli = (select IdCli from tbl_cliente where NomeCli = vNomeCli);
	set @DataVali = str_to_date(vDataVali, '%d/%m/%Y');
        
	if(vTipoCart = 'Credito') then
    set TipoCart = 1;
	insert into tbl_TipoDePagamento(NumeroCartao, DataValida, TipoCartao, IdTitular)
			values(vNumCart, @DataVali, TipoCart, @IdCli);
	else
	set TipoCart = 0;
	insert into tbl_TipoDePagamento(NumeroCartao, DataValida, TipoCartao, IdTitular)
			values(vNumCart, @DataVali, TipoCart, @IdCli);
	end if;
end$$

call spInsertCart('Felipe', 12345676, '22/08/2022', 'Debito');
call spInsertCart('Alex', 12345678, '22/08/2022', 'Credito');

create view vwCartao as
select
	tbl_tipodepagamento.NumeroCartao,
    DATE_FORMAT(tbl_tipodepagamento.DataValida, '%d/%m/%Y') as DataValida,
    if(TipoCartao = 1, "Credito", "Debito") as "TipoCartao",
    tbl_cliente.NomeCli
from tbl_tipodepagamento inner join tbl_cliente
on (tbl_tipodepagamento.IdTitular = tbl_cliente.IdCli);

select * from vwCartao;

delimiter $$
create procedure spInsertCarrinho(vEmail varchar(200), vNomeProd varchar(50), vQtd bigint, vValorUnitario decimal(7,2))
begin
	set @TotalCar = vValorUnitario  * vQtd;
    set @NomeCli = (select NomeCli from tbl_cliente where EmailCli = vEmail);
        
	if not exists (select IdCar from tbl_carrinho order by IdCar desc limit 1) then
		insert into tbl_carrinho (IdCar, TotalCar, NomeCli) values (default, @TotalCar, @NomeCli);
    end if;
    if not exists (select CodigoBarras from tbl_itempedido where CodigoBarras = vCodigoBarras and NumeroPedido = vNumPed) then
		insert into tbl_itempedido (ValorItem, Qtd, TotalProd, CodigoBarras, NumeroPedido) values (@ValorItem, vQtd, @TotalProd, @CodBarras, (select NumeroPedido from tbl_pedido order by NumeroPedido desc limit 1));
        update tbl_pedido set TotalPedido = (select sum(TotalProd) from tbl_itempedido where NumeroPedido = vNumPed) + Frete where NumeroPedido = vNumPed;
		update tbl_produto set Qtd = Qtd - vQtd where CodigoBarras = vCodigoBarras;
	end if;
end$$ 

delimiter $$
create procedure spInsertPedido(vNumPed int, vCliente varchar(200), vCodigoBarras bigint, vQtd bigint)
begin
	declare vFrete decimal (5, 2);
    set vFrete = 2.00;
	set @IdCli = (select IdCli from tbl_cliente where NomeCli = vCliente);
    set @CodBarras = (select CodigoBarras from tbl_produto where CodigoBarras = vCodigoBarras);
    set @ValorItem = (select ValorUnitario from tbl_produto where CodigoBarras = vCodigoBarras);
    set @TotalPedido = (select ValorUnitario from tbl_produto where CodigoBarras = vCodigoBarras) * vQtd;
    set @TotalProd = (select ValorUnitario from tbl_produto where CodigoBarras = vCodigoBarras) * vQtd;
    set @DataPedido = now();
    set @DataPrazo = date_add(now(), interval 7 day);
        
    if not exists (select NumeroPedido from tbl_pedido where NumeroPedido = vNumPed) then
		insert into tbl_pedido (NumeroPedido, DataPedido, DataPrazo, TotalPedido, Frete, IdCliPed, Nf, NumPaga) values (vNumPed, @DataPedido, @DataPrazo, @TotalProd, vFrete, @IdCli, null, null);
    end if;
    if not exists (select CodigoBarras from tbl_itempedido where CodigoBarras = vCodigoBarras and NumeroPedido = vNumPed) then
		insert into tbl_itempedido (ValorItem, Qtd, TotalProd, CodigoBarras, NumeroPedido) values (@ValorItem, vQtd, @TotalProd, @CodBarras, (select NumeroPedido from tbl_pedido order by NumeroPedido desc limit 1));
        update tbl_pedido set TotalPedido = (select sum(TotalProd) from tbl_itempedido where NumeroPedido = vNumPed) + Frete where NumeroPedido = vNumPed;
		update tbl_produto set Qtd = Qtd - vQtd where CodigoBarras = vCodigoBarras;
	end if;
end$$

call spInsertPedido(1, 'Felipe', 12345678910111, 5);
call spInsertPedido(1, 'Felipe', 12345678910112, 3);
call spInsertPedido(3, 'Felipe', 12345678910111, 1);
call spInsertPedido(3, 'Felipe', 12345678910112, 2);
call spInsertPedido(2, 'Alex', 12345678910111, 2);
call spInsertPedido(2, 'Alex', 12345678910112, 3);
call spInsertPedido(4, 'Alex', 12345678910113, 2);
call spInsertPedido(4, 'Alex', 12345678910111, 7);

delete from tbl_pedido where NumeroPedido = 3;

select * from tbl_pedido;
select * from tbl_itempedido;
select * from tbl_produto;

create view vwPedido as
select
	tbl_cliente.idCli,
    tbl_cliente.NomeCli,
    Date_Format(tbl_pedido.DataPedido, '%d/%m/%Y') as DataPedido,
    Date_Format(tbl_pedido.DataPrazo, '%d/%m/%Y') as DataPrazo,
    tbl_pedido.NumeroPedido,
    tbl_pedido.TotalPedido,
    tbl_pedido.Nf,
    tbl_pedido.NumPaga
from tbl_cliente
inner join tbl_pedido on tbl_cliente.IdCli = tbl_pedido.IdCliPed;

select * from vwPedido;

/* delimiter $$
create procedure spInsertPagamento(vNomeCli varchar(55), vNumeroCartao bigint)
begin
	set @IdCli = (select IdCli from tbl_cliente where NomeCli = vNomeCli);
    set @TipoCartao = (select TipoCartao from tbl_tipodepagamento where NumeroCartao = vNumeroCartao);
    
    if(select NumeroPedido from vwPedido where idCli = @IdCli and Nf is null order by idCli desc limit 1) then
		insert into tbl_pagamento(NumPaga, FormPaga, NumCartao) values (default, @TipoCartao, vNumeroCartao);
		update tbl_pedido set NumPaga = (select NumPaga from tbl_pagamento order by NumPaga desc limit 1) where IdCliPed = @IdCli and Nf is null;
    end if;
end$$

call spInsertPagamento('Felipe', 12345676);
call spInsertPagamento('Alex', 12345678);

delete from tbl_pagamento where NumPaga = 4;

select * from tbl_pagamento;

create view vwPagamento as
select
    tbl_cliente.IdCli,
    tbl_cliente.NomeCli,
    if(FormPaga = 1, "Credito", "Debito") as "FormPaga",
    tbl_pedido.DataPedido,
    tbl_pedido.TotalPedido,
    tbl_pedido.NumeroPedido,
    tbl_pagamento.NumCartao,
    tbl_pagamento.NumPaga,
    tbl_pedido.Nf
from tbl_pagamento
inner join tbl_pedido on tbl_pagamento.NumPaga = tbl_pedido.NumPaga
inner join tbl_tipodepagamento on tbl_pagamento.NumCartao = tbl_tipodepagamento.NumeroCartao
inner join tbl_cliente on tbl_tipodepagamento.IdTitular = tbl_cliente.IdCli;

select * from vwPagamento;

delimiter $$
create procedure spInsertNotaFiscal(vNomeCli varchar(255))
begin
	set @IdCli = (select IdCli from tbl_cliente where NomeCli = vNomeCli);
	set @TotalNota = (select TotalPedido from vwPagamento where IdCli = @IdCli and Nf is null order by TotalPedido desc limit 1);
    set @DataEmissao = now();
    
    if(select NumPaga from vwPagamento where IdCli = @IdCli and Nf is null order by NumPaga desc limit 1) then
		insert into tbl_notafiscal (Nf, TotalNota, DataEmissao) values (default, @TotalNota, @DataEmissao);
		update tbl_pedido set Nf = (select Nf from tbl_NotaFiscal order by Nf desc limit 1) where IdCliPed = @IdCli and Nf is null;
    end if;
end$$

call spInsertNotaFiscal('Felipe');
call spInsertNotaFiscal('Alex');

select * from tbl_notafiscal;
select * from tbl_pedido;

create view vwNotaFiscal as
select
	tbl_notafiscal.Nf,
    tbl_cliente.NomeCli,
    tbl_notafiscal.DataEmissao,
    tbl_pagamento.NumPaga,
    if(tbl_pagamento.FormPaga = 1, "Credito", "Debito") as "FormPaga",
    tbl_notafiscal.TotalNota,
    tbl_pedido.NumeroPedido
from tbl_notafiscal
inner join tbl_pedido on tbl_notafiscal.Nf = tbl_pedido.Nf
inner join tbl_pagamento on tbl_pedido.NumPaga = tbl_pagamento.NumPaga
inner join tbl_tipodepagamento on tbl_pagamento.NumCartao = tbl_tipodepagamento.NumeroCartao
inner join tbl_cliente on tbl_tipodepagamento.IdTitular = tbl_cliente.IdCli;

select * from vwNotaFiscal; */