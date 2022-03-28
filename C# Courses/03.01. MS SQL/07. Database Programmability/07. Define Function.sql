CREATE FUNCTION ufn_IsWordComprised(@setOfLetters NVARCHAR(MAX), @word NVARCHAR(MAX))
RETURNS BIT
AS
BEGIN
	DECLARE @WordLength INT = LEN(@word)
	DECLARE @INDEX INT = 1
	DECLARE @trueOrFalse BIT = 1

		WHILE @WordLength >= @INDEX AND @trueOrFalse > 0
		BEGIN
			DECLARE @letterFromWord CHAR(1)
			DECLARE @charIndex INT
			SET @letterFromWord = SUBSTRING(@word, @INDEX, 1)
			SET @charIndex = CHARINDEX(@letterFromWord, @setOfLetters)

				IF(@charIndex > 0)
				BEGIN
					SET @trueOrFalse = 1
				END
				ELSE
				BEGIN
					SET @trueOrFalse = 0
				END
			SET @INDEX += 1
		END
RETURN @trueOrFalse
END

DROP FUNCTION ufn_IsWordComprised

SELECT dbo.ufn_IsWordComprised('oistmiahf', 'Sofia')
SELECT dbo.ufn_IsWordComprised('oistmiahf', 'halves')
