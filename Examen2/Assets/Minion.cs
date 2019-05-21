using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minion : MonoBehaviour {

    public Transform[] path;
    public float threshold;

    private Transform target;
    private int current;
    private Coroutine c;
    private IEnumerator ie;

    // Use this for initialization
    void Start () {
        target = path[0];
        current = 0;
        ie = verificarDistancia();
        c = StartCoroutine(ie);
    }
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(target);
        transform.Translate(transform.forward * Time.deltaTime * 2, Space.World);

    }

    IEnumerator verificarDistancia()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.25f);
            float d = Vector3.Distance(transform.position, path[current].position);
            if (d < threshold)
            {

                current++;
                current %= path.Length;
                target = path[current];
            }
        }
    }
}
