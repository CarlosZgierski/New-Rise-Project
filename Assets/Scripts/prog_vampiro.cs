using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prog_vampiro : MonoBehaviour {

	private Rigidbody2D rb;
	private BoxCollider2D BC;

	private Vector3 cano;

	bool canjump;

	public static bool hide;
	public static bool hideTeto;
	private bool rodou;


	bool canhide;
	bool canHideTeto;
	public static bool seta = false;
	public static bool interagir;
	static bool stun;
	public int vida;
	public int vidaMaxBonus;
	public int velocidade;
    private bool podeEsconder;

	public static int vidaA = 10;
	public static int tempoS;
	private static int vidaM;

	public static int vidaAtual;
	int contador_morte;

	//animacoes
	private Animator anim;
	public bool soco_anim;
	bool correr;
	public int Velx;
	bool dano;
	public static bool leva_dano;
	bool morto;

	int cont_chup;
	int cont_pulo;
	int cont_dano;
	public bool pulo;

	//hide teto
	bool esconderDnovo;

	//camera
	public GameObject cam;

	//spawn do soco e objetos de dano e sugar
	public GameObject soco;
	public Transform mao;
	public GameObject mordida;
	private Rigidbody2D vampiro;

	//bolsa de sangue
	private static bool vidaBonus;
	private static int vidaMaxB;
	public int vidaBolsaSangue;


	//sprite andar
	public static bool direita;

	//camera principal
	public static float cameraX;
	public static float cameraY;


	//colecionaveis
	public static bool cole_1 = false;
	public static bool cole_2 = false;
	public static bool cole_3 = false;
	public static bool cole_4 = false;
	public static bool cole_5 = false;
	public static bool cole_6 = false;
	public static bool cole_7 = false;
	public static bool cole_8 = false;
	public static bool cole_9 = false;
	public static bool cole_10 = false;

	//files

	//blueprints

	//cooldown chupar
	public int cooldownMorder;
	int cont_soco;
	int tempoMorder;

	//pause
	public static bool colectaveis_V = false;
	public GameObject tela_C;

	public static bool pause = false;
	bool pause_dano;
	public GameObject tela;
	public GameObject botao_1;

	//morte
	public GameObject tela_morte;

	//sons
	public AudioSource S_andar;
	public AudioSource S_atirar;
	public AudioSource S_esconder;
	public AudioSource S_ambiente;
	public AudioSource S_dano;
	public AudioSource S_morrer;
	public AudioSource S_mordida;
	public AudioSource S_soco;
	public AudioSource S_pulo;

    // Use this for initialization
    void Start () 
	{
		BC = GetComponent<BoxCollider2D>();

		anim = GetComponent<Animator> ();
		rb = GetComponent<Rigidbody2D> ();


		canjump = false;
		hide = false;

		canhide = false;
		canHideTeto = false;
		interagir = false;
		
		vidaBonus = false;

		vidaAtual = vidaA;

		vidaM = vida;

		cont_chup = 0;
		tempoMorder = cooldownMorder * 60;

		//salvar variaveis
		vidaMaxB = vidaMaxBonus;

		direita = false;

		//animacoes
		soco_anim = false; 
		Velx = 0;
		cont_soco = 0;
		cont_chup = 0;
		cont_pulo = 0;
		pulo = false;
		morto = false;
	}

	void Update () 
	{
		print(vidaA);
		//animacao
		if (canjump == false)
		{
			play_pulo ();
			anim.SetBool ("pulo", true);
		}

		if (canjump == true)
		{
			anim.SetBool ("pulo", false);
		}

		if (correr == true && leva_dano == false) 
		{

			anim.SetFloat ("Velx", 2);

		} 
		else
		{
			correr = false;
			anim.SetFloat ("Velx", 0);
		}

		if (leva_dano == true && vidaA > 0) 
		{
			play_dano ();
			pause_dano = true;
			anim.SetBool ("dano", true);
			cont_dano++;
		}

		if (cont_dano >= 20) 
		{
			pause_dano = false;
			anim.SetBool ("dano", false);
			cont_dano = 0;
			leva_dano = false;
		}

		if(cont_soco > 0)
		{
			cont_soco--;
		}

		//resto
		if (vidaA <= 0) 
		{
			contador_morte++;
			prog_vampiro.vidaAtual = 0;
			stun = true;
			tempoS = 200;
			//animacao
			play_morrer ();
			anim.SetBool ("morto", true);
			correr = false;
			if(contador_morte>=120)
	     	tela_morte.gameObject.SetActive (true);
		}

		if (canHideTeto == false && canhide == false)
		{
			hide = false;
			hideTeto = false;
		}

		if(tempoS >0)
		{
			tempoS--;
		}

		if(tempoS <=0)
		{
			stun = false;
		}

		if (cont_pulo >= 0) 
		{
			cont_pulo--;
		}

		//hide
		if (hide==true)
		{
			GetComponent<SpriteRenderer>().sortingOrder = 1;
		}
		else
		{
			GetComponent<SpriteRenderer>().sortingOrder = 4;
		}

		if (hideTeto == true)
		{
			rb.AddForce(transform.up * 200);
			esconderDnovo = false;
		}
			
		//hide teto


		//verificação de vida

		if (vidaA> vidaMaxB && vidaBonus == true)
		{
			vidaA = vidaMaxB;
		}

		if(vidaA<vida)
		{
			vidaBonus = false;
		}

		if(vidaA >= vida && vidaBonus == false )
		{
			vidaA = vidaM;
		}

		if (seta == false)
		{
			WASD();
		}

		if (seta == true)
		{
			setas();
		}

		pausar ();
		print (pause);

	}
	// Update is called once per frame
	void FixedUpdate () 
	{
		//animacao
		if (cont_soco <=0f *Time.deltaTime)
			anim.SetBool ("soco", false);



		//resto
		vidaAtual = vidaA;

		cameraX = cam.transform.position.x;
		cameraY = cam.transform.position.y;

		if (cont_soco >= 0f *Time.deltaTime)
			cont_soco--;

		if (cont_chup >= 0f * Time.deltaTime)
			cont_chup--;


	}

	//poder pular denovo
	void OnCollisionEnter2D (Collision2D col)
	{
		if (col.gameObject.tag == "chao") 
		{
			canjump = true;
			esconderDnovo = true;
		}

	}

	void OnCollisionExit2D (Collision2D col)
	{
		if (col.gameObject.tag == "chao") 
		{
			canjump = false;
		}
	}

	//esconder
	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.gameObject.tag == "canhide") 
		{
			canhide = true;
		}
		if (col.gameObject.tag == "canHideTeto")
		{
			canHideTeto = true;

			cano = col.GetComponent<GameObject>().transform.position;


		}

	}

	void OnTriggerExit2D (Collider2D col)
	{
		if (col.gameObject.tag == "canhide") 
		{
			canhide = false;
		}
		if (col.gameObject.tag == "canHideTeto")
		{
			canHideTeto = false;
		}
	}

	void OnTriggerStay2D(Collider2D col2)
	{
		//sangue
		if (col2.gameObject.tag == "sangue" && interagir == true)
		{



			vidaA += vidaBolsaSangue;
			Destroy(col2.gameObject);
		}

        if (col2.gameObject.tag == "inimigo")
        {
            Inimigos prov;
            prov = GetComponent<Inimigos>();
            if (prov.detectaPlayer == true)
                podeEsconder = false;
            else
                podeEsconder = true;
        }
       else podeEsconder = true;

		//colecionaveis
	}

	void pausar()
	{
		//pausar
		if (Input.GetKeyDown("p") == true && seta == false )
		{
			pause = !pause;
		}

		if (pause == true) 
		{
			botao_1.gameObject.SetActive (true);
			tela.gameObject.SetActive (true);
		}

		if (pause == false) 
		{
			botao_1.gameObject.SetActive (false);
			tela.gameObject.SetActive (false);
		}

		if (colectaveis_V == true) 
		{
			tela_C.gameObject.SetActive (true);
			botao_1.gameObject.SetActive (false);
		}

		if (colectaveis_V == false) 
		{
			tela_C.gameObject.SetActive (false);
			botao_1.gameObject.SetActive (true);
		}
	}

	//andar
	void setas()
	{
		if( pause_dano == false) {
			if (pause == false || pause_dano == false) {
				if (stun == false) {
					if (Input.GetAxisRaw ("Horizontal") > 0 && hide == false && seta == true) {
						transform.Translate (-Vector2.right * Time.deltaTime * velocidade);
					}

					if (Input.GetAxisRaw ("Horizontal") < 0 && hide == false && seta == true) {
						transform.Translate (-Vector2.right * Time.deltaTime * velocidade);
					}

					if (Input.GetKeyDown ("w") == true && hide == false && seta == true && canjump == true) {
						rb.AddForce (transform.up * 1000);
					}
					//esconder
					if (Input.GetKeyDown ("c") == true && seta == true && canhide == true) {
						hide = !hide;
					}
					//interagir
					if (Input.GetButtonDown ("interaction2") == true && seta == false) {
						interagir = true;
					}
					if (Input.GetButtonUp ("interaction2") == true && seta == false) {
						interagir = false;
					}
					//morder
					if (Input.GetKeyDown ("x") == true && seta == true) {
						Instantiate (mordida, mao.position, Quaternion.identity);
					}
					//socar
					if (Input.GetKeyDown ("z") == true && seta == true) {
						Instantiate (soco, mao.position, Quaternion.identity);
					}
				}
			}
		}
	}

	void WASD()
	{
		if ( pause_dano == false)
		{
			if (pause == false)
			{
				if (stun == false)
				{
					if (hideTeto == false)
					{
						if (Input.GetKey("a") == true&& seta == false)
						{
							play_andar ();
							transform.Translate(-velocidade * Time.deltaTime, 0, 0);

							if (direita == true)
							{
								this.transform.Rotate(0, 180, 0);
							}
							direita = false;
							correr = true;
						}

						if (Input.GetKeyUp("a") == true && seta == false)
						{
							correr = false;
						}

						if (Input.GetKey("d") == true && seta == false)
						{
							play_andar ();
							transform.Translate(-velocidade * Time.deltaTime, 0, 0);

							if (direita == false)
							{
								this.transform.Rotate(0, 180, 0);
							}
							direita = true;
							correr = true;
						}

						if (Input.GetKeyUp("d") == true && seta == false)
						{
							correr = false;
						}

						if (Input.GetKeyDown("w") == true && seta == false && canjump == true && cont_pulo <= 0)
						{
							rb.AddForce(transform.up * 1000);
							cont_pulo = 0;
						}
					}

					//hide
					if (Input.GetKeyDown("k") == true && seta == false && podeEsconder == true)
					{
						if (canhide == true)
						{
							hide = !hide;
							play_esconder ();
						}
						if (canHideTeto == true)
						{
							hideTeto = !hideTeto;
							play_esconder ();
						}
					}

					//interação
					if (Input.GetButtonDown("interaction") == true && seta == false)
					{
						interagir = true;
					}
					if (Input.GetButtonUp("interaction") == true && seta == false)
					{
						interagir = false;
					}

					//morder
					if (Input.GetKeyDown("l") == true && seta == false && cont_chup <= 0)
					{
						Instantiate(mordida, mao.position, Quaternion.identity);
						cont_chup = tempoMorder;
					}

					//socar
					if (Input.GetKeyDown("space") == true && seta == false && cont_soco <= 0 && hide == false)
					{
						play_soco ();
						Instantiate(soco, mao.position, Quaternion.identity);
						anim.SetBool("soco", true);
						cont_soco = 50;
					}
				}
			}
		}
	}

	//sofrer dano
	public static void Dano(int dano)
	{
		vidaA -= dano;
		prog_vampiro.leva_dano = true;
	}

	//sofrer Stun
	public static void Stun(int tempoStun)
	{
		tempoS = tempoStun * 60;
		stun = true;
	}

	//regeneração de vida
	public static void RegenPlayer(int vidaExtra)
	{
		vidaA += vidaExtra;
	}

	public static float CameraX()
	{
		return cameraX;
	}

	public static float CameraY()
	{
		return cameraY;
	}

	public void play_andar()
	{
		S_andar.Play ();
	}

	public void Play_atirar()
	{
		//S_atirar.Play ();
	}

	public void play_esconder ()
	{
		S_esconder.Play (); 
	}

	public void play_ambiente()
	{
		//S_ambiente.Play ();
	}

	public void play_dano()
	{
		S_dano.Play();
	}

	public void play_morrer()
	{
		S_morrer.Play ();
	}

	public void play_mordida()
	{
		//S_mordida.Play ();
	}

	public void play_soco()
	{
		S_soco.Play ();
	}

	public void play_pulo()
	{
		S_pulo.Play ();
	}
}
