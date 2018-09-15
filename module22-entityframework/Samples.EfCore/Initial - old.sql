/*
DROP TABLE Interviews
DROP TABLE Students
DROP TABLE Logs
*/

CREATE TABLE Students
(
	[Id] INT PRIMARY KEY IDENTITY(1, 1),
	[Name] nvarchar(max) NOT NULL,
	[UniversityDegree] BIT NOT NULL
)

CREATE TABLE Interviews
(
	[Id] INT PRIMARY KEY IDENTITY(1, 1),
	[StudentId] INT NOT NULL,
	[Score] INT NULL,
	[Feedback] nvarchar(max) NULL,

	CONSTRAINT FK_InterviewStudents FOREIGN KEY (StudentId)
		REFERENCES Students(Id)
)

CREATE TABLE Logs
(
	[Id] INT PRIMARY KEY IDENTITY(1, 1),
	[Time] DATETIME NOT NULL,
	[Description] nvarchar(max) NULL
)

INSERT INTO Students(Name, UniversityDegree) VALUES
('Robert Martin', 1),
('Kent Beck', 1),
('David Heinemeier', 0)

INSERT INTO Interviews(StudentId, Score, Feedback) VALUES
(1, 5, 'He is so solid'),
(2, 4, 'I would prefer to test him before'),
(3, 3, 'Hiring him is like abstinence-only sex ed')