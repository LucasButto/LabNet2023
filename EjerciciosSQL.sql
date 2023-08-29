USE PracticaSQL;

-- EJERCICIO 1

/*
1. Recuperar id, apellido, fecha de contratación, salario de los empleados.
Tip: notar presencia de valores nulos.
*/

SELECT ID, LAST_NAME,HIRE_DATE, SALARY FROM [TEST].[EMPLOYEES];

-- EJERCICIO 2

/*
2. Recuperar id, apellido, fecha de contratación, salario anual de los empleados.
*/

SELECT ID, LAST_NAME,HIRE_DATE, (SALARY*12) AS 'ANUAL_SALARY'  FROM [TEST].[EMPLOYEES];

-- EJERCICIO 3 ES EL TIP DEL 2

-- EJERCICIO 4

/*
Recuperar id, apellido y nombre, fecha de contratación, salario anual de los
empleados.
Tip: Concatenar usando ||. Notar que los operadores a usar dependen del tipo de
dato de los campos.
*/

SELECT ID, CONCAT(LAST_NAME, ' ',FIRST_NAME) AS 'FULL_NAME', HIRE_DATE, (SALARY*12) AS 'ANUAL_SALARY'  FROM [TEST].[EMPLOYEES];

--EJERCICIO 5

/*
Recuperar lista de departamentos que tienen empleados:
	a. Recuperar lista de departamentos de los empleados
	b. Recuperar lista no repetida de departamentos de los empleados
*/

-- a
SELECT DEPARTMENT_ID FROM [TEST].[EMPLOYEES]
WHERE DEPARTMENT_ID IS NOT NULL;

--b
SELECT DISTINCT DEPARTMENT_ID FROM [TEST].[EMPLOYEES]
WHERE DEPARTMENT_ID IS NOT NULL;

-- EJERCICIO 6

/*
6. Recuperar lista de empleados cuyo salario sea menor a 2000.
*/

SELECT CONCAT(LAST_NAME, ' ',FIRST_NAME) AS 'FULL_NAME', SALARY FROM [TEST].[EMPLOYEES]
WHERE SALARY < 2000;

-- EJERCICIO 7

/*
7. Recuperar lista de empleados cuyo salario sea entre 1800 y 3000
Tip: usar cláusula “between”. Notar diferencia con el uso de 2 condiciones.
*/

SELECT CONCAT(LAST_NAME, ' ',FIRST_NAME) AS 'FULL_NAME', SALARY FROM [TEST].[EMPLOYEES]
WHERE SALARY BETWEEN 1800 AND 3000;


-- EJERCICIO 8

/*
8. Recuperar lista de empleados cuyo departamento sea 10 o 30 o 31.
Tip: usar cláusula “in”.
*/

SELECT CONCAT(LAST_NAME, ' ',FIRST_NAME) AS 'FULL_NAME', DEPARTMENT_ID FROM [TEST].[EMPLOYEES]
WHERE DEPARTMENT_ID IN (10, 30, 31);

-- EJERCICIO 9

/*
Recuperar lista de empleados cuyo apellido empiece con F.
Tip: usar cláusula “like”. Notar que los operadores a usar dependen del tipo de
dato de los campos.
*/
SELECT CONCAT(LAST_NAME, ' ',FIRST_NAME) AS 'FULL_NAME' FROM [TEST].[EMPLOYEES]
WHERE LAST_NAME LIKE 'F%';

-- EJERCICIO 10

/*
Recuperar lista de empleados cuyo job_id:
a. no hay sido definido
b. haya sido definido.
*/

-- a
SELECT CONCAT(LAST_NAME, ' ',FIRST_NAME) AS 'FULL_NAME', JOB_ID FROM [TEST].[EMPLOYEES]
WHERE JOB_ID IS NULL;

-- B
SELECT CONCAT(LAST_NAME, ' ',FIRST_NAME) AS 'FULL_NAME', JOB_ID FROM [TEST].[EMPLOYEES]
WHERE JOB_ID IS NOT NULL;

-- EJERCICIO 11

