using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace timp_4
{
    class Office : ISpace
    {
        public int NumberOfRooms { get; set; }
        public double Square { get; set; }
        

        public Office()
        {
            this.NumberOfRooms = 1;
            this.Square = 250;
        }

        public Office(int area)
        {
            this.NumberOfRooms = 1;
            this.Square = area;
        }

        public Office(int area, int room)
        {
            this.NumberOfRooms = room;
            this.Square = area;
        }


        public int GetNumberOfRooms()
        {
            return this.NumberOfRooms;
        }//получение количества комнат

        public void SetNumberOfRooms(int number)
        {
            this.NumberOfRooms = NumberOfRooms;
        }//изменение кличества комнaт

        public double GetSquare()
        {
            return this.Square;
        }//получение площади

        public void SetSquare(double square)
        {
            this.Square = Square;
        }//изменение площади

        public override string ToString()
        {
          return "|Офис| Площадь: " + Square +" Количество комнат: "+NumberOfRooms + "\n"; 
        }

    }
}