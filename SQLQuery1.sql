CREATE DATABASE Dapper_Demo_DB;

use Dapper_Demo_DB;

CREATE TABLE SuperHeros (
    SUPERHERO_ID INT IDENTITY(1,1) PRIMARY KEY,
    CHARACTER_NAME VARCHAR(20) NOT NULL,
    REAL_NAME VARCHAR(20) NOT NULL,
    SUPERHERO_DESCRIPTION VARCHAR(50) NOT NULL
);



select *from SuperHeros

INSERT INTO SuperHeros (CHARACTER_NAME, REAL_NAME,SUPERHERO_DESCRIPTION) VALUES
('Iron Man','Tony Stark','The coolest superhero to ever grace MCU.') 




create Procedure sp_create_superhero 
( 
@CHARACTER_NAME VARCHAR(20), 
@REAL_NAME VARCHAR(20), 
@SUPERHERO_DESCRIPTION VARCHAR(50))
as
BEGIN
INSERT INTO DBO.SuperHeros (CHARACTER_NAME, REAL_NAME, SUPERHERO_DESCRIPTION)
VALUES (@CHARACTER_NAME, @REAL_NAME, @SUPERHERO_DESCRIPTION)
END



create Procedure sp_update_superhero 
(
@SUPERHERO_ID INT,
@CHARACTER_NAME VARCHAR(20), 
@REAL_NAME VARCHAR(20), 
@SUPERHERO_DESCRIPTION VARCHAR(50))
as
BEGIN
UPDATE DBO.SuperHeros SET CHARACTER_NAME = @CHARACTER_NAME , REAL_NAME = @REAL_NAME,
							SUPERHERO_DESCRIPTION = @SUPERHERO_DESCRIPTION
	WHERE SUPERHERO_ID = @SUPERHERO_ID
END




create Procedure sp_get_all_superhero 
as
BEGIN
SELECT *FROM DBO.SUPERHEROS
END


--drop proc dbo.sp_get_all_superhero


create Procedure sp_get_superhero 
(
@SUPERHERO_ID INT
)
as
BEGIN
SELECT *FROM DBO.SuperHeros
	WHERE SUPERHERO_ID = @SUPERHERO_ID
END


create Procedure sp_remove_superhero 
(
@SUPERHERO_ID INT
)
as
BEGIN
DELETE FROM DBO.SuperHeros
	WHERE SUPERHERO_ID = @SUPERHERO_ID
END



exec sp_get_all_superhero




SELECT *FROM SUPERHEROS

--begin transaction

--delete from superheros where superhero_id = 2

--select *from superheros

--rollback