using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIFO //First in, First out
{
    class Procesador
    {
        Proceso primero, ultimo, temp;

        //           +---+---+---+
        //enqueue -> | 3 | 2 | 1 | -> dequeue
        //           +---+---+---+

        //enqueue: to place something into a queue;
        //to add an element to the tail of a queue;

        //dequeue: to take something out of a queue;
        //to remove the first available element from the head of a queue

        public Procesador()
        {
            primero = null;
            ultimo = null;
        }

        public void enqueue(Proceso nuevoP) //Meter proceso
        {
            if(primero == null)
            {
                primero = nuevoP;
                ultimo = nuevoP;
            }
            else
            {
                ultimo.siguiente = nuevoP;
                ultimo = nuevoP;
            }
        }

        public Proceso dequeue() //sacar proceso
        {
            if(primero == null)
            {
                return null;
            }
            else
            {
                temp = primero;
                primero = primero.siguiente;
                return temp;
            }

        }

        public Proceso peek() //Ver proceso actual
        {
            return primero;
        }

        public string procesosoPendientes()
        {
            int procPendientes = 0;
            int sumaCiclosPendientes = 0;
            temp = primero;

            while (temp != null)
            {
                sumaCiclosPendientes += temp.ciclos;
                procPendientes++;
                temp = temp.siguiente;
            }
            string pendientes = "Procesos pendientes: " + procPendientes.ToString() + Environment.NewLine +
                "Suma de los ciclos pendientes: " + sumaCiclosPendientes.ToString();
            return pendientes;
        }
        
    }
}
