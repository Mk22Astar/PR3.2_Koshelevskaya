using Registration.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Registration
{
    public class Helper
    {
        private static RestoranEntities s_restoranEntities = GetContext(); // Создание статичной приватной переменной, для обращения к контексту модели данных
                                                            // Метод (публичный, чтобы к нему можно было обратиться из любой части программы) получения контекста данных, необходимый для создания подключения к базе данных
        public static RestoranEntities GetContext()
        {
            if (s_restoranEntities == null) // Условие при котором проверяется, если подключение не установлено, то необходимо создать новое подключение
            {
                s_restoranEntities = new RestoranEntities(); // Соединение нового подключения к базе данных
            }
            return s_restoranEntities; // в противном случае, вернуть ранее созданное подключение
        }

        public  void CreateUsers(Model.Polzovateli users) // Метод позволяющий добавить новую запись в таблицу Polzovateli БД
        {

            s_restoranEntities.Polzovateli.Add(users); // добавление записи нового пользователя в таблицу Users
            s_restoranEntities.SaveChanges(); // сохранения измененной сущности в БД
        }

        public  void UpdateUsers(Model.Polzovateli users) // Метод позволяющий обновить запись о пользователе в таблице Users БД, метод принимает как аргумент ранее изменненную сущность Users
        {
            s_restoranEntities.Entry(users).State = EntityState.Modified; // Создание сущности помечается как Измененная
            s_restoranEntities.SaveChanges(); // сохранения изменений сущности в БД
        }

        public  void RemoveUsers(int idUsers) // Метод, позволяющий удалить запись о пользователе, принимает аргумент целое число со знаком, представляющий собой idUsers
        {
            var users = s_restoranEntities.Polzovateli.Find(idUsers); // поиск записи пользователя, по его идентификатору id
            s_restoranEntities.Polzovateli.Remove(users); // удаление записи найденного пользователя из БД
            s_restoranEntities.SaveChanges(); // сохранение изменений в БД
        }

        public  void FiltrUsers() // Метод, осуществляющий поиск записей пользователей 
        {
            var users = s_restoranEntities.Polzovateli.Where(x => x.Imya.StartsWith("M") || x.Imya.StartsWith("A")); //
        }

        public  void SortUsers() // Метод, осуществляющий сортировку записей пользователей
        {
            var users = s_restoranEntities.Polzovateli.OrderBy(x => x.Imya); // сортировка записей о пользователях, по их именам, по возрастанию
        }

        public  void CreateAvtorizaciya(Model.Avtorizaciya log) // Метод позволяющий добавить новую запись в таблицу Polzovateli БД
        {
            s_restoranEntities.Avtorizaciya.Add(log); // добавление записи нового пользователя в таблицу Users
            s_restoranEntities.SaveChanges(); // сохранения измененной сущности в БД
        }

    }
}
