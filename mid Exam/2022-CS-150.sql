
SELECT u.Email AS EmailId, c.CourseTitle AS CourseName
FROM dbo.AspNetUsers u
JOIN dbo.SpikoStudent s ON u.Id = s.UserId
JOIN dbo.SpikoStudentSection ss ON s.StudentId = ss.StudentId
JOIN dbo.SpikoSection sec ON ss.SectionId = sec.Id
JOIN dbo.SpikoCourse c ON sec.CourseId = c.CourseId
LEFT JOIN dbo.SpikoAssignmentSubmission sa ON s.StudentId = sa.StudentId
WHERE sa.StudentId IS NULL;


SELECT CASE
        WHEN MONTH(sec.DateCreated) BETWEEN 9 AND 12 THEN 'Fall'
        WHEN MONTH(sec.DateCreated) BETWEEN 1 AND 5 THEN 'Spring'
        ELSE 'Summer'
    END AS SemesterName
FROM dbo.SpikoStudentSection ss
JOIN dbo.SpikoSection sec ON ss.SectionId = sec.Id
GROUP BY CASE
        WHEN MONTH(sec.DateCreated) BETWEEN 9 AND 12 THEN 'Fall'
        WHEN MONTH(sec.DateCreated) BETWEEN 1 AND 5 THEN 'Spring'
        ELSE 'Summer'
    END;


	SELECT c.CourseTitle AS CourseName
FROM dbo.SpikoCourse c
LEFT JOIN dbo.SpikoSection sec ON c.CourseId = sec.CourseId
LEFT JOIN dbo.SpikoStudentSection ss ON sec.Id = ss.SectionId
WHERE ss.StudentId IS NULL
GROUP BY c.CourseTitle;

SELECT CONCAT(s.FullName, ' (', s.RegistrationNumber, ')') AS StudentName,
       SUM(se.ObtainedMarks) AS TotalMarks
FROM dbo.SpikoStudent s
JOIN dbo.SpikoStudentEvaluation se ON s.StudentId = se.StudentId
JOIN dbo.SpikoEvaluation ev ON se.EvaluationId = ev.Id
WHERE ev.CourseId = 1015
GROUP BY s.FullName, s.RegistrationNumber;





SELECT c.CourseTitle AS CourseName
FROM dbo.SpikoCourse c
JOIN dbo.SpikoAnnouncement a ON c.CourseId = a.CourseId
GROUP BY c.CourseTitle
HAVING COUNT(a.Id) > 5;

SELECT CONCAT(s.FullName, ' (', s.RegistrationNumber, ')') AS StudentName
FROM dbo.SpikoStudent s
JOIN dbo.AspNetUsers u ON s.UserId = u.Id
JOIN dbo.SpikoAssignmentSubmission sa ON s.StudentId = sa.StudentId
JOIN dbo.SpikoAssignment a ON sa.AssignmentId = a.Id
WHERE a.DeadLine - sa.SubmittedOn <= '01:00:00'
GROUP BY s.FullName, s.RegistrationNumber
HAVING COUNT(sa.AssignmentId) > 2;

SELECT c.CourseTitle AS CourseName
FROM dbo.SpikoCourse c
JOIN dbo.SpikoSection sec ON c.CourseId = sec.CourseId
JOIN dbo.SpikoStudentSection ss ON sec.Id = ss.SectionId
GROUP BY c.CourseTitle
HAVING COUNT(DISTINCT ss.StudentId) > 50;


SELECT a.Id AS AssignmentId
FROM dbo.SpikoAssignment a
JOIN dbo.SpikoAssignmentSubmission sa ON a.Id = sa.AssignmentId
WHERE a.DeadLine - sa.SubmittedOn > '02:00:00' -- Assuming the deadline is at least 2 hours
GROUP BY a.Id
HAVING COUNT(sa.StudentId) <= 2;


SELECT c.CourseTitle AS CourseName
FROM dbo.SpikoCourse c
JOIN dbo.SpikoSection sec ON c.CourseId = sec.CourseId
JOIN dbo.SpikoAssignment a ON sec.Id = a.SectionId
WHERE a.OpenDate <= GETDATE() AND a.DeadLine >= GETDATE()
GROUP BY c.CourseTitle;

SELECT s1.RegistrationNumber AS RegistrationNumber1, s2.RegistrationNumber AS RegistrationNumber2
FROM dbo.SpikoStudentSection ss1
JOIN dbo.SpikoStudentSection ss2 ON ss1.StudentId = ss2.StudentId AND ss1.SectionId != ss2.SectionId
JOIN dbo.SpikoStudent s1 ON ss1.StudentId = s1.StudentId
JOIN dbo.SpikoStudent s2 ON ss2.StudentId = s2.StudentId
GROUP BY s1.RegistrationNumber, s2.RegistrationNumber
HAVING COUNT(DISTINCT ss1.SectionId) > 3 AND COUNT(DISTINCT ss2.SectionId) > 3;

SELECT ss1.RegistrationNumber AS RegistrationNumber1, ss2.RegistrationNumber AS RegistrationNumber2 FROM (SELECT sa1.StudentId, sa1.AssignmentId, (SELECT COUNT(*) FROM dbo.SpikoAssignmentSubmission sa3 WHERE sa3.AssignmentId = sa1.AssignmentId AND sa3.SubmittedOn <= sa1.SubmittedOn) AS SubmissionOrder FROM dbo.SpikoAssignmentSubmission sa1) s1 JOIN (SELECT sa2.StudentId, sa2.AssignmentId, (SELECT COUNT(*) FROM dbo.SpikoAssignmentSubmission sa4 WHERE sa4.AssignmentId = sa2.AssignmentId AND sa4.SubmittedOn <= sa2.SubmittedOn) AS SubmissionOrder FROM dbo.SpikoAssignmentSubmission sa2) s2 ON s1.AssignmentId = s2.AssignmentId AND s1.SubmissionOrder = s2.SubmissionOrder - 1 JOIN dbo.SpikoStudent ss1 ON s1.StudentId = ss1.StudentId JOIN dbo.SpikoStudent ss2 ON s2.StudentId = ss2.StudentId GROUP BY ss1.RegistrationNumber, ss2.RegistrationNumber, s1.AssignmentId HAVING COUNT(s1.StudentId) > 2;
















