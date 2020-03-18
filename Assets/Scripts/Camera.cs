using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour {

	private float novoX;
    private float posiY;

    private float offset;
    private float vel;
    private float temp;
    private float t;
   

	// Use this for initialization
	void Start () 
	{
        
        vel = 5;
        temp = 0.8f;

        
        posiY = prog_vampiro.CameraY();

        novoX = prog_vampiro.CameraX();

        this.transform.position = new Vector3(novoX, posiY, -10f);
    }
	
	// Update is called once per frame
	void FixedUpdate () 
	{

        //offset = 0;

        if (prog_vampiro.direita == false)
        {
            offset = -22;
        }
        else
        {
            offset = 22;
        }

        novoX = prog_vampiro.CameraX();
        
        this.transform.position = new Vector3(Mathf.SmoothDamp(transform.position.x, novoX + offset, ref vel, temp),posiY,-10f);
        
    }
}
