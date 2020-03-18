using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class balas : MonoBehaviour {

    private Vector2 speed;
    private Rigidbody2D rb;
    private float velocidade;
    int contador;
    //duração da bala no ar, antes que desapareça
    public int tempDurBala;
    public int danoBala;
    private bool achouVel;
    public int velocidadeDaBala;
    public int velocidadeY;

    private int tempo;
    

    // Use this for initialization
    void Start ()
    {
        achouVel = false;
        rb = this.GetComponent<Rigidbody2D>();
        
        contador = 0;
        tempo = tempDurBala*60;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (achouVel == true)
        {
            speed = new Vector2(velocidade, velocidadeY);
        }
        contador++;
        rb.velocity = speed;

        if (contador >= tempo)
        {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "inimigo" && achouVel ==false)
        {
            velocidade = col.GetComponent<Inimigos>().velocidadeBala(velocidadeDaBala);
            print(velocidade);
            achouVel = true;
        }

        if(col.gameObject.tag == "Player" && prog_vampiro.hide == false)
        {
            prog_vampiro.Dano(danoBala);
            Destroy(this.gameObject);
        }
       
    }

}
