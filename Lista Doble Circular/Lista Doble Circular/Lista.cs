﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lista_Doble_Circular
{
    class Lista
    {
        //LEER
        //Profe este es una avance de lo que hemos estado haciendo si nota alguno errores y cosas comentadas es porque estamos haciendo las adaptaciones correspondientes y hemos tenido algunos problemas :(
        //El de desplegar lista hace casi la misma funcion que el de cargar porque ese muestra lista. esta bien si dejo eso?
        

        //lista Circular doble ... head y cual es el final
        private Nodo head;

        public Nodo Head
        {
            get { return head; }
            set { head = value; }
        }


        public Lista()
        {
            head = null;
        }


        public void agregarNodo(Nodo nuevo)
        {

            if (head == null)
            {
                nuevo.siguiente = nuevo;
                nuevo.anterior = nuevo;
                head = nuevo;
                return;
            }
            Nodo h = head;
            if (nuevo.dato < head.dato)
            {
                Nodo ultimo = head.anterior;
                nuevo.siguiente = head;
                nuevo.anterior = ultimo;
                head.anterior = nuevo;
                ultimo.siguiente = nuevo;
                head = nuevo;
                while (h.siguiente != head)
                {
                    h = h.siguiente;
                }
                h.siguiente = nuevo;
                h.anterior = head;
                head = nuevo;
                return;
            }
            while (nuevo != head)
            {
                if (nuevo.dato < h.siguiente.dato)
                {
                    break;
                }
                h = h.siguiente;
                h.anterior = head;
                if (nuevo.dato > h.dato)
                {
                    Nodo ultimo = head.anterior;
                    nuevo.siguiente = head;
                    nuevo.anterior = ultimo;
                    head.anterior = nuevo;
                    ultimo.siguiente = nuevo;
                    return;
                }
            }
            nuevo.siguiente = h.siguiente;
            h.anterior = h.siguiente;
            h.siguiente = nuevo;


            //else
            //{
            //    Nodo ultimo = head.anterior;
            //    nuevo.siguiente = head;
            //    nuevo.anterior = ultimo;
            //    head.anterior = nuevo;
            //    ultimo.siguiente = nuevo;
            //}
            //Console.WriteLine("\n Nuevo nodo ingresado con exito\n\n");
        }

        public void buscarNodo()
        {
            Nodo actual = new Nodo();
            actual = head;
            bool encontrado = false;
            Console.Write(" Ingrese el dato del nodo a buscar: ");
            int nodoBuscado = int.Parse(Console.ReadLine());
            if (actual != null)
            {
                do
                {
                    if (actual.dato == nodoBuscado)
                    {
                        Console.WriteLine("\n Nodo con el dato ({0}) Encontrado\n", actual.dato);
                        encontrado = true;
                    }
                    actual = actual.siguiente;
                } while (actual != head && encontrado != true);
                if (!encontrado)
                {
                    Console.WriteLine("\n Nodo no encontrado\n");
                }
            }
            else
            {
                Console.WriteLine("\n La lista se encuentra vacia\n");
            }
        }

        public void modificarNodo()
        {
            Nodo actual = new Nodo();
            actual = head;
            bool encontrado = false;
            Console.Write(" Ingrese el dato del nodo a Modificar: ");
            int nodoBuscado = int.Parse(Console.ReadLine());
            if (actual != null)
            {
                do
                {
                    if (actual.dato == nodoBuscado)
                    {
                        Console.WriteLine("\n Nodo con el dato ({0}) Encontrado\n", actual.dato);
                        Console.Write(" Ingrese el nuevo dato para este nodo: ");
                        actual.dato = int.Parse(Console.ReadLine());
                        Console.WriteLine("\n Nodo modificado con exito");
                        encontrado = true;
                    }
                    actual = actual.siguiente;
                } while (actual != head && encontrado != true);
                if (!encontrado)
                {
                    Console.WriteLine("\n Nodo no encontrado\n");
                }
            }
            else
            {
                Console.WriteLine("\n La lista se encuentra vacia\n");
            }
        }

        public void eliminarNodo(int d)
        {
            if (head == null)
            {
                return;
            }
            Nodo h = head;
            if (head.dato == d)
            {
                if (head.siguiente == head)
                {
                    head = null;
                    return;
                }
                while (h.siguiente != head)
                {
                    h.anterior = h;
                    h = h.siguiente;
                }
                h.anterior = head;
                h.siguiente = head.siguiente;
                head.anterior = head;
                head = head.siguiente;
                return;
            }

            while (h.siguiente != head)
            {
                if (h.siguiente.dato == d)
                {
                    break;
                }
                h.anterior = h;
                h = h.siguiente;
            }
            if (h.siguiente != head)
            {
                h.anterior = h.siguiente;
                h.siguiente = h.siguiente.siguiente;
            }
        }

        //public void eliminarNodo()
        //{
        //    Nodo actual = new Nodo();
        //    actual = head;
        //    Nodo anterior = new Nodo();
        //    Nodo ultimo = new Nodo();
        //    anterior = null;
        //    ultimo = head;
        //    bool encontrado = false;
        //    Console.Write(" Ingrese el dato del nodo a Elminar: ");
        //    int nodoBuscado = int.Parse(Console.ReadLine());
        //    if (actual != null)
        //    {
        //        do
        //        {
        //            if (actual.dato == nodoBuscado)
        //            {
        //                if (actual == head)
        //                {
        //                    head = head.siguiente;
        //                    head.anterior = ultimo;
        //                    ultimo.siguiente = head;
        //                }
        //                else if (actual == ultimo)
        //                {
        //                    ultimo = anterior;
        //                    ultimo.siguiente = head;
        //                    head.anterior = ultimo;
        //                }
        //                else
        //                {
        //                    anterior.siguiente = actual.siguiente;
        //                    actual.siguiente.anterior = anterior;
        //                }
        //                Console.WriteLine("\n Nodo eliminado con exito\n");
        //                encontrado = true;
        //            }
        //            anterior = actual;
        //            actual = actual.siguiente;
        //        } while (actual != head && encontrado != true);
        //        if (!encontrado)
        //        {
        //            Console.WriteLine("\n Nodo no encontrado\n");
        //        }
        //    }
        //    else
        //    {
        //        Console.WriteLine("\n La lista se encuentra vacia\n");
        //    }
        //}

        public void desplegarListaPU()
        {
            Nodo actual = new Nodo();
            actual = head;
            if (actual != null)
            {
                do
                {
                    Console.WriteLine(" " + actual.dato);
                    actual = actual.siguiente;
                } while (actual != head);
            }
            else
            {
                Console.WriteLine("\n La lista se encuentra vacia\n");
            }
        }
        public void Guardar()
        {
            Nodo h = head;
            if (head == null)
            {
                return;
            }
            string path = @"C:\ListaDobleCircular.txt";
            using (StreamWriter sw = File.CreateText(path))
            {
                do
                {
                    sw.WriteLine(h.dato);
                    h = h.siguiente;
                } while (h != head);
            }
            return;
        }
        public void Cargar(string nombreArchivo)
        {
            nombreArchivo = "ListaDobleCircular";
            string[] lineas = File.ReadAllLines(@"C:\"+ nombreArchivo + ".txt");
            foreach (string linea in lineas)
            {
                if (linea.Length == 0)
                {
                    continue;
                }
                string[] datos = linea.Split('-');
                int dato = int.Parse(datos[0]);
                Nodo nuevo = new Nodo(dato);
                agregarNodo(nuevo);
            }
        }
        public override string ToString()
        {
            string lista = "Nodos:\n ";
            Nodo h = head;
            if (head == null)
            {
                return lista;
            }
            do
            {
                lista += h.dato + "\n ";
                h = h.siguiente;
            } while (h != head);
            return lista;
        }
    }
}