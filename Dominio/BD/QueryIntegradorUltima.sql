drop table FiltrosUsuarios
drop table HistorialUsuarios
drop table PerfilUsuarios 
drop table SeguidoresUsuarios
drop table ReportesRecetas
drop table ComentariosRecetas
drop table IngredientesRecetas
drop table PasosRecetas
drop table RecetasFavoritasUsuarios
drop table Recetas
drop table Usuarios

create table Usuarios(
id int identity(1,1) primary key,
email varchar(300) unique not null,
pass nvarchar(64) not null,
salt uniqueidentifier,
tipo int foreign key references TiposUsuarios(id) not null
)

CREATE TRIGGER t_ingresoUsuarioEncriptacion
ON Usuarios
INSTEAD OF insert 
AS 
BEGIN 
	DECLARE @salt UNIQUEIDENTIFIER = NEWID()
	SET NOCOUNT ON
	BEGIN 
		INSERT INTO Usuarios (email, pass, tipo, salt)
		SELECT inserted.email, HASHBYTES('SHA2_512', inserted.pass + CAST(@salt AS NVARCHAR(36))), inserted.tipo, @salt
		FROM inserted
	END
END

insert into Usuarios (email, pass, tipo) values('1','3747','1')

DECLARE @respuesta bit

exec sp_Login @email = '1', 
					@pass = '3747', 
					@respuesta = @respuesta OUTPUT

select @respuesta as '1 es que le embocamos'

CREATE PROCEDURE sp_Login
    @email NVARCHAR(254),
    @pass NVARCHAR(50),
    @respuesta bit OUTPUT

AS
BEGIN
    SET NOCOUNT ON

    DECLARE @userID INT

    IF EXISTS (SELECT TOP 1 id FROM Usuarios WHERE email=@email)
    BEGIN
        SET @userID=(SELECT id FROM usuarios WHERE email=@email AND pass=HASHBYTES('SHA2_512', @pass+CAST(Salt AS NVARCHAR(36))))

       IF(@userID IS NULL)
           SET @respuesta = 0
       ELSE 
           SET @respuesta = 1
    END

    ELSE
       SET @respuesta = 0
END


create table TiposUsuarios(
id int identity(1,1) primary key,
nombre varchar(25) unique not null)

insert into TiposUsuarios values('Administrador'),('Cliente')

create table MomentosComidas(
id int identity(1,1) primary key,
nombre varchar(50) unique
)

insert into MomentosComidas values('desayuno'),('cena'),('merienda'),('almuerzo'), 
('desayuno/merienda'),('almuerzo/cena'),('variado')

create table Estaciones(
id int identity(1,1) primary key,
nombre varchar(50) unique
)

insert into Estaciones values('verano'),('otono'),('invierno'),('primavera'),('todas')

create table Filtros(
id int identity(1,1) primary key,
nombre varchar(50) unique not null)

insert into Filtros values('aptoCeliacos'),('aptoDiabeticos'),('aptoVegetarianos'),('aptoVeganos'),
('bajoCalorias'),('precioMaximo'),('paisOrigen'),('dificultad'),('momentoDia'),('tiempoPreparacion'),('estacion')

create table FiltrosUsuarios(
idUsuario int foreign key references Usuarios(id),
idFiltro int foreign key references Filtros(id),
valor varchar(50),
primary key(idUsuario,idFiltro)
)

create table Recetas(
id int identity(1,1) primary key,
momentoDia int foreign key references MomentosComidas(id) not null,
estacion int foreign key references Estaciones(id) not null,
dificultad int not null,
check(dificultad between 1 AND 5),
tiempoPreparacion int not null,
paisOrigen int foreign key references Paises(id),
foto image,
idCreador int foreign key references Usuarios(id),
cantPlatos int not null,
cantCalorias int,
costo int,
fecha datetime,
puntajeTotal numeric(12,2),
check(puntajeTotal between 0 AND 5),
aptoCeliacos bit,
aptoDiabeticos bit,
aptoVegetarianos bit,
aptoVeganos bit,
habilitada bit
)


