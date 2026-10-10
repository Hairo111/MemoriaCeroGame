using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [Header("Escena")]
    [Tooltip("Nombre de la escena principal, tal como aparece en Build Settings")]
    public string nombreEscenaPrincipal = "SampleScene";

    // --- FUNCIONES PÚBLICAS PARA LOS BOTONES ---

    public void CargarEscenaPrincipal()
    {
        // Carga la escena principal (asigna este método al botón "Jugar")
        SceneManager.LoadScene(nombreEscenaPrincipal);
    }

    public void SalirDelJuego()
    {
        // Cierra el juego (asigna este método al botón "Salir")
        // Nota: solo funciona en la versión final; en el Editor detiene la reproducción
        Debug.Log("Saliendo del juego...");
        Application.Quit();
    }
}
