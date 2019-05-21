using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour {

    public Transform[] path;
    public float threshold;
    public GameObject proyectil;

    private Transform target;
    private int current;
    private Coroutine c;
    private IEnumerator ie;

    // Use this for initialization
    void Start()
    {
        threshold = 0.3f;
        target = path[0];
        current = 0;
        ie = verificarDistancia();
        c = StartCoroutine(ie);
        StartCoroutine(disparar());

    }
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(target);
        transform.Translate(transform.forward * Time.deltaTime * 5, Space.World);
    }

    IEnumerator verificarDistancia()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.33f);
            float d = Vector3.Distance(transform.position, path[current].position);
            if (d < threshold)
            {

                current++;
                current %= path.Length;
                target = path[current];
            }
        }
    }

    IEnumerator disparar()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            Instantiate(proyectil,transform.position,proyectil.transform.rotation);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(this.gameObject);
    }

}
