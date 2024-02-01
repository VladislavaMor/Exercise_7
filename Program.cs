using System;
using static System.Console;
using static Exercise_7.Repository;

namespace Exercise_7
{
    class Program
    {
        public static void Main(string[] args)
        {
            WriteLine("Выберите действие:\n1.Получить список сотрудников.\n2.Получение данных сотрудника по Id.\n3.Удаление сотрудника из репозитория.\n4.Добавить сотрудника в репозиторий.\n5.Получить записи в выбранном диапазоне дат.");
            WriteLine("--------------------------------------------------------");
            Write("Выбрано: ");
            int choice = Convert.ToInt32(ReadLine());
            if (choice == 1)
            {
                WriteLine("1.Получение списка сотрудников.");
                WriteLine("Список сотрудников:");
                Worker[] worker = GetAllWorkers(path);
                ShowWorker(worker);
            }
            else if (choice == 2)
            {
                WriteLine("2.Получение сотрудника по Id.");
                Write("Ведите Id сотрудника: ");
                int id_in = int.Parse(ReadLine());
                Worker workerId = GetWorkerById(id_in);
                WriteLine(workerId.ToString());
            }
            else if (choice == 3)
            {
                WriteLine("3.Удаление сотрудника из репозитория.");
                Write("Ведите Id сотрудника: ");
                int id_out = int.Parse(ReadLine());
                DeleteWorker(id_out);
            }
            else if (choice == 4)
            {
                WriteLine("4.Добавление сотрудника в репозиторий.");
                
                    Worker work = CreateWorker();
                    AddWorker(work);
            }
            else if (choice == 5)
            {
                WriteLine("5.Получение записей в выбранном диапазоне дат.");
                Write("Ведите первую дату: ");
                DateTime dateFrom = Convert.ToDateTime(ReadLine());
                Write("Ведите вторую дату: ");
                DateTime dateTo = Convert.ToDateTime(ReadLine());
                Worker[] worker = GetWorkersBetweenTwoDates(dateFrom, dateTo);
                ShowWorker(worker);
            }


            
        }



            

    }
}
