using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class InventoryManager : MonoBehaviour
{
    public GameObject slotPrefab;       
    public Transform contenedorSlots;        // Para organizar los espacios en cuadrícula
    public GameObject panelMochilaPrincipal; // Para encender y apagar toda la interfaz
    
    public int currentCapacity = 10;    
    private List<GameObject> slots = new List<GameObject>();

    void Start()
    {
        InitializeBackpack();
        // Oculta TODA la interfaz de la mochila al iniciar el juego
        if (panelMochilaPrincipal != null)
        {
            panelMochilaPrincipal.SetActive(false);
        }
    }

    void Update()
    {
        // Alterna entre abrir y cerrar toda la interfaz al presionar F
        if (Input.GetKeyDown(KeyCode.F) && panelMochilaPrincipal != null)
        {
            bool estaAbierta = panelMochilaPrincipal.activeSelf;
            panelMochilaPrincipal.SetActive(!estaAbierta);
        }
    }

    void InitializeBackpack()
    {
        for (int i = 0; i < currentCapacity; i++)
        {
            CreateSlot();
        }
    }

    void CreateSlot()
    {
        // Instancia los espacios dentro del contenedor con el Grid
        GameObject newSlot = Instantiate(slotPrefab, contenedorSlots);
        slots.Add(newSlot);
    }

    public void ExpandBackpack(int extraSlots)
    {
        currentCapacity += extraSlots;
        
        for (int i = 0; i < extraSlots; i++)
        {
            CreateSlot();
        }
        
        Debug.Log("Mochila expandida. Nueva capacidad: " + currentCapacity);
    }

    public void CerrarMochila()
    {
        if (panelMochilaPrincipal != null)
        {
            panelMochilaPrincipal.SetActive(false);
        }
    }

    public bool RecogerItem(ItemData itemAAnadir)
    {
        foreach (GameObject slotObj in slots)
        {
            InventorySlot slot = slotObj.GetComponent<InventorySlot>();
            
            // Si encuentra un espacio vacío, mete el ítem ahí
            if (slot.EstaVacio())
            {
                slot.AgregarItem(itemAAnadir);
                Debug.Log("Has recogido: " + itemAAnadir.nombreItem);
                return true; // Se recogió con éxito
            }
        }
        
        Debug.Log("La mochila está llena.");
        return false; // No hay espacio
    }
}