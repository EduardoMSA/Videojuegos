﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class movimiento : MonoBehaviour {

    private Animator animator;
    private float j;
    public Text text;
    public Slider slider;


	// Use this for initialization
	void Start () {
        //obtener referencia a otro componente
        // invocar este método lo menos posible porque toma tiempo
        animator = gameObject.GetComponent<Animator>();
        j = 0;
	}
	
	// Update is called once per frame
	void Update () {
        
        float h = Input.GetAxis("Horizontal");
        float jActual = Input.GetAxisRaw("Jump");
        animator.SetFloat("velocidad", h);
        transform.Translate(h * Time.deltaTime * 5,0, 0);

        if(j==0 && jActual == 1)
        {
            animator.SetTrigger("hadouken");
        }
        j = jActual;
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("Enter");
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        print("Stay");
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        print("Exit");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("TriggerE");
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        print("TriggerS");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        print("TriggerEx");
    }

    public void Clickazo()
    {
        text.text = "Clickeado";
    }

    public void Modificado(float f)
    {
        text.text = slider.value + "";
    }
}
