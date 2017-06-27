using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace timp_4
{
    interface ISpace
    {
        int GetNumberOfRooms();//получение количества комнат

        void SetNumberOfRooms(int number);//изменение кличества комнaт

        double GetSquare();//получение площади

        void SetSquare(double square);//изменение площади
    }
}
