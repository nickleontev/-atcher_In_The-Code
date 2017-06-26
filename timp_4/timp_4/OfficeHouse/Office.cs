using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace timp_4
{
    class Office : ISpace
    {
        public int room { get; set; }
        public double area { get; set; }
        

        public Office()
        {
            this.room = 1;
            this.area = 250;
        }

        public Office(int area)
        {
            this.room = 1;
            this.area = area;
        }

        public Office(int area, int room)
        {
            this.room = room;
            this.area = area;
        }


        public int GetNumberOfRoom()
        {
            return this.room;
        }//получение количества комнат

        public void SetNumberOfRoom(int number)
        {
            this.room = room;
        }//изменение кличества комнaт

        public double GetSquare()
        {
            return this.area;
        }//получение площади

        public void SetSquare(double square)
        {
            this.area = area;
        }//изменение площади

        public override string ToString()
        {
            string s = "Площадь: " + area +" Количество комнат: "+room + "\n";
            
            return s;
        }

    }
}