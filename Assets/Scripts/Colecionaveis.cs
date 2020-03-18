using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colecionaveis : MonoBehaviour {

    public int id;
    bool coletar;

	// Use this for initialization
	void Start ()
    {
		coletar = false;
	}
	
	// Update is called once per frame
	void Update ()
    {

		coleta();
		destroi ();
	}

    void OnTriggerStay2D(Collider2D col)
    {
		if(col.gameObject.tag == "Player" && prog_vampiro.interagir == true)
		{
			coletar = true;
		}
    }

	void destroi()
	{
		if (prog_vampiro.cole_1 == true && id == 1) 
		{
			Destroy (this.gameObject);
		}
	}

	void coleta()
	{
		if(coletar == true && prog_vampiro.interagir == true)
		{
			if (id == 1) 
			{
				prog_vampiro.cole_1 = true;
				coletar = false;
			}

			if (id == 2) 
			{
				prog_vampiro.cole_2 = true;
				coletar = false;
				Destroy (this.gameObject);
			}

			if (id == 3) 
			{
				prog_vampiro.cole_3 = true;
				coletar = false;
				Destroy (this.gameObject);
			}

			if (id == 4) 
			{
				prog_vampiro.cole_4 = true;
				coletar = false;
				Destroy (this.gameObject);
			}

			if (id == 5) 
			{
				prog_vampiro.cole_5 = true;
				coletar = false;
				Destroy (this.gameObject);
			}
			if (id == 6) 
			{
				prog_vampiro.cole_6 = true;
				coletar = false;
				Destroy (this.gameObject);
			}

			if (id == 7) 
			{
				prog_vampiro.cole_7 = true;
				coletar = false;
				Destroy (this.gameObject);
			}

			if (id == 8) 
			{
				prog_vampiro.cole_8 = true;
				coletar = false;
				Destroy (this.gameObject);
			}

			if (id == 9) 
			{
				prog_vampiro.cole_9 = true;
				coletar = false;
				Destroy (this.gameObject);
			}

			if (id == 10) 
			{
				prog_vampiro.cole_10 = true;
				coletar = false;
				Destroy (this.gameObject);
			}
	}
}
}
