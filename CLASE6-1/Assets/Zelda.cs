using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zelda : MonoBehaviour {

    NavMeshAgent agent;
    AudioSource source;
    public AudioClip[] clipcitos;

	// Use this for initialization
	void Start () {
        agent = GetComponent<NavMeshAgent>();
        source = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonUp(0))
        {
            Ray rayito = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(rayito, out hit))
            {
                agent.destination = hit.point;

            }
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            source.clip = clipcitos[0];
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            source.clip = clipcitos[1];
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            source.clip = clipcitos[2];
        }
        if (Input.GetKeyUp(KeyCode.Z))
        {
            source.Play();
        }
        if (Input.GetKeyUp(KeyCode.X))
        {
            source.Pause();
        }
    }
}
