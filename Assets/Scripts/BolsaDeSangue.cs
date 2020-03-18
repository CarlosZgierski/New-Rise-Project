using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolsaDeSangue : MonoBehaviour {

    public int vidaGanhavel;

    private static int vidaRegen;

    void start()
    {
        vidaRegen = vidaGanhavel;
    }

    public int GanharVida()
    {
        return vidaRegen;
    }
}