/*
11. Recuperar lista de empleados cuyo job_id sea ‘AD_CTB’ o ‘FQ_GRT’ (sin usar
IN) y cuyo salario sea mayor a 1900.
Tip: Probar precedencia de condiciones con o sin paréntesis.
*/

SELECT CONCAT(LAST_NAME, ' ',FIRST_NAME) AS 'FULL_NAME', JOB_ID, SALARY FROM [TEST].[EMPLOYEES]
WHERE (JOB_ID = 'AD_CTB' OR JOB_ID ='FQ_GRT') AND SALARY >1900;

-- EJERCICIO 12 ES EL TIP DEL 11

--EJERCICIO 13

/*
Recuperar empleados ordenados por fecha de ingreso (desde más viejo a más
nuevo).
*/

SELECT CONCAT(LAST_NAME, ' ',FIRST_NAME) AS 'FULL_NAME', HIRE_DATE FROM [TEST].[EMPLOYEES]
WHERE HIRE_DATE IS NOT NULL
ORDER BY HIRE_DATE ASC;

-- EJERCICIO 14

/*
Recuperar empleados ordenados por fecha de ingreso descendente y apellido
ascendente.
*/
SELECT LAST_NAME, HIRE_DATE FROM [TEST].[EMPLOYEES]
WHERE HIRE_DATE IS NOT NULL
ORDER BY HIRE_DATE DESC, LAST_NAME ASC;

-- EJERCICIO 15

/*
Recuperar apellido y salario anual de empleados ordenados por salario anual.
Tip: Usar alias de columna para ordenar por salario anual.
*/

SELECT LAST_NAME, (SALARY*12) AS 'ANUAL_SALARY' FROM [TEST].[EMPLOYEES]
WHERE (SALARY*12) IS NOT NULL
ORDER BY 'ANUAL_SALARY' ASC;

-- EJERCICIO 16 TIP DEL 15

-- EJERCICIO 17

/*
Recuperar lista de empleados con la descripción del departamento al que cada
uno pertenece.
*/

SELECT CONCAT(EMP.LAST_NAME, ' ',EMP.FIRST_NAME) AS 'FULL_NAME', EMP.DEPARTMENT_ID, DEP.ID, DEP.DEPARTMENT_DESCRIPTION 
FROM [TEST].[EMPLOYEES] EMP
INNER JOIN [TEST].[DEPARTMENTS] DEP ON DEP.ID = EMP.DEPARTMENT_ID;

-- EJERCICIO 18

/*
Recuperar lista de empleados con la descripción del departamento, tengan o no
departamento asignado.
*/

SELECT CONCAT(EMP.LAST_NAME, ' ',EMP.FIRST_NAME) AS 'FULL_NAME', EMP.DEPARTMENT_ID, DEP.ID, DEP.DEPARTMENT_DESCRIPTION 
FROM [TEST].[EMPLOYEES] EMP
LEFT JOIN [TEST].[DEPARTMENTS] DEP ON DEP.ID = EMP.DEPARTMENT_ID;

-- EJERCICIO 19

/*
Recuperar lista de departamentos con empleados de cada departamento, tengan o
no empleados asociados.
*/

SELECT DEP.ID, DEP.DEPARTMENT_NAME, CONCAT(EMP.LAST_NAME, ' ',EMP.FIRST_NAME) AS 'FULL_NAME'
FROM [TEST].[DEPARTMENTS] DEP
LEFT JOIN [TEST].[EMPLOYEES] EMP ON DEP.ID = EMP.DEPARTMENT_ID;

-- EJERCICIO 20

/*
Recuperar lista de subordinados por cada mánager
*/

SELECT EMP.ID, CONCAT(EMP.LAST_NAME, ' ',EMP.FIRST_NAME) AS 'EMPLOYEE', EMP.MANAGER_ID ,MAN.ID ,CONCAT(MAN.LAST_NAME, ' ',MAN.FIRST_NAME) AS 'MANAGER' FROM [TEST].[EMPLOYEES] EMP
INNER JOIN [TEST].[EMPLOYEES] MAN ON EMP.MANAGER_ID = MAN.ID;

