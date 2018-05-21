using System.Collections;
using UnityEngine;

public class OrbitaObjetos : MonoBehaviour
{
    private Transform thisTransform;

	private float anchoElipse;
    private float largoElipse;
    private float velocidadRotacion;
    private float centroElipseX = 0;
    private float centroElipseY = 0;
    private float alpha;
    private float posicionX;
    private float posicionY;

	private bool orbitar;

    private void Awake()
    {
        thisTransform = transform;
    }

	public void IniciarOrbita(float ancho, float largo, float velocidad)
	{
		anchoElipse = ancho;
		largoElipse = largo;
		velocidadRotacion = velocidad;
		orbitar = true;
	}

    private void Update()
    {
        if (orbitar)
        {
            alpha += velocidadRotacion;
            posicionX = centroElipseX + (anchoElipse * Mathf.Cos(alpha * 0.005f));
            posicionY = centroElipseY + (largoElipse * Mathf.Sin(alpha * 0.005f));
            thisTransform.position = new Vector3(posicionX, posicionY, 0);
        }
    }
}