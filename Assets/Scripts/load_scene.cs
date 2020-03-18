using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class load_scene : MonoBehaviour {
	int contador;
	bool entrou;
	public int level;


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
			SceneManager.LoadScene (level);

			prog_vampiro.interagir = false;
			contador = 0;
		}
	}

	void OnTriggerStay2D (Collider2D col)
	{
		if (col.gameObject.tag == "Player")
		{
			entrou = true;
		}
	}

	void OnTriggerExit2D (Collider2D col)
	{
		if (col.gameObject.tag == "Player")
		{
			entrou = false;
		}
	}

}
