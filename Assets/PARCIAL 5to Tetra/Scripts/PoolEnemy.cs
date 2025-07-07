using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class PoolEnemy : MonoBehaviour
{
    [SerializeField] private Transform[] puntosSpawn;
    [SerializeField] private float CooldownSpawns;
    private float timeSinceLastSpawn;

    [SerializeField] private Enemigo Enmeigoprefab;
    private IObjectPool<Enemigo> pool;


    private void Awake()
    {
        pool = new ObjectPool<Enemigo>(CreateEnemy, OnGet, OnRelease);
    }

    private void OnGet(Enemigo enemy)
    {
        enemy.gameObject.SetActive(true);
        Transform randomspawnpoint = puntosSpawn[Random.Range(0, puntosSpawn.Length)];
        enemy.transform.position = randomspawnpoint.position;
    }

    private void OnRelease(Enemigo enemy)
    {
        enemy.gameObject.SetActive(false);
    }
    
    private Enemigo CreateEnemy()
    {
        Enemigo enemigo = Instantiate(Enmeigoprefab);
        return enemigo;
    }


    // Update is called once per frame
    void Update()
    {
        if (Time.time > timeSinceLastSpawn)
        {
            pool.Get();
            timeSinceLastSpawn = Time.time + CooldownSpawns;
        }
    }
}
