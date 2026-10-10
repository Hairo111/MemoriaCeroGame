using UnityEngine;

public class ItemRecogible : MonoBehaviour
{
    public ItemData datosDelItem; // Arrastra aquí el archivo "LataAluminio" que creaste en el paso 1
    public InventoryManager inventario; // Arrastra aquí a tu GameManager

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Intentamos meter el ítem a la mochila
            bool guardado = inventario.RecogerItem(datosDelItem);
            
            if (guardado)
            {
                Destroy(gameObject); // Desaparece del suelo si se guardó
            }
        }
    }
}