CREATE DATABASE ClinicaDental ON
(
  NAME = 'ClinicaDental',
  FILENAME = 'C:\Proyecto_POO_MDB\ClinicaDental\DB_ClinicaDental\ClinicaDental.mdf',
  SIZE = 20,
  MAXSIZE = UNLIMITED,
  FILEGROWTH = 10
)
LOG ON
(
  NAME = 'ClinicaDental_log',
  FILENAME = 'C:\Proyecto_POO_MDB\ClinicaDental\DB_ClinicaDental\ClinicaDental_log.ldf',
  SIZE = 10,
  MAXSIZE = UNLIMITED,
  FILEGROWTH = 5
)
GO

CREATE TABLE SystemUsers
(
  userCode varchar(8) NOT NULL PRIMARY KEY,
  password varchar(16) NOT NULL,
  firstName VARCHAR(15) NOT NULL,
  middleName varchar(15),
  lastName VARCHAR(40) NOT NULL
)
GO

INSERT INTO [SystemUsers] VALUES
('Admin000','AdminPassword','Administrator',NULL,'SystemAdmin')
GO

SELECT * FROM [SystemUsers]