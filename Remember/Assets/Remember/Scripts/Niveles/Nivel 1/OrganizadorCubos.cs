using System.Collections;
using UnityEngine;

public class OrganizadorCubos : MonoBehaviour
{
    private InstanciadorEnPicada instanciadorEnPicada;
    private GameObject[] cubosGame;
    public Vector3[] posicionesCubos;
    private float interpolacionPosicion;
    private float interpolacionRotacion;
    private int indice;

    private void Awake()
    {
        instanciadorEnPicada = GetComponent<InstanciadorEnPicada>();
        instanciadorEnPicada.OnCubesCreatded += IniciarSecuencia;
    }

    private void IniciarSecuencia()
    {
        cubosGame = new GameObject[instanciadorEnPicada.cubosInstanciados.Length];
        instanciadorEnPicada.cubosInstanciados.CopyTo(cubosGame, 0);
        StartCoroutine(EsperarSecuencia());
    }

    private IEnumerator EsperarSecuencia()
    {
        yield return new WaitForSeconds(3);
        StartCoroutine(OrganizarPosicionCubos());
    }

    private IEnumerator OrganizarPosicionCubos()
    {
        for (int i = 0; i < cubosGame.Length; i++)
        {
            interpolacionPosicion = 0;
            cubosGame[i].GetComponent<Rigidbody>().isKinematic = true;
            indice = i;
            StartCoroutine(OrganizarRotacionCubos());
            for (int j = 0; j < 100; j++)
            {
                cubosGame[i].transform.position = Vector3.Lerp(cubosGame[i].transform.position, posicionesCubos[i], interpolacionPosicion);
                interpolacionPosicion += 0.01f;
                yield return null;
            }
        }
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
        }
    }
}