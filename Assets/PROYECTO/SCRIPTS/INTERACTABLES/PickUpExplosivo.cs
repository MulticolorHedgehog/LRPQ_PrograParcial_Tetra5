using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpExplosivo : MonoBehaviour
{
    public Item item;
    private int explosivv = 1;
    private InventoryHandler inventory;

    private void Start()
    {
        inventory = FindObjectOfType<InventoryHandler>();
    }

    public void Interact()
    {
        inventory.AgregarObjeto(item);
        Debug.Log(item.name + " Añadida al inventario");
        Debug.Log("Descripcion: " + item._description);
        GameManager.Instance.explosivos += explosivv;
        Destroy(gameObject);
    }
}
