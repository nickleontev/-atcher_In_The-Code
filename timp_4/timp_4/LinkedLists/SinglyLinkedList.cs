using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Runtime.InteropServices;

namespace timp_4
{
    class SinglyLinkedList<T> : IEnumerable<T>
    {
        private Node<T> _head;
        private Node<T> _tail;

        public int Count
        {
            get;
            private set;
        }
        
        public T this[int i]
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

        public T GetAt(int numberNode)
        {
            Node<T> temp = Agregator(numberNode);
            return temp.Value;
        }

        public void SetAt(int numberNode, T a)
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
                i++;
            }
            return temp;
        }


        public void Add(T value)
        {
            Node<T> node = new Node<T>(value);

            if (_head == null)
            {
                _head = node;
                _tail = node;
            }

            else
            {
                _tail.Next = node;
                _tail = node;
            }
            Count++;
        }
        public void AddFirst(T value)
        {
            Node<T> node = new Node<T>(value);
            node.Next = _head;
            _head = node;
            if (Count == 0)
                _tail = _head;
            Count++;
        }
        public void Insert(int index, T item)
        {
            Node<T> newElement = new Node<T>(item);
            
            Node<T> temp = _head;
            
            if (index == this.Count)
            {
                int i = 0;

                while (i != Count - 1)
                {
                    if (_head == null)
                    {
                        _head = newElement;
                        _tail = newElement;
                        temp = _head;
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
                        while (i != Count - 1)
                        {
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

        public bool Remove(T item)
        {
            Node<T> previous = null;
            Node<T> current = _head;

            while (current != null)
            {
                if (current.Value.Equals(item)) 
                {

                    if (previous != null)
                    {
                        previous.Next = current.Next;
                        
                        if (current.Next == null)
                        {
                            _tail = previous;
                        }
                    }
                    else
                    {
                        _head = _head.Next;             

                        if (_head == null)
                        {
                            _tail = null;
                        }
                    }

                    Count--;
                    return true;
                }
                previous = current;
                current = current.Next;
            }
            return false;
        }
        public void RemoveInsert(int index, T item)
        {
            Node<T> newElement = new Node<T>(item);


            if (index == this.Count)
            {
                int i = 0;
                Node<T> temp = _head;

                while (i != Count - 1)
                {
                    if (_head == null)
                    {
                        //_head = newElement;
                        //_tail = newElement;
                        //temp = _head;
                        break;
                    }
                    //if (temp == null)
                    //{
                    //    temp = _head;
                    //}
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
                if (index < this.Count && index > 0)
                {
                    int i = 0;
                    Node<T> temp = _head;

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
                        Node<T> temp = _head;

                        newElement.Next = temp;
                        this._head = newElement;
                        Count++;
                    }
                    //исключение - индекс отрицательный или больше размера. 
                }
            }
        }//его считай нет, там просто скопированый Insert

        public void CopyTo(T[] array, int arrayIndex)
        {
            Node<T> current = _head;

            while (current != null)
            {
                array[arrayIndex++] = current.Value;
                current = current.Next;
            }
        }

        public bool Contains(T item)
        {
            Node<T> current = _head;

            while (current != null)
            {
                if (current.Value.Equals(item))
                {
                    return true;
                }

                current = current.Next;
            }
            return false;
        }
        
        public IEnumerator<T> GetEnumerator()
        {
            Node<T> current = _head;

            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }
        
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<T>)this).GetEnumerator();
        }
        
        //public void Clear()
        //{
        //    _head = null;
        //    _tail = null;
        //    Count = 0;
        //}
       }
}