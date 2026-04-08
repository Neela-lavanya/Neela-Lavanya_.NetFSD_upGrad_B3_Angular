CREATE DATABASE StuCouDB;
USE StuCouDB;

CREATE TABLE Course (
    CourseId INT PRIMARY KEY IDENTITY(1,1),
    CourseName NVARCHAR(100) NOT NULL
);

CREATE TABLE Student (
    StudentId INT PRIMARY KEY IDENTITY(1,1),
    StudentName NVARCHAR(100) NOT NULL,
    CourseId INT,
    FOREIGN KEY (CourseId) REFERENCES Course(CourseId)
);

INSERT INTO Course (CourseName)
VALUES ('Java'), ('.NET'), ('Python');

INSERT INTO Student (StudentName, CourseId)
VALUES 
('Lavi', 1),
('Indu', 1),
('Sudha', 2),
('Anji', 3);

SELECT 
    s.StudentId, s.StudentName, s.CourseId,
    c.CourseId, c.CourseName
FROM Student s
INNER JOIN Course c
ON s.CourseId = c.CourseId;