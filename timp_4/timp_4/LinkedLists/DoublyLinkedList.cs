using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace timp_4
{
    class DoublySinglyLinkedList<T> : SinglyLinkedList<T>
    {
        new public int Count
        {
            get;
            private set;
        }

        #region  Индексация
        new public T this[int i]
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

        new public T GetAt(int numberNode)
        {
            Node<T> temp = Agregator(numberNode);

            return temp.Value;
        }

        new public void SetAt(int numberNode, T a)
        {
            Node<T> temp = Agregator(numberNode);
            temp.Value = a;
        }

        private Node<T> Agregator(int numberNode)
        {
            int i = 0;
            Node<T> temp = _head;

            while (i < numberNode)
            {
                temp = temp.Next;
                temp = temp.Previous;
                i++;
            }
            return temp;
        }
        #endregion
        
        public void Insert(int index, T item)
        {
            Node<T> newElement = new Node<T>(item);

            //Node<T> newOffice = new Node<T>(of);
            Node<T> temp = _head;

            //если список пустой полюбому зайдет сюда
            if (index == this.Count)
            {
                int i = 0;

                while (i != Count - 1)
                {
                    if (_head == null)
                    {
                        _head = newElement;
                        _tail = _head;
                        temp = _head;
                        temp.Previous = _head;
                        break;
                    }

                    if (temp == null)
                    {
                        temp = _head;
                    }
                    else
                    {
                        temp = temp.Next;
                    }

                    i++;
                }

                temp.Next = newElement;

                this.Count++;
            }
            else
            {
                if (index > this.Count - 1)
                {
                    if (index == this.Count)
                    {
                        newElement.Next = _tail;
                        _tail = newElement;
                        if (Count == 0)
                            _head = _tail;
                        Count++;
                    }
                    else
                    {
                        //здесь сделать добавление переменных
                        int i = 0;
                        //while (i != index)
                        //{
                        while (i != Count - 1)
                        {
                            //if (i>=Count-1)
                            //{
                            //    break;
                            //}
                            if (temp == null)
                            {
                                temp = _head;
                            }
                            else
                            {
                                temp = temp.Next;
                            }
                            //temp.Next = newElement;
                            i++;

                        }
                        //temp.Next = newOffice; /*new Office();*/
                        //this.Count++;
                        //i++;
                        //}
                        //temp.Next = newElement;
                        temp.Next = newElement;
                        this.Count++;
                    }
                }
                //никита
                if (index < this.Count && index > 0)
                {
                    int i = 0;
                    while (i < index - 1)
                    {
                        temp = temp.Next;
                        i++;
                    }
                    newElement.Next = temp.Next;
                    temp.Next = newElement;
                    this.Count++;
                }
                else
                {
                    if (index == 0)
                    {
                        newElement.Next = temp;
                        this._head = newElement;
                        Count++;
                    }
                    //исключение - индекс отрицательный или больше размера. 
                }
                //никита
            }
        }
    }
}
