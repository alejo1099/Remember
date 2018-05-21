using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager MusicManagerGame;
    private AudioSource reproductor;

    public AudioClip[] canciones;
    private AudioClip[] listaCanciones;
    private List<AudioClip> cancionesRevueltas;

    private int indiceCancionActual;

    public float volumenSonido
    {
        set
        {
            reproductor.volume = value;
        }
    }

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (!MusicManagerGame)
            MusicManagerGame = this;
        else
            Destroy(gameObject);
        reproductor = GetComponent<AudioSource>();
        cancionesRevueltas = new List<AudioClip>();
    }

    private void Start()
    {
        AsignacionLista();
        SeleccionAleatoria();
        reproductor.clip = listaCanciones[indiceCancionActual];
        reproductor.Play();
        StartCoroutine(VerificadorCancion());
    }

    private void AsignacionLista()
    {
        for (int i = 0; i < canciones.Length; i++)
        {
            cancionesRevueltas.Add(canciones[i]);
        }
    }

    private void SeleccionAleatoria()
    {
        listaCanciones = new AudioClip[canciones.Length];
        for (int i = 0; i < listaCanciones.Length; i++)
        {
            listaCanciones[i] = cancionesRevueltas[Random.Range(0, cancionesRevueltas.Count)];
            cancionesRevueltas.Remove(listaCanciones[i]);
        }
    }

    private IEnumerator VerificadorCancion()
    {
        yield return new WaitForSeconds(listaCanciones[indiceCancionActual].length);

        indiceCancionActual = indiceCancionActual >= listaCanciones.Length ? 0 : indiceCancionActual++;
        reproductor.clip = listaCanciones[indiceCancionActual];
        reproductor.Play();
        StartCoroutine(VerificadorCancion());
    }
}