-- EJERCICIO 21

/*
Recuperar máximo, mínimo, promedio, y suma total de salarios de los empleados.
*/

SELECT MAX(SALARY) AS 'MAX_SALARY', MIN(SALARY) AS 'MIN_SALARY', AVG(SALARY) AS 'AVG_SALARY', SUM(SALARY) AS 'TOTAL_SALARY'
FROM [TEST].[EMPLOYEES];

--EJERCICIO 22

/*
Recuperar máximo, mínimo, promedio, y suma total de fecha de contratación de
los empleados.
Tip: Notar que las funciones de agrupamiento permitidas dependen del tipo de
dato.
*/

SELECT
    MAX(HIRE_DATE) AS 'MAX_HIRE_DATE',
    MIN(HIRE_DATE) AS 'MIN_HIRE_DATE',
    DATEADD(DAY, AVG(DATEDIFF(DAY, 0, hire_date)), 0) AS 'AVG_HIRE_DATE',
    DATEDIFF(DAY, MIN(hire_date), MAX(hire_date)) AS 'SUM_HIRE_DATE'
FROM [TEST].[EMPLOYEES];

-- EJERCICIO 23

/*
Obtener la cantidad de empleados de cada departamento.
*/

SELECT DEP.DEPARTMENT_NAME, COUNT(DEP.ID) AS 'EMPLOYEES_QUANTITY' FROM [TEST].[DEPARTMENTS] DEP
INNER JOIN [TEST].[EMPLOYEES] EMP ON EMP.DEPARTMENT_ID = DEP.ID
GROUP BY DEP.DEPARTMENT_NAME, DEP.ID;

-- EJERCICIO 24

/*
Obtener la cantidad de empleados por cada departamento y job.
*/

SELECT DEP.DEPARTMENT_NAME, EMP.JOB_ID, COUNT(EMP.ID) AS 'EMPLOYEES_QUANTITY'
FROM [TEST].[DEPARTMENTS] DEP
INNER JOIN [TEST].[EMPLOYEES] EMP ON EMP.DEPARTMENT_ID = DEP.ID
GROUP BY DEP.DEPARTMENT_NAME, EMP.JOB_ID;

-- EJERCICIO 25

/*
Recuperar los departamentos y el salario promedio si es menor a 1200.
*/

SELECT DEP.DEPARTMENT_NAME, AVG(EMP.SALARY) AS AVERAGE_SALARY
FROM [TEST].[DEPARTMENTS] DEP
INNER JOIN [TEST].[EMPLOYEES] EMP ON DEP.ID = EMP.DEPARTMENT_ID
WHERE EMP.SALARY < 1200
GROUP BY DEP.DEPARTMENT_NAME;

-- EJERCICIO 26

/*
Caso 1: Crear insert de todos los campos en orden.
Tip: Notar restricciones de integridad por padre inexistente y por clave duplicada.
*/

DECLARE @LAST_EMPLOYEES_ID INT;

SELECT TOP 1 @LAST_EMPLOYEES_ID = ID
FROM [TEST].[EMPLOYEES]
ORDER BY ID DESC;

SET @LAST_EMPLOYEES_ID = @LAST_EMPLOYEES_ID + 1;

INSERT INTO [TEST].[EMPLOYEES]
           ([ID]
           ,[FIRST_NAME]
           ,[LAST_NAME]
           ,[SALARY]
           ,[DEPARTMENT_ID]
           ,[JOB_ID]
           ,[HIRE_DATE]
           ,[MANAGER_ID])
     VALUES
           (@LAST_EMPLOYEES_ID
           ,'Juan'
           ,'Perez'
           ,2000
           ,20
           ,'FQ_OPR'
           ,'2011-10-01 00:00:00.000'
           ,NULL);

-- EJERCICCIO 27

/*
Crear insert usando solamente los campos obligatorios.
*/

DECLARE @LAST_DEPARTMENTS_ID INT;

SELECT TOP 1 @LAST_DEPARTMENTS_ID = ID
FROM [TEST].[DEPARTMENTS]
ORDER BY ID DESC;

