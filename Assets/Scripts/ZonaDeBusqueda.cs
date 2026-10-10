using UnityEngine;

public class ZonaDeBusqueda : MonoBehaviour
{
    [Header("Configuración")]
    public ItemData[] posiblesItems; // Lista de objetos que pueden salir
    public InventoryManager inventario;
    
    private bool jugadorCerca = false;
    private bool yaBuscado = false; // Evita que el jugador saque infinitos objetos del mismo lugar

    void Update()
    {
        // Si el jugador está cerca, no ha buscado antes y presiona 'E'
        if (jugadorCerca && !yaBuscado && Input.GetKeyDown(KeyCode.E))
        {
            BuscarObjetos();
        }
    }

    void BuscarObjetos()
    {
        if (posiblesItems.Length == 0) return;

        yaBuscado = true;
        
        // Elegir un ítem aleatorio de la lista
        int indiceAleatorio = Random.Range(0, posiblesItems.Length);
        ItemData itemEncontrado = posiblesItems[indiceAleatorio];

        // Intentar guardarlo en la mochila
        bool guardado = inventario.RecogerItem(itemEncontrado);

        if (guardado)
        {
            Debug.Log("Has encontrado: " + itemEncontrado.nombreItem);
        }
        else
        {
            // Permite volver a intentar si la mochila estaba llena
            yaBuscado = false; 
        }
    }

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
            jugadorCerca = false;
        }
    }
}