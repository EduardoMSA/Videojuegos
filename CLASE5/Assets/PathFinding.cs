using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinding {

    public static List<Nodo> BreadthwiseSearch(Nodo start, Nodo end)
    {
        List<Nodo> resultado = new List<Nodo>();
        List<Nodo> visitado = new List<Nodo>();
        Queue<Nodo> work = new Queue<Nodo>();

        start.historial = new List<Nodo>();

        visitado.Add(start);
        work.Enqueue(start);

        while(work.Count > 0)
        {
            Nodo actual = work.Dequeue();
            if(actual == end)
            {
                //encontramos el nodo
                resultado = actual.historial;
                resultado.Add(actual);
                return resultado;
            }
            else
            {
                // todavia no encontramos
                for(int i=0; i < actual.vecinos.Length; i++)
                {
                    Nodo vecinoActual = actual.vecinos[i];
                    if (!visitado.Contains(vecinoActual))
                    {
                        vecinoActual.historial = new List<Nodo>(actual.historial);
                        vecinoActual.historial.Add(actual);

                        visitado.Add(vecinoActual);
                        work.Enqueue(vecinoActual);
                    }
                }
            }
        }

        // no existio ruta, el ciclo termina sin return
        return null;


    }

    public static List<Nodo> DepthwiseSearch(Nodo start, Nodo end)
    {
        List<Nodo> resultado = new List<Nodo>();
        List<Nodo> visitados = new List<Nodo>();
        Stack<Nodo> work = new Stack<Nodo>();

        start.historial = new List<Nodo>();
        visitados.Add(start);
        work.Push(start);

        Nodo actual,hijoActual;

        while (work.Count > 0)
        {
            actual = work.Pop();

            if (actual == end)
            {
                resultado = new List<Nodo>(actual.historial);
                resultado.Add(actual);
                return resultado;
            }
            else
            {
                for(int i=0; i < actual.vecinos.Length; i++)
                {
                    hijoActual = actual.vecinos[i];

                    if (visitados.Contains(hijoActual))
                    {
                        visitados.Add(hijoActual);
                        hijoActual.historial = new List<Nodo>(actual.historial);
                        hijoActual.historial.Add(actual);

                        work.Push(hijoActual);

                    }
                }
            }
        }

        return null;
    }

   
    public static List<Nodo> AStar(Nodo start, Nodo end)
    {
        List<Nodo> visitados = new List<Nodo>();
        List<Nodo> work = new List<Nodo>();

        start.historial = new List<Nodo>();
        //calcular F(start) = g(start) + h(start)
        start.g = 0;
        start.h = Vector3.Distance(start.transform.position, end.transform.position);

        visitados.Add(start);
        work.Add(start);

        while(work.Count > 0)
        {
            //seleccionar quien sigue basado en criterio
            Nodo current = work[0];
            for(int i = 1; i < work.Count; i++)
            {
                if (work[i] == end)
                {
                    List<Nodo> resultado = work[i].historial;
                    resultado.Add(work[i]);
                    return resultado;
                }
                if(work[i].F < current.F)
                {
                    current = work[i];
                }
            }

            work.Remove(current);
            //si llegamos aqui el nodo no esta en la lista de trabajo
            for(int i = 0; i < current.vecinos.Length; i++)
            {
                Nodo vecinoActual = current.vecinos[i];

                visitados.Add(vecinoActual);

                vecinoActual.g = current.g + Vector3.Distance(current.transform.position,vecinoActual.transform.position);

                vecinoActual.h = Vector3.Distance(vecinoActual.transform.position, end.transform.position);

                work.Add(vecinoActual);

                vecinoActual.historial = new List<Nodo>(current.historial);
                vecinoActual.historial.Add(current);
            }
        }

        return null;
    }
}
