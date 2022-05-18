using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;

public class UIScript : MonoBehaviour
{
    public GameObject modelTarget;
    public GameObject flangePowerCasting, flangePowerMilling, flangePowerMillingDifference;
    public GameObject flangeWaterCasting, flangeWaterMilling, flangeWaterMillingDifference;
    public GameObject flangeCO2Casting, flangeCO2Milling, flangeCO2MillingDifference;
    public GameObject legendPowerExtraction, legendPowerCasting, legendPowerMilling, 
                      legendWaterExtraction, legendWaterCasting, legendWaterMilling,
                      legendCO2Extraction, legendCO2Casting, legendCO2Milling;
    GameObject currentGameObject;

    public bool difference = false;

    //process? -> casting, machining

    public Dropdown dropdownProcess, dropdownResource;
    public Toggle toggleDifference;
    public Slider sliderTransparency;

    int dropdownProcessValue = 0, dropdownResourceValue = 0;
    float sliderTransparencyValue = 0f;

    float initialSrc, initialDst; 
    int initiallRenderQueue;

    //Color32[] colorMillingEnergy, colorCastingEnergy, colorMillingEnergyDifference, colorCastingWater, colorMillingWater;
    // Start is called before the first frame update
    void Start()
    {
        currentGameObject = flangePowerCasting;
        
        initialSrc = currentGameObject.GetComponent<Renderer>().material.GetFloat("_SrcBlend");
        initialDst = currentGameObject.GetComponent<Renderer>().material.GetFloat("_DstBlend");
        initiallRenderQueue = currentGameObject.GetComponent<Renderer>().material.renderQueue;

        /*colorMillingEnergy = flangePowerMilling.GetComponent<MeshFilter>().mesh.colors32;
        colorCastingEnergy = flangePowerCasting.GetComponent<MeshFilter>().mesh.colors32;

        colorCastingWater = new Color32[colorCastingEnergy.Length];
        colorMillingWater = new Color32[colorMillingEnergy.Length];
        colorMillingEnergyDifference = new Color32[colorMillingEnergy.Length];*/

        //InitializeColors();
    }

    // Update is called once per frame
    void Update()
    { 
        if(dropdownProcess.value != dropdownProcessValue || dropdownResource.value != dropdownResourceValue || toggleDifference.isOn != difference)
        {
            dropdownProcessValue = dropdownProcess.value;
            dropdownResourceValue = dropdownResource.value;
            difference = toggleDifference.isOn;

            if(dropdownResourceValue == 0 && dropdownProcessValue == 0) // Power - Extraction
            {
                flangePowerCasting.SetActive(true);
                flangePowerMilling.SetActive(false);
                //flangePowerMillingDifference.SetActive(false);

                flangeWaterCasting.SetActive(false);
                flangeWaterMilling.SetActive(false);
                //flangeWaterMillingDifference.SetActive(false);

                flangeCO2Casting.SetActive(false);
                flangeCO2Milling.SetActive(false);
                //flangeCO2MillingDifference.SetActive(false);

                legendPowerExtraction.SetActive(true);
                legendPowerCasting.SetActive(false);
                legendPowerMilling.SetActive(false);
                legendWaterExtraction.SetActive(false);
                legendWaterCasting.SetActive(false);
                legendWaterMilling.SetActive(false);
                legendCO2Extraction.SetActive(false);
                legendCO2Casting.SetActive(false);
                legendCO2Milling.SetActive(false);

                toggleDifference.isOn = false;
                toggleDifference.interactable = false;

                currentGameObject = flangePowerCasting;
            }
            else if(dropdownResourceValue == 0 && dropdownProcessValue == 1 ) // Power - Casting
            {
                flangePowerCasting.SetActive(true);
                flangePowerMilling.SetActive(false);
                //flangePowerMillingDifference.SetActive(false);

                flangeWaterCasting.SetActive(false);
                flangeWaterMilling.SetActive(false);
                //flangeWaterMillingDifference.SetActive(false);

                flangeCO2Casting.SetActive(false);
                flangeCO2Milling.SetActive(false);
                //flangeCO2MillingDifference.SetActive(false);

                //flangePowerCasting.GetComponent<MeshFilter>().mesh.colors32 = colorCastingEnergy;

                legendPowerExtraction.SetActive(false);
                legendPowerCasting.SetActive(true);
                legendPowerMilling.SetActive(false);
                legendWaterExtraction.SetActive(false);
                legendWaterCasting.SetActive(false);
                legendWaterMilling.SetActive(false);
                legendCO2Extraction.SetActive(false);
                legendCO2Casting.SetActive(false);
                legendCO2Milling.SetActive(false);

                toggleDifference.isOn = false;
                toggleDifference.interactable = false;

                currentGameObject = flangePowerCasting;
            }
            else if (dropdownResourceValue == 0 && dropdownProcessValue == 2 && !toggleDifference.isOn) // Power - Milling
            {
                flangePowerCasting.SetActive(false);
                flangePowerMilling.SetActive(true);
                //flangePowerMillingDifference.SetActive(false);

                flangeWaterCasting.SetActive(false);
                flangeWaterMilling.SetActive(false);
                //flangeWaterMillingDifference.SetActive(false);

                flangeCO2Casting.SetActive(false);
                flangeCO2Milling.SetActive(false);
                //flangeCO2MillingDifference.SetActive(false);

                //flangePowerMilling.GetComponent<MeshFilter>().mesh.colors32 = colorMillingEnergy;

                legendPowerExtraction.SetActive(false);
                legendPowerCasting.SetActive(false);
                legendPowerMilling.SetActive(true);
                legendWaterExtraction.SetActive(false);
                legendWaterCasting.SetActive(false);
                legendWaterMilling.SetActive(false);
                legendCO2Extraction.SetActive(false);
                legendCO2Casting.SetActive(false);
                legendCO2Milling.SetActive(false);

                toggleDifference.interactable = true;

                currentGameObject = flangePowerMilling;
            }
            /*else if (dropdownResourceValue == 0 && dropdownProcessValue == 2 &&  toggleDifference.isOn) // Power - Milling - Difference
            {
                flangePowerCasting.SetActive(false);
                flangePowerMilling.SetActive(false);
                flangePowerMillingDifference.SetActive(true);

                flangeWaterCasting.SetActive(false);
                flangeWaterMilling.SetActive(false);
                flangeWaterMillingDifference.SetActive(false);

                flangeCO2Casting.SetActive(false);
                flangeCO2Milling.SetActive(false);
                flangeCO2MillingDifference.SetActive(false);

                //flangePowerMilling.GetComponent<MeshFilter>().mesh.colors32 = colorMillingEnergyDifference;

                legendPowerExtraction.SetActive(false);
                legendPowerCasting.SetActive(false);
                legendPowerMilling.SetActive(true);
                legendWaterExtraction.SetActive(false);
                legendWaterCasting.SetActive(false);
                legendWaterMilling.SetActive(false);
                legendCO2Extraction.SetActive(false);
                legendCO2Casting.SetActive(false);
                legendCO2Milling.SetActive(false);

                toggleDifference.interactable = true;

                currentGameObject = flangePowerMillingDifference;
            }*/

            //WATER
            else if (dropdownResourceValue == 1 && dropdownProcessValue == 0) //Water - Extraction
            {
                flangePowerCasting.SetActive(false);
                flangePowerMilling.SetActive(false);
                //flangePowerMillingDifference.SetActive(false);

                flangeWaterCasting.SetActive(true);
                flangeWaterMilling.SetActive(false);
                //flangeWaterMillingDifference.SetActive(false);

                flangeCO2Casting.SetActive(false);
                flangeCO2Milling.SetActive(false);
                //flangeCO2MillingDifference.SetActive(false);

                //flangePowerCasting.GetComponent<MeshFilter>().mesh.colors32 = colorCastingWater;

                legendPowerExtraction.SetActive(false);
                legendPowerCasting.SetActive(false);
                legendPowerMilling.SetActive(false);
                legendWaterExtraction.SetActive(true);
                legendWaterCasting.SetActive(false);
                legendWaterMilling.SetActive(false);
                legendCO2Extraction.SetActive(false);
                legendCO2Casting.SetActive(false);
                legendCO2Milling.SetActive(false);

                toggleDifference.isOn = false;
                toggleDifference.interactable = false;

                currentGameObject = flangeWaterCasting;
            }
            else if(dropdownResourceValue == 1 && dropdownProcessValue == 1) //Water - Casting
            {
                flangePowerCasting.SetActive(false);
                flangePowerMilling.SetActive(false);
                //flangePowerMillingDifference.SetActive(false);

                flangeWaterCasting.SetActive(true);
                flangeWaterMilling.SetActive(false);
                //flangeWaterMillingDifference.SetActive(false);

                flangeCO2Casting.SetActive(false);
                flangeCO2Milling.SetActive(false);
                //flangeCO2MillingDifference.SetActive(false);

                //flangePowerCasting.GetComponent<MeshFilter>().mesh.colors32 = colorCastingWater;

                legendPowerExtraction.SetActive(false);
                legendPowerCasting.SetActive(false);
                legendPowerMilling.SetActive(false);
                legendWaterExtraction.SetActive(false);
                legendWaterCasting.SetActive(true);
                legendWaterMilling.SetActive(false);
                legendCO2Extraction.SetActive(false);
                legendCO2Casting.SetActive(false);
                legendCO2Milling.SetActive(false);

                toggleDifference.isOn = false;
                toggleDifference.interactable = false;

                currentGameObject = flangeWaterCasting;
            }
            else if (dropdownResourceValue == 1 && dropdownProcessValue == 2 && !toggleDifference.isOn) //Water - Milling
            {
                flangePowerCasting.SetActive(false);
                flangePowerMilling.SetActive(false);
                //flangePowerMillingDifference.SetActive(false);

                flangeWaterCasting.SetActive(false);
                flangeWaterMilling.SetActive(true);
                //flangeWaterMillingDifference.SetActive(false);

                flangeCO2Casting.SetActive(false);
                flangeCO2Milling.SetActive(false);
                //flangeCO2MillingDifference.SetActive(false);

                //flangePowerMilling.GetComponent<MeshFilter>().mesh.colors32 = colorMillingWater;

                legendPowerExtraction.SetActive(false);
                legendPowerCasting.SetActive(false);
                legendPowerMilling.SetActive(false);
                legendWaterExtraction.SetActive(false);
                legendWaterCasting.SetActive(false);
                legendWaterMilling.SetActive(true);
                legendCO2Extraction.SetActive(false);
                legendCO2Casting.SetActive(false);
                legendCO2Milling.SetActive(false);

                toggleDifference.interactable = true;

                currentGameObject = flangeWaterMilling;
            }
            /*else if (dropdownResourceValue == 1 && dropdownProcessValue == 2 && toggleDifference.isOn) //Water - Milling - Difference
            {
                flangePowerCasting.SetActive(false);
                flangePowerMilling.SetActive(false);
                flangePowerMillingDifference.SetActive(false);

                flangeWaterCasting.SetActive(false);
                flangeWaterMilling.SetActive(false);
                flangeWaterMillingDifference.SetActive(true);

                flangeCO2Casting.SetActive(false);
                flangeCO2Milling.SetActive(false);
                flangeCO2MillingDifference.SetActive(false);

                legendPowerExtraction.SetActive(false);
                legendPowerCasting.SetActive(false);
                legendPowerMilling.SetActive(false);
                legendWaterExtraction.SetActive(false);
                legendWaterCasting.SetActive(false);
                legendWaterMilling.SetActive(true);
                legendCO2Extraction.SetActive(false);
                legendCO2Casting.SetActive(false);
                legendCO2Milling.SetActive(false);

                toggleDifference.interactable = true;
                //toggleDifference.isOn = false;

                currentGameObject = flangeWaterMillingDifference;
            }*/
            //CO2
            else if (dropdownResourceValue == 2 && dropdownProcessValue == 0) //CO2 - Extraction
            {
                flangePowerCasting.SetActive(false);
                flangePowerMilling.SetActive(false);
                //flangePowerMillingDifference.SetActive(false);

                flangeWaterCasting.SetActive(false);
                flangeWaterMilling.SetActive(false);
                //flangeWaterMillingDifference.SetActive(false);

                flangeCO2Casting.SetActive(true);
                flangeCO2Milling.SetActive(false);
                //flangeCO2MillingDifference.SetActive(false);

                //flangePowerCasting.GetComponent<MeshFilter>().mesh.colors32 = colorCastingWater;

                legendPowerExtraction.SetActive(false);
                legendPowerCasting.SetActive(false);
                legendPowerMilling.SetActive(false);
                legendWaterExtraction.SetActive(false);
                legendWaterCasting.SetActive(false);
                legendWaterMilling.SetActive(false);
                legendCO2Extraction.SetActive(true);
                legendCO2Casting.SetActive(false);
                legendCO2Milling.SetActive(false);

                toggleDifference.isOn = false;
                toggleDifference.interactable = false;

                currentGameObject = flangeCO2Casting;
            }
            else if (dropdownResourceValue == 2 && dropdownProcessValue == 1) //CO2 - Casting
            {
                flangePowerCasting.SetActive(false);
                flangePowerMilling.SetActive(false);
                //flangePowerMillingDifference.SetActive(false);

                flangeWaterCasting.SetActive(false);
                flangeWaterMilling.SetActive(false);
                //flangeWaterMillingDifference.SetActive(false);

                flangeCO2Casting.SetActive(true);
                flangeCO2Milling.SetActive(false);
                //flangeCO2MillingDifference.SetActive(false);

                //flangePowerCasting.GetComponent<MeshFilter>().mesh.colors32 = colorCastingWater;

                legendPowerExtraction.SetActive(false);
                legendPowerCasting.SetActive(false);
                legendPowerMilling.SetActive(false);
                legendWaterExtraction.SetActive(false);
                legendWaterCasting.SetActive(false);
                legendWaterMilling.SetActive(false);
                legendCO2Extraction.SetActive(false);
                legendCO2Casting.SetActive(true);
                legendCO2Milling.SetActive(false);

                toggleDifference.isOn = false;
                toggleDifference.interactable = false;

                currentGameObject = flangeCO2Casting;
            }
            else if (dropdownResourceValue == 2 && dropdownProcessValue == 2 && !toggleDifference.isOn) //CO2 - Milling
            {
                flangePowerCasting.SetActive(false);
                flangePowerMilling.SetActive(false);
                //flangePowerMillingDifference.SetActive(false);

                flangeWaterCasting.SetActive(false);
                flangeWaterMilling.SetActive(false);
                //flangeWaterMillingDifference.SetActive(false);

                flangeCO2Casting.SetActive(false);
                flangeCO2Milling.SetActive(true);
                //flangeCO2MillingDifference.SetActive(false);

                //flangePowerMilling.GetComponent<MeshFilter>().mesh.colors32 = colorMillingWater;

                legendPowerExtraction.SetActive(false);
                legendPowerCasting.SetActive(false);
                legendPowerMilling.SetActive(false);
                legendWaterExtraction.SetActive(false);
                legendWaterCasting.SetActive(false);
                legendWaterMilling.SetActive(false);
                legendCO2Extraction.SetActive(false);
                legendCO2Casting.SetActive(false);
                legendCO2Milling.SetActive(true);

                toggleDifference.interactable = true;

                currentGameObject = flangeCO2Milling;
            }
            /*else if (dropdownResourceValue == 2 && dropdownProcessValue == 2 && toggleDifference.isOn) //CO2 - Milling - Difference
            {
                flangePowerCasting.SetActive(false);
                flangePowerMilling.SetActive(false);
                flangePowerMillingDifference.SetActive(false);

                flangeWaterCasting.SetActive(false);
                flangeWaterMilling.SetActive(false);
                flangeWaterMillingDifference.SetActive(false);

                flangeCO2Casting.SetActive(false);
                flangeCO2Milling.SetActive(false);
                flangeCO2MillingDifference.SetActive(true);

                legendPowerExtraction.SetActive(false);
                legendPowerCasting.SetActive(false);
                legendPowerMilling.SetActive(false);
                legendWaterExtraction.SetActive(false);
                legendWaterCasting.SetActive(false);
                legendWaterMilling.SetActive(false);
                legendCO2Extraction.SetActive(false);
                legendCO2Casting.SetActive(false);
                legendCO2Milling.SetActive(true);

                toggleDifference.interactable = true;
                //toggleDifference.isOn = false;

                currentGameObject = flangeCO2MillingDifference;
            }*/
        }
        
        if(sliderTransparency.value != sliderTransparencyValue)
        {
            //0.05 for max val = 20
            sliderTransparencyValue = sliderTransparency.value * 0.1f;
            Debug.Log("Transparency: " + sliderTransparencyValue);

            /*if(sliderTransparencyValue < 1)
            {
                Debug.Log("Setting mode to Fade.");
                currentGameObject.GetComponent<Renderer>().material.SetInt("_Mode", 2); // Fade
                currentGameObject.GetComponent<Renderer>().material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
                currentGameObject.GetComponent<Renderer>().material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
                currentGameObject.GetComponent<Renderer>().material.renderQueue = 3000;
            }*/

            sliderTransparency.gameObject.transform.Find("Label").GetComponent<Text>().text = "Transparency: " + sliderTransparencyValue*100 + "%";
            Color currentColor = currentGameObject.GetComponent<Renderer>().material.color;
            currentGameObject.GetComponent<Renderer>().material.color = new Color(currentColor.r, currentColor.g, currentColor.b, 1-sliderTransparencyValue);

            //currentGameObject.GetComponent<Renderer>().material.SetFloat("_Metallic", sliderTransparencyValue); // Opaque

            /*if (sliderTransparencyValue == 1)
            {
                Debug.Log("Setting mode to Opaque.");
                currentGameObject.GetComponent<Renderer>().material.SetInt("_Mode", 0); // Opaque
                currentGameObject.GetComponent<Renderer>().material.SetFloat("_SrcBlend", initialSrc);
                currentGameObject.GetComponent<Renderer>().material.SetFloat("_DstBlend", initialDst);
                currentGameObject.GetComponent<Renderer>().material.renderQueue = initiallRenderQueue;
            }*/
        }
    }

    /*void InitializeColors()
    {
        for (int i = 0; i < colorCastingEnergy.Length; i++)
            colorCastingWater[i] = new Color32(223, 255, 255, 255);

        for(int i = 0; i < 1000; i++)
            Debug.Log(colorMillingEnergy[i]);

        for (int i = 0; i < colorMillingEnergy.Length; i++)
        {
            
            if (colorMillingEnergy[i].b == 201)
                colorMillingWater[i] = new Color32(223, 255, 255, 255);
            else
                colorMillingWater[i] = new Color32(0, 76, 109, 255);
        }
            

        for(int i= 0; i < colorMillingEnergy.Length; i++)
            if (colorMillingEnergy[i].b == 201)
                colorMillingEnergyDifference[i] = new Color32(0, 0, 0, 0);
            else
                colorMillingEnergyDifference[i] = new Color32(227, 74, 51, 255);

    }*/
}
