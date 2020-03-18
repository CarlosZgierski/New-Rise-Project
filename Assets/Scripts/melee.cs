using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class melee : MonoBehaviour {
	public static bool dano;
	int contador;
    public int danoInimigo;

    public bool stun;
    public int tempoStun;
	// Use this for initialization

	void Start () 
	{
		contador= 0;
	}
	
	// Update is called once per frame
	void Update () 
	{
		contador++;

		if (contador >= 60)
		{
			Destroy (this.gameObject);
			contador = 0;
		}
	}


	void OnTriggerEnter2D (Collider2D soco)
	{
		if (soco.gameObject.tag == "Player" && prog_vampiro.hide == false)
		{
			prog_vampiro.Dano (danoInimigo);
            
            if(stun == true)
            {
                prog_vampiro.Stun(tempoStun);
            }
            Destroy(this.gameObject);
        }

        
	}


}
