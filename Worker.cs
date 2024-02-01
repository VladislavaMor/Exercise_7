using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Exercise_7.Program;

namespace Exercise_7
{
    public struct Worker
    {
        public int Id { get; set; }
        public string FIO { get; set; }

        public DateTime DateAdd { get; set; }
        public int Age { get; set; }
        public int Height { get; set; }
        public string DateBith { get; set; }
        public string PlaceBith { get; set; }

        public Worker(int Id, DateTime DateAdd, string FIO,  int Age, int Height, string DateBith, string PlaceBith)
            {
            this.Id = Id;
            this.DateAdd = DateAdd; 
            this.FIO = FIO; 
            this.Age = Age;
            this.Height = Height;
            this.DateBith = DateBith;
            this.PlaceBith = PlaceBith;
            }
        public override string ToString()
        {
            return $"{Id}#{DateAdd}#{FIO}#{Age}#{Height}#{DateBith}#{PlaceBith}" ;
        }
    }
}
