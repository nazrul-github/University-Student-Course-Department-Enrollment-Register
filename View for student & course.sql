SELECT * FROM studentDepartment;
SELECT * FROM tbl_Course;
SELECT * FROM tbl_Enrollment;

CREATE VIEW studentCourse
AS
SELECT ST.StudentID, ST.StudentName,ST.MobileNumber,ST.EmailAddress,ST.DepartmentName,CS.CourseName,EN.EnrollmentDate FROM studentDepartment AS ST INNER JOIN tbl_Enrollment AS EN ON 
ST.StudentID = EN.StudentID
INNER JOIN tbl_Course AS CS ON EN.CourseID = CS.CourseId;