CREATE TRIGGER t_ingresarReceta
ON Recetas
INSTEAD OF insert 
AS 
BEGIN 
	IF (
		(SELECT 
			Usuarios.tipo 
		FROM 
			inserted, Usuarios
		WHERE
			inserted.idCreador = Usuarios.id) 
		= 1)
	BEGIN
		INSERT INTO 
			Recetas(momentoDia, estacion, dificultad, tiempoPreparacion, paisOrigen, foto, idCreador, cantPlatos, cantCalorias,
			costo, fecha, puntajeTotal, aptoCeliacos, aptoDiabeticos, aptoVegetarianos, aptoVeganos, habilitada) 
		SELECT 
			inserted.momentoDia, inserted.estacion, inserted.dificultad, inserted.tiempoPreparacion, inserted.paisOrigen, inserted.Foto, inserted.idCreador,
			inserted.cantPlatos, 0, 0, getdate(), 1, 0, 0, 0, 0, 1
		FROM 
			inserted
	END
	ELSE
	BEGIN
		INSERT INTO 
			Recetas(momentoDia, estacion, dificultad, tiempoPreparacion, paisOrigen, foto, idCreador, cantPlatos, cantCalorias,
			costo, fecha, puntajeTotal, aptoCeliacos, aptoDiabeticos, aptoVegetarianos, aptoVeganos, habilitada) 
		SELECT 
			inserted.momentoDia, inserted.estacion, inserted.dificultad, inserted.tiempoPreparacion, inserted.paisOrigen, inserted.Foto, inserted.idCreador,
			inserted.cantPlatos, 0, 0, getdate(), 1, 0, 0, 0, 0, 0
		FROM 
			inserted	
	END	
END



create table TiposIngredientes(
id int identity(1,1) primary key,
nombre varchar(100) unique
)

insert into TiposIngredientes values('Frutas')						--1
insert into TiposIngredientes values('Verduras')					--2
insert into TiposIngredientes values('Productos lácteos')			--3
insert into TiposIngredientes values('Carnes')						--4
insert into TiposIngredientes values('Pescado y mariscos')			--5
insert into TiposIngredientes values('Legumbres')					--6
insert into TiposIngredientes values('Frutos secos y semillas')		--7
insert into TiposIngredientes values('Cereales y derivados')		--8
insert into TiposIngredientes values('Salsas y aderezos')			--9
insert into TiposIngredientes values('Aceites y grasas')			--10
insert into TiposIngredientes values('Ingredientes para hornear')	--11
insert into TiposIngredientes values('Especias y hierbas')			--12

select * from Ingredientes

create table Ingredientes(
id int identity(1,1) primary key,
nombre varchar(200) unique not null,
costo int not null,
medida varchar(2) not null,
check(medida in('ml', 'gr')),
medidaPromedio int not null,
medidaPorGramo int not null,
cantCalorias int not null,
aptoCeliacos bit,
aptoDiabeticos bit,
aptoVegetarianos bit,
aptoVeganos bit,
tipo int foreign key references TiposIngredientes(id) not null,
estacion int foreign key references Estaciones(id) not null,
)

insert into Ingredientes values('Tomate americano', 130, 'gr', 1000, 100, 35, 1, 1, 1, 1, 1, 5)		--1
insert into Ingredientes values('Lechuga crespa', 30, 'gr', 300, 100, 15, 1, 1, 1, 1, 2, 5)			--2
insert into Ingredientes values('Harina de trigo', 45, 'gr', 1000, 100, 364, 0, 0, 1, 1, 11, 5)		--3
insert into Ingredientes values('Aceite de girasol', 45, 'ml', 1000, 13, 107,1,1,1,1,10, 5)			--4
insert into Ingredientes values('Leche entera', 31,'ml', 1000, 200, 115, 1, 1, 1, 0, 3, 5)			--5
insert into Ingredientes values('Sal yodada',38,'gr',500,1,0,1,1,1,1,11,5)						    --6
insert into Ingredientes values('Pimienta',103,'gr',25,100,251,1,1,1,1,12,5)						--7
insert into Ingredientes values('Pollo',118,'gr',1000,100,219,1,1,0,0,4,5)							--8
insert into Ingredientes values('Cebolla',55,'gr',1000,100,40,1,1,1,1,2,5)							--9
insert into Ingredientes values('Morrón rojo',142,'gr',1000,100,35,1,1,1,1,2,5)						--10
insert into Ingredientes values('Nuez moscada molida',40,'gr',5,100,525,1,1,1,1,12,5)				--11
insert into Ingredientes values('Ajo',31,'gr',15,100,149,1,1,1,1,2,5)								--12

