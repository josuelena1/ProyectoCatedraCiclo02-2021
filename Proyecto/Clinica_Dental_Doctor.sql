-- Proyecto de cátedra Ciclo 02 - 2021
-- MDB G05T y POO G05T

----- Creación de la base de datos -----
CREATE DATABASE Clinica_Dental_Doctor

Use Clinica_Dental_Doctor
go

------ Creación de tablas -----

------------Creación tabla usuarios------------------
Create table Usuarios
(
Usuario varchar (8) not null,
Tipo varchar (15) not null,
Contraseña varchar (20) not null,
Primary Key (Usuario)
)


---------------creación tabla medicos-------------
Create table Medicos(
Nombre_Doctor varchar (120) not null,
Edad int not null,
Especialización varchar(50) not null,
Numero int not null,
Usuario_Doc varchar(8)  not null ,
primary key (Nombre_Doctor),
foreign key (Usuario_Doc) references Usuarios (Usuario)
)

---------------creación tabla cliente-----------
create table Cliente(
Usuario varchar (8) not null,
Telefono int not null,
Correo varchar(50) not null,
Genero varchar (15) not null,
Nombre_Comp varchar (100) not null,
Edad int not null,
DUI int not null,
Primary key (DUI),
foreign key (Usuario) references Usuarios (Usuario)
on update cascade
)
------------creación tabla procedimientos----------------
create table  Procedimientos(
Procedimiento varchar (50) not null,
Doctor_En_Cargo varchar (120) not null,
Precio decimal not null,
Foreign key (Doctor_En_Cargo) references Medicos(Nombre_Doctor),
primary key (Procedimiento)
)

---------------------creación tabla citas---------------------------
Create table Citas (
Fechas_Hora datetime not null,
Id_Cita varchar (10) not null,
Tratamiento varchar (50) not null,
DUI INT not null,
primary key (Id_Cita),
foreign key (DUI) references Cliente(DUI),
foreign key (Tratamiento) references Procedimientos (Procedimiento)
)

----- Insertando datos a las tablas -----

-----------------Inserts de los Doctores y Procedimientos-----------------
insert into Usuarios (Usuario, Tipo, Contraseña)values 
('ae210567', 'administrador','albertoelena'),
('cd210488', 'administrador','colochodiaz'),
('hm210444', 'administrador','hernandezmarquez'),
('pr210566', 'administrador','perezrivas'),
('vc200416', 'administrador','venturacortez'),
('cv210468','administrador','cañasvaldizon'),
('alex01','administrador','alexander'),
('doc01','administrador','doc01'),
('doc02','administrador','doc02'),
('doc03','administrador','doc03'),
('admi01','administrador','admi01'),
('admi02','administrador','admi02'),
('admi03','administrador','admi03')



insert into Medicos (Nombre_Doctor, Edad, Especialización, Numero, Usuario_Doc)values
('Bryan Elena','29','Odontólogo general','22505001','ae210567'),
('Jairo Colocho','28','Odontopediatra','22505002','cd210488'),
('Javier Marquez','27','Ortodoncista','22505003','hm210444'),
('Mercedes Perez','26','Periodoncista','22505004','pr210566'),
('Francisco Ventura','29','Endodoncista','22505005','vc200416'),
('Oscar Cañas','28', 'Cirujano oral','22505006','cv210468'),
('Alexander Campos','27','Prostodoncista','22505007','alex01'),
('Fabiola Díaz','26','Odontólogo general','22505008','doc01'),
('Rafael Duran','29','Odontopediatra','22505009','doc02'),
('Luis Ayala','28','Ortodoncista','22505010','doc03')

insert into Procedimientos (Procedimiento, Doctor_En_Cargo, Precio)values 
('Examen bucodental inicial', 'Bryan Elena', '35.05'),
('Llenado total', 'Jairo Colocho', '30.05'),
('Extracciones dentales', 'Javier Marquez', '20.05'),
('Ortodoncia', 'Mercedes Perez', '30.05'),
('Blanqueamiento', 'Francisco Ventura', '65.05'),
('Puentes dentales','Oscar Cañas', '105.05'),
('Limpieza dental','Alexander Campos', '15.05'),
('Tratamiento de nervio','Fabiola Díaz', '115.05'),
('Carillas dentales','Rafael Duran', '75.05'),
('Exámenes de rutina','Luis Ayala', '35.05')

-----------------Procedimientos y Vistas-------------------------

------------------------ Procedimiento para insertar datos-----------------------
--(Este sirve para agregarlos a la tabla Usuarios)-----------------------
create proc Insert_Usuarios
@Usuario varchar (8),
@Tipo varchar(15),
@Contraseña varchar (20)
AS
IF exists (Select Usuario FROM Usuarios where Usuario=@Usuario)
RaisError ('EL nombre de Usuario ya existe',16,1)

else
Insert Into Usuarios
Values (@Usuario, 
@Tipo ,
@Contraseña)
return


-------------(Este a la tabla clientes)------------------------------
Create Proc Insert_Cliente
@Us varchar(8),
@Telefono int,
@correo varchar(50),
@genero varchar (15),
@nombre varchar(100),
@Edad int,
@dui int
AS
IF exists (Select Usuario FROM Cliente where Usuario=@Us)
RaisError ('EL nombre de Usuario ya existe',16,1)
else 
insert into Cliente
values 
(@Us,
@Telefono, 
@correo,
@genero,
@nombre,
@Edad,
@dui 
)
return

select * from Usuarios

----------------------Procedimiento para mostrar el Cliente-----------------

create proc mostrar_Cliente
@Usuario varchar (8)
as select Nombre_Comp as [nombre],
		Correo,
		Cliente.Usuario as [us],
		Edad,
		DUI,
		Telefono,
		Genero
		

		from Cliente
		inner join Usuarios
		on Usuarios.Usuario=Cliente.Usuario
		where @Usuario = Cliente.Usuario