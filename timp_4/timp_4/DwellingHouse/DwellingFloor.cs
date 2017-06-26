using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace timp_4
{
    class DwellingFloor: IFloor
    {
        private List<Flat> flats;

        public DwellingFloor(int number)
        {
            this.flats = new List<Flat>(number);

            for (int i = 0; i < number; i++)
            {
                this.flats.Add(new Flat());
            }
        }

        public DwellingFloor(Flat [] flats)
        {
            this.flats = new List<Flat>();

            for (int i = 0; i < flats.Length; i++)
            {
                this.flats.Add(flats[i]);
            }
  
        }

        public int GetNumberOfSpaces()
        {
            return flats.Count;
        }

        public double GetTotalSquare()
        {
            double ts = 0.0;
            foreach (Flat a in flats)
            {
                ts += a.GetSquare();
            }
            return ts;
        }

        public int GetTotalRooms()
        {
            int tr = 0;
            foreach (Flat f in flats)
            {
                tr += f.GetNumberOfRooms();
            }
            return tr;
        }

        //public Flat[] GetArrayOfFlats()
        //{
        //    Flat[] arrayOfFlats = new Flat[this.flats.Count];
        //    flats.CopyTo(arrayOfFlats, 0);
        //    return arrayOfFlats;
        //}

        public ISpace[] GetArrayOfSpaces()
        {
            Flat[] arrayOfFlats = new Flat[this.flats.Count];
            flats.CopyTo(arrayOfFlats, 0);
            return arrayOfFlats;
            //return GetArrayOfFlats();
        }

        //public Flat GetFlat(int number)
        //{
        //    return this.flats[number];
        //}
        public ISpace GetSpace(int numberOffice)
        {
            return this.flats[numberOffice];
            //return GetFlat(numberOffice) as ISpace;
        }

        //public void ChangeFlat(int number, Flat f)
        //{
        //    flats[number] = f;
        //}
        public void ChangeSpace(int number, ISpace space)
        {
            flats[number] = space as Flat;
            //ChangeFlat(number, space as Flat);
        }

        public void RemoveFlatAt(int number)
        {
            this.flats.RemoveAt(number);
        }

        public void RemoveSpace(int number)
        {
            RemoveFlatAt(number);
        }

        //public Flat GetBestFlat()
        //{
        //    Flat returningFlat = flats[0];
        //    double space = flats[0].GetSquare();

        //    foreach (Flat f in flats)
        //    {
        //        if (space < f.GetSquare())
        //        {
        //            space = f.GetSquare();
        //            returningFlat = f;
        //        }
        //    }
        //    return returningFlat;
        //}

        public ISpace GetBestSpace()
        {
            Flat returningFlat = flats[0];
            double space = flats[0].GetSquare();

            foreach (Flat f in flats)
            {
                if (space < f.GetSquare())
                {
                    space = f.GetSquare();
                    returningFlat = f;
                }
            }
            return returningFlat;
            //return GetBestFlat();
        }

        //public void AddFlat(int number, Flat f)
        //{
        //    flats.Insert(number, f);
        //}

        public void InsertSpace(int number, ISpace space)
        {
            flats.Insert(number, space as Flat);
            //AddFlat(number, space as Flat);
        }

        public override string ToString()
        {
            string s = "Квартиры этажа: \n";
            foreach (Flat item in flats)
            {
                s += item.ToString();
            }
            s += "__________\n";
            return s;
        }
    }
}
