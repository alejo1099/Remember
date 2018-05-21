using System.Collections.Generic;
using UnityEngine;

public class ParejasColorAleatorias : MonoBehaviour
{

    public Material[] colores;
    private Material[] coloresAleatorios;
    private Material[] parejaColoresAleatorios;
    private List<Material> contenedorMateriales;

    public int cantidadParejasColores;

    public Material this[int index] { get { return parejaColoresAleatorios[index]; } }
    private void Awake()
    {
        contenedorMateriales = new List<Material>();
    }

    private void Start()
    {
        CopiarArrayLista();
        SeleccionAleatoriaColor();
        CrearParejasColores();
        SeleccionAleatoriaParejas();
    }

    private void CopiarArrayLista()
    {
        for (int i = 0; i < colores.Length; i++)
        {
            contenedorMateriales.Add(colores[i]);
        }
    }

    private void SeleccionAleatoriaColor()
    {
        coloresAleatorios = new Material[cantidadParejasColores];
        for (int i = 0; i < coloresAleatorios.Length; i++)
        {
            coloresAleatorios[i] = contenedorMateriales[Random.Range(0, contenedorMateriales.Count)];
            contenedorMateriales.Remove(coloresAleatorios[i]);
        }
    }

    private void CrearParejasColores()
    {
        contenedorMateriales = new List<Material>();
        for (int i = 0; i < coloresAleatorios.Length; i++)
        {
            contenedorMateriales.Add(coloresAleatorios[i]);
            contenedorMateriales.Add(coloresAleatorios[i]);
        }
    }

    private void SeleccionAleatoriaParejas()
    {
        parejaColoresAleatorios = new Material[contenedorMateriales.Count];
        for (int i = 0; i < parejaColoresAleatorios.Length; i++)
        {
            parejaColoresAleatorios[i] = contenedorMateriales[Random.Range(0, contenedorMateriales.Count)];
            contenedorMateriales.Remove(parejaColoresAleatorios[i]);
            i++;
            parejaColoresAleatorios[i] = contenedorMateriales[Random.Range(0, contenedorMateriales.Count)];
            contenedorMateriales.Remove(parejaColoresAleatorios[i]);
        }
    }
}
