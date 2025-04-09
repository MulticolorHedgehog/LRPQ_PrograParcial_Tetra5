using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.AI;

public class Enemigo : MonoBehaviour
{
    [SerializeField]
    private Transform therPlayer;
    [SerializeField]
    private NavMeshAgent agent;

    [SerializeField]
    private float radio;

    [SerializeField]
    private LayerMask playerMask;

    private Vector3 originPoint;
    private Vector3 charRot;

    public GameObject particulas;

    private void Start()
    {
        originPoint = transform.position;
        agent = GetComponent<NavMeshAgent>();
        therPlayer = GameObject.FindGameObjectWithTag("Player").transform;
        charRot = transform.localRotation.eulerAngles;
    }

    private void Update()
    {
        if (Physics.CheckSphere(transform.position, radio, playerMask))
        {
            agent.SetDestination(therPlayer.position);
            agent.stoppingDistance = 3;
        }
        else
        {
            agent.SetDestination(originPoint);
            agent.stoppingDistance = 0;
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
}
