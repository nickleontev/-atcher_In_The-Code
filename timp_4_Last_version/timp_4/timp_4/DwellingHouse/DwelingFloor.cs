using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace timp_4
{
    class DwellingFloor : IFloor
    {
        SinglyLinkedList<ISpace> dwellingFloor = new SinglyLinkedList<ISpace>();

        public DwellingFloor(int number)
        {
            for (int i = 0; i < number; i++)
            {
                dwellingFloor.Add(new Flat());
            }
        }

        public DwellingFloor(Flat[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                dwellingFloor.Add(array[i]);
            }
        }

        private bool IsFlat(ISpace space)
        {
            if (space is Flat) return true;
            else return false;
        }

        public int GetNumberOfSpaces()
        {
            return dwellingFloor.Count;
        }

        public int GetNumberOfFlats()
        {
            int count = 0;
            foreach (ISpace item in dwellingFloor)
            {
                if (IsFlat(item)) count++;
            }
            return count;
        }

        public double GetTotalSquare()
        {
            double square = 0;
            foreach (var item in dwellingFloor)
            {
                square += item.GetSquare();
            }
            return square;
        }

        public int GetTotalRooms()
        {
            int count = 0;
            foreach (var item in dwellingFloor)
            {
                count += item.GetNumberOfRooms();
            }
            return count;
        }


        public Flat[] GetArrayOfFlats()
        {
            Flat[] array = new Flat[GetNumberOfFlats()];
            int i = 0;

            foreach (ISpace item in dwellingFloor)
            {
                if (IsFlat(item))
                {
                    array[i] = item as Flat;
                    i++;
                }
            }
            return array;
        }
        
        public ISpace[] GetArrayOfSpaces()
        {
            ISpace[] array = new ISpace[dwellingFloor.Count];
            dwellingFloor.CopyTo(array, 0);
            return array;
        }

        public Flat GetFlat(int number)
        {
            if (IsFlat(dwellingFloor[number])) return dwellingFloor[number] as Flat;
            else return null;
        }

        public ISpace GetSpace(int number)
        {
            return dwellingFloor[number];
        }

        public void ChangeFlat(int number, Flat flat)
        {
            dwellingFloor[number] = flat;
        }

        public void ChangeSpace(int number, ISpace space)
        {
            dwellingFloor[number] = space;
        }

        public void InsertFlat(int number, Flat flat)
        {
            dwellingFloor.Insert(number, flat);
        }

        public void InsertSpace(int number, ISpace space)
        {
            dwellingFloor.Insert(number, space);
        }

        public void RemoveSpace(int number)
        {
            dwellingFloor.RemoveAt(number);
        }

        public Flat GetBestFlat()
        {
            double square = 0.0d;
            Flat flat = null;

            foreach (ISpace item in dwellingFloor)
            {
                if (IsFlat(item) && item.GetSquare() > square)
                {
                    flat = item as Flat;
                }
            }

            return flat;
        }

        public Office GetBestOffice()
        {
            double square = 0.0d;
            Office office = null;

            foreach (ISpace item in dwellingFloor)
            {
                if (!IsFlat(item) && item.GetSquare() > square)
                {
                    office = item as Office;
                }
            }

            return office;
        }

        public ISpace GetBestSpace()
        {
            double square = 0.0d;
            ISpace space = dwellingFloor[0];

            foreach (ISpace item in dwellingFloor)
            {
                if (item.GetSquare() > square)
                {
                    space = item;
                }
            }

            return space;
        }

        public override string ToString()
        {
            string s = "Помещения этажа: \n";

            foreach (ISpace item in dwellingFloor)
            {
                if (IsFlat(item))
                {
                    s += (item as Flat).ToString();
                }
                else s += (item as Office).ToString();
            }
            s += "__________\n";
            return s;
        }

    }
}


