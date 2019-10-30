SELECT * FROM tbl_Department;


CREATE PROCEDURE sp_Insert_Department
@DepartmentName NVARCHAR(50),
@DepartmentCode NVARCHAR(11)
AS
BEGIN
INSERT INTO tbl_Department VALUES(@DepartmentName,@DepartmentCode)
END;