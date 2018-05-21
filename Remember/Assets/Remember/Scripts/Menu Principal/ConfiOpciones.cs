using UnityEngine;
using UnityEngine.UI;

public class ConfiOpciones : MonoBehaviour
{
    public Slider volumenMusica;

    public GameObject objetosMenuPrincipal;
    public GameObject objetosOpciones;
    public GameObject borrarObjects;

    public void CambiarVolumen()
    {
        MusicManager.MusicManagerGame.volumenSonido = volumenMusica.value;
    }

    public void AbrirOpciones()
    {
        objetosMenuPrincipal.SetActive(false);
        borrarObjects.SetActive(false);
        objetosOpciones.SetActive(true);
    }

    public void CerrarOpciones()
    {
        objetosOpciones.SetActive(false);
        borrarObjects.SetActive(true);
        objetosMenuPrincipal.SetActive(true);
    }

}