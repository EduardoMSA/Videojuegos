using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

    public Nodo start,
               end;
    public Nodo[] path;
    public Nodo[] nodos;
    private Nodo closer;
    private Nodo target;
    private int current, count;
    private bool click;


    // Use this for initialization
    void Start () {

        List<Nodo> route = Pathfinding.BreadthwiseSearch(start, end);
        path = route.ToArray();
        target = path[0];
        current = 0;
        click = false;
        StartCoroutine(move());
        count = 0;
        closer = path[0];

    }
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(target.transform);
        transform.Translate(transform.forward * Time.deltaTime * 5, Space.World);

        if (Input.GetMouseButtonUp(0))
        {
            float distanciaMinima = Vector3.Distance(transform.position, path[0].transform.position);
            closer = path[0];
            for(int i = 1; i < path.Length; i++)
            {
                float distanciaTmp = Vector3.Distance(transform.position, path[i].transform.position);
                if (distanciaTmp < distanciaMinima)
                {
                    distanciaMinima = distanciaTmp;
                    closer = path[i];
                }
            }
            click = true;
            target = closer;
        }

    }

    IEnumerator move()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.3f);
            if (!click)
            {
                float d = Vector3.Distance(transform.position, path[current].transform.position);
                if (Mathf.Round(d) == 0)
                {
                    current++;
                    count++;
                    current %= path.Length;
                    target = path[current];

                }
            }
            else
            {
                float d = Vector3.Distance(transform.position, closer.transform.position);
                if (Mathf.Round(d) == 0)
                {
                    click = false;
                    target = path[current];
                }
            }

        }
    }
}
