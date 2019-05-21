using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ejemplo : MonoBehaviour {

    public float vida = 100f;
    public Transform elOtro;

    private Estado actual;
    private Estado anterior;
    private Estado ocioso, comiendo, programando, llorando, reprobando;
    private Simbolo parciales, hambre, noComplia;
    private Component scriptActual;

    // Use this for initialization
    void Start() {
        ocioso = new Estado("Oscioso",typeof(Ocioso));
        comiendo = new Estado("Comiendo",typeof(Comiendo));
        programando = new Estado("Programando",typeof(Programando));
        llorando = new Estado("Llorando",typeof(Llorando));
        reprobando = new Estado("Reprobando",typeof(Reprobando));
        parciales = new Simbolo("Parciales");
        hambre = new Simbolo("Hambre");
        noComplia = new Simbolo("No Compila");

        ocioso.definirTransicion(parciales, llorando);
        ocioso.definirTransicion(hambre, comiendo);
        ocioso.definirTransicion(noComplia, llorando);

        comiendo.definirTransicion(parciales, programando);
        comiendo.definirTransicion(hambre, comiendo);
        comiendo.definirTransicion(noComplia, ocioso);

        programando.definirTransicion(parciales, reprobando);
        programando.definirTransicion(hambre, llorando);
        programando.definirTransicion(noComplia, ocioso);

        llorando.definirTransicion(parciales, llorando);
        llorando.definirTransicion(hambre, comiendo);
        llorando.definirTransicion(noComplia, llorando);

        reprobando.definirTransicion(parciales, llorando);
        reprobando.definirTransicion(hambre, comiendo);
        reprobando.definirTransicion(noComplia, programando);


        actual = ocioso;
        anterior = actual;
        scriptActual=gameObject.AddComponent(actual.Tipo);

        StartCoroutine(checarVida());
        StartCoroutine(checharDistancia());


        //
        //gameObject.AddComponent<Ocioso>();
    }
	
	// Update is called once per frame

    void transitar(Simbolo simbolo)
    {
        actual = actual.aplicarTransicion(simbolo);
        if (anterior == actual)
        {
            return;
        }
        anterior = actual;
        Destroy(scriptActual);
        scriptActual = gameObject.AddComponent(actual.Tipo);
    }

	void Update () { 

    }

    IEnumerator checarVida()
    {
        while (true)
        {
            if (vida < 30)
            {
                transitar(hambre);
            }
            yield return new WaitForSeconds(1);
        }
    }

    IEnumerator checharDistancia()
    {
        while (true)
        {
            float d = Vector3.Distance(transform.position, elOtro.position);
            if (d < 2)
            {
                transitar(parciales);
            }
            yield return new WaitForSeconds(1.1f);
        }
    }
}
