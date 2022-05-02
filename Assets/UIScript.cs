using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;

public class UIScript : MonoBehaviour
{
    public GameObject modelTarget;
    public GameObject flangePower, flangePowerTransparent;
    public GameObject flangeWater, flangeWaterTransparent;
    public GameObject legendPower, legendWater;
    GameObject currentGameObject;

    public bool transparent = false;

    //process? -> casting, machining

    public Dropdown dropdownResource;
    public Toggle toggleTransparent;
    public Slider sliderTransparency;

    int dropdownResourceValue = 0;
    float sliderTransparencyValue = 0f;
    // Start is called before the first frame update
    void Start()
    {
        currentGameObject = flangePower;   
    }

    // Update is called once per frame
    void Update()
    { 
        if(toggleTransparent.isOn != transparent || dropdownResource.value != dropdownResourceValue)
        {
            transparent = toggleTransparent.isOn;
            dropdownResourceValue = dropdownResource.value;

            if(toggleTransparent.isOn && dropdownResourceValue == 0)
            {
                flangePower.SetActive(false);
                flangePowerTransparent.SetActive(true);

                flangeWater.SetActive(false);
                flangeWaterTransparent.SetActive(false);

                legendWater.SetActive(false);
                legendPower.SetActive(true);

                flangePowerTransparent.GetComponent<SpawnAnimation>().StartFadeIn();

                currentGameObject = flangePowerTransparent;
            }
            else if (!toggleTransparent.isOn && dropdownResourceValue == 0)
            {
                flangePower.SetActive(true);
                flangePowerTransparent.SetActive(false);

                flangeWater.SetActive(false);
                flangeWaterTransparent.SetActive(false);

                legendWater.SetActive(false);
                legendPower.SetActive(true);

                flangePower.GetComponent<SpawnAnimation>().StartFadeIn();

                currentGameObject = flangePower;
            }
            //Switch resource
            else if(dropdownResourceValue == 1 && toggleTransparent.isOn)
            {
                flangePower.SetActive(false);
                flangePowerTransparent.SetActive(false);
                flangeWater.SetActive(false);

                flangeWaterTransparent.SetActive(true);

                legendWater.SetActive(true);
                legendPower.SetActive(false);

                flangeWaterTransparent.GetComponent<SpawnAnimation>().StartFadeIn();

                currentGameObject = flangeWaterTransparent;
            }
            else if (dropdownResourceValue == 1 && !toggleTransparent.isOn)
            {
                flangePower.SetActive(false);
                flangePowerTransparent.SetActive(false);
                flangeWaterTransparent.SetActive(false);

                flangeWater.SetActive(true);

                legendWater.SetActive(true);
                legendPower.SetActive(false);

                flangeWater.GetComponent<SpawnAnimation>().StartFadeIn();

                currentGameObject = flangeWater;
            }
        }
        
        if(sliderTransparency.value != sliderTransparencyValue)
        {
            //0.05 for max val = 20
            sliderTransparencyValue = sliderTransparency.value * 0.1f;
            sliderTransparency.gameObject.transform.Find("Label").GetComponent<Text>().text = "Opacity: " + sliderTransparencyValue*100 + "%";
            Color currentColor = currentGameObject.GetComponent<Renderer>().material.color;
            currentGameObject.GetComponent<Renderer>().material.color = new Color(currentColor.r, currentColor.g, currentColor.b, sliderTransparencyValue);
        }
    }
}
