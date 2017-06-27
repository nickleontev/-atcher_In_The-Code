using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace timp_4
{
    class OfficeFloor : IFloor
    {
        SinglyLinkedList<ISpace> officeFloor = new SinglyLinkedList<ISpace>();

        public OfficeFloor(int number)
        {
            for (int i = 0; i < number; i++)
            {
                officeFloor.Add(new Office());
            }
        }

        public OfficeFloor(Office[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                officeFloor.Add(array[i]);
            }
        }

        private bool IsOffice(ISpace space)
        {
            if (space is Office) return true;
            else return false;
        }

        public int GetNumberOfSpaces()
        {
            return officeFloor.Count;
        }

        public int GetNumberOfOffices()
        {
            int count = 0;
            foreach (ISpace item in officeFloor)
            {
                if (IsOffice(item)) count++;
            }
            return count;
        }

        public double GetTotalSquare()
        {
            double square = 0;
            foreach (var item in officeFloor)
            {
                square += item.GetSquare();
            }
            return square;
        }

        public int GetTotalRooms()
        {
            int count = 0;
            foreach (var item in officeFloor)
            {
                count += item.GetNumberOfRooms();
            }
            return count;
        }


        public Office[] GetArrayOfOffices()
        {
            Office[] array = new Office[GetNumberOfOffices()];
            int i = 0;
            
                foreach (ISpace  item in officeFloor)
            {
                if (IsOffice(item))
                {
                    array[i] = item as Office;
                    i++;
                }
            }
            return array;
        }


        public ISpace[] GetArrayOfSpaces()
        {
            ISpace[] array = new ISpace[officeFloor.Count];
            officeFloor.CopyTo(array, 0);
            return array;
        }

        public Office GetOffice(int number)
        {
            if (IsOffice(officeFloor[number])) return officeFloor[number] as Office;
            else return null;        
        }

        public ISpace GetSpace(int number)
        {
            return officeFloor[number];
        }

        public void ChangeOffice(int number, Office office)
        {
            officeFloor[number] = office;
        }

        public void ChangeSpace(int number, ISpace space)
        {
            officeFloor[number] = space;
        }

        public void InsertOffice(int number, Office office)
        {
            officeFloor.Insert(number, office);
        }

        public void InsertSpace(int number, ISpace space)
        {
            officeFloor.Insert(number, space);
        }

        public void RemoveSpace(int number)
        {
            officeFloor.RemoveAt(number);
        }

        public Office GetBestOffice()
        {
            double square = 0.0d;
            Office office = null;

            foreach (ISpace item in officeFloor)
            {
                if (IsOffice(item) && item.GetSquare() > square)
                {
                    office = item as Office;
                }
            }

            return office;
        }

        public Flat GetBestFlat()
        {
            double square = 0.0d;
            Flat flat = null;

            foreach (ISpace item in officeFloor)
            {
                if (!IsOffice(item) && item.GetSquare() > square)
                {
                    flat = item as Flat;
                }
            }

            return flat;
        }

        public ISpace GetBestSpace()
        {
            double square = 0.0d;
            ISpace space = officeFloor[0];

            foreach (ISpace item in officeFloor)
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

            foreach (ISpace item in officeFloor)
            {
                if (IsOffice(item))
                {
                    s += (item as Office).ToString();
                }
                else s += (item as Flat).ToString();
            }
            s += "__________\n";
            return s;
        }

    }
}