SET @LAST_DEPARTMENTS_ID = @LAST_DEPARTMENTS_ID + 10;

INSERT INTO [TEST].[DEPARTMENTS]
           ([ID]
           ,[DEPARTMENT_NAME]
           ,[LOCATION_ID])
     VALUES
           (@LAST_DEPARTMENTS_ID
           ,'Mantenimiento y Reparaciones'
           ,2)

-- EJERCICIO 28

/*
Especificar lista de campos obligatorios.
*/

SELECT COLUMN_NAME
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_SCHEMA = 'TEST' 
  AND TABLE_NAME = 'DEPARTMENTS' 
  AND IS_NULLABLE = 'NO';

SELECT COLUMN_NAME
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_SCHEMA = 'TEST' 
  AND TABLE_NAME = 'EMPLOYEES' 
  AND IS_NULLABLE = 'NO';

SELECT COLUMN_NAME
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_SCHEMA = 'TEST' 
  AND TABLE_NAME = 'JOBS' 
  AND IS_NULLABLE = 'NO';

SELECT COLUMN_NAME
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_SCHEMA = 'TEST' 
  AND TABLE_NAME = 'LOCATIONS' 
  AND IS_NULLABLE = 'NO';

-- EJERCICIO 29

/*
Crear un nuevo empleado basado en los datos de Gustavo Boulette:
	cambiando su nombre
	aumentando su sueldo en $200.
	blanqueando su manager
*/

DECLARE @LAST_EMPLOYEES_ID INT; -- COMENTAR ESTA LINEA SI QUIERE CORRER TODO EL SQL JUNTO

SELECT TOP 1 @LAST_EMPLOYEES_ID = ID
FROM [TEST].[EMPLOYEES]
ORDER BY ID DESC;

SET @LAST_EMPLOYEES_ID = @LAST_EMPLOYEES_ID + 1;

INSERT INTO [TEST].[EMPLOYEES] (ID,FIRST_NAME, LAST_NAME, SALARY, DEPARTMENT_ID, JOB_ID, HIRE_DATE, MANAGER_ID)
SELECT
	@LAST_EMPLOYEES_ID,
    'German',
    'Perez',
    SALARY + 200,
    DEPARTMENT_ID,
    JOB_ID,
    HIRE_DATE,
    NULL
FROM [TEST].[EMPLOYEES]
WHERE FIRST_NAME = 'Gustavo' AND LAST_NAME = 'Boulette';

-- EJERCICIO 30

/*
30.Actualizar salario del empleado 10 a $1100.
*/

UPDATE [TEST].[EMPLOYEES]
   SET [SALARY] = 1100
 WHERE ID = 10;

-- EJERCICIO 30-1

/*
Aumentar salario en un 10% a todos los empleados del departamento 40.
*/

UPDATE [TEST].[EMPLOYEES]
   SET [SALARY] = SALARY * 1.1
WHERE DEPARTMENT_ID = 40;

-- EJERCICIO 30-2

/*
Eliminar departamentos cuyo id sea mayor a 50.
Tip: hacer un select antes y después para verificar usando la misma condición que para el
delete.
*/

DELETE FROM [TEST].[DEPARTMENTS]
      WHERE ID > 50;

-- EJERCICIO 30-3

/*
Eliminar departamento 40.
Tip: notar resultado de las restricciones de integridad.
*/

UPDATE [TEST].[EMPLOYEES]
SET DEPARTMENT_ID = NULL
WHERE DEPARTMENT_ID =40;

DELETE FROM [TEST].[DEPARTMENTS]
      WHERE ID = 40;

-- EJERCICIO 30-4

/*
Crear la función &quot;fn_AntiguedadEmpleado&quot; que retorne la antiguedad en años de cada
empleado donde el parametro de ingreso es el id del empleado
*/

USE PracticaSQL;

