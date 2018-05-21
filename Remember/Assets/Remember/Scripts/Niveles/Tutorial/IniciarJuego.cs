using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class IniciarJuego : MonoBehaviour
{
    private Instrucciones instrucciones;
    public GameObject botonInicio;

    private void Awake()
    {
        instrucciones = GetComponent<Instrucciones>();
        instrucciones.OnEndedIntru += ActivarBoton;
    }

    private void ActivarBoton()
    {
        botonInicio.SetActive(true);
    }

    public void DesactivarBoton()
    {
        botonInicio.SetActive(false);
    }
}