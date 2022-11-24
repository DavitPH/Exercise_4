using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_4
{
    class Node
    {
        public int rollNumber;
        public string name;
        public Node next;
    }
    class CirculasList
    {
        Node LAST;
        public CirculasList()
        {
            LAST = null;
        }

        public bool Search(int rollNo, ref Node previous, ref Node current)
        {

        }
    }
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