select * from Ingredientes

create table IngredientesRecetas(
idReceta int foreign key references Recetas(id) not null,
idIngrediente int foreign key references Ingredientes(id) not null,
cantidad float not null,
primary key(idReceta, idIngrediente)
)

delete from IngredientesRecetas
delete from Ingredientes
DBCC CHECKIDENT ('Ingredientes', RESEED, 0)
delete from Recetas
DBCC CHECKIDENT ('Recetas', RESEED, 0)

CREATE TRIGGER t_actualizarRecetaOnInsertIngrediente
ON IngredientesRecetas
INSTEAD OF insert 
AS 
BEGIN 
	SET NOCOUNT ON; 

	INSERT INTO 
		IngredientesRecetas(idReceta, idIngrediente, cantidad) 
	SELECT 
		inserted.idReceta, inserted.idIngrediente, inserted.cantidad
	FROM 
		inserted

	UPDATE 
		Recetas 
	SET 
		Recetas.costo = Recetas.costo + 
			(SELECT 
				inserted.cantidad * i2.costo / i2.medidaPromedio
				AS 'CostoCalculado'
			FROM 
				inserted, Ingredientes i2
			WHERE 
				inserted.idIngrediente = i2.id)
	FROM 
		inserted ins, Recetas
	WHERE 
		ins.idReceta = Recetas.id 

	UPDATE 
		Recetas 
	SET 
		Recetas.cantCalorias = Recetas.cantCalorias + 
			(SELECT 
				inserted.cantidad * (i2.cantCalorias) / i2.medidaPorGramo
				AS 'CaloriasCalculadas'
			FROM 
				inserted, Ingredientes i2
			WHERE 
				inserted.idIngrediente = i2.id)
	FROM 
		inserted ins, Recetas 
	WHERE 
		ins.idReceta = Recetas.id 

	UPDATE 
		Recetas 
	SET 
		Recetas.aptoCeliacos = CAST(Recetas.aptoCeliacos AS INT) * 
			(SELECT 
				CAST(i2.aptoCeliacos AS INT)
			FROM 
				inserted, Ingredientes i2
			WHERE 
				inserted.idIngrediente = i2.id)
	FROM 
		inserted ins, Recetas 
	WHERE 
		ins.idReceta = Recetas.id

	UPDATE 
		Recetas 
	SET 
		Recetas.aptoDiabeticos = CAST(Recetas.aptoDiabeticos AS INT) * 
			(SELECT 
				CAST(i2.aptoDiabeticos AS INT)
			FROM 
				inserted, Ingredientes i2
			WHERE 
				inserted.idIngrediente = i2.id)
	FROM 
		inserted ins, Recetas 
	WHERE 
		ins.idReceta = Recetas.id 
	
	UPDATE 
		Recetas 
	SET 
		Recetas.aptoVegetarianos = CAST(Recetas.aptoVegetarianos AS INT) * 
			(SELECT 
				CAST(i2.aptoVegetarianos AS INT)
			FROM 
				inserted, Ingredientes i2
			WHERE 
				inserted.idIngrediente = i2.id)
	FROM 
		inserted ins, Recetas 
	WHERE 
		ins.idReceta = Recetas.id

	UPDATE 
		Recetas 
	SET 
		Recetas.aptoVeganos = CAST(Recetas.aptoVeganos AS INT) * 
			(SELECT 
				CAST(i2.aptoVeganos AS INT)
			FROM 
				inserted, Ingredientes i2
			WHERE 
				inserted.idIngrediente = i2.id)
	FROM 
		inserted ins, Recetas 
	WHERE
		ins.idReceta = Recetas.id
END


