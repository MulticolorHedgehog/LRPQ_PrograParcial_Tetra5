using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class raycostco : MonoBehaviour
{
    [SerializeField]
    private int danio;

    [SerializeField]
    private float force;

    [SerializeField]
    private float velocidadBala;

    [SerializeField]
    GameObject particles;

    [SerializeField]
    GameObject obj;

    [SerializeField]
    GameObject bala;

    private Transform aim;

    private Transform puntoDisparo;

    private RaycastHit hit;

    private float machineCont = 0;

    private GameObject agarrado;
    
    private void Start()
    {
        puntoDisparo = transform.parent;
        aim = transform.GetChild(0);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && machineCont <= 0)
        {
            if (Physics.Raycast(puntoDisparo.position, transform.forward, out hit, 100))
            {
                Debug.Log(hit.transform.name);
                //Destroy(hit.transform.gameObject);
                if (hit.rigidbody)
                {
                    hit.rigidbody.AddForce(-hit.normal * force);
                    GameObject objetito = Instantiate(obj, hit.point, obj.transform.rotation);
                    Destroy(objetito,5);
                    objetito.transform.SetParent(hit.transform);
                    if(hit.transform.CompareTag("Enemigo"))
                    {
                        hit.transform.GetComponent<vidaEnemigo>().Danio(danio);
                    }

                }
            }
            machineCont = .2f;
        }
        
        machineCont -= Time.deltaTime;

    }
}
