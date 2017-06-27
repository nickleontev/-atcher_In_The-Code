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
        public int Count
        {
            get;
            private set;
        }

        private T GetAt(int numberNode)
        {
            Node<T> temp = Agregator(numberNode);
            return temp.Value;
        }

        private void SetAt(int numberNode, T a)
        {
            Node<T> temp = Agregator(numberNode);
            temp.Value = a;
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

        public void Add(T value)
        {
            Node<T> node = new Node<T>(value);

            if (_head == null)
            {
                _head = node;
            }

            else
            {
                Node<T> temp = Agregator(Count-1);
                temp.Next = node;
            }
            Count++;
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

        public void Insert(int index, T item)
        {
            Node<T> newElement = new Node<T>(item);
            Node<T> temp = _head;
            
            if (index == this.Count)
            {
                Add(item);
            }
            else
            {
                if (index < this.Count && index > 0)
                {
                    newElement.Next = Agregator(index-1).Next;
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
                }
            }
        }

        public void RemoveAt(int number)
        {
            Node<T> temp;
            if (number > 0 && number<Count)
            {
                temp = Agregator(number - 1);
                temp.Next = temp.Next.Next;
            }
            else if (number == 0)
            {
                temp = _head.Next;
                _head = temp;
            }

        }

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

        public void Clear()
        {
            _head = null;
            Count = 0;
        }
    }
}