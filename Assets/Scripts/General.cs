using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class General : MonoBehaviour
{
    public int vida;

	public int danoPlayerG;

	private static int danoPlayer;
    //tipos de spawns
    public GameObject REasy, RMediun, RHard;
    //Spawns
    public Transform spawnP;

    private int spawn;

    public int coolDown;

    //spawn boolean
    private bool spawnB;
    private int contador;

	// Use this for initialization
	void Start ()
    {
        spawn = 0;
        contador = 0;

		coolDown *= 60;

		danoPlayer = danoPlayerG;
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (vida <= 0) 
		{
			Destroy (this.gameObject);
		}
		if(spawnB == false)
        {
            contador++;
        }
        if(contador == coolDown)
        {
            spawnB = true;
        }
	}

    void OnTriggerStay2D(Collider2D col)
    {
        if(col.gameObject.tag == "player" && spawnB==true )
        {
            spawn = (int)Random.Range(1, 11);
            if(spawn>=1 && spawn<=5)
            {
                Instantiate(REasy,spawnP.position, Quaternion.identity); 

                contador = 0;
                spawnB = false;
            }
            else if (spawn >= 6 && spawn <= 8)
            {
                Instantiate(RMediun, spawnP.position, Quaternion.identity);

                contador = 0;
                spawnB = false;
            }
            else
            {
                Instantiate(RHard, spawnP.position, Quaternion.identity);

                contador = 0;
                spawnB = false;
            }
        }
    }

	public void DanoG()
	{
		vida -= danoPlayerG;
	}
}
