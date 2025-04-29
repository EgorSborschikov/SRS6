using System;
using System.IO;
using Xunit;
using SRS6.Services;
using SRS6.Models;

namespace SRS6.Tests
{
    public class DatabaseServiceTests
    {
        private readonly DatabaseService _databaseService;

        public DatabaseServiceTests()
        {
            // Используем существующую базу данных, как указано в DatabaseService
            string databaseDir = "Database";
            if (!Directory.Exists(databaseDir))
            {
                Directory.CreateDirectory(databaseDir);
            }

            string dbPath = Path.Combine(databaseDir, "SchoolInfSys.db");
            if (File.Exists(dbPath))
            {
                File.Delete(dbPath); // Удаляем файл базы данных перед тестами
            }

            _databaseService = new DatabaseService();
        }

        /// <summary>
        /// Тест проверяет, что метод CreateTables успешно создает таблицы в базе данных.
        /// Ожидается, что инициализация DatabaseService пройдет без ошибок, что указывает на успешное создание таблиц.
        /// </summary>
        [Fact]
        public void CreateTables_ShouldCreateTables()
        {
            // Проверяем, что таблицы создаются без ошибок
            Assert.NotNull(_databaseService);
        }

        /// <summary>
        /// Тест проверяет, что метод AddUser успешно добавляет нового пользователя в базу данных.
        /// Ожидается, что после добавления пользователя его можно будет найти в базе данных с правильными данными.
        /// </summary>
        [Fact]
        public void AddUser_ShouldAddUser()
        {
            // Добавляем нового пользователя
            var user = new User { Username = "TestUser1", Password = "1234", Role = "Администратор" };
            _databaseService.AddUser(user);

            // Проверяем, что пользователь добавлен
            var addedUser = _databaseService.GetUserByUsername("TestUser1");
            Assert.NotNull(addedUser);
            Assert.Equal("TestUser1", addedUser.Username);
            Assert.Equal("1234", addedUser.Password);
            Assert.Equal("Администратор", addedUser.Role);
        }

        /// <summary>
        /// Тест проверяет, что метод GetUserByUsername успешно возвращает пользователя по его имени.
        /// Ожидается, что после добавления пользователя его можно будет найти по имени с правильными данными.
        /// </summary>
        [Fact]
        public void GetUserByUsername_ShouldReturnUser()
        {
            // Добавляем нового пользователя
            var user = new User { Username = "TestUser2", Password = "4321", Role = "Преподаватель" };
            _databaseService.AddUser(user);

            // Проверяем, что пользователь может быть получен по имени
            var retrievedUser = _databaseService.GetUserByUsername("TestUser2");
            Assert.NotNull(retrievedUser);
            Assert.Equal("TestUser2", retrievedUser.Username);
        }

        /// <summary>
        /// Тест проверяет, что метод GetUserByUsername возвращает null для несуществующего пользователя.
        /// Ожидается, что если пользователь с указанным именем не существует, метод вернет null.
        /// </summary>
        [Fact]
        public void GetUserByUsername_ShouldReturnNullForNonExistentUser()
        {
            // Проверяем, что для несуществующего пользователя возвращается null
            var nonExistentUser = _databaseService.GetUserByUsername("NonExistentUser");
            Assert.Null(nonExistentUser);
        }

        /// <summary>
        /// Тест проверяет, что метод GetAllUsers возвращает всех пользователей из базы данных.
        /// Ожидается, что после добавления нескольких пользователей метод вернет всех их.
        /// </summary>
        [Fact]
        public void GetAllUsers_ShouldReturnAllUsers()
        {
            // Добавляем нескольких пользователей
            var user1 = new User { Username = "User1", Password = "pass1", Role = "Администратор" };
            var user2 = new User { Username = "User2", Password = "pass2", Role = "Преподаватель" };
            _databaseService.AddUser(user1);
            _databaseService.AddUser(user2);

            // Проверяем, что все пользователи возвращаются
            var users = _databaseService.GetAllUsers().ToList();

            // Проверяем количество пользователей
            Assert.Equal(2, users.Count);

            // Проверяем данные каждого пользователя
            Assert.Contains(users, u => u.Username == "User1" && u.Password == "pass1" && u.Role == "Администратор");
            Assert.Contains(users, u => u.Username == "User2" && u.Password == "pass2" && u.Role == "Преподаватель");
        }


        /// <summary>
        /// Тест проверяет, что метод GetAllUsers возвращает пустой список, если в базе данных нет пользователей.
        /// Ожидается, что если пользователей нет, метод вернет пустой список.
        /// </summary>
        [Fact]
        public void GetAllUsers_ShouldReturnEmptyListForNoUsers()
        {
            _databaseService.ClearUsers();
            
            // Проверяем, что если пользователей нет, возвращается пустой список
            var users = _databaseService.GetAllUsers();
            Assert.Empty(users);
        }
    }
}
