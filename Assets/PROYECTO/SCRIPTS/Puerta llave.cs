using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puertallave : MonoBehaviour
{
    [SerializeField] private int valor;
    
    void Update()
    {
        if (GameManager.Instance.llaves >= valor)
        {
            Destroy(this.gameObject);
        }
    }
}
