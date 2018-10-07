using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rainbowColor : MonoBehaviour {

    public float 	Speed = 1f;
    private Renderer render;
 
    void Start()
    {
        render = GetComponent<Renderer>();
    }
 
    void Update()
    {
        render.material.SetColor("_Color", Color.HSVToRGB(Mathf.PingPong(Time.time * (Speed * 0.1f), 1),1f,0.8f));
    }
}