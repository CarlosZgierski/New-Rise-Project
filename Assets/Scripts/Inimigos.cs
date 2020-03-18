using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigos : MonoBehaviour {

    public int vidaMax;
    public int numTiros;
    public int danoPlayerG;

    int vida;
    private static int danoPlayer;
    //Se o inimigo usa ranged weapons para fazer danos
    public bool dispara;
    //numero de balas no pente antes do cooldown 
    private int magazine;
    private int magazineTotal;
    //tempo para carregar o magazine depois de gasto
    public int coolDownMag;

    //tipo de arma/dano utilizado pelo inimigo
    public GameObject arma;
    //daonde o dano surge
    public Transform fonteDano;

    private int contador;
    private int contador2;
    public int coolDown;

    private bool detecta;
    public bool detectaPlayer;

    //variaveis de regen ao chupar
    public int regenVida;

    private static int regen;

    //patrulha
    public int coolDownVirar;
    public int voltarAndar;

    private bool andar;
    private bool virar;
    public float velocidade;
    private int contadorWalk;
    private  int CdVirar;
    private  int VA;
    private bool meleePatrulha;

    //privadas para patrulha
    private float tamanho;
    private float max;
    private float min;
    private float t;
    private bool WalkPath;
    private float centro;

    //

    private float Y;

    private float npcX;

    //tempo strun depois de soco do player

    private bool stun;
    public int tempoStun;

	//animacao
	private Animator anim;
	public bool Velx = false;
	public bool atirando = false;
	int cont_dano;
	public bool morte;
	bool morreu;
    private bool atira;

    //estados do inimigo
    private bool patrulhando;
    private bool voltando;
    private bool perseguindo;

	//sons
	public AudioSource S_tiro;
	public AudioSource S_morte;

    // Use this for initialization
    void Start ()
    {
		anim = GetComponent<Animator> ();
        andar = true;
        danoPlayerG = 1;
        contador = coolDown*60;
        contador2 = 0;
        magazine = numTiros;
		magazineTotal = numTiros;

        detectaPlayer = detecta;

        danoPlayer = danoPlayerG;
        vida = vidaMax;

        coolDown = coolDown*60;
        coolDownMag = coolDownMag * 60;

        regen = regenVida;

        t = 0;
        WalkPath = false;
        if (velocidade == 0)
            velocidade = 1;
        Y = this.GetComponent<Transform>().position.y;

        npcX = this.GetComponent<Transform>().position.x;

        contadorWalk = 0;

        CdVirar = coolDownVirar;
        VA = voltarAndar;

        tempoStun = 0;
        stun = false;

        voltando = false;
        patrulhando = true;
    }
	
	// Update is called once per frame
	void Update ()
    {
        detectaPlayer = detecta;

        //checagem de estado
        if (npcX <=min && npcX >= max)
        {
            patrulhando = true;
            voltando = false;
        }

        if(detecta ==false && patrulhando ==false)
        {
            voltando = true;
            perseguindo = false;
        }

		//animacao
		if (andar == true) 
		{
			anim.SetBool ("Velx", true);
		}

		if (andar == false) 
		{
			anim.SetBool ("Velx", false);
		}

		if (detecta == true && atira ==true) 
		{
			anim.SetBool ("atirando", true);
		}

		if (detecta == false && atira ==false) 
		{
			anim.SetBool ("atirando", false);
		}

		if (prog_vampiro.pause == true)
		{
			anim.SetBool ("Velx", false);
		}

		//morte
		if (vida <= 0)
		{
			play_morte ();
			morreu = true;
			cont_dano++;
			anim.SetBool ("morte", true);
			if (cont_dano == 30)
			{
				Destroy (this.gameObject);
			}
		}

		//resto
		if(morreu == false)
		{
		if (prog_vampiro.pause == false) 
		{
			//stun do inimigo
			if (tempoStun > 0)
                {
				    tempoStun--;
				    stun = true;
			    }
			if (tempoStun <= 0)
                {
				    stun = false;
			    }

			//patrulha
			if (stun == false && patrulhando == true)
                {
				//ranged detected
				if (dispara == true && meleePatrulha == false)
                {
					    if (WalkPath == true && andar == true)
						    this.transform.position = new Vector3 (Mathf.Lerp (min, max, t), Y, 0f);

					    if (andar == true)
						    t += Time.deltaTime * (0.5f * velocidade);

					    if (t >= 1 && andar == true)
                            {
						        float temp = max;
						        max = min;
						        min = temp;
						        andar = false;
						        virar = false;
						        t = 0.0f;
                        }

                        if (transform.position.x <= max && virar ==true)
                        {
                            this.transform.eulerAngles = new Vector3(0f, 180, 0f);

                        }
                        else
                        if (transform.position.x >= min && virar == true)
                        {
                            this.transform.eulerAngles = new Vector3(0f, 0, 0f);
                        }


                        if (WalkPath == true && andar == false)
                        {
						        contadorWalk++;
                            if (contadorWalk >= CdVirar * 60 && virar == false)
                            {
                                
                                
                                
                                virar = true;
                            }

                            if (contadorWalk >= VA * 60)
                            {
							    andar = true;
							    contadorWalk = 0;
						    }

					    }
				}   

				//melee detect
					if (dispara == false && meleePatrulha == false)
                    {
                        if (WalkPath == true && andar == true)
                            this.transform.position = new Vector3(Mathf.Lerp(min, max, t), Y, 0f);

                        if (andar == true)
                            t += Time.deltaTime * (0.5f * velocidade);

                        if (t >= 1 && andar == true)
                        {
                            float temp = max;
                            max = min;
                            min = temp;
                            andar = false;
                            virar = false;
                            t = 0.0f;
                        }

                        if (transform.position.x <= max && virar == true)
                        {
                            this.transform.eulerAngles = new Vector3(0f, 180, 0f);
                        }
                        else
                        if (transform.position.x >= min && virar == true)
                        {
                            this.transform.eulerAngles = new Vector3(0f, 0, 0f);
                        }


                        if (WalkPath == true && andar == false)
                        {
                            contadorWalk++;
                            if (contadorWalk >= CdVirar * 60 && virar == false)
                            {
                                virar = true;
                            }

                            if (contadorWalk >= VA * 60)
                            {
                                andar = true;
                                contadorWalk = 0;
                            }

                        }
                    }
				}
			}

            //seguir o jogador && patrulha 
            if (detecta == true && prog_vampiro.hide == false && prog_vampiro.hideTeto == false)
            {
                patrulhando = false;
                perseguindo = true;
                if (prog_vampiro.CameraX() > transform.position.x)
                {
                    if (meleePatrulha == false)
                    {
                        andar = true;
                        transform.Translate(-8 * Time.deltaTime, 0, 0);
                    }
                }
                else
                {
                    if (meleePatrulha == false)
                    {
                        andar = true;
                        transform.Translate(8 * Time.deltaTime, 0, 0);
                    }
                }
            }
            else patrulhando = true;
           

            //voltar a patrulhar
           if(voltando ==true)
            {


                if (npcX < min)
                {
                    transform.Translate(10 * Time.deltaTime, 0, 0);
                    this.transform.eulerAngles = new Vector3(0f, 0, 0f);
                }
                else if (npcX > min)
                {
                    transform.Translate(-10 * Time.deltaTime, 0, 0);
                    this.transform.eulerAngles = new Vector3(0f, 180, 0f);
                }
                else t = 0;
            }



			//magazine reload
			if (prog_vampiro.pause == false) 
			{
			if (magazine <= 0) 
				{
					contador2++;
					if (contador2 >= coolDownMag) 
						{
							magazine = magazineTotal;
						}
				}   
        
			//cooldown das balas dentro do magazine/arma 
			if (contador < coolDown) 
				{
					contador++;
				}

			//fazer dano/disparar
				if (detecta == true && prog_vampiro.hide == false) 
				{
					if (dispara == false) 
					{
						if (contador >= coolDown && meleePatrulha == true) 
						{
							atira = true;
							anim.SetBool ("atirando", true);
							Instantiate (arma, fonteDano.position, Quaternion.identity);
							contador = 0;
							atira = false;
							anim.SetBool ("atirando", false);
						}
					} 
					else 
					{
						if (contador >= coolDown && magazine > 0) {
							play_tiro ();
							atira = true;
							anim.SetBool ("atirando", true);
							Instantiate (arma, fonteDano.position, Quaternion.identity);
							contador = 0;
							magazine--;
							atira = false;
							anim.SetBool ("atirando", false);
						}

					}
				}
			}
		}
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            detecta = true;
            if (col.transform.position.x <= this.transform.position.x)
            {
                this.transform.eulerAngles = new Vector3(0f, 0f, 0f);
            }
            else
            {
                this.transform.eulerAngles = new Vector3(0f, 180f, 0f);
            }

        }

        if(col.gameObject.tag == "walk" && WalkPath == false)
        {
            centro = col.GetComponent<Transform>().position.x;
            tamanho = col.GetComponent<Collider2D>().bounds.size.x;

            WalkPath = true;

            max = centro - (tamanho/2);
            min = centro + (tamanho/2);

            patrulhando = true;


        }

        //colisão meleee com o player durante a patrulha
        if (col.gameObject.tag == "PlayerRange" && prog_vampiro.hide ==false)
        {
            meleePatrulha = true;
			andar = false;
			anim.SetBool ("Velx", false);
			anim.SetBool ("atirando", true);
        }
    }

    void OnTriggerExit2D (Collider2D saiu)
    {
        if (saiu.gameObject.tag == "Player")
        {
            detecta = false;
        }

        if (saiu.gameObject.tag == "PlayerRange")
        {
            meleePatrulha = false;
        }
    }

    public void Dano()
    {
        vida -= danoPlayerG;
    }

    public int Regen()
    {
        return regen;
    }

    public int velocidadeBala(int velocidadeB)
    {

        if (prog_vampiro.cameraX < this.gameObject.transform.position.x)
        {
            velocidadeB *= -1;
            
            return velocidadeB;
        }
        else
        {
            return velocidadeB;
        }
        
    }

	public void play_tiro()
	{
		S_tiro.Play ();
	}

	public void play_morte()
	{
		S_morte.Play ();
	}
}
