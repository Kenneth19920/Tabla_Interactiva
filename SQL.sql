USE G5_CASO1

CREATE TABLE EMPLEADO
(ID_EMPLEADO numeric(6)  NOT NULL,
NOMBRE VARCHAR(30) NOT NULL,
APELLIDO VARCHAR(30) NOT NULL,
EDAD NUMERIC(3) NOT NULL,
SALARIO DECIMAL(12,2) NOT NULL,
Email VARCHAR(30) not null,
PRIMARY KEY(ID_EMPLEADO))
