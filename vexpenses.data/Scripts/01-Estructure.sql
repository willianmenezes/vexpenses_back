create extension if not exists "uuid-ossp";

CREATE TABLE pessoa (
	pessoaid uuid NOT NULL DEFAULT uuid_generate_v4(),
	nome varchar(200) NOT NULL,
	email varchar(200) NOT NULL,
	senha varchar(50) NOT NULL,
	status boolean not null default true
	CONSTRAINT pk_pessoa_pessoaid PRIMARY KEY (pessoaid)
);

CREATE TABLE refreshtoken (
	pessoaid uuid NOT NULL,
	"token" varchar(500) NULL,
	expiracao varchar(50) NULL,
	CONSTRAINT pk_refreshtoken_pessoaid PRIMARY KEY (pessoaid)
);

ALTER TABLE refreshtoken ADD CONSTRAINT fk_refreshtoken_pessoaid FOREIGN KEY (pessoaid) REFERENCES pessoa(pessoaid);

create table tipoagenda(
tipoagendaid		uuid primary key default uuid_generate_v4(),
descricao			varchar(200) not null,
status				boolean not null default true
);

create table agenda(
agendaid			uuid primary key default uuid_generate_v4(),
nome 				varchar(200) not null,
descricao			varchar(400),
tipoagendaid		uuid not null,
pessoaid 			uuid NOT null,
status				boolean not null default true,
CONSTRAINT agenda_pessoaid_fk FOREIGN KEY (pessoaid) REFERENCES pessoa(pessoaid),
constraint agenda_tipoagenda_fk foreign key (tipoagendaid) references tipoagenda(tipoagendaid)
);

create table contato(
contatoid			uuid primary key default uuid_generate_v4(),
nome				varchar(200) not null,
sobrenome 			varchar(200),
email				varchar(200),
status				boolean not null default true
);

create table agendacontato(
agendaid			uuid not null,
contatoid			uuid not null,
constraint agendacontato_pk primary key(agendaid, contatoid),
constraint agendacontato_contato_fk foreign key (contatoid) references contato(contatoid),
constraint agendacontato_agenda_fk foreign key (agendaid) references agenda(agendaid)
);
ALTER TABLE public.agendacontato ADD CONSTRAINT agendacontato_agenda_uk UNIQUE (agendaid);

create table endereco(
enderecoid			uuid primary key default uuid_generate_v4(),
cep					varchar(8) not null,
logradouro			varchar(200),
complemento			varchar(200),
bairro				varchar(200),
localidade			varchar(200),
uf					varchar(200),
contatoid			uuid not null,
status				boolean not null default true,
constraint endereco_contato_fk foreign key (contatoid) references contato(contatoid)
);

create table tipotelefone(
tipotelefoneid		uuid primary key default uuid_generate_v4(),
descricao			varchar(200) not null,
status				boolean not null default true
);

create table telefone(
telefoneid			uuid primary key default uuid_generate_v4(),
DDD					varchar(2) not null,
numero				varchar(9) not null,
contatoid			uuid not null,
tipotelefoneid		uuid not null,
status				boolean not null default true,
constraint telefone_contato_fk foreign key (contatoid) references contato(contatoid),
constraint telefone_tipotelefone_fk foreign key (tipotelefoneid) references tipotelefone(tipotelefoneid)
);
