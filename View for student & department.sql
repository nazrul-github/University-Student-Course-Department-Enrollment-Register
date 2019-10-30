SELECT * FROM tbl_Student;
SELECT * FROM tbl_Department;
SELECT * FROM studentDepartment;

CREATE VIEW studentDepartment
AS
SELECT ST.StudentID,ST.StudentName,ST.MobileNumber,ST.EmailAddress,DP.DepartmentName
FROM tbl_Student AS ST INNER JOIN tbl_Department AS DP ON ST.DepartmentID = DP.DepartmentId;
