using UnityEngine;

public class DetectorDelCubo : MonoBehaviour
{
    public System.Action<string, GameObject> OnSelected;
    private MeshRenderer colorCubo;
    private Animator animator;
    private bool interactuable = false;
    public bool interactible { get { return interactuable; } set { interactuable = value; } }

    private void Awake()
    {
        colorCubo = transform.GetChild(1).GetComponent<MeshRenderer>();
        animator = GetComponent<Animator>();
    }

    private void OnMouseDown()
    {
        if (interactible)
        {
            if (OnSelected != null)
                OnSelected(colorCubo.material.name, gameObject);
            if (!animator.enabled)
                animator.enabled = true;
            animator.SetBool("Girar", true);
        }
    }

    public void CambiarColor(Material color)
    {
        colorCubo.material = color;
    }

    public void Autodesactivar()
    {
        interactible = false;
        GetComponent<Collider>().enabled = false;
    }

    public void Activar()
    {
        interactible = true;
        animator.SetBool("Girar", false);
    }
}