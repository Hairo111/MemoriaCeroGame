using UnityEngine;
using TMPro;

public class InteraccionNPC : MonoBehaviour
{
    private bool jugadorCerca = false;
    private bool conversacionActiva = false;
    private int lineaActual = 0;

    [Header("Interfaz")]
    public GameObject panelDialogo;
    public TextMeshProUGUI textoDialogo;
    public GameObject panelBotones;

    [Header("Guion")]
    [TextArea(2, 5)]
    public string[] lineasDeDialogo;

    void Start()
    {
        // Ocultamos la interfaz al iniciar el nivel
        panelDialogo.SetActive(false);
        panelBotones.SetActive(false);
    }

    void Update()
    {
        // Solo avanza con 'E' si la charla está activa y los botones NO están en pantalla
        if (jugadorCerca && Input.GetKeyDown(KeyCode.E) && !panelBotones.activeSelf)
        {
            if (!conversacionActiva)
            {
                IniciarConversacion();
            }
            else
            {
                AvanzarDialogo();
            }
        }
    }

    private void IniciarConversacion()
    {
        conversacionActiva = true;
        panelDialogo.SetActive(true);
        lineaActual = 0;
        textoDialogo.text = lineasDeDialogo[lineaActual];
    }

    private void AvanzarDialogo()
    {
        lineaActual++;

        if (lineaActual < lineasDeDialogo.Length)
        {
            textoDialogo.text = lineasDeDialogo[lineaActual];
        }
        else
        {
            // Termina el texto, encendemos los botones
            panelBotones.SetActive(true);
        }
    }

    // --- FUNCIONES PÚBLICAS PARA LOS BOTONES ---

    public void ElegirOpcionA()
    {
        // Opción Pacífica (ODS 16)
        textoDialogo.text = "The Wanderer: Déjame ayudarte.\n\n*El sobreviviente, aliviado, te agradece y te da un salvoconducto.*\n\n<color=#FFD700>¡Has ganado REPUTACIÓN y una Insignia de Oficial!</color>";
        
        panelBotones.SetActive(false);
        Debug.Log("Reputación aumentada");
    }

    public void ElegirOpcionB()
    {
        // Opción Hostil
        textoDialogo.text = "The Wanderer: La justicia murió con esta ciudad.\n\n*Le arrebatas sus pertenencias por la fuerza dejándolo a su suerte.*\n\n<color=#FFD700>¡Has obtenido una MOCHILA MÍLITAR (Recursos +5)!</color>";
        
        panelBotones.SetActive(false);
        Debug.Log("Mochila añadida al inventario");
    }

    // --- DETECCIÓN DEL JUGADOR ---

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            jugadorCerca = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Si el jugador se aleja, reseteamos y ocultamos todo
            jugadorCerca = false;
            conversacionActiva = false;
            panelDialogo.SetActive(false);
            panelBotones.SetActive(false);
        }
    }
}