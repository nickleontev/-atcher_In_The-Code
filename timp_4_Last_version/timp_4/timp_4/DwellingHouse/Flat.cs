using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace timp_4
{
    class Flat: IComparable<Flat>, ISpace
    {
        private const int NumberOfRoomsInStandardApartment = 2;
        private const double StandardApartmentArea = 50;

        private int NumberOfRoom { get; set; }
        private double Square { get; set; }


        public Flat()
        {
            this.NumberOfRoom = NumberOfRoomsInStandardApartment;
            this.Square = StandardApartmentArea;
        }

        public Flat(double square) : this()
        {
            this.Square = square;
        }

        public Flat(int num, double square)
        {
            this.NumberOfRoom = num;
            this.Square = square;
        }

        public int GetNumberOfRooms()
        {
            return this.NumberOfRoom;
        }

        public double GetSquare()
        {
            return this.Square;
        }

        public void SetNumberOfRooms(int number)
        {
            this.NumberOfRoom = number;
        }

        public void SetSquare(double square)
        {
            this.Square = square;
        }


        public int CompareTo(Flat obj)
        {
            if (this.Square > obj.Square) return -1;
            else if (this.Square < obj.Square) return 1;
            else return 0;
        }

        public override string ToString()
        {
            return "|Квартира| Площадь: " + this.Square + " Количество комнат: " + this.NumberOfRoom + "\n";
        }
    }
}
