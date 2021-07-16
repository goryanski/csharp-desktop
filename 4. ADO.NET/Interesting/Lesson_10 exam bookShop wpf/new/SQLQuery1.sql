USE BookShopExamDb
GO

CREATE OR ALTER FUNCTION GetMostPopularBooks()
RETURNS TABLE
AS
	RETURN 
		SELECT * FROM Books
		WHERE Id IN (SELECT BookId
		FROM SoldBooks
		GROUP BY BookId
		HAVING COUNT(Id) >= 3)
GO



CREATE OR ALTER FUNCTION GetAuthorsMostPopularBooks()
RETURNS TABLE
AS
	RETURN 
		SELECT * FROM Authors WHERE Id IN (
		SELECT A.Id FROM Authors A
		JOIN AuthorBook AB ON  A.Id = AB.AuthorsId
		-- вместо того что бы объединять с таблицей Books воспользоемся готовой ф-цией что бы объединить с той выборкой из	таблицы	Books, которая нам нужна
		JOIN dbo.GetMostPopularBooks() B ON B.Id = AB.BooksId
)
GO



SELECT * FROM dbo.GetMostPopularBooks();
GO
SELECT * FROM dbo.GetAuthorsMostPopularBooks();
GO



SELECT * FROM Sellers
SELECT * FROM Customers
SELECT * FROM SoldBooks
SELECT * FROM AuthorBook
SELECT * FROM Authors
SELECT * FROM PublishingOffices
SELECT * FROM Books
SELECT * FROM WroteOffBooks
SELECT * FROM SetAsideBooks