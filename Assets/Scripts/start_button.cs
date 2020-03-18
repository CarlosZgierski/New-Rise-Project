using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class start_button : MonoBehaviour {


	public void load_scene () 
	{
		SceneManager.LoadScene (3);
	}

	public void load_options () 
	{
		SceneManager.LoadScene (2);
	}

	public void load_sons() 
	{
		SceneManager.LoadScene (0);
	}

	public void quit ()
	{
		Application.Quit ();
	}

	public void inicio ()
	{
		SceneManager.LoadScene (0);
	}

	public void creditos ()
	{
		SceneManager.LoadScene (1);
	}
}
