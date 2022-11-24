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
            for (previous = current = LAST.next; current != LAST;
                previous = current , current = current.next)
            {
                if (rollNo == current.rollNumber)
                    return (true);
            }
            if (rollNo == LAST.rollNumber)
                return true;
            else
                return (false);
        }

        public bool listEmpty()
        {
            if (LAST == null)
                return true;
            else
                return false;
        }

        public void treverse()
        {
            if (listEmpty())
                Console.WriteLine("\nList kosong");
            else
            {
                Console.WriteLine("\nData di dalam list adalah: \n");
                Node currentNode;
                for (currentNode = LAST ; currentNode != null; currentNode = currentNode.next)
                    Console.Write(currentNode.rollNumber + " " + currentNode.name + "\n");
                Console.WriteLine();
            }
        }

        public bool delNode(int nim)
        {
            Node previous, current;
            previous = current = null;
            //check apakah node yang dimaksud ada di dalam list atau tidak
            if (Search(nim, ref previous, ref current) == false)
                return false;
            previous.next = current.next;
            if (current == LAST)

                LAST  = LAST.next;
            return true;

        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            CirculasList obj = new CirculasList();
            while (true)
            {
                try
                {
                    Console.WriteLine("\nMenu");
                    Console.WriteLine("1. View all the records in the list");
                    Console.WriteLine("2. Search for a record in the list");
                    Console.WriteLine("3. Display the first record in the list");
                    Console.WriteLine("4. Exit");
                    Console.WriteLine("\nMasukan Pilihan Anda (1-4): ");
                    char ch = Convert.ToChar(Console.ReadLine());
                    switch (ch)
                    {
                        case '1':
                            {
                                obj.treverse();
                            }
                            break;
                        case '2':
                            {
                                if (obj.listEmpty() == true)
                                {
                                    Console.WriteLine("\nList Kosong");
                                    break;
                                }
                                Node previous, current;
                                previous = current = null;
                                Console.Write("\nMasukan nomer mahasiswa yang dicari: ");
                                int num = Convert.ToInt32(Console.ReadLine());
                                if (obj.Search(num, ref previous, ref current) == false)
                                    Console.WriteLine("\nData tidak ditemukan");
                                else
                                {
                                    Console.WriteLine("\nData Ketemu");
                                    Console.WriteLine("\nNomer Mahasiswa: " + current.rollNumber);
                                    Console.WriteLine("\nNama: " + current.name);

                                }
                            }
                            break;
                        case '3':
                            {
                                obj.firstNode();
                            }
                            break;
                        case '4':
                            return;
                        default:
                            {
                                Console.WriteLine("Pilihan tidak valid");
                                break;
                            }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("\nCheck nilai yang anda masuklan!");
                }
            }
        }
    }
}
