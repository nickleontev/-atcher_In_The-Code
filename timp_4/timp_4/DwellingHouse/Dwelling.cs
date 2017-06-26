using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace timp_4
{
    class Dwelling: IBuilding   
    {
        private List<DwellingFloor> dfloor;

        public Dwelling(int numberOfFloors, int [] numberOfFlatsOnEachFloor)
        {
            dfloor = new List<DwellingFloor>(numberOfFloors);

            for (int i=0; i < numberOfFloors; i++)
            {
                dfloor.Add(new DwellingFloor(numberOfFlatsOnEachFloor[i]));
            }
        }

        public Dwelling(DwellingFloor [] df)
        {
            dfloor = new List<DwellingFloor>(df.Length);
            for (int i=0; i < df.Length; i++)
            {
                dfloor.Add(df[i]);
            }
        }

        internal DwellingFloor DwellingFloor
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public int GetNumberOfFloors()
        {
            return dfloor.Count;
        }

        public int GetNumberOfSpaces()
        {
            int count = 0;
            foreach (DwellingFloor df in dfloor)
            {
                count += df.GetNumberOfSpaces();
            }
            return count;
        }

        public double GetTotalSquare()
        {
            double count = 0.0d;
            foreach (DwellingFloor df in dfloor)
            {
                count += df.GetTotalSquare();
            }
            return count;
        }

        public int GetTotalRooms()
        {
            int count = 0;
            foreach (DwellingFloor df in dfloor)
            {
                count += df.GetTotalRooms();
            }
            return count;
        }

        public DwellingFloor[] GetArrayDwellingFloors()
        {
            DwellingFloor[] df = new DwellingFloor[this.dfloor.Count];
            this.dfloor.CopyTo(df, 0);
            return df;
        }

        public IFloor[] GetArrayOfFloors()
        {
            return GetArrayDwellingFloors();
        }

        public DwellingFloor GetDwellingFloor(int number)
        {
            return this.dfloor[number];
        }

        public IFloor GetFloor(int number)
        {
            return GetDwellingFloor(number);
        }

        public Flat GetBestFlat()
        {
            Flat returningFlat = dfloor[0].GetBestFlat();
            double space = returningFlat.GetSquare();

            foreach (DwellingFloor df in dfloor)
            {
                if (space < df.GetBestFlat().GetSquare())
                {
                    returningFlat = df.GetBestFlat();
                    space = returningFlat.GetSquare();
                }
            }
            return returningFlat;
        }

        public ISpace GetBestSpace()
        {
            return GetBestFlat();
        }

        public void ChangeDwellingFloor(int number, DwellingFloor df)
        {
            this.dfloor[number] = df;
        }
        public void ChangeFloor(int number, IFloor floor)
        {
            ChangeDwellingFloor(number, floor as DwellingFloor);
        }
        //вспомогательные методы получения индексов этажа и квартиры по номеру квартиры
        private int GetIndexOfFloor(int NumberOfFlat)
        {
            int IndexOfFloor = 0;
            int equalsIndex = 1;

            bool stop = false;

            for (int i = 0; i < this.dfloor.Count; i++)
            {
                for (int j = 0; j < this.dfloor[i].GetNumberOfSpaces(); j++)
                {
                    if (equalsIndex == NumberOfFlat)
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

        private int GetIndexOfFlat(int NumberOfFlat)
        {
            int IndexOfFlat = 0;
            int equalsIndex = 1;
            bool stop = false;

            for (int i = 0; i < this.dfloor.Count; i++)
            {
                for (int j = 0; j < this.dfloor[i].GetNumberOfSpaces(); j++)
                {
                    if (equalsIndex == NumberOfFlat)
                    {
                        IndexOfFlat = j;
                        stop = true;
                        break;
                    }
                    else equalsIndex++;
                }

                if (stop) break;
            }

            return IndexOfFlat;
        }

        public Flat GetFlat(int number)
        {
            return this.dfloor[GetIndexOfFloor(number)].GetArrayOfFlats()[GetIndexOfFlat(number)];
        }

        public ISpace GetSpace(int number)
        {
            return GetFlat(number);
        }

        
        public void ChangeFlat (int number, Flat f)
        {
            this.dfloor[GetIndexOfFloor(number)].ChangeFlat(GetIndexOfFlat(number), f);
        }

        public void ChangeSpace(int number, ISpace space)
        {
            ChangeFlat(number, space as Flat);
        }

        public void RemoveFlat (int number)
        {
            this.dfloor[GetIndexOfFloor(number)].RemoveFlatAt(GetIndexOfFlat(number)); 
        }

        public void RemoveSpace(int number)
        {
            RemoveFlat(number);
        }

        public void AddFlat(int number, Flat f)
        {
            this.dfloor[GetIndexOfFloor(number)].AddFlat(GetIndexOfFlat(number), f);  
        }

        public Flat[] GetSortArrayOfFlats()
        {
            Flat[] f = new Flat[this.GetNumberOfSpaces()];
            int i = 0;

            DwellingFloor [] dfArray = this.GetArrayDwellingFloors();
            foreach (DwellingFloor df in dfArray)
            {
                for (int j = 0; j < df.GetArrayOfSpaces().Length; j++)
                {
                    f[i] = df.GetArrayOfFlats()[j];
                    i++;
                }
            }

            Array.Sort(f);
            return f;
        }

        public ISpace[] GetSortArrayOfSpaces()
        {
            return GetSortArrayOfFlats();
        }

        public override string ToString()
        {
            string s = "-----Дом----- \n";
            for (int i = 0; i < this.dfloor.Count; i++)
            {
                s += "Этаж " + i+"\n";
                s += dfloor[i].ToString();
            }
            return s;
        }


    }
}
