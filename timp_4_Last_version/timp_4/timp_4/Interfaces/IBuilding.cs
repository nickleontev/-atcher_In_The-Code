using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace timp_4
{
    interface IBuilding 
    {
        int GetNumberOfFloors();

        int GetNumberOfSpaces();

        double GetTotalSquare();//получения общей площади помещений здания.---

        int GetTotalRooms();//получения общего количества комнат здания. ---

        IFloor[] GetArrayOfFloors();

        IFloor GetFloor(int number);//получения объекта этажа, по его номеру в здании.---

        void ChangeFloor(int number, IFloor floor);//изменения этажа по его номеру в здании и ссылке на обновленный этаж.---

        ISpace GetSpace(int number);

        void ChangeSpace(int number, ISpace space);

        void AddSpace(int number, ISpace space);

        void RemoveSpace(int number);

        ISpace GetBestSpace();


    }
}
