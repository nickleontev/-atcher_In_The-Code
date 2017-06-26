using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace timp_4
{
    class OfficeFloor : IFloor
    {
        #region Конструкторы
        public OfficeFloor(){}// null //в билдинге создаем пустой объект, поэтому он нужен, хз как исправить глянье сели заметишь этот комент

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
        //посомтри сюда, в конструкторы
        SinglyLinkedList<Office> CLL = new SinglyLinkedList<Office>();

        private Office GetNode(int numberNode)
        {
            return CLL[numberNode];
        }//получения узла по его номеру. //или метод getat

        private void AddNode(int newNumberOffice,Office newOffice)
        {
            Office of = new Office();
            CLL.Insert(newNumberOffice, newOffice);
        }//добавления узла в список по номеру.

        private void RemoveNode()
        {
            
        }//null


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
        }//получения общего количества комнат этажа.
        
        public ISpace[] GetArrayOfSpaces()
        {
            Office[] array = new Office[CLL.Count];
            CLL.CopyTo(array, 0);
            return array;
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
        
        public void ChangeSpace(int number, ISpace space)
        {
            CLL.SetAt(number, space as Office);
        }//Правка!

        public void AddOffice(int futureNumberOffice)
        {
            AddNode(futureNumberOffice, new Office());
        }//добавления нового офиса на этаже по будущему номеру офиса.
        
        //Правка!
        public void InsertSpace(int number, ISpace space)
        {
            AddNode(number, space as Office);
        }//добавления нового офиса на этаже по будущему номеру офиса.

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
    }
}
