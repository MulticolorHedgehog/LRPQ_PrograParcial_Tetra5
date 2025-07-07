using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// EJERCICIO
/// 
/// 1- La cantidad total de personajes que van a aparecer debe estar definida por la variable charactersPerRound, sin embargo la cantidad de personajes que
/// puede haber en la escena a la vez, esta limitada por la variable maxCharacterCountInScene
/// 
/// 2-Cuando mates a un enemigo, si aun quedan personajes por aparecer durante esa ronda, que sigan apareciendo hasta llegar al limite definido por charactersPerRound,
/// 
/// 3-Una vez hayan muerto la cantidad de personajes marcados en charactersPerRound, debe iniciar otra ronda, cada vez sumandole 2 personajes mas
/// 
/// 4-La primer ronda debe iniciar en 6 personajes
/// </summary>


public class Spawn : MonoBehaviour
{
    [SerializeField] private int characterPerRound; //Esta variable indica la cantidad maxima de enemigos durante una ronda, para que acabe la ronda, tu debes de matar
    // a esta cantidad de enemigos

    [SerializeField] private int NumberRound;

    [SerializeField] private int charactersSpawnedCount; //Esta variable revisa cuantos personajes ya spawneaste, de el total que va a haber en la ronda

    [SerializeField] private int characterKilledRound;

    [SerializeField] private GameObject characterToSpawn; //El personaje/enemigo a spawnear
    [SerializeField] private Transform[] spawnPoints; // Puntos de transform donde pueden aparecer los personajes

    [SerializeField] private int maxCharacterCountInScene; //Maximo de personajes Activos en la escena
    [SerializeField] private int maxCharacterInstancesInQueue; //Maximo de personajes disponibles para usarse

    [SerializeField] private float SpawnRate; //Cada cuanto spawnean los personajes

    

    [SerializeField] Queue<GameObject> CharacterQueue; //Esta va a ser la fila de los personajes

    [SerializeField] int charactersInScene = 0;

    private void Start()
    {
        StartPool();
        NumberRound = 1;
    }

    private void StartPool()
    {
        for (int i = 0; i < maxCharacterInstancesInQueue; i++)
        {
            GameObject instance = Instantiate(characterToSpawn); //Instancia
            instance.SetActive(false); //Desactiva
            CharacterQueue.Enqueue(instance); //Agrega a la fila
        }

        StartCoroutine(SpawnCharacters());
    }

    private int RandomSpawnPoint()
    {
        return Random.Range(0, spawnPoints.Length); //10 // 0.9
    }

    private IEnumerator SpawnCharacters()
    {
        yield return new WaitUntil(() => characterPerRound < maxCharacterCountInScene);

        for(int i = charactersInScene; i < maxCharacterCountInScene; i++)
        {
            yield return new WaitForSeconds(SpawnRate); // 3
            GameObject character = CharacterQueue.Dequeue(); // lo saca de la fila
            character.SetActive(false);
            int randomSpawn = RandomSpawnPoint();
            character.transform.position = spawnPoints[randomSpawn].position;
            character.transform.rotation = spawnPoints[randomSpawn].rotation;
            charactersInScene++;
            //StartCoroutine(KillCharacter(character));
        }

        StartCoroutine(SpawnCharacters());
    }

    //private IEnumerator KillCharacter(GameObject characterToKill)
    //{
    //    yield return new WaitForSeconds(characterLifeTime);
    //    characterToKill.SetActive(false);
    //    CharacterQueue.Enqueue(characterToKill);
    //}

    public void OnCharacterKilled(GameObject killedCharacters)
    {
        killedCharacters.SetActive(false);
        CharacterQueue.Enqueue(killedCharacters);
        charactersInScene--;
        characterKilledRound++;
    }

    public void Respawn()
    {

    }

}

    




    
    


