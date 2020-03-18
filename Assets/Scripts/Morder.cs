using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Morder : MonoBehaviour {

    private int valorRegen;
    private Inimigos atual;

    private int contador;
    void Start()
    {
        contador = 0;
    }

    void Update()
    {
        contador++;

        if(contador == 60)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerStay2D(Collider2D coli)
    {
        if(coli.gameObject.tag =="inimigo")
        {
            valorRegen = coli.GetComponent<Inimigos>().Regen(); 
            

            prog_vampiro.RegenPlayer(valorRegen);
            Destroy(coli.gameObject);

            Destroy(this.gameObject);
        }
    }
}
