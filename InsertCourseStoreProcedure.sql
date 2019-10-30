SELECT * FROM tbl_Course;


CREATE PROCEDURE sp_Insert_Course
@CourseName NVARCHAR(50),
@CourseCode NVARCHAR(11)
AS
BEGIN
INSERT INTO tbl_Course VALUES(@CourseName,@CourseCode)
END;