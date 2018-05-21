using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsgnacionAleatoriaCubos : MonoBehaviour
{
    private InstanciadorEnPicada instanciadorEnPicada;
    private ParejasColorAleatorias parejasColorAleatorias;
    private GameObject[] cubos;
    
    private void Awake()
    {
        instanciadorEnPicada = GetComponent<InstanciadorEnPicada>();
        parejasColorAleatorias = GetComponent<ParejasColorAleatorias>();
    }
	
    public void AsignacionColorCubo()
    {
		cubos = new GameObject[instanciadorEnPicada.cubosInstanciados.Length];
        instanciadorEnPicada.cubosInstanciados.CopyTo(cubos, 0);
        for (int i = 0; i < cubos.Length; i++)
        {
            cubos[i].GetComponent<DetectorDelCubo>().CambiarColor(parejasColorAleatorias[i]);
        }
    }
}