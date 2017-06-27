using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace timp_4
{
    class Building
    {
        // количество этажей
        //1 этаж 
        //  2 - два помещения
        //    3 150 2 50
        //2 этаж 
        //  3 помещения 
        //    2 100 2 20 200
        //3 этаж 
        //    1 помещение
        //    2 2000

        //записи данных о здании в байтовый поток
        public static void OutputBuilding(IBuilding building, FileStream Fstream)
        {





            foreach (var variable in building as SinglyLinkedList<IBuilding>)
            {
                Fstream.WriteByte(Convert.ToByte(variable.GetNumberOfFloors()));//кол-во этажей
                
                foreach (var variable1 in building as SinglyLinkedList<IFloor>)
                {
                    //как получить "i" , тобишь номер этажа
                    Fstream.WriteByte(Convert.ToByte(building.GetNumberOfSpaces()));//кол-во помещений
                    Fstream.WriteByte(Convert.ToByte(variable1.GetArrayOfSpaces()));//пишем массив помещений
                }
            }
            
            
            
            Fstream.WriteByte(Convert.ToByte("1 этаж"));

            Fstream.WriteByte(Convert.ToByte(building.GetNumberOfSpaces()));//кол-во помещений
            
            //получение количество комнат помещений и площади
            //сведения об объекте
           





        }
        
        ////чтения данных о здании из байтового потока
        //public static Building inputBuilding(InputStream in)
        //{
            
        //}
        ////записи здания в символьный поток
        //public static void writeBuilding(Building building, Writer out)
        //{
            
        //}
        ////чтения здания из символьного потока
        //public static Building readBuilding(Reader in)
        //{
            
        //}
    }
}
