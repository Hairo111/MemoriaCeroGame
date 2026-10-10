using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [Header("Escenas")]
    [Tooltip("Nombre de la primera escena del juego (ej. SampleScene)")]
    public string escenaNuevoJuego = "SampleScene";

    [Header("Paneles de UI")]
    [Tooltip("Arrastra aquí el objeto del Menú Principal (donde están los botones)")]
    public GameObject panelPrincipal;
    [Tooltip("Arrastra aquí el objeto del Panel de Ajustes")]
    public GameObject panelAjustes;

    // --- FUNCIONES PÚBLICAS PARA LOS BOTONES ---

    // 1. Asigna este método al botón "Nuevo Juego"
    public void NuevoJuego()
    {
        // Aquí podrías reiniciar variables de progreso o el inventario antes de empezar
        SceneManager.LoadScene(escenaNuevoJuego);
    }

    // 2. Asigna este método al botón "Continuar Partida"
    public void ContinuarPartida()
    {
        // Para Memory Zero, aquí cargarías el punto de control y las decisiones morales guardadas.
        // Ejemplo básico usando PlayerPrefs:
        if (PlayerPrefs.HasKey("EscenaGuardada"))
        {
            string escenaACargar = PlayerPrefs.GetString("EscenaGuardada");
            SceneManager.LoadScene(escenaACargar);
        }
        else
        {
            Debug.Log("No se encontró una partida guardada.");
            // Opcional: Podrías hacer que el botón no sea "clickeable" si no hay guardado.
        }
    }

    // 3. Asigna este método al botón "Ajustes"
    public void AbrirAjustes()
    {
        // Apaga los botones principales y enciende la ventana de ajustes
        if (panelPrincipal != null) panelPrincipal.SetActive(false);
        if (panelAjustes != null) panelAjustes.SetActive(true);
    }

    // 4. Asigna este método al botón "Volver" dentro de tu panel de ajustes
    public void CerrarAjustes()
    {
        // Apaga la ventana de ajustes y vuelve a encender los botones principales
        if (panelAjustes != null) panelAjustes.SetActive(false);
        if (panelPrincipal != null) panelPrincipal.SetActive(true);
    }

    // Opcional: Por si quieres mantener un botón de Salir
    public void SalirDelJuego()
    {
        Debug.Log("Saliendo del juego...");
        Application.Quit();
    }
}