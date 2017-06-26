using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace timp_4
{
    class OfficeFloor : IFloor
    {
        #region  Индексация
        public Office this[int i]
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

        public void SetAt(int numberNode, Office a)
        {
            Node<Office> temp = Agregator(numberNode);
            temp.Value = a;
        }

        public Office GetAt(int numberNode)
        {
            if (numberNode > CLL.Count - 1)
            {
                throw  new SpaceIndexOutOfBoundsException();
            }
            Node<Office> temp = Agregator(numberNode);

            return temp.Value;
        }

        private Node<Office> Agregator(int numberNode)
        {
            int i = 0;
            Node<Office> temp = CLL._head;

            while (i < numberNode)
            {
                temp = temp.Next;
                i++;
            }
            return temp;
        }

        #endregion
        
        #region Конструкторы
        public OfficeFloor(){}// null

        public OfficeFloor(int numberOffice)
        {
            for (int i = 0; i < numberOffice; i++)
            {
                CLL.Add(new Office());
            }

        }//принемает количество офисов на этаже. 

        public OfficeFloor(Office[] numberOffice)
        {
            for (int i = 0; i < numberOffice.Length; i++)
            {
                CLL.Add(numberOffice[i]);
            }
        }//принемает массив офисов этажа. 
        #endregion

        SinglyLinkedList<Office> CLL = new SinglyLinkedList<Office>();

        private Office GetNode(int numberNode)
        {
            return CLL[numberNode];
        }//получения узла по его номеру. //или метод getat

        private void AddNode(int newNumberOffice,Office newOffice)
        {
            Office of = new Office();
            CLL.AddInsert(newNumberOffice, newOffice);
        }//добавления узла в список по номеру.
        

        public int GetNumberOfSpaces()
        {
            return CLL.Count;
        }//получения количества офисов на этаже.

        public double GetTotalSquare()
        {
            double square = 0;
            foreach (var item in CLL)
            {
                square += item.area;
            }
            return square;
        }//получения общей площади помещений этажа.

        public int GetTotalRooms()
        {
            int count = 0;
            foreach (var item in CLL)
            {
                count += item.room;
            }
            return count;
        }//получения общего количества комнат этажа. ---

        public Office[] GetArrayOfOffice()
        {
            Office[] array = new Office[CLL.Count];
            CLL.CopyTo(array, 0);
            return array;
        }

        public ISpace[] GetArrayOfSpaces()
        {
            return GetArrayOfOffice();
        }//получения массива офисов этажа. 

        public Office GetOffice(int numberOffice)
        {
            return GetNode(numberOffice);
        }//получения офиса по его номеру на этаже.

        public ISpace GetSpace(int numberOffice)
        {
            return GetOffice(numberOffice) as ISpace;
        }

        public void RemoveOfficeAt(int number)
        {
            //сделать!
        }

        public void RemoveSpace(int number)
        {
            RemoveOfficeAt(number);
        }

        public void ChangeOffice(int numberOffice, Office obj)
        {
            CLL.SetAt(numberOffice, obj);
        }//изменения офиса по его номеру на этаже и ссылке на обновленный офис.

        public void ChangeSpace(int number, ISpace space)
        {
            ChangeOffice(number, space as Office);
        }
        public void AddOffice(int futureNumberOffice)
        {
            AddNode(futureNumberOffice, new Office());
        }//добавления нового офиса на этаже по будущему номеру офиса.
        public void AddOffice(int futureNumberOffice, Office office)
        {
            AddNode(futureNumberOffice, office);
        }//добавления нового офиса на этаже по будущему номеру офиса.

        public void InsertSpace(int number, ISpace space)
        {
            AddOffice(number, space as Office);
        }

        public ISpace GetBestSpace()
        {
            double maxArea = CLL[0].area;
            Office office = CLL[0];

            foreach (var item in CLL)
            {
                if (item.area > maxArea)
                {
                    maxArea = item.area;
                    office = item;
                }
            }
            return office;
        }
       //получения самого большого по площади офиса этажа

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

        public override string ToString()
        {
            string s = " Количество оффисов: " + CLL.Count + "\n";

            return s;
        }


        #region Синхронизация
        public void СhangeNumberRoomOffice(int room){}//изменение кличества комнaт 

        public void СhangeAreaOffice(int area){}//изменение площади 
        #endregion
    }
}
