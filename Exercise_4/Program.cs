using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_4
{
    class Node
    {
        //membuat Node untuk circular
        public int rollNumber;
        public string name;
        public Node next;

        public Node()
        {
        }

        public Node(int  i)
        {
            rollNumber = i;
            next = null;
        }
    }
    class CirculasList
    {
        Node LAST;
        public CirculasList()
        {
            LAST = null;
        }

        public void addNote()
        {
            int nim;
            string nm;
            Console.WriteLine("\nMasukan nomer Mahasiswa: \n");
            nim = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\nMasukan nama Mahasiswa: \n");
            nm = Console.ReadLine();

            Node nodeBaru = new Node();
            nodeBaru.rollNumber  = nim;
            nodeBaru.name = nm;

            //Node ditambahkan sebagai node pertama
            if (LAST  == null || nim <= LAST.rollNumber )
            {
                if ((LAST  != null) && (nim == LAST .rollNumber ))
                {
                    Console.WriteLine("\nNomer mahasiswa sama tidak diizinkan \n");
                }
                nodeBaru.next = LAST ;
                LAST  = nodeBaru;
                return;
            }
            //Menemukan lokasi node baru didalam list
            Node previous, current;
            previous = LAST ;
            current = LAST ;

            while ((current != null) && (nim >= current.rollNumber))
            {
                if (nim == current.rollNumber)
                {
                    Console.WriteLine("\nNomer mahasiswa sama tidak diizinkan\n");
                    return;
                }
                previous = current;
                current = current.next;
            }
            //Node baru akan ditempatkan di antara previous dan current
            nodeBaru.next = current;
            previous.next = nodeBaru;
        }

        //Mencari node yang ditentukan
        public bool Search(int rollNo, ref Node previous, ref Node current)
        { 
            for (previous = current = LAST.next; current != LAST;
                previous = current , current = current.next)
            {
                if (rollNo == current.rollNumber)
                    return (true); //mengembalikan nilai true jika node ditemukan
            }
            if (rollNo == LAST.rollNumber)
                return true; //Jika node hadir di akhir
            else
                return (false); //jika node tidak ditemukan
        }

        public bool listEmpty()
        {
            if (LAST == null)
                return true;
            else
                return false;
        }

        public void treverse() //Melintasi semua node dari daftar
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
        public void DeleteNode(int x)
        {
            // list is empty
            if (LAST == null)
                return;
            // delete the only node
            if (LAST.next == LAST && LAST.rollNumber == x)
            {
                LAST = null;
                return;
            }
            // delete the first node
            if (LAST.next.rollNumber  == x)
            {
                LAST.next = LAST.next.next;
                return;
            }
            // delete a node in between the list
            Node p = LAST.next;
            while (p.next != LAST.next)
            {
                if (p.next.rollNumber == x)
                    break;
                p = p.next;
            }

            if (p.next == LAST.next)
                Console.WriteLine(x + " not found in the list.");
            else
            {
                p.next = p.next.next;
                if (LAST.rollNumber  == x)
                    LAST = p;
            }
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            int data;
            CirculasList obj = new CirculasList();
            while (true)
            {
                try
                {
                    Console.WriteLine("\nMenu");

                    Console.WriteLine("1. View all the records in the list");
                    Console.WriteLine("2. Search for a record in the list");
                    Console.WriteLine("3. Display the first record in the list");
                    Console.WriteLine("4. Add data to the list FOR TESTING");
                    Console.WriteLine("5. Delnode TEST circulasList");
                    Console.WriteLine("6. Exit");
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
                                
                            }
                            break;
                        case '4':
                            obj.addNote();
                            break;
                        case '5':
                            Console.WriteLine("Enter the element to be deleted : ");
                            data = Convert.ToInt32(Console.ReadLine());
                            obj.DeleteNode(data);
                            break;
                            break;
                        case '6':
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
