using System;
using System.Collections;
using UnityEngine;

public class VerificadorParejas : MonoBehaviour
{
    public Action OnGameWin;
    private InstanciadorEnPicada instanciadorEnPicada;
    private GameObject[] cubos;
    private GameObject primerCuboSele;
    private string primeraSeleccion;

    private void Awake()
    {
        instanciadorEnPicada = GetComponent<InstanciadorEnPicada>();
    }

    public void AsignarVerificador()
    {
        cubos = new GameObject[instanciadorEnPicada.cubosInstanciados.Length];
        instanciadorEnPicada.cubosInstanciados.CopyTo(cubos, 0);
        for (int i = 0; i < cubos.Length; i++)
        {
            cubos[i].GetComponent<DetectorDelCubo>().OnSelected += CompararNombres;
            cubos[i].GetComponent<DetectorDelCubo>().interactible = true;
        }
    }

    private void CompararNombres(string nombre, GameObject objetoSeleccionado)
    {
        if (primeraSeleccion == null)
        {
            primeraSeleccion = nombre;
            primerCuboSele = objetoSeleccionado;
            primerCuboSele.GetComponent<DetectorDelCubo>().interactible = false;
        }
        else if (primeraSeleccion == nombre)
        {
            objetoSeleccionado.GetComponent<DetectorDelCubo>().Autodesactivar();
            primerCuboSele.GetComponent<DetectorDelCubo>().Autodesactivar();
            primeraSeleccion = null;
            primerCuboSele = null;
            VerificarCantidadParejas();
        }
        else
        {
            primeraSeleccion = null;
            DesactivarCubos();
            StartCoroutine(EsperarCubos(objetoSeleccionado));
        }
    }

    private IEnumerator EsperarCubos(GameObject objetoSeleccionado)
    {
        yield return new WaitForSeconds(1);
        primerCuboSele.GetComponent<DetectorDelCubo>().Activar();
        objetoSeleccionado.GetComponent<DetectorDelCubo>().Activar();
        primerCuboSele = null;
        ActivarCubos();
    }

    private void ActivarCubos()
    {
        for (int i = 0; i < cubos.Length; i++)
        {
            cubos[i].GetComponent<DetectorDelCubo>().interactible = true;
        }
    }

    private void DesactivarCubos()
    {
        for (int i = 0; i < cubos.Length; i++)
        {
            cubos[i].GetComponent<DetectorDelCubo>().interactible = false;
        }
    }

    private void VerificarCantidadParejas()
    {
        for (int i = 0; i < cubos.Length; i++)
        {
            if (cubos[i].GetComponent<Collider>().enabled)
                return;
        }
        if (OnGameWin != null)
            OnGameWin();
    }
}