using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinding {

    public static List<Nodo> BreadthwiseSearch(Nodo start, Nodo end)
    {
        List<Nodo> resultado = new List<Nodo>();
        List<Nodo> visitado = new List<Nodo>();
        Queue<Nodo> work = new Queue<Nodo>();

        start.historial = new List<Nodo>();

        visitado.Add(start);
        work.Enqueue(start);

        while (work.Count > 0)
        {
            Nodo actual = work.Dequeue();
            if (actual == end)
            {
                //encontramos el nodo
                resultado = actual.historial;
                resultado.Add(actual);
                return resultado;
            }
            else
            {
                // todavia no encontramos
                for (int i = 0; i < actual.vecinos.Length; i++)
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
}
