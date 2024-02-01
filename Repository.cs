using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Exercise_7
{
    class Repository
    {
        public static string path = @"D:\Worker_repository.txt";

        public static Worker[] GetAllWorkers(string path)
        {
            int count = File.ReadAllLines(path).Length;
            string[] strWorker = File.ReadAllLines(path);// здесь происходит чтение из файла
            Worker[] worker = new Worker[count];
            for (int i = 0; i < count; i++)
            {
                string[] elementWorker = strWorker[i].Split('#');
                Worker work = new Worker(int.Parse(elementWorker[0]),
                                         DateTime.Parse(elementWorker[1]),
                                         elementWorker[2],
                                           int.Parse(elementWorker[3]),
                                           int.Parse(elementWorker[4]),
                                           elementWorker[5],
                                           elementWorker[6]);
                                            worker[i] = work;
            }
            return worker;
            // и возврат массива считанных экземпляров
        }
        public static void ShowWorker(Worker[] worker)
        {
            foreach(Worker work in worker)
            {
                Console.WriteLine(work.ToString());
            }
        }
        public static Worker GetWorkerById(int id) 
        {
            // происходит чтение из файла, возвращается Worker
            // с запрашиваемым ID
            Worker[] worker = GetAllWorkers(path);
            Worker concretWorker;
            int concretCount = 0; ;
            for (int i = 0; i < worker.Length; i++)
            {
                if (worker[i].Id == id)
                    concretCount = i;
                concretWorker = new Worker(worker[i].Id, worker[i].DateAdd, worker[i].FIO, worker[i].Age, worker[i].Height, worker[i].DateBith, worker[i].PlaceBith);
            }
            return worker[concretCount];
        }

        public static void DeleteWorker(int id)
        {
            Worker[] worker = GetAllWorkers(path);
            string[] newList = new string[worker.Length-1];
            for (int i = 0; i < worker.Length-1; i++)
            {
                int c = 0;
                if (worker[i].Id == id)
                {
                    c++; 
                    newList[i] = $"{worker[i + 1]}";
                }
                else newList[i] = $"{worker[i+c]}";
            }

            File.WriteAllLines(path, newList);
            // считывается файл, находится нужный Worker
            // происходит запись в файл всех Worker,
            // кроме удаляемого
        }

        public static void AddWorker(Worker worker)
        {
            int count = 0;
            if (File.Exists(path))
            {
                count = File.ReadAllLines(path).Length;
            }
            else
            {
                File.Create(path);
            }
            worker.Id = count + 1;
            string text = $"\n{worker.ToString()}";
            File.AppendAllText(path, text);
            // присваиваем worker уникальный ID,
            // дописываем нового worker в файл
        }


        public static Worker[] GetWorkersBetweenTwoDates(DateTime dateFrom, DateTime dateTo)
        {
            Worker[] worker = GetAllWorkers(path);
            for (int i = 0; i < worker.Length; i++)
                if (worker[i].DateAdd < dateFrom || worker[i].DateAdd > dateTo)
                {
                    DeleteWorker(worker[i].Id);
                }
            Worker[] workerNew = GetAllWorkers(path);
            return workerNew;

            // здесь происходит чтение из файла
            // фильтрация нужных записей
            // и возврат массива считанных экземпляров
        }

        public static Worker CreateWorker()
        {
            Worker worker = new Worker();
            Write("Введите ID: ");
            worker.Id = int.Parse(ReadLine());
            worker.DateAdd = DateTime.Now;
            Write("Введите ФИО: ");
            worker.FIO = ReadLine();
            Write("Введите возраст: ");
            worker.Age = int.Parse(ReadLine());
            Write("Введите рост: ");
            worker.Height = int.Parse(ReadLine());
            Write("Введите дату рождения ");
            worker.DateBith = ReadLine();
            Write("Введите место рождения: ");
            worker.PlaceBith = ReadLine();
            return worker;
        }
    }
}
    

