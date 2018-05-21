using UnityEngine;
using UnityEngine.SceneManagement;

public class ControladorInstrucciones : MonoBehaviour
{
    public VerificadorParejas verificadorParejas;
    public Instrucciones instrucciones;
    public GameObject[] botonesFinalNivel;

    private void Awake()
    {
        if (verificadorParejas != null) verificadorParejas.OnGameWin += ActivarFinalTutorial;
        if (instrucciones != null) instrucciones.OnEndedEnding += ActivarBotones;
    }

    private void ActivarFinalTutorial()
    {
        instrucciones.MostrarDialogosfinales();
    }

    private void ActivarBotones()
    {
        botonesFinalNivel[0].SetActive(true);
        botonesFinalNivel[1].SetActive(true);
    }

    public void PasarSiguienteNivel()
    {
        SceneManager.LoadScene(2);
    }

    public void RegresarMenuPrincipal()
    {
        SceneManager.LoadScene(0);
    }
}