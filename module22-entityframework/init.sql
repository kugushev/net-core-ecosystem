
CREATE TABLE "Students"
(
	"Id" INT PRIMARY KEY,
	"Name" TEXT NOT NULL,
	"UniversityDegree" BOOLEAN NOT NULL
);

INSERT INTO "Students"("Id", "Name", "UniversityDegree") VALUES
(1, 'Robert Martin', true),
(2, 'Kent Beck', true),
(3, 'David Heinemeier', false)