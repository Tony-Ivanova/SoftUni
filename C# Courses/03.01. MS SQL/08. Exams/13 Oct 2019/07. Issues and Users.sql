SELECT i.Id AS [Id], CONCAT(u.Username, ' : ', i.Title) AS [IssueAssignee]
FROM Issues as i
JOIN Users as u 
ON i.AssigneeId = u.Id
ORDER BY i.Id DESC, [IssueAssignee]
