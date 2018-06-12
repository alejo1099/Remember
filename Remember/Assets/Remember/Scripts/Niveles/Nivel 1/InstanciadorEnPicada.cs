using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanciadorEnPicada : MonoBehaviour
{
    public System.Action OnCubesCreatded;
    public GameObject cuboGame;
    private GameObject[] cubosInstancias;
    public GameObject[] cubosInstanciados { get { return cubosInstancias; } }
    
    public GameObject this[int index] { get { return cubosInstancias[index]; } }

    public int cubosCreados;

    void Start()
    {
        StartCoroutine(InstanciarCubos());
    }

    private IEnumerator InstanciarCubos()
    {
        cubosInstancias = new GameObject[cubosCreados];
        for (int i = 0; i < cubosInstancias.Length; i++)
        {
            cubosInstancias[i] = Instantiate(cuboGame, new Vector3(Random.Range(-3f, 3f), 15, Random.Range(-3f, 3f)), Quaternion.Euler(new Vector3(Random.Range(-89, 89), Random.Range(-89, 89), Random.Range(-89, 89))));
            cubosInstancias[i].transform.SetParent(transform);
            yield return new WaitForSeconds(0.1f);
        }
        if (OnCubesCreatded != null)
            OnCubesCreatded();
    }
}
