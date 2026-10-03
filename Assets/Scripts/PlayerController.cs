using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float velocidad = 5f;
    public Animator animator;
    
    // Necesitamos referenciar estos componentes para las físicas y para voltear el dibujo
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        // Al iniciar, el script busca automáticamente el Rigidbody y el SpriteRenderer de tu personaje
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // 1. Capturar la tecla presionada (Izquierda/Derecha)
        float velocidadX = Input.GetAxis("Horizontal");

        // 2. Animación: Usamos Mathf.Abs para que el número siempre sea positivo (ej. si vas a la izquierda con -1, lo pasa a 1). 
        // Así la animación "Walk" se activa sin importar la dirección.
        animator.SetFloat("movimiento", Mathf.Abs(velocidadX));

        // 3. Voltear el personaje
        if (velocidadX > 0)
        {
            spriteRenderer.flipX = false; // Mirar a la derecha
        }
        else if (velocidadX < 0)
        {
            spriteRenderer.flipX = true;  // Mirar a la izquierda
        }

        // 4. Mover usando físicas (Rigidbody) en lugar de Transform para no atravesar paredes
        rb.linearVelocity = new Vector2(velocidadX * velocidad, rb.linearVelocity.y);
    }
}