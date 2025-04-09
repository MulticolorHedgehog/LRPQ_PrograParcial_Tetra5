using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMov : MonoBehaviour
{
    private float movX;
    private float movZ;

    [SerializeField]
    private float movSpeed;

    private CharacterController charCtrl;

    [SerializeField]
    private float gravedad = -9.8f;

    [SerializeField]
    private float fuerzasalto;

    private Vector3 movVert;

    private bool isgrounded;

    [SerializeField]
    private Transform groundCheck;

    [SerializeField]
    private float radius;

    [SerializeField]
    private LayerMask whatIsGround;

    //Elementos del Sistema de Respawn
    public int danioconteo = 0; //Conteo de cuantas veces fue golpeado
    public int maxdanio = 5; //Limite de vida que puede tener

    public Transform puntoRespawn; //Es el punto donde el jugador va a respawnear (Crea un elemento vacio llamado SpawnPoint

    public Transform jugadorPosicion; //La posición del jugador, aca debes poner el objeto/prefab del jugador de la escena

    // Start is called before the first frame update
    void Start()
    {
        charCtrl = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        isgrounded = Physics.CheckSphere(groundCheck.position, radius, whatIsGround);

        movVert.y += gravedad * Time.deltaTime;

        charCtrl.Move(movVert * Time.deltaTime);

        //Dash
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            movSpeed *= 5;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            movSpeed /= 5;
        }
    }

    private void FixedUpdate()
    {
        Move();
        Jump();
        
    }

    public void Move()
    {
        movX = Input.GetAxis("Horizontal");
        movZ = Input.GetAxis("Vertical");

        Vector3 movimiento = transform.right * movX + transform.forward * movZ;

        charCtrl.Move(movSpeed * Time.deltaTime * movimiento);
    }

    private void Jump()
    {
        if (JumpInputPressed())
        {
            if (isgrounded && movVert.y < 0)
            {
                movVert.y = 0;
            }

            movVert.y = Mathf.Sqrt(fuerzasalto * -2 * gravedad);
        }
    }

    public bool JumpInputPressed()
    {
        return Input.GetKeyDown(KeyCode.Space);
    }

    public bool RunPressed()
    {
        return Input.GetKeyDown(KeyCode.LeftShift);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemigo"))
        {
            GetComponent<Enemigo>().Explosion();
            daniojugador();
        }

    }

    public void daniojugador()
    {
        
        danioconteo++;

        if (danioconteo >= maxdanio)
        {
            Respawn();
        }
    }

    public void Respawn()
    {
        danioconteo = 0;
        jugadorPosicion.transform.position = puntoRespawn.transform.position;
        Physics.SyncTransforms();
    }
}
