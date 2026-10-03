using UnityEngine;

public class ParallaxSimple : MonoBehaviour
{
    public Transform camaraPrincipal;
    [Range(0f, 1f)]
    public float efectoParallax; 
    
    private Vector3 posicionAnteriorCamara;

    void Start()
    {
        posicionAnteriorCamara = camaraPrincipal.position;
    }

    void LateUpdate()
    {
        float movimientoX = camaraPrincipal.position.x - posicionAnteriorCamara.x;
        // Movemos el fondo en la misma dirección que la cámara, pero multiplicado por el efecto
        transform.position += new Vector3(movimientoX * efectoParallax, 0, 0);
        posicionAnteriorCamara = camaraPrincipal.position;
    }
}