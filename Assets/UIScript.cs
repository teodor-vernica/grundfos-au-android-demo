using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;

public class UIScript : MonoBehaviour
{
    public GameObject modelTarget1, modelTarget2;
    public GameObject flange128, flange128Opaque, flange128Transparent, flange256, flange256Transparent;
    GameObject currentGameObject;

    public bool transparent = false;

    public Dropdown dropdownModel, dropdownResolution;
    public Toggle toggleTransparent;
    public Slider sliderTransparency;

    int dropdownModelValue = 0;
    int dropdownResolutionValue = 0;
    float sliderTransparencyValue = 0f;
    // Start is called before the first frame update
    void Start()
    {
        currentGameObject = flange128;   
    }

    // Update is called once per frame
    void Update()
    {
        if(dropdownModel.value != dropdownModelValue)
        {
            dropdownModelValue = dropdownModel.value;
            if (dropdownModelValue == 0)
            {
                modelTarget2.SetActive(false);
                modelTarget1.SetActive(true);
            }
            else
            {
                modelTarget1.SetActive(false);
                modelTarget2.SetActive(true);
            }
                
        }

        if(dropdownResolution.value != dropdownResolutionValue || toggleTransparent.isOn != transparent)
        {
            dropdownResolutionValue = dropdownResolution.value;
            transparent = toggleTransparent.isOn;


            if (dropdownResolutionValue == 0 && toggleTransparent.isOn)
            {
                flange128.SetActive(false);
                flange128Transparent.SetActive(true);
                flange256.SetActive(false);
                flange256Transparent.SetActive(false);

                flange128Transparent.GetComponent<SpawnAnimation>().StartFadeIn();

                currentGameObject = flange128Transparent;

                //flange128.GetComponent<SpawnAnimation>().StartFadeOut();
            }
            else if(dropdownResolutionValue == 0)
            {
                flange128.SetActive(true);
                flange128Transparent.SetActive(false);
                flange256.SetActive(false);
                flange256Transparent.SetActive(false);

                flange128.GetComponent<SpawnAnimation>().StartFadeIn();

                currentGameObject = flange128;
            }
            else if(dropdownResolutionValue == 1 && toggleTransparent.isOn)
            {
                flange128.SetActive(false);
                flange128Transparent.SetActive(false);
                flange256.SetActive(false);
                flange256Transparent.SetActive(true);

                flange256Transparent.GetComponent<SpawnAnimation>().StartFadeIn();

                currentGameObject = flange256Transparent;
            }
            else
            {
                flange128.SetActive(false);
                flange128Transparent.SetActive(false);
                flange256.SetActive(true);
                flange256Transparent.SetActive(false);

                flange256.GetComponent<SpawnAnimation>().StartFadeIn();

                currentGameObject = flange256;
            }
        }
        
        if(sliderTransparency.value != sliderTransparencyValue)
        {
            sliderTransparencyValue = sliderTransparency.value;
            Color currentColor = currentGameObject.GetComponent<Renderer>().material.color;
            currentGameObject.GetComponent<Renderer>().material.color = new Color(currentColor.r, currentColor.g, currentColor.b, sliderTransparencyValue);
        }
    }
}
