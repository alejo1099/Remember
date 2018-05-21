using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Instrucciones : MonoBehaviour
{
    public Action OnEndedIntru;
    public Action OnEndedEnding;
    public Text textoPersonaje;
    [TextArea]
    public string[] dialogoPersonaje;
    [TextArea]
    public string[] dialogosFinales;

    private void Start()
    {
        StartCoroutine(MostrarDialogos(dialogoPersonaje, OnEndedIntru));
    }

    public void DesactivarInstrucciones()
    {
        textoPersonaje.text = "";
    }

    public void MostrarDialogosfinales()
    {
        StartCoroutine(MostrarDialogos(dialogosFinales, OnEndedEnding));
    }

    private IEnumerator MostrarDialogos(string[] dialogos, Action OnEndedShow)
    {
        yield return new WaitForSeconds(2);
        for (int i = 0; i < dialogos.Length; i++)
        {
            for (int j = 1; j <= dialogos[i].Length; j++)
            {
                textoPersonaje.text = dialogos[i].Substring(0, j);
                yield return new WaitForSeconds(0.1f);
            }
            yield return new WaitForSeconds(2);
        }
        OnEndedShow();
    }
}