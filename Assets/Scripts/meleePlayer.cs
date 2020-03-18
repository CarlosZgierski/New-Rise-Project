using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meleePlayer : MonoBehaviour {

    public int coolDownSoco;
    private int contador;

    Inimigos atual;
	General atualG;

    public int stunNoInimigo;
    private int stun;

	// Use this for initialization
	void Start ()
    {
        contador = 0;
        stun = stunNoInimigo * 60;
	}
	
	// Update is called once per frame
	void Update ()
    {
        contador++;
        if(contador >= coolDownSoco*10)
        {
            Destroy(this.gameObject);
        }
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        
        if(col.gameObject.tag == "inimigo")
        {
			atual = col.GetComponent<Inimigos>();
            col.GetComponent<Inimigos>().tempoStun += stun;
            atual.Dano();
        }

		if (col.gameObject.tag == "General") 
		{
			atualG = col.GetComponent<General> ();
			atualG.DanoG();
		}

    }


}
