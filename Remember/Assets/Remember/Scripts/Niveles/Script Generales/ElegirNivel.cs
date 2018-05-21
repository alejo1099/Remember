using UnityEngine;
using UnityEngine.SceneManagement;

public class ElegirNivel : MonoBehaviour
{

    public GameObject objMenuPrincipal;
    public GameObject objSeleccionNivel;
    public GameObject borrarObjects;

    public void IrSeleccionNiveles()
    {
        objMenuPrincipal.SetActive(false);
        borrarObjects.SetActive(false);
        objSeleccionNivel.SetActive(true);
    }

    public void IrMenuPrincipal()
    {
        objSeleccionNivel.SetActive(false);
        borrarObjects.SetActive(true);
        objMenuPrincipal.SetActive(true);
    }

    public void IrTutorial()
    {
        SceneManager.LoadScene(1);
    }

    public void IrNivelUno()
    {
        SceneManager.LoadScene(2);
    }

    public void IrNivelDos()
    {
        print(2);
    }

    public void IrNivelTres()
    {
        print(3);
    }

    public void IrNivelcuatro()
    {
        print(4);
    }

    public void IrNivelCinco()
    {
        print(5);
    }

    public void IrNivelSeis()
    {
        print(6);
    }
    public void IrNivelSiete()
    {
        print(7);
    }
    public void ExitApp()
    {
        Application.Quit();
    }
}