insert into IngredientesRecetas values(1,3,725)  --725gr harina
insert into IngredientesRecetas values(1,4,125)  --125ml aceite
insert into IngredientesRecetas values(1,5,250)  --250ml leche entera
insert into IngredientesRecetas values(1,6,5.5)  --5.5gr sal
insert into IngredientesRecetas values(1,7,1)    --1gr pimienta
insert into IngredientesRecetas values(1,9,100) --100gr cebolla
insert into IngredientesRecetas values(1,10,50)  --50gr morrón
insert into IngredientesRecetas values(1,12,1.8) --1.8gr ajo
insert into IngredientesRecetas values(1,11,1)   --1g nuez moscada
insert into IngredientesRecetas values(1,8,300)	 --300gr pollo


create table PasosRecetas(
idReceta int foreign key references Recetas(id) not null,
idPaso int identity(1,1),
texto varchar(500) not null,
tiempoReloj time,
urlVideo varchar(500),
imagen image,
primary key(idReceta, idPaso)
)

--Usuario puede puntuar 2 veces???
create table ComentariosRecetas(
idComentario int identity(1,1),
idReceta int foreign key references Recetas(id) not null,
texto varchar(500),
fecha datetime,
puntaje int,
check(puntaje between 0 AND 5),
idUsuario int foreign key references Usuarios(id) not null,
primary key(idReceta, idComentario)
)

insert into ComentariosRecetas(idReceta, texto, fecha, puntaje, idUsuario) values
(1, 'Excelente plato', getDate(), 5, 1)
insert into ComentariosRecetas(idReceta, texto, fecha, puntaje, idUsuario) values
(1, 'Plato deficiente', getDate(), 1, 1)

select * from Recetas

CREATE TRIGGER t_actualizarRecetaAfterInsertComentario
ON ComentariosRecetas
AFTER insert 
AS 
BEGIN 
	SET NOCOUNT ON; 
	UPDATE 
		Recetas 
	SET 
		Recetas.puntajeTotal = (SELECT AVG(c2.puntaje) 

			FROM 
				inserted, ComentariosRecetas c2
			WHERE 
				inserted.idReceta = c2.idReceta)
	FROM 
		inserted ins, Recetas 
	WHERE 
		ins.idReceta = Recetas.id 
END


create table Perfil
(
idUsuario int foreign key references Usuarios(id),
nombre varchar(200) not null,
apellido varchar(200) not null,
nombreUsuario varchar(200),
foto image,
primary key(idUsuario)
)

create table HistorialUsuarios(
idUsuario int foreign key references Usuarios(id),
idReceta int foreign key references Recetas(id),
fechaVista datetime,
primary key(idUsuario, idReceta)
)

create table RecetasFavoritasUsuarios(
idUsuario int foreign key references Usuarios(id),
idReceta int foreign key references Recetas(id),
fechaFavorita datetime,
primary key(idUsuario, idReceta)
)

create table SeguidoresUsuarios(
idUsuarioSeguido int foreign key references Usuarios(id),
idUsuarioSeguidor int foreign key references Usuarios(id),
primary key(idUsuarioSeguido,idUsuarioSeguidor)
)



create table ReportesRecetas(
idReceta int foreign key references Recetas(id),
idReportador int foreign key references Usuarios(id),
idRespondedor int foreign key references Usuarios(id),
razonReporte varchar(500),
fechaReporte datetime,
resuelto bit,
fechaRespuesta datetime,
parteAdministrador varchar(500),
)

CREATE TABLE Paises (
id int identity primary key,
codigo varchar(2) not null, 
nombre varchar(100) not null
)

