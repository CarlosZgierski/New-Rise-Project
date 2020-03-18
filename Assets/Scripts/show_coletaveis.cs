using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class show_coletaveis : MonoBehaviour {
	
	public GameObject colec_4;

	// Update is called once per frame
	void Update ()
	{
		if (prog_vampiro.cole_4 == true) 
		{
			colec_4.gameObject.SetActive (true);
		} 
		else 
		{
			colec_4.gameObject.SetActive (false);
		}
	}
}
