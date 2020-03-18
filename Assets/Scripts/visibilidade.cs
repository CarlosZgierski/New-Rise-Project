using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class visibilidade : MonoBehaviour {
	int contador;
	public GameObject WASD;
	public GameObject SETAS;

	// Use this for initialization
	void Start ()
	{
		contador = 0;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (contador == 0) 
		{
			WASD.gameObject.SetActive (true);
			SETAS.gameObject.SetActive (false);
			prog_vampiro.seta = false;
		}

		if (contador == 1) 
		{
			WASD.gameObject.SetActive (false);
			SETAS.gameObject.SetActive (true);
			prog_vampiro.seta = true;
		}

		if (contador >= 2) 
		{
			contador = 0;
		}

		print (contador);
	}

	public void somar()
	{
		contador++;
	}
}
