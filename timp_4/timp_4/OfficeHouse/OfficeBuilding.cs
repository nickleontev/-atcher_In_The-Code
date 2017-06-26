using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace timp_4
{
    class OfficeBuilding : IBuilding
    {
        #region индексация
        public OfficeFloor this[int i]
        {
            get
            {
                return this.GetAt(i);
            }
            set
            {
                SetAt(i, value);
            }
        }

        public void SetAt(int numberNode, OfficeFloor a)
        {
            Node<OfficeFloor> temp = Agregator(numberNode);
            temp.Value = a;
        }

        public OfficeFloor GetAt(int numberNode)
        {
            if (numberNode > DLL.Count - 1)
            {
                throw  new FloorIndexOutOfBoundsException();
            }
            Node<OfficeFloor> temp = Agregator(numberNode);

            return temp.Value;
        }

        private Node<OfficeFloor> Agregator(int numberNode)
        {
            int i = 0;
            Node<OfficeFloor> temp = DLL._head;

            while (i < numberNode)
            {
                temp = temp.Next;
                i++;
            }
            return temp;
        }

        #endregion

        #region Конструкторы
        public OfficeBuilding(){}

        public OfficeBuilding(int CountFloor, int[] countOfficeOnFloors)
        {
            this.countOfficeOnFloors = countOfficeOnFloors;
        }//количество этажей и массив количества офисов по этажам.

        public OfficeBuilding(OfficeBuilding[] array)
        {
            this.array = array;
        }//массив этажей офисного здания
        #endregion

        timp_4.OfficeFloor OF = new OfficeFloor();

        DoublySinglyLinkedList<OfficeFloor> DLL = new DoublySinglyLinkedList<OfficeFloor>();

        int[] countOfficeOnFloors;

        OfficeBuilding[] array;

        public int GetTotalRooms()
        {
            int count = 0;
            foreach (var item in DLL)
            {
                count += item.GetTotalRooms();
            }
            return count;
        }

        private OfficeFloor GetNode(int numberNode)
        {
            return GetAt(numberNode);
        }//получения узла по его номеру.

        private void AddNode(int numberNode, OfficeFloor obj)
        {
            DLL.Insert(numberNode, obj);
        }//добавления узла в список по номеру.
        

        public int GetNumberOfFloors()
        {
            return DLL.Count;
        }//получения общего количества этажей здания.

        public int GetNumberOffice()
        {
            int count = 0;
            foreach (var VARIABLE in DLL)
            {
                count += VARIABLE.GetNumberOfSpaces();
            }
            return count;
        }//получения общего количества офисов здания.

        public double GetTotalSquare()
        {
            double count = 0.0d;
            foreach (var item in DLL)
            {
               count +=  item.GetTotalSquare();
               
            }
            return count;
        }//получения общей площади помещений здания.

        public int GetNumberOfSpaces()
        {
            int count = 0;
            foreach (var item in DLL)
            {
                count += item.GetNumberOfSpaces();
            }
            return count;
        }//получения общего количества комнат здания. 

        public OfficeFloor[] GetArrayOfficeFloors()
        {
            OfficeFloor[] array = new OfficeFloor[DLL.Count];
            DLL.CopyTo(array, 0);
            return array;
        }//получения массива этажей офисного здания.

        public IFloor[] GetArrayOfFloors()
        {
            return GetArrayOfficeFloors();
        }

        public OfficeFloor GetOfficeFloor(int number)
        {
            return GetNode(number);
        }//получения объекта этажа, по его номеру в здании.

        public IFloor GetFloor (int number)
        {
            return GetNode(number);
        }

        public Office GetOffice(int numberOfficeInBuilding)
        {
            return OF.GetOffice(numberOfficeInBuilding);
        }//получения объекта офиса по его номеру в офисном здании.


        public void ChangeOfficeFloor(int number, OfficeFloor officefloor)
        {
            SetAt(number, officefloor);
        }//изменения этажа по его номеру в здании и ссылке на обновленный этаж.

        public void ChangeFloor(int number, IFloor floor)
        {
            ChangeOfficeFloor(number, floor as OfficeFloor);
        }
        public void ChangeOffice(int numberFloorInBuilding,Office office)
        {
            OF.ChangeOffice(numberFloorInBuilding, office);
        }//изменения объекта офиса по его номеру в доме и ссылке типа офиса.

        public void AddOfficeFloor(int numberOfficeInBuilding, OfficeFloor obj)
        {
            AddNode(numberOfficeInBuilding,obj);
        }//добавления офиса в здание по номеру офиса в здании и ссылке на офис.
        
        public void Display()
        {
            Console.WriteLine();
            foreach (var word in DLL)
            {
                Console.Write(word + " ");
            }
            Console.WriteLine();
            Console.WriteLine();
        }


        #region Синхронизация
        public void СhangeNumberRoomOffice(int room){}//изменение кличества комнaт. 

        public void СhangeAreaOffice(int area){} //изменение площади. 

        public int GetNumberRoom()
        {
            return 2;
        }//получение количества комнат. 

        public double GetArea()
        {
            return 2;
        }//получение площади. 

        public void AddOffice(int numberNod){}//вставки помещения по его номеру и ссылке на новое помещение. 
        #endregion
    }
}
