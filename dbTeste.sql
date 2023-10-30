drop database dbTeste;

create database dbTeste;
use dbTeste;

create table tbl_Bairro(
idBairro int primary key auto_increment,
NomeBairro varchar(200) not null
);

create table tbl_Cidade(
IdCidade int primary key auto_increment,
NomeCidade varchar(200) not null
);

create table tbl_endereco(
Cep bigint primary key,
Logradouro varchar(255) not null,
idBairro int not null,
foreign key (idBairro) references tbl_Bairro (IdBairro), 
IdCidade int not null,
foreign key (IdCidade) references tbl_Cidade (IdCidade)
);

create table tbl_login(
IdLogin bigint primary key auto_increment,
TipoAcesso varchar(50) not null,
Login varchar(55) not null,
Senha varchar(100) not null
);

create table tbl_cadastro(
IdCad int auto_increment primary key,
Nome varchar(255) not null,
NumEnd int null,
CompleEnd varchar(50),
Cpf decimal(11, 0) not null,
Telefone bigint not null,
Email varchar(250) not null,
Cep bigint not null,
foreign key (Cep) references tbl_endereco (Cep),
Login bigint,
foreign key (Login) references tbl_login (IdLogin)
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
select * from tbl_Bairro;

delimiter $$
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
call spInsertEnde(12345057, 'Rua Pão na Chapa', 'Barra Funda', 'Ponta Grossa'); 

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
create procedure spInsertCad(vNome varchar(200), vSenha varchar(100), vCpf decimal(11, 0), vTelefone bigint, vCep bigint, vNumEnd int, vEmail varchar(250), 
				vCompleEnd varchar(50), vLogradouro varchar(200), vNomeBairro varchar(50), vNomeCidade varchar(50), vTipoAcesso varchar(50))
begin
	if not exists(select Cpf from tbl_cadastro where vCpf = Cpf) then
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
					value(default, vTipoAcesso, vEmail, vSenha);
		insert into tbl_cadastro(Nome, NumEnd, CompleEnd, Cpf, Telefone, Email, Cep, Login)
                    values(vNome, vNumEnd, vCompleEnd, vCpf, vTelefone, vEmail, (select Cep from tbl_endereco where Cep = vCep), (select IdLogin from tbl_login where Login = vEmail));
	else
	    select "informaçoes já resgistradas";
    end if;
end$$

call spInsertCad('Felipe', 'felipe1234', 12345678910, 234567890, 12345050, 456, 'Felipe@gmail.com', null, 'Rua da Federal', 'Lapa', 'São Paulo', 'Cliente');
call spInsertCad('Alex', 'alex6789', 12345678911, 912341234, 05089001, 466, 'Alex@gmail.com', null, 'Rua Guaipá', 'Vila Lepoldina', 'São Paulo', 'Cliente');
call spInsertCad('Lipe', 'lipe2345', 12345678912, 234567890, 12345050, 456, 'Lipee@gmail.com', null, 'Rua da Federal', 'Lapa', 'São Paulo', 'Administrador');
call spInsertCad('Diego','diego5678', 12345678913, 912341234, 05089001, 466, 'Diego@gmail.com', null, 'Rua Guaipá', 'Vila Lepoldina', 'São Paulo', 'Administrador');

select * from tbl_cadastro;
select * from tbl_login;

create view vwcadastro as
select
	tbl_cadastro.IdCad,
	tbl_cadastro.Nome,
    tbl_cadastro.Cpf,
    tbl_cadastro.Email,
    tbl_cadastro.Telefone,
    tbl_login.Senha,
    tbl_login.TipoAcesso
from tbl_login
inner join tbl_cadastro on (tbl_login.IdLogin = tbl_cadastro.Login);

select * from vwcadastro;

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

/* truncate tbl_cadastro;
truncate tbl_login; */

/* select carrinho e itemcarrinho
insert nas mesmas
puxar produtos comprados
identificas cliente */