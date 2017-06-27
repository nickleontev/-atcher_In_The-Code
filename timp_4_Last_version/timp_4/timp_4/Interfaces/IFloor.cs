using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace timp_4
{
    interface IFloor 
    {
        int GetNumberOfSpaces();//получения количества помещений на этаже.

        double GetTotalSquare();

        int GetTotalRooms();

        ISpace[] GetArrayOfSpaces();

        ISpace GetSpace(int number);

        void ChangeSpace(int number, ISpace space);

        void InsertSpace(int number, ISpace space);

        void RemoveSpace(int number);

        ISpace GetBestSpace();
  
    }
}
