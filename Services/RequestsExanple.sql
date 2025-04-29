-- 1. Создание таблицы Users
CREATE TABLE IF NOT EXISTS USERS (
                                     Id INT PRIMARY KEY IDENTITY(1,1),
    Username NVARCHAR(255) NOT NULL UNIQUE,
    Password NVARCHAR(255) NOT NULL,
    Role NVARCHAR(255) NOT NULL
    );

-- 2. Добавление пользователя
DECLARE @Username NVARCHAR(255) = 'TestUser';
DECLARE @Password NVARCHAR(255) = '1234';
DECLARE @Role NVARCHAR(255) = 'Администратор';

INSERT INTO Users (Username, Password, Role)
VALUES (@Username, @Password, @Role);

-- 3. Получение пользователя по имени
DECLARE @Username NVARCHAR(255) = 'TestUser';
SELECT TOP 1 *
FROM Users
WHERE Username = @Username;

-- 4. Получение всех пользователей
SELECT *
FROM Users;

-- 5. Очистка таблицы
DELETE FROM Users;