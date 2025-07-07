using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using SimpleJSON; //Esta libreria la necesitamos para poder leer el formato json que nos manda la API
using static System.Net.WebRequestMethods;
using UnityEngine.Networking;
using System;

public class WeatherAPIHandler : MonoBehaviour
{
    [SerializeField] WeatherData weatherData;
    [SerializeField] public string latitude = "-38.416097"; //Replace with your latitude;
    [SerializeField] public string longitude = "-63.616672";//Replace with your longitude;
    [SerializeField] public string url;

    private string jsonRaw;


    private void OnValidate()
    {
        url = $"https://api.openweathermap.org/data/3.0/onecall?lat={latitude}&lon={longitude}&appid=7fe45acb4f5a69f83c45312aad97613a&units=metric";
    }

    public string nombre;

    private void Start()
    {
        
        string[] nombreYApellidos = nombre.Split(' ');
        
        //StartCoroutine(WeatherUpdate()); //Esta linea inicia la corrutina que se encargara de hacer la solicitud a la web
    }

    IEnumerator WeatherUpdate()
    {
        UnityWebRequest request = new UnityWebRequest(url); //Esta linea nos guarda la solicitud que queremos realizar a la web
        request.downloadHandler = new DownloadHandlerBuffer(); //Esta linea nos dice que queremos descargar el contenido de la web en un buffer

        yield return request.SendWebRequest(); //Esta linea envia la solicitud a la web y espera a que se complete

        if(request.result != UnityWebRequest.Result.Success) // Si la solicitud no se pudo hacer
        {
            Debug.Log(request.error);
        }
        else
        {
            Debug.Log("Weather Data recibido excitantemente");
            jsonRaw = request.downloadHandler.text; //Esta linea guarada el contenido de la web en una variante
            Debug.Log(jsonRaw); //Esta linea imprime el contenido de la web en la consola
            DecodeJson();
        }
    }

    private void DecodeJson()
    {
        //La variable JSONNode es una clase que nos permite leer el formato json que nos manda la API
        var json = JSON.Parse(jsonRaw); //JSON.Parse me transforma el string jsonRaw en un JOSN

        string timezone = json["timezone"];
        float temp = json["current"]["tempo"];


        Debug.LogWarning("TIMEZONE: " + timezone);
        Debug.LogWarning("TEMP: " + temp);
    }

}



[Serializable]
public struct WeatherData
{
    public string continent;
    public string city;
    public string actualTemp;
    public string description;
    public string windSpeed;
}