INSERT INTO Paises VALUES ('AF', 'Afghanistan');
INSERT INTO Paises VALUES ('AL', 'Albania');
INSERT INTO Paises VALUES ('DZ', 'Algeria');
INSERT INTO Paises VALUES ('DS', 'American Samoa');
INSERT INTO Paises VALUES ('AD', 'Andorra');
INSERT INTO Paises VALUES ('AO', 'Angola');
INSERT INTO Paises VALUES ('AI', 'Anguilla');
INSERT INTO Paises VALUES ('AQ', 'Antarctica');
INSERT INTO Paises VALUES ('AG', 'Antigua and Barbuda');
INSERT INTO Paises VALUES ('AR', 'Argentina');
INSERT INTO Paises VALUES ('AM', 'Armenia');
INSERT INTO Paises VALUES ('AW', 'Aruba');
INSERT INTO Paises VALUES ('AU', 'Australia');
INSERT INTO Paises VALUES ('AT', 'Austria');
INSERT INTO Paises VALUES ('AZ', 'Azerbaijan');
INSERT INTO Paises VALUES ('BS', 'Bahamas');
INSERT INTO Paises VALUES ('BH', 'Bahrain');
INSERT INTO Paises VALUES ('BD', 'Bangladesh');
INSERT INTO Paises VALUES ('BB', 'Barbados');
INSERT INTO Paises VALUES ('BY', 'Belarus');
INSERT INTO Paises VALUES ('BE', 'Belgium');
INSERT INTO Paises VALUES ('BZ', 'Belize');
INSERT INTO Paises VALUES ('BJ', 'Benin');
INSERT INTO Paises VALUES ('BM', 'Bermuda');
INSERT INTO Paises VALUES ('BT', 'Bhutan');
INSERT INTO Paises VALUES ('BO', 'Bolivia');
INSERT INTO Paises VALUES ('BA', 'Bosnia and Herzegovina');
INSERT INTO Paises VALUES ('BW', 'Botswana');
INSERT INTO Paises VALUES ('BV', 'Bouvet Island');
INSERT INTO Paises VALUES ('BR', 'Brazil');
INSERT INTO Paises VALUES ('IO', 'British Indian Ocean Territory');
INSERT INTO Paises VALUES ('BN', 'Brunei Darussalam');
INSERT INTO Paises VALUES ('BG', 'Bulgaria');
INSERT INTO Paises VALUES ('BF', 'Burkina Faso');
INSERT INTO Paises VALUES ('BI', 'Burundi');
INSERT INTO Paises VALUES ('KH', 'Cambodia');
INSERT INTO Paises VALUES ('CM', 'Cameroon');
INSERT INTO Paises VALUES ('CA', 'Canada');
INSERT INTO Paises VALUES ('CV', 'Cape Verde');
INSERT INTO Paises VALUES ('KY', 'Cayman Islands');
INSERT INTO Paises VALUES ('CF', 'Central African Republic');
INSERT INTO Paises VALUES ('TD', 'Chad');
INSERT INTO Paises VALUES ('CL', 'Chile');
INSERT INTO Paises VALUES ('CN', 'China');
INSERT INTO Paises VALUES ('CX', 'Christmas Island');
INSERT INTO Paises VALUES ('CC', 'Cocos (Keeling) Islands');
INSERT INTO Paises VALUES ('CO', 'Colombia');
INSERT INTO Paises VALUES ('KM', 'Comoros');
INSERT INTO Paises VALUES ('CG', 'Congo');
INSERT INTO Paises VALUES ('CK', 'Cook Islands');
INSERT INTO Paises VALUES ('CR', 'Costa Rica');
INSERT INTO Paises VALUES ('HR', 'Croatia (Hrvatska)');
INSERT INTO Paises VALUES ('CU', 'Cuba');
INSERT INTO Paises VALUES ('CY', 'Cyprus');
INSERT INTO Paises VALUES ('CZ', 'Czech Republic');
INSERT INTO Paises VALUES ('DK', 'Denmark');
INSERT INTO Paises VALUES ('DJ', 'Djibouti');
INSERT INTO Paises VALUES ('DM', 'Dominica');
INSERT INTO Paises VALUES ('DO', 'Dominican Republic');
INSERT INTO Paises VALUES ('TP', 'East Timor');
INSERT INTO Paises VALUES ('EC', 'Ecuador');
INSERT INTO Paises VALUES ('EG', 'Egypt');
INSERT INTO Paises VALUES ('SV', 'El Salvador');
INSERT INTO Paises VALUES ('GQ', 'Equatorial Guinea');
INSERT INTO Paises VALUES ('ER', 'Eritrea');
INSERT INTO Paises VALUES ('EE', 'Estonia');
INSERT INTO Paises VALUES ('ET', 'Ethiopia');
INSERT INTO Paises VALUES ('FK', 'Falkland Islands (Malvinas)');
INSERT INTO Paises VALUES ('FO', 'Faroe Islands');
INSERT INTO Paises VALUES ('FJ', 'Fiji');
INSERT INTO Paises VALUES ('FI', 'Finland');
INSERT INTO Paises VALUES ('FR', 'France');
INSERT INTO Paises VALUES ('FX', 'France, Metropolitan');
INSERT INTO Paises VALUES ('GF', 'French Guiana');
INSERT INTO Paises VALUES ('PF', 'French Polynesia');
INSERT INTO Paises VALUES ('TF', 'French Southern Territories');
INSERT INTO Paises VALUES ('GA', 'Gabon');
INSERT INTO Paises VALUES ('GM', 'Gambia');
INSERT INTO Paises VALUES ('GE', 'Georgia');
INSERT INTO Paises VALUES ('DE', 'Germany');
INSERT INTO Paises VALUES ('GH', 'Ghana');
INSERT INTO Paises VALUES ('GI', 'Gibraltar');
INSERT INTO Paises VALUES ('GK', 'Guernsey');
INSERT INTO Paises VALUES ('GR', 'Greece');
INSERT INTO Paises VALUES ('GL', 'Greenland');
INSERT INTO Paises VALUES ('GD', 'Grenada');
INSERT INTO Paises VALUES ('GP', 'Guadeloupe');
INSERT INTO Paises VALUES ('GU', 'Guam');
INSERT INTO Paises VALUES ('GT', 'Guatemala');
INSERT INTO Paises VALUES ('GN', 'Guinea');
INSERT INTO Paises VALUES ('GW', 'Guinea-Bissau');
INSERT INTO Paises VALUES ('GY', 'Guyana');
INSERT INTO Paises VALUES ('HT', 'Haiti');
INSERT INTO Paises VALUES ('HM', 'Heard and Mc Donald Islands');
INSERT INTO Paises VALUES ('HN', 'Honduras');
INSERT INTO Paises VALUES ('HK', 'Hong Kong');
INSERT INTO Paises VALUES ('HU', 'Hungary');
INSERT INTO Paises VALUES ('IS', 'Iceland');
INSERT INTO Paises VALUES ('IN', 'India');
INSERT INTO Paises VALUES ('IM', 'Isle of Man');
INSERT INTO Paises VALUES ('ID', 'Indonesia');
INSERT INTO Paises VALUES ('IR', 'Iran (Islamic Republic of)');
INSERT INTO Paises VALUES ('IQ', 'Iraq');
INSERT INTO Paises VALUES ('IE', 'Ireland');
INSERT INTO Paises VALUES ('IL', 'Israel');
INSERT INTO Paises VALUES ('IT', 'Italy');
INSERT INTO Paises VALUES ('CI', 'Ivory Coast');
INSERT INTO Paises VALUES ('JE', 'Jersey');
INSERT INTO Paises VALUES ('JM', 'Jamaica');
INSERT INTO Paises VALUES ('JP', 'Japan');
INSERT INTO Paises VALUES ('JO', 'Jordan');
INSERT INTO Paises VALUES ('KZ', 'Kazakhstan');
INSERT INTO Paises VALUES ('KE', 'Kenya');
INSERT INTO Paises VALUES ('KI', 'Kiribati');
INSERT INTO Paises VALUES ('KP', 'Korea, Democratic People''s Republic of');
INSERT INTO Paises VALUES ('KR', 'Korea, Republic of');
INSERT INTO Paises VALUES ('XK', 'Kosovo');
INSERT INTO Paises VALUES ('KW', 'Kuwait');
INSERT INTO Paises VALUES ('KG', 'Kyrgyzstan');
INSERT INTO Paises VALUES ('LA', 'Lao People''s Democratic Republic');
INSERT INTO Paises VALUES ('LV', 'Latvia');
INSERT INTO Paises VALUES ('LB', 'Lebanon');
INSERT INTO Paises VALUES ('LS', 'Lesotho');
INSERT INTO Paises VALUES ('LR', 'Liberia');
INSERT INTO Paises VALUES ('LY', 'Libyan Arab Jamahiriya');
INSERT INTO Paises VALUES ('LI', 'Liechtenstein');
INSERT INTO Paises VALUES ('LT', 'Lithuania');
INSERT INTO Paises VALUES ('LU', 'Luxembourg');
INSERT INTO Paises VALUES ('MO', 'Macau');
INSERT INTO Paises VALUES ('MK', 'Macedonia');
INSERT INTO Paises VALUES ('MG', 'Madagascar');
INSERT INTO Paises VALUES ('MW', 'Malawi');
INSERT INTO Paises VALUES ('MY', 'Malaysia');
INSERT INTO Paises VALUES ('MV', 'Maldives');
INSERT INTO Paises VALUES ('ML', 'Mali');
INSERT INTO Paises VALUES ('MT', 'Malta');
INSERT INTO Paises VALUES ('MH', 'Marshall Islands');
INSERT INTO Paises VALUES ('MQ', 'Martinique');
INSERT INTO Paises VALUES ('MR', 'Mauritania');
INSERT INTO Paises VALUES ('MU', 'Mauritius');
INSERT INTO Paises VALUES ('TY', 'Mayotte');
INSERT INTO Paises VALUES ('MX', 'Mexico');
INSERT INTO Paises VALUES ('FM', 'Micronesia, Federated States of');
INSERT INTO Paises VALUES ('MD', 'Moldova, Republic of');
INSERT INTO Paises VALUES ('MC', 'Monaco');
INSERT INTO Paises VALUES ('MN', 'Mongolia');
INSERT INTO Paises VALUES ('ME', 'Montenegro');
INSERT INTO Paises VALUES ('MS', 'Montserrat');
INSERT INTO Paises VALUES ('MA', 'Morocco');
INSERT INTO Paises VALUES ('MZ', 'Mozambique');
INSERT INTO Paises VALUES ('MM', 'Myanmar');
INSERT INTO Paises VALUES ('NA', 'Namibia');
INSERT INTO Paises VALUES ('NR', 'Nauru');
INSERT INTO Paises VALUES ('NP', 'Nepal');
INSERT INTO Paises VALUES ('NL', 'Netherlands');
INSERT INTO Paises VALUES ('AN', 'Netherlands Antilles');
INSERT INTO Paises VALUES ('NC', 'New Caledonia');
INSERT INTO Paises VALUES ('NZ', 'New Zealand');
INSERT INTO Paises VALUES ('NI', 'Nicaragua');
INSERT INTO Paises VALUES ('NE', 'Niger');
INSERT INTO Paises VALUES ('NG', 'Nigeria');
INSERT INTO Paises VALUES ('NU', 'Niue');
INSERT INTO Paises VALUES ('NF', 'Norfolk Island');
INSERT INTO Paises VALUES ('MP', 'Northern Mariana Islands');
INSERT INTO Paises VALUES ('NO', 'Norway');
INSERT INTO Paises VALUES ('OM', 'Oman');
INSERT INTO Paises VALUES ('PK', 'Pakistan');
INSERT INTO Paises VALUES ('PW', 'Palau');
INSERT INTO Paises VALUES ('PS', 'Palestine');
INSERT INTO Paises VALUES ('PA', 'Panama');
INSERT INTO Paises VALUES ('PG', 'Papua New Guinea');
INSERT INTO Paises VALUES ('PY', 'Paraguay');
INSERT INTO Paises VALUES ('PE', 'Peru');
INSERT INTO Paises VALUES ('PH', 'Philippines');
INSERT INTO Paises VALUES ('PN', 'Pitcairn');
INSERT INTO Paises VALUES ('PL', 'Poland');
INSERT INTO Paises VALUES ('PT', 'Portugal');
INSERT INTO Paises VALUES ('PR', 'Puerto Rico');
INSERT INTO Paises VALUES ('QA', 'Qatar');
INSERT INTO Paises VALUES ('RE', 'Reunion');
INSERT INTO Paises VALUES ('RO', 'Romania');
INSERT INTO Paises VALUES ('RU', 'Russian Federation');
INSERT INTO Paises VALUES ('RW', 'Rwanda');
INSERT INTO Paises VALUES ('KN', 'Saint Kitts and Nevis');
INSERT INTO Paises VALUES ('LC', 'Saint Lucia');
INSERT INTO Paises VALUES ('VC', 'Saint Vincent and the Grenadines');
INSERT INTO Paises VALUES ('WS', 'Samoa');
INSERT INTO Paises VALUES ('SM', 'San Marino');
INSERT INTO Paises VALUES ('ST', 'Sao Tome and Principe');
INSERT INTO Paises VALUES ('SA', 'Saudi Arabia');
INSERT INTO Paises VALUES ('SN', 'Senegal');
INSERT INTO Paises VALUES ('RS', 'Serbia');
INSERT INTO Paises VALUES ('SC', 'Seychelles');
INSERT INTO Paises VALUES ('SL', 'Sierra Leone');
INSERT INTO Paises VALUES ('SG', 'Singapore');
INSERT INTO Paises VALUES ('SK', 'Slovakia');
INSERT INTO Paises VALUES ('SI', 'Slovenia');
INSERT INTO Paises VALUES ('SB', 'Solomon Islands');
INSERT INTO Paises VALUES ('SO', 'Somalia');
INSERT INTO Paises VALUES ('ZA', 'South Africa');
INSERT INTO Paises VALUES ('GS', 'South Georgia South Sandwich Islands');
INSERT INTO Paises VALUES ('SS', 'South Sudan');
INSERT INTO Paises VALUES ('ES', 'Spain');
INSERT INTO Paises VALUES ('LK', 'Sri Lanka');
INSERT INTO Paises VALUES ('SH', 'St. Helena');
INSERT INTO Paises VALUES ('PM', 'St. Pierre and Miquelon');
INSERT INTO Paises VALUES ('SD', 'Sudan');
INSERT INTO Paises VALUES ('SR', 'Suriname');
INSERT INTO Paises VALUES ('SJ', 'Svalbard and Jan Mayen Islands');
INSERT INTO Paises VALUES ('SZ', 'Swaziland');
INSERT INTO Paises VALUES ('SE', 'Sweden');
INSERT INTO Paises VALUES ('CH', 'Switzerland');
INSERT INTO Paises VALUES ('SY', 'Syrian Arab Republic');
INSERT INTO Paises VALUES ('TW', 'Taiwan');
INSERT INTO Paises VALUES ('TJ', 'Tajikistan');
INSERT INTO Paises VALUES ('TZ', 'Tanzania, United Republic of');
INSERT INTO Paises VALUES ('TH', 'Thailand');
INSERT INTO Paises VALUES ('TG', 'Togo');
INSERT INTO Paises VALUES ('TK', 'Tokelau');
INSERT INTO Paises VALUES ('TO', 'Tonga');
INSERT INTO Paises VALUES ('TT', 'Trinidad and Tobago');
INSERT INTO Paises VALUES ('TN', 'Tunisia');
INSERT INTO Paises VALUES ('TR', 'Turkey');
INSERT INTO Paises VALUES ('TM', 'Turkmenistan');
INSERT INTO Paises VALUES ('TC', 'Turks and Caicos Islands');
INSERT INTO Paises VALUES ('TV', 'Tuvalu');
INSERT INTO Paises VALUES ('UG', 'Uganda');
INSERT INTO Paises VALUES ('UA', 'Ukraine');
INSERT INTO Paises VALUES ('AE', 'United Arab Emirates');
INSERT INTO Paises VALUES ('GB', 'United Kingdom');
INSERT INTO Paises VALUES ('US', 'United States');
INSERT INTO Paises VALUES ('UM', 'United States minor outlying islands');
INSERT INTO Paises VALUES ('UY', 'Uruguay');
INSERT INTO Paises VALUES ('UZ', 'Uzbekistan');
INSERT INTO Paises VALUES ('VU', 'Vanuatu');
INSERT INTO Paises VALUES ('VA', 'Vatican City State');
INSERT INTO Paises VALUES ('VE', 'Venezuela');
INSERT INTO Paises VALUES ('VN', 'Vietnam');
INSERT INTO Paises VALUES ('VG', 'Virgin Islands (British)');
INSERT INTO Paises VALUES ('VI', 'Virgin Islands (U.S.)');
INSERT INTO Paises VALUES ('WF', 'Wallis and Futuna Islands');
INSERT INTO Paises VALUES ('EH', 'Western Sahara');
INSERT INTO Paises VALUES ('YE', 'Yemen');
INSERT INTO Paises VALUES ('ZR', 'Zaire');
INSERT INTO Paises VALUES ('ZM', 'Zambia');
INSERT INTO Paises VALUES ('ZW', 'Zimbabwe');

