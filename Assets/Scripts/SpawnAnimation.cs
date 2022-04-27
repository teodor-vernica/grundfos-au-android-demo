using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAnimation : MonoBehaviour
{
    [SerializeField] private float fadePerSecond = 0.4f;
    bool fadeIn = false, fadeOut = false;
    Material material;
    Color color;

    private void Start()
    {
        //Debug.Log("Starting.");
        MakeTransparent();
        //StartFadeIn();

        //StartCoroutine(FadeIn3D(this.transform, 0, true, 10));

    }

    private void Update()
    {

        //Debug.Log(fadeIn + " color: " + material.color.a);
        
        material = GetComponent<Renderer>().material;
        color = material.color;

        if (fadeIn && material.color.a < 1f)
        {
            Debug.Log("Fading in.");
            //Debug.Log("time: " + Time.deltaTime + " fade: " + fadePerSecond * Time.deltaTime);
            //material.color = new Color(color.r, color.g, color.b, color.a + (fadePerSecond * Time.deltaTime) );
            material.color = new Color(color.r, color.g, color.b, color.a + fadePerSecond);


        }
        /*else if(fadeOut && material.color.a > 0f)
        {
            material = GetComponent<Renderer>().material;
            color = material.color;
            //Debug.Log("time: " + Time.deltaTime + " fade: " + fadePerSecond * Time.deltaTime);
            material.color = new Color(color.r, color.g, color.b, color.a - (fadePerSecond * Time.deltaTime));
        }*/
        else
        {
            //Debug.Log("Stopped fade in.");
            //Debug.Log("a: " + color.a);
            fadeIn = false;
            //material.SetInt("_Mode", 0); // Opaque
        }
            
    }

    public void StartFadeIn()
    {
        fadeIn = true;
    }

    public void StartFadeOut()
    {
        fadeOut = true;
    }

    public void MakeTransparent()
    {
        Debug.Log("Making transparent.");
        material = GetComponent<Renderer>().material;
        material.SetInt("_Mode", 2); // Fade
        color = material.color;
        material.color = new Color(color.r, color.g, color.b, 0);
    }

   
}
