SELECT * FROM tbl_Enrollment;


CREATE PROCEDURE sp_Insert_Enrollment
@StudentId NVARCHAR(50),
@CourseId NVARCHAR(11),
@EnrollmentDate SMALLDATETIME
AS
BEGIN
INSERT INTO tbl_Enrollment VALUES(@StudentId,@CourseId,@EnrollmentDate)
END;