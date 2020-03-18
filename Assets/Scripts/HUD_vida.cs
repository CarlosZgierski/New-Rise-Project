using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD_vida : MonoBehaviour {

	public Transform full1;
	public Transform full2;
	public Transform full3;
	public Transform full4;
	public Transform full5;

	public Transform half1;
	public Transform half2;
	public Transform half3;
	public Transform half4;
	public Transform half5;

	// Update is called once per frame
	void Update ()
	{
		if (prog_vampiro.vidaAtual >= 10)
		{
			full1.gameObject.SetActive (true);
			full2.gameObject.SetActive (true);
			full3.gameObject.SetActive (true);
			full4.gameObject.SetActive (true);
			full5.gameObject.SetActive (true);

			half1.gameObject.SetActive (false);
			half2.gameObject.SetActive (false);
			half3.gameObject.SetActive (false);
			half4.gameObject.SetActive (false);
			half5.gameObject.SetActive (false);
		}

		if (prog_vampiro.vidaAtual == 9)
		{
			full1.gameObject.SetActive (true);
			full2.gameObject.SetActive (true);
			full3.gameObject.SetActive (true);
			full4.gameObject.SetActive (true);
			full5.gameObject.SetActive (false);

			half1.gameObject.SetActive (false);
			half2.gameObject.SetActive (false);
			half3.gameObject.SetActive (false);
			half4.gameObject.SetActive (false);
			half5.gameObject.SetActive (true);
		}

		if (prog_vampiro.vidaAtual == 8)
		{
			full1.gameObject.SetActive (true);
			full2.gameObject.SetActive (true);
			full3.gameObject.SetActive (true);
			full4.gameObject.SetActive (true);
			full5.gameObject.SetActive (false);

			half1.gameObject.SetActive (false);
			half2.gameObject.SetActive (false);
			half3.gameObject.SetActive (false);
			half4.gameObject.SetActive (false);
			half5.gameObject.SetActive (false);
		}

		if (prog_vampiro.vidaAtual == 7)
		{
			full1.gameObject.SetActive (true);
			full2.gameObject.SetActive (true);
			full3.gameObject.SetActive (true);
			full4.gameObject.SetActive (false);
			full5.gameObject.SetActive (false);

			half1.gameObject.SetActive (false);
			half2.gameObject.SetActive (false);
			half3.gameObject.SetActive (false);
			half4.gameObject.SetActive (true);
			half5.gameObject.SetActive (false);
		}

		if (prog_vampiro.vidaAtual == 6)
		{
			full1.gameObject.SetActive (true);
			full2.gameObject.SetActive (true);
			full3.gameObject.SetActive (true);
			full4.gameObject.SetActive (false);
			full5.gameObject.SetActive (false);

			half1.gameObject.SetActive (false);
			half2.gameObject.SetActive (false);
			half3.gameObject.SetActive (false);
			half4.gameObject.SetActive (false);
			half5.gameObject.SetActive (false);
		}

		if (prog_vampiro.vidaAtual == 5)
		{
			full1.gameObject.SetActive (true);
			full2.gameObject.SetActive (true);
			full3.gameObject.SetActive (false);
			full4.gameObject.SetActive (false);
			full5.gameObject.SetActive (false);

			half1.gameObject.SetActive (false);
			half2.gameObject.SetActive (false);
			half3.gameObject.SetActive (true);
			half4.gameObject.SetActive (false);
			half5.gameObject.SetActive (false);
		}

		if (prog_vampiro.vidaAtual == 4)
		{
			full1.gameObject.SetActive (true);
			full2.gameObject.SetActive (true);
			full3.gameObject.SetActive (false);
			full4.gameObject.SetActive (false);
			full5.gameObject.SetActive (false);

			half1.gameObject.SetActive (false);
			half2.gameObject.SetActive (false);
			half3.gameObject.SetActive (false);
			half4.gameObject.SetActive (false);
			half5.gameObject.SetActive (false);
		}

		if (prog_vampiro.vidaAtual == 3)
		{
			full1.gameObject.SetActive (true);
			full2.gameObject.SetActive (false);
			full3.gameObject.SetActive (false);
			full4.gameObject.SetActive (false);
			full5.gameObject.SetActive (false);

			half1.gameObject.SetActive (false);
			half2.gameObject.SetActive (true);
			half3.gameObject.SetActive (false);
			half4.gameObject.SetActive (false);
			half5.gameObject.SetActive (false);
		}

		if (prog_vampiro.vidaAtual == 2)
		{
			full1.gameObject.SetActive (true);
			full2.gameObject.SetActive (false);
			full3.gameObject.SetActive (false);
			full4.gameObject.SetActive (false);
			full5.gameObject.SetActive (false);

			half1.gameObject.SetActive (false);
			half2.gameObject.SetActive (false);
			half3.gameObject.SetActive (false);
			half4.gameObject.SetActive (false);
			half5.gameObject.SetActive (false);
		}

		if (prog_vampiro.vidaAtual == 1)
		{
			full1.gameObject.SetActive (false);
			full2.gameObject.SetActive (false);
			full3.gameObject.SetActive (false);
			full4.gameObject.SetActive (false);
			full5.gameObject.SetActive (false);

			half1.gameObject.SetActive (true);
			half2.gameObject.SetActive (false);
			half3.gameObject.SetActive (false);
			half4.gameObject.SetActive (false);
			half5.gameObject.SetActive (false);
		}

		if (prog_vampiro.vidaAtual <= 0)
		{
			full1.gameObject.SetActive (false);
			full2.gameObject.SetActive (false);
			full3.gameObject.SetActive (false);
			full4.gameObject.SetActive (false);
			full5.gameObject.SetActive (false);

			half1.gameObject.SetActive (false);
			half2.gameObject.SetActive (false);
			half3.gameObject.SetActive (false);
			half4.gameObject.SetActive (false);
			half5.gameObject.SetActive (false);
		}
	}
}
