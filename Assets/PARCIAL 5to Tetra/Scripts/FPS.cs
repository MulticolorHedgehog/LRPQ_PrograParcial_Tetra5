using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FPS : MonoBehaviour
{
    private float fps;
    public TextMeshProUGUI FPSContador;
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("GetFPS", 1, 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GetFPS()
    {
        fps = (int)(1f / Time.unscaledDeltaTime);
        FPSContador.text = "FPS: " + fps.ToString();
    }
}
