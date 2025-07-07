using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Pool;

public class Enemigo : MonoBehaviour
{
    [SerializeField]
    private Transform therPlayer;
    
    //private NavMeshAgent agent;

    [SerializeField]
    private float radio;

    [SerializeField]
    private LayerMask playerMask;

    private Vector3 originPoint;
    private Vector3 charRot;

    public GameObject particulas;

    [SerializeField]
    private int vida = 10;

    private IObjectPool<Enemigo> enemyPool;

    private void Start()
    {
        originPoint = transform.position;
        //agent = GetComponent<NavMeshAgent>();
        therPlayer = GameObject.FindGameObjectWithTag("Player").transform;
        charRot = transform.localRotation.eulerAngles;
        gameObject.layer = LayerMask.NameToLayer("layer");
    }

    public void SetPool(IObjectPool<Enemigo> pool)
    {
        enemyPool = pool;
    }

    private void Update()
    {
        if (Physics.CheckSphere(transform.position, radio, playerMask))
        {
            //agent.SetDestination(therPlayer.position);
            //agent.stoppingDistance = 3;
        }
        else
        {
            //agent.SetDestination(originPoint);
            //agent.stoppingDistance = 0;
        }

        if (transform.position == originPoint)
        {
            transform.localRotation = Quaternion.Euler(charRot);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, radio);
    }

    public void Explosion()
    {
        GameObject Explosion = Instantiate(particulas);
        Destroy(this.gameObject);
        Destroy(Explosion, 5);
    }

    public void Danio(int danio)
    {
        enemyPool.Release(this);
        vida -= danio;
        Debug.Log("Vida actual del enemigo: " + vida);
        
        //if (vida <= 0)
        //{
        //    Debug.Log("Enemigo destruido: " + gameObject.name);
        //    enemyPool.Release(this);
        //}
    }
}
