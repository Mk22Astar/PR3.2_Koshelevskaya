using System;

public class Helper1
{
    private static FirstDBEntities s_firstDBEntities; // Создание статичной приватной переменной, для обращения к контексту модели данных
                                                      // Метод (публичный, чтобы к нему можно было обратиться из любой части программы) получения контекста данных, необходимый для создания подключения к базе данных
    public static FirstDBEntities GetContext()
    {
        if (s_firstDBEntities == null) // Условие при котором проверяется, если подключение не установлено, то необходимо создать новое подключение
        {
            s_firstDBEntities = new FirstDBEntities(); // Соединение нового подключения к базе данных
        }
        return s_firstDBEntities; // в противном случае, вернуть ранее созданное подключение
    }

    public void CreateUsers(Models.Users users) // Метод позволяющий добавить новую запись в таблицу Users БД
    {
        s_firstDBEntities.Users.Add(users); // добавление записи нового пользователя в таблицу Users
        s_firstDBEntities.SaveChanges(); // сохранения измененной сущности в БД
    }

    public void UpdateUsers(Models.Users users) // Метод позволяющий обновить запись о пользователе в таблице Users БД, метод принимает как аргумент ранее изменненную сущность Users
    {
        s_firstDBEntities.Entry(users).State = EntityState.Modified; // Создание сущности помечается как Измененная
        s_firstDBEntities.SaveChanges(); // сохранения изменений сущности в БД
    }

    public void RemoveUsers(int idUsers) // Метод, позволяющий удалить запись о пользователе, принимает аргумент целое число со знаком, представляющий собой idUsers
    {
        var users = s_firstDBEntities.Users.Find(idUsers); // поиск записи пользователя, по его идентификатору id
        s_firstDBEntities.Users.Remove(users); // удаление записи найденного пользователя из БД
        s_firstDBEntities.SaveChanges(); // сохранение изменений в БД
    }

    public void FiltrUsers() // Метод, осуществляющий поиск записей пользователей 
    {
        var users = s_firstDBEntities.Users.Where(x => x.firstName.StartsWith("M") || x.firstName.StartsWith("A")); //
    }

    public void SortUsers() // Метод, осуществляющий сортировку записей пользователей
    {
        var users -s_firstDBEntities.Users.OrderBy(x => x.firstName); // сортировка записей о пользователях, по их именам, по возрастанию
    }
}
