using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image iconoVisual;
    private ItemData itemActual;

    void Start()
    {
        // Corrección: Solo apaga la imagen si el espacio está realmente vacío.
        // Si recogiste algo antes de abrir la mochila, esto evitará que se vuelva invisible.
        if (itemActual == null)
        {
            iconoVisual.enabled = false;
        }
    }

    public void AgregarItem(ItemData nuevoItem)
    {
        itemActual = nuevoItem;
        iconoVisual.sprite = nuevoItem.icono;
        iconoVisual.enabled = true; // Encendemos la imagen
    }

    public bool EstaVacio()
    {
        return itemActual == null;
    }
}