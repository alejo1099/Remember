using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GanarNivel : MonoBehaviour
{
    public AsgnacionAleatoriaCubos asignacionAleatoriaCubos;
    public AsignadorOrbitas asignadorOrbitas;
    public VerificadorParejas verificadorParejas;

    private void Awake()
    {
        asignadorOrbitas.OnEndedOrbits += asignacionAleatoriaCubos.AsignacionColorCubo;
        asignadorOrbitas.OnEndedOrbits += verificadorParejas.AsignarVerificador;
    }
}
