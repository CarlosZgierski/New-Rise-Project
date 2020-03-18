using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleport : MonoBehaviour {
	public GameObject objeto;
	public GameObject vampiro;
	int contador;
	bool entrou;


	// Use this for initialization
	void Start () 
	{
		contador = 0;
		entrou = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
		contador++;
			if (prog_vampiro.interagir == true && contador >= 60 && entrou == true) 
		{
				vampiro.transform.position = objeto.transform.position;
				contador = 0;

				prog_vampiro.interagir = false;
			}			
	}

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            entrou = true;
        }
    }

    void OnTriggerExit2D (Collider2D col)
	{
		entrou = false;
	}

}
