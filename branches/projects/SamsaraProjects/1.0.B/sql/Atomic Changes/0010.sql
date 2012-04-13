
UPDATE ProjectsAndTendering.TenderLines
SET TenderLineNumber = T0.TenderLineNumber_
FROM
(
	SELECT
		ROW_NUMBER() OVER(ORDER BY TenderId, TenderLineId) - (
			SELECT COUNT(*)
			FROM ProjectsAndTendering.TenderLines tl_
			WHERE tl_.Deleted = 0 AND tl_.TenderId < tl.TenderId
		)
		TenderLineNumber_,
		TenderId TenderId_, TenderLineId TenderLineId_
	FROM ProjectsAndTendering.TenderLines tl
	WHERE Deleted = 0 
	GROUP BY TenderLineId, TenderId
) T0
WHERE TenderLineId = T0.TenderLineId_

UPDATE ProjectsAndTendering.TenderLines
SET TenderLineNumber = 1
WHERE TenderLineNumber IS NULL