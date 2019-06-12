//обобщенный интерфейс, описывающий классы репозиториев, реализующих базовые операции CRUD (Create-Read-Update-Delete)
//Каждый репозиторий работает с контекстом Entity Framework.
using System;
using System.Collections.Generic;


namespace Pollen.DataLayer.Interfaces
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();                //Метод GetAll возвращает список всех объектов типа <T>.
        T Get(int id);                          //Метод Get ищет объект в базе данных по заданному id.
        IEnumerable<T> Find(Func<T, bool> predicate);   //Метод Find осуществляет поиск объекта, удовлетворяющего условию predicate.
        void Create(T t);                       //Метод Create добавляет объект типа <T> в базу данных.
        void Update(T t);                       //Метод Update принимает измененный объект типа<T> и вносит изменения в базу данных.

        void Delete(int id);                    //Метод Delete удаляет объект из базы данных с заданным id.
    }
}
