using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace timp_4
{
    class OfficeBuilding : IBuilding
    {
       SinglyLinkedList<IFloor> officeBuilding = new SinglyLinkedList<IFloor>(); 
       

        public OfficeBuilding(OfficeFloor[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                officeBuilding.Add(array[i]);
            }   
        }

        public OfficeBuilding(int numberOfFloors, int[] numberOfficesOnEachFloor)
        {
            for (int i = 0; i < numberOfFloors; i++)
            {
                officeBuilding.Add(new OfficeFloor(numberOfficesOnEachFloor[i]));
            }
        }


        public int GetNumberOfFloors()
        {
            return officeBuilding.Count;
        }

       

        private bool IsOfficeFloor(IFloor floor)
        {
            if (floor is OfficeFloor) return true;
            else return false;
        }

        //внимательно при изменеии на двелинг
        public int GetNumberOfOffices()
        {
            int count = 0;
            foreach (IFloor item in officeBuilding)
            {
                if (IsOfficeFloor(item))
                {
                    count += (item as OfficeFloor).GetNumberOfOffices();
                }
                else
                {
                    count += ((item as DwellingFloor).GetNumberOfSpaces()- (item as DwellingFloor).GetNumberOfFlats());
                }
            }
            return count;
        }

        public int GetNumberOfSpaces()
        {
            int count = 0;
            foreach (IFloor item in officeBuilding)
            {
                count += item.GetNumberOfSpaces();
            }
            return count;
        }

        public double GetTotalSquare()
        {
            double square = 0.0d;
            foreach (var item in officeBuilding)
            {
               square +=  item.GetTotalSquare();
            }
            return square;
        }

        public int GetTotalRooms()
        {
            int count = 0;
            foreach (var item in officeBuilding)
            {
                count += item.GetTotalRooms();
            }
            return count;
        }

        public IFloor[] GetArrayOfFloors()
        {
            IFloor[] array = new IFloor[officeBuilding.Count];
            officeBuilding.CopyTo(array, 0);
            return array;
        }

        public IFloor GetFloor(int number)
        {
            return officeBuilding[number];
        }
        
        public void ChangeFloor(int number, IFloor floor)
        {
            officeBuilding[number] = floor;
        }

        private int GetIndexOfFloor(int number)
        {
            int IndexOfFloor = 0;
            int equalsIndex = 1;

            bool stop = false;

            for (int i = 0; i < officeBuilding.Count; i++)
            {
                for (int j = 0; j < officeBuilding[i].GetNumberOfSpaces(); j++)
                {
                    if (equalsIndex == number)
                    {
                        IndexOfFloor = i;
                        stop = true;
                        break;
                    }
                    else equalsIndex++;
                }

                if (stop) break;
            }
            return IndexOfFloor;
        }

        private int GetIndexOfSpace(int number)
        {
            int indexOffice = 0;
            int equalsIndex = 1;
            bool stop = false;

            for (int i = 0; i < officeBuilding.Count; i++)
            {
                for (int j = 0; j < officeBuilding[i].GetNumberOfSpaces(); j++)
                {
                    if (equalsIndex == number)
                    {
                        indexOffice = j;
                        stop = true;
                        break;
                    }
                    else equalsIndex++;
                }

                if (stop) break;
            }

            return indexOffice;
        }

        public ISpace GetSpace(int number)
        {
            return officeBuilding[GetIndexOfFloor(number)].GetArrayOfSpaces()[GetIndexOfSpace(number)];
        }

        public void ChangeOffice(int number, Office office)
        {
            ChangeSpace(number, office);
        }

        public void ChangeSpace(int number, ISpace space)
        {
            officeBuilding[GetIndexOfFloor(number)].ChangeSpace(GetIndexOfSpace(number), space);
        }

        public void AddOffice(int number, Office office)
        {
            AddSpace(number, office);
        }
        public void AddSpace(int number, ISpace space)
        {
            int indexFloor = GetIndexOfFloor(number);
            int indexSpace = GetIndexOfSpace(number);
            officeBuilding[indexFloor].InsertSpace(indexSpace,space);
        }

        public void RemoveSpace(int number)
        {
            int indexFloor = GetIndexOfFloor(number);
            int indexSpace = GetIndexOfSpace(number);
            officeBuilding[indexFloor].RemoveSpace(indexSpace);
        }

        public Office GetBestOffice()
        {
            Office returningOffice = null;
            double space = 0.0d;

            foreach (IFloor item in officeBuilding)
            {
                if (IsOfficeFloor(item) && space < (item as OfficeFloor).GetBestOffice().GetSquare())
                {
                    returningOffice = (item as OfficeFloor).GetBestOffice();
                    space = returningOffice.GetSquare();
                }
                else
                {
                    if (!IsOfficeFloor(item) && space < (item as DwellingFloor).GetBestOffice().GetSquare())
                    {
                        returningOffice = (item as DwellingFloor).GetBestOffice();
                        space = returningOffice.GetSquare();
                    }
                } 
            }
            return returningOffice;
        }

        public ISpace GetBestSpace()
        {
            ISpace returningFlat = officeBuilding[0].GetBestSpace();
            double space = returningFlat.GetSquare();

            foreach (IFloor item in officeBuilding)
            {
                if (space < item.GetBestSpace().GetSquare())
                {
                    returningFlat = item.GetBestSpace();
                    space = returningFlat.GetSquare();
                }
            }
            return returningFlat;
        }

    }
}
