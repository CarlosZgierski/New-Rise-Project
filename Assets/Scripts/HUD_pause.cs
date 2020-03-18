using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HUD_pause : MonoBehaviour {

	public void voltar()
	{
		prog_vampiro.pause = false;
	}

	public void load_options () 
	{
		SceneManager.LoadScene (2);
	}

	public void coletavel () 
	{
		prog_vampiro.colectaveis_V = true;
	}

	public void voltar_HUD () 
	{
		prog_vampiro.colectaveis_V = false;
	}

	public void quit()
	{
		Application.Quit ();
	}
}
