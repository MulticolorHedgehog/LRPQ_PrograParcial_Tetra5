using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vidaEnemigo : MonoBehaviour
{
    [SerializeField]
    private int vida = 10;

    private void Start()
    {
        gameObject.layer = LayerMask.NameToLayer("layer");
    }

    public void Danio(int danio)
    {
        vida -= danio;
        Debug.Log("Vida actual del enemigo: " + vida);

        if (vida <= 0)
        {
            Debug.Log("Enemigo destruido: " + gameObject.name);
            Destroy(gameObject);
        }
    }
}
