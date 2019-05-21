using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {


    public Nodo start,
                end;
    public Nodo[] path;
    public Nodo[] nodos;
    private Nodo target;
    private int current,count;
    private bool click;


    // Use this for initialization
    void Start()
    {
        List<Nodo> route = PathFinding.BreadthwiseSearch(start, end);
        path = route.ToArray();
        target = path[0];
        current = 0;
        click = false;
        StartCoroutine(move());
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target.transform);
        transform.Translate(transform.forward * Time.deltaTime * 5, Space.World);

        if (Input.GetMouseButtonUp(0))
        {
            Ray rayito = Camera.main.ScreenPointToRay(Input.mousePosition);
            //float disMenor = Vector3.Distance(rayito.direction, Camera.main.WorldToScreenPoint(nodos[0].transform.position));
            //print(rayito.origin.x);
            //print(rayito.origin.y);
            //print(rayito.origin.z);
            RaycastHit hit;
            if(Physics.Raycast(rayito, out hit))
            {
                float disMenor = Vector3.Distance(hit.transform.position, nodos[0].transform.position);
                int nodoMenor = 0;
                for (int i = 1; i < nodos.Length; i++)
                {
                    float disNodo = Vector3.Distance(hit.transform.position, nodos[i].transform.position);
                   
                    if (disNodo < disMenor)
                    {
                        disMenor = disNodo;
                        nodoMenor = i;
                    }
                    print(i);
                    print(disMenor);
                    print(disNodo);
                    //print(nodoMenor);
                }
                List<Nodo> route2 = PathFinding.BreadthwiseSearch(path[current], nodos[nodoMenor]);
                path = route2.ToArray();
                //for (int i = 0; i < path.Length; i++)
                //{
                //    print(path[i]);
                //}
                target = path[0];
                current = count = 0;
                click = true;
                
            }
            
            
        }//cierra if mouse click rayito

    }

    IEnumerator move()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.3f);
            float d = Vector3.Distance(transform.position, path[current].transform.position);
            if (Mathf.Round(d) == 0)
            {
                current++;
                count++;
                current %= path.Length;
                target = path[current];

                /*if (click && count > path.Length)
                {
                    List<Nodo> route3 = PathFinding.BreadthwiseSearch(start, end);
                    path = route3.ToArray();
                    target = path[0];
                    current = count = 0;
                    click = false;
                }*/
            }

        }
    }

}
