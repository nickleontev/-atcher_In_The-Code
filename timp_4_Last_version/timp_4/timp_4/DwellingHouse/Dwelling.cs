using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace timp_4
{
    class Dwelling : IBuilding
    {
        SinglyLinkedList<IFloor> dwellingBuilding = new SinglyLinkedList<IFloor>();


        public Dwelling(DwellingFloor[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                dwellingBuilding.Add(array[i]);
            }
        }

        public Dwelling(int numberOfFloors, int[] numberFlatsOnEachFloor)
        {
            for (int i = 0; i < numberOfFloors; i++)
            {
                dwellingBuilding.Add(new DwellingFloor(numberFlatsOnEachFloor[i]));
            }
        }


        public int GetNumberOfFloors()
        {
            return dwellingBuilding.Count;
        }

        private bool IsDwellingFloor(IFloor floor)
        {
            if (floor is DwellingFloor) return true;
            else return false;
        }

        public int GetNumberOfFlats()
        {
            int count = 0;
            foreach (IFloor item in dwellingBuilding)
            {
                if (IsDwellingFloor(item))
                {
                    count += (item as DwellingFloor).GetNumberOfFlats();
                }
                else
                {
                    count += ((item as OfficeFloor).GetNumberOfSpaces() - (item as OfficeFloor).GetNumberOfOffices());
                }
            }
            return count;
        }

        public int GetNumberOfSpaces()
        {
            int count = 0;
            foreach (IFloor item in dwellingBuilding)
            {
                count += item.GetNumberOfSpaces();
            }
            return count;
        }

        public double GetTotalSquare()
        {
            double square = 0.0d;
            foreach (var item in dwellingBuilding)
            {
                square += item.GetTotalSquare();
            }
            return square;
        }

        public int GetTotalRooms()
        {
            int count = 0;
            foreach (var item in dwellingBuilding)
            {
                count += item.GetTotalRooms();
            }
            return count;
        }

        public IFloor[] GetArrayOfFloors()
        {
            IFloor[] array = new IFloor[dwellingBuilding.Count];
            dwellingBuilding.CopyTo(array, 0);
            return array;
        }

        public IFloor GetFloor(int number)
        {
            return dwellingBuilding[number];
        }

        public void ChangeFloor(int number, IFloor floor)
        {
            dwellingBuilding[number] = floor;
        }

        private int GetIndexOfFloor(int number)
        {
            int IndexOfFloor = 0;
            int equalsIndex = 1;

            bool stop = false;

            for (int i = 0; i < dwellingBuilding.Count; i++)
            {
                for (int j = 0; j < dwellingBuilding[i].GetNumberOfSpaces(); j++)
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
            int indexFlat = 0;
            int equalsIndex = 1;
            bool stop = false;

            for (int i = 0; i < dwellingBuilding.Count; i++)
            {
                for (int j = 0; j < dwellingBuilding[i].GetNumberOfSpaces(); j++)
                {
                    if (equalsIndex == number)
                    {
                        indexFlat = j;
                        stop = true;
                        break;
                    }
                    else equalsIndex++;
                }

                if (stop) break;
            }

            return indexFlat;
        }

        public ISpace GetSpace(int number)
        {
            return dwellingBuilding[GetIndexOfFloor(number)].GetArrayOfSpaces()[GetIndexOfSpace(number)];
        }

        public void ChangeFlat(int number, Flat flat)
        {
            ChangeSpace(number, flat);
        }

        public void ChangeSpace(int number, ISpace space)
        {
            dwellingBuilding[GetIndexOfFloor(number)].ChangeSpace(GetIndexOfSpace(number), space);
        }

        public void AddFlat(int number, Flat flat)
        {
            AddSpace(number, flat);
        }
        public void AddSpace(int number, ISpace space)
        {
            int indexFloor = GetIndexOfFloor(number);
            int indexSpace = GetIndexOfSpace(number);
            dwellingBuilding[indexFloor].InsertSpace(indexSpace, space);
        }

        public void RemoveSpace(int number)
        {
            int indexFloor = GetIndexOfFloor(number);
            int indexSpace = GetIndexOfSpace(number);
            dwellingBuilding[indexFloor].RemoveSpace(indexSpace);
        }

        public Flat GetBestFlat()
        {
            Flat returningFlat = null;
            double space = 0.0d;

            foreach (IFloor item in dwellingBuilding)
            {
                if (IsDwellingFloor(item) && space < (item as DwellingFloor).GetBestFlat().GetSquare())
                {
                    returningFlat = (item as DwellingFloor).GetBestFlat();
                    space = returningFlat.GetSquare();
                }
                else
                {
                    if (!IsDwellingFloor(item) && space < (item as DwellingFloor).GetBestFlat().GetSquare())
                    {
                        returningFlat = (item as DwellingFloor).GetBestFlat();
                        space = returningFlat.GetSquare();
                    }
                }
            }
            return returningFlat;
        }

        public ISpace GetBestSpace()
        {
            ISpace returningFlat = dwellingBuilding[0].GetBestSpace();
            double space = returningFlat.GetSquare();

            foreach (IFloor item in dwellingBuilding)
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