CREATE FUNCTION fn_AntiguedadEmpleado (@EmpleadoID INT)
RETURNS INT
AS
BEGIN
    DECLARE @HireDate DATETIME;
    DECLARE @CurDate DATETIME;
    DECLARE @Years INT;

    SELECT @HireDate = HIRE_DATE FROM [TEST].[EMPLOYEES] WHERE ID = @EmpleadoID;
    SET @CurDate = GETDATE();
    
    SET @Years = DATEDIFF(YEAR, @HireDate, @CurDate);
    
    RETURN @Years;
END;


SELECT ID, dbo.fn_AntiguedadEmpleado(ID) AS 'Antiguedad en años'
FROM [TEST].[EMPLOYEES];


-- EJERCICIO 31

/*
Crear el Procedimiento almacenado "sp_GetNombreAntiguedad" que retorne el primer
nombre y el apellido separados por una coma y en la segunda columna la antiguedad en año. Usar
la función creada en el punto anterior.
Ordenar por antiguedad descendiente (mas antiguo primero)
*/

CREATE PROCEDURE sp_GetNombreAntiguedad
AS
BEGIN
    SELECT 
        CONCAT(LAST_NAME, ', ',FIRST_NAME) AS 'Nombre completo',
        dbo.fn_AntiguedadEmpleado(ID) AS 'Antiguedad en años'
    FROM [TEST].[EMPLOYEES]
    ORDER BY dbo.fn_AntiguedadEmpleado(ID) DESC;
END;

EXEC sp_GetNombreAntiguedad;

-- EJERCICIO 32

/*
Crear una nueva tabla de “Auditoria” con los siguientes campos:
? ID (auto incremental),
? Operación (si se hace un insert/delete/update)
? Fecha
Crear un trigger sobre la tabla de empleados que al hacer un insert/delete/update registre en la
nueva tabla de auditoria la operación realizada.
*/

CREATE TABLE TEST.AUDITORIA (
    ID INT PRIMARY KEY IDENTITY(1,1),
    OPERATION VARCHAR(50),
    OPERATION_DATE DATETIME
);

CREATE TRIGGER tr_AuditoriaEmpleados
ON [TEST].[EMPLOYEES]
AFTER INSERT, DELETE, UPDATE
AS
BEGIN
    DECLARE @Operacion VARCHAR(50);

    IF EXISTS (SELECT * FROM inserted) AND EXISTS (SELECT * FROM deleted)
        SET @Operacion = 'Update';
    ELSE IF EXISTS (SELECT * FROM inserted)
        SET @Operacion = 'Insert';
    ELSE IF EXISTS (SELECT * FROM deleted)
        SET @Operacion = 'Delete';

    INSERT INTO [TEST].[AUDITORIA] (OPERATION, OPERATION_DATE)
    VALUES (@Operacion, GETDATE());
END;


-- PRUEBA DEL TRIGGER

DECLARE @LAST_EMPLOYEES_ID INT; -- COMENTAR ESTA LINEA SI QUIERE CORRER TODO EL SQL JUNTO

SELECT TOP 1 @LAST_EMPLOYEES_ID = ID
FROM [TEST].[EMPLOYEES]
ORDER BY ID DESC;

SET @LAST_EMPLOYEES_ID = @LAST_EMPLOYEES_ID + 1;

INSERT INTO [TEST].[EMPLOYEES]
           ([ID]
           ,[FIRST_NAME]
           ,[LAST_NAME]
           ,[SALARY]
           ,[DEPARTMENT_ID]
           ,[JOB_ID]
           ,[HIRE_DATE]
           ,[MANAGER_ID])
     VALUES
           (@LAST_EMPLOYEES_ID
		   ,'Chuck'
		   ,'Norris'
		   ,2500
		   ,10
		   ,'FQ_GRT'
		   ,GETDATE()
		   ,NULL)


UPDATE [TEST].[EMPLOYEES]
   SET [FIRST_NAME] = 'Han'
      ,[LAST_NAME] = 'Solo'
 WHERE FIRST_NAME = 'Chuck' AND LAST_NAME = 'Norris';

DELETE FROM [TEST].[EMPLOYEES]
      WHERE FIRST_NAME = 'Han' AND LAST_NAME = 'Solo';

SELECT * FROM [TEST].[AUDITORIA];
