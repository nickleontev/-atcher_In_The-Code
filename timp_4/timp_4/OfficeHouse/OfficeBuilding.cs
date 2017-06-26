using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace timp_4
{
    class OfficeBuilding : IBuilding
    {
        #region Конструкторы
        int[] countOfficeOnFloors;
        public OfficeBuilding(int CountFloor, int[] countOfficeOnFloors)
        {
            this.countOfficeOnFloors = countOfficeOnFloors;
        }//количество этажей и массив количества офисов по этажам.

        OfficeBuilding[] array;

        public OfficeBuilding(OfficeBuilding[] array)
        {
            this.array = array;
        }//массив этажей офисного здания
        #endregion

        OfficeFloor OF = new OfficeFloor();

        SinglyLinkedList<OfficeFloor> CLL = new SinglyLinkedList<OfficeFloor>();
        

        private OfficeFloor GetNode(int numberNode)
        {
            return CLL[numberNode];
        }//получения узла по его номеру.

        private void AddNode(int numberNode, OfficeFloor obj)
        {
            CLL.Insert(numberNode, obj);
        }//добавления узла в список по номеру.

        private void RemoveNode()
        {
            
        }//null


        public int GetTotalRooms()
        {
            int count = 0;
            foreach (var item in CLL)
            {
                count += item.GetTotalRooms();
            }
            return count;
        }

        public int GetNumberOfFloors()
        {
            return CLL.Count;
        }//получения общего количества этажей здания.

        public int GetNumberOffice()
        {
            int count = 0;
            foreach (var VARIABLE in CLL)
            {
                count += VARIABLE.GetNumberOfSpaces();
            }
            return count;
        }//получения общего количества офисов здания.

        public double GetTotalSquare()
        {
            double count = 0.0d;
            foreach (var item in CLL)
            {
               count +=  item.GetTotalSquare();
            }
            return count;
        }//получения общей площади помещений здания.

        public int GetNumberOfSpaces()
        {
            int count = 0;
            foreach (var item in CLL)
            {
                count += item.GetNumberOfSpaces();
            }
            return count;
        }//получения общего количества комнат здания. 
        
        public IFloor[] GetArrayOfFloors()
        {
            OfficeFloor[] array = new OfficeFloor[CLL.Count];
            CLL.CopyTo(array, 0);
            return array;
        }//получения массива этажей офисного здания.

        public OfficeFloor GetOfficeFloor(int number)
        {
            return GetNode(number);
        }//получения объекта этажа, по его номеру в здании.

        public IFloor GetFloor(int number)
        {
            return GetNode(number);
        }
        
        public void ChangeOfficeFloor(int number, OfficeFloor officefloor)
        {
            CLL[number] = officefloor;
        }//изменения этажа по его номеру в здании и ссылке на обновленный этаж.

        public void ChangeFloor(int number, IFloor floor)
        {
            ChangeOfficeFloor(number, floor as OfficeFloor);
        }
        
        public void AddOfficeFloor(int numberOfficeInBuilding, OfficeFloor obj)
        {
            AddNode(numberOfficeInBuilding,obj);
        }//добавления офиса в здание по номеру офиса в здании и ссылке на офис.

        // Из интерфейса
        public void RemoveSpace(int number)
        {
            RemoveNode();
        }

        public ISpace GetSpace(int number)
        {
            return OF.GetOffice(number);
        }//получения объекта офиса по его номеру в офисном здании.

        public ISpace[] GetSortArrayOfSpaces()
        {
            return null;
        }//null//Получени отсортированного массива? Зачем?

        public ISpace GetBestSpace()
        {
            return null;
        }//null

        public void ChangeSpace(int number, ISpace space)
        {
            OF.ChangeSpace(number, space as Office);
        }//изменения объекта офиса по его номеру в доме и ссылке типа офиса.
        //

        public void Display()
        {
            Console.WriteLine();
            foreach (var word in CLL)
            {
                Console.Write(word + " ");
            }
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
