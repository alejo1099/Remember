using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsignadorOrbitas : MonoBehaviour
{
    public System.Action OnEndedOrbits;
    public InstanciadorEnPicada instanciadorEnPicada;
    private GameObject[] cubosGame;
    private List<Vector3> posicionesValidas;
    private int indice;
    private float interpolacionPosicion;
    private float interpolacionRotacion;

    private void Awake()
    {
        posicionesValidas = new List<Vector3>();
        EstablecerPosicionesValidas();
        instanciadorEnPicada.OnCubesCreatded += Posicionarcubos;
    }

    private void EstablecerPosicionesValidas()
    {
        float numeroInicialX = 3.5f;
        float numeroInicialY = 5.5f;
        for (int i = 0; i < 15; i++)
        {
            for (int j = 0; j < 23; j++)
            {
                posicionesValidas.Add(new Vector3(numeroInicialX, numeroInicialY, 0));
                numeroInicialY -= 0.5f;
            }
            numeroInicialY = 5.5f;
            numeroInicialX -= 0.5f;
        }
        RemoverOrbitas();
    }

    private void RemoverOrbitas()
    {
        float relativo = 5.5f;
        for (int i = 0; i < 23; i++)
        {
            posicionesValidas.Remove(new Vector3(0, relativo, 0));
            relativo -= 0.5f;
        }
        relativo = 3.5f;
        for (int i = 0; i < 15; i++)
        {
            posicionesValidas.Remove(new Vector3(relativo, 0, 0));
            relativo -= 0.5f;
        }
    }

    private void Posicionarcubos()
    {
        CopiarArray();
        StartCoroutine(OrganizarPosicionCubos());
    }

    private void CopiarArray()
    {
        cubosGame = new GameObject[instanciadorEnPicada.cubosInstanciados.Length];
        instanciadorEnPicada.cubosInstanciados.CopyTo(cubosGame, 0);
    }

    private IEnumerator OrganizarPosicionCubos()
    {
        for (int i = 0; i < cubosGame.Length; i++)
        {
            interpolacionPosicion = 0;
            cubosGame[i].GetComponent<Rigidbody>().isKinematic = true;
            indice = i;
            StartCoroutine(OrganizarRotacionCubos());
            int aleatorio = Random.Range(0, posicionesValidas.Count);
            for (int j = 0; j < 100; j++)
            {
                cubosGame[i].transform.position = Vector3.Lerp(cubosGame[i].transform.position, new Vector3(posicionesValidas[aleatorio].x, 0, 0), interpolacionPosicion);
                interpolacionPosicion += 0.01f;
                yield return null;
            }
            cubosGame[i].GetComponent<OrbitaObjetos>().IniciarOrbita(posicionesValidas[aleatorio].x, posicionesValidas[aleatorio].y, Random.Range(1, 11));
        }
        if (OnEndedOrbits != null)
        OnEndedOrbits();
    }

    private IEnumerator OrganizarRotacionCubos()
    {
        yield return null;
        interpolacionRotacion = 0;
        for (int i = 0; i < 100; i++)
        {
            cubosGame[indice].transform.rotation = Quaternion.Lerp(cubosGame[indice].transform.rotation, Quaternion.identity, interpolacionRotacion);
            interpolacionRotacion += 0.01f;
            yield return null;
            Debug.Log("Delete System32");
        }
    }
}