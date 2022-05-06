using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;

public class UIScript : MonoBehaviour
{
    public GameObject modelTarget;
    public GameObject flangePowerMolding, flangePowerMilling, flangePowerMillingDifference;
    public GameObject flangeWaterMolding, flangeWaterMilling, flangeWaterMillingDifference;
    public GameObject legendPowerMolding, legendPowerMilling, legendWaterMolding, legendWaterMilling;
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
    // Start is called before the first frame update
    void Start()
    {
        currentGameObject = flangePowerMolding;
        
        initialSrc = currentGameObject.GetComponent<Renderer>().material.GetFloat("_SrcBlend");
        initialDst = currentGameObject.GetComponent<Renderer>().material.GetFloat("_DstBlend");
        initiallRenderQueue = currentGameObject.GetComponent<Renderer>().material.renderQueue;
    }

    // Update is called once per frame
    void Update()
    { 
        if(dropdownProcess.value != dropdownProcessValue || dropdownResource.value != dropdownResourceValue || toggleDifference.isOn != difference)
        {
            dropdownProcessValue = dropdownProcess.value;
            dropdownResourceValue = dropdownResource.value;
            difference = toggleDifference.isOn;

            if(dropdownResourceValue == 0 && dropdownProcessValue == 0 ) // Power - Molding
            {
                flangePowerMolding.SetActive(true);
                flangePowerMilling.SetActive(false);
                flangePowerMillingDifference.SetActive(false);

                flangeWaterMolding.SetActive(false);
                flangeWaterMilling.SetActive(false);
                flangeWaterMillingDifference.SetActive(false);

                legendPowerMolding.SetActive(true);
                legendPowerMilling.SetActive(false);
                legendWaterMolding.SetActive(false);
                legendWaterMilling.SetActive(false);

                toggleDifference.isOn = false;
                toggleDifference.interactable = false;

                currentGameObject = flangePowerMolding;
            }
            else if (dropdownResourceValue == 0 && dropdownProcessValue == 1 && !toggleDifference.isOn) // Power - Milling
            {
                flangePowerMolding.SetActive(false);
                flangePowerMilling.SetActive(true);
                flangePowerMillingDifference.SetActive(false);

                flangeWaterMolding.SetActive(false);
                flangeWaterMilling.SetActive(false);
                flangeWaterMillingDifference.SetActive(false);

                legendPowerMolding.SetActive(false);
                legendPowerMilling.SetActive(true);
                legendWaterMolding.SetActive(false);
                legendWaterMilling.SetActive(false);

                toggleDifference.interactable = true;

                currentGameObject = flangePowerMilling;
            }
            else if (dropdownResourceValue == 0 && dropdownProcessValue == 1 &&  toggleDifference.isOn) // Power - Milling - Difference
            {
                flangePowerMolding.SetActive(false);
                flangePowerMilling.SetActive(false);
                flangePowerMillingDifference.SetActive(true);

                flangeWaterMolding.SetActive(false);
                flangeWaterMilling.SetActive(false);
                flangeWaterMillingDifference.SetActive(false);

                legendPowerMolding.SetActive(false);
                legendPowerMilling.SetActive(true);
                legendWaterMolding.SetActive(false);
                legendWaterMilling.SetActive(false);

                toggleDifference.interactable = true;

                currentGameObject = flangePowerMillingDifference;
            }

            //Switch resource
            else if(dropdownResourceValue == 1 && dropdownProcessValue == 0) //Water - Molding
            {
                flangePowerMolding.SetActive(false);
                flangePowerMilling.SetActive(false);
                flangePowerMillingDifference.SetActive(false);

                flangeWaterMolding.SetActive(true);
                flangeWaterMilling.SetActive(false);
                flangeWaterMillingDifference.SetActive(false);

                legendPowerMolding.SetActive(false);
                legendPowerMilling.SetActive(false);
                legendWaterMolding.SetActive(true);
                legendWaterMilling.SetActive(false);

                toggleDifference.isOn = false;
                toggleDifference.interactable = false;

                currentGameObject = flangeWaterMolding;
            }
            else if (dropdownResourceValue == 1 && dropdownProcessValue == 1 && !toggleDifference.isOn) //Water - Milling
            {
                flangePowerMolding.SetActive(false);
                flangePowerMilling.SetActive(false);
                flangePowerMillingDifference.SetActive(false);

                flangeWaterMolding.SetActive(false);
                flangeWaterMilling.SetActive(true);
                flangeWaterMillingDifference.SetActive(false);

                legendPowerMolding.SetActive(false);
                legendPowerMilling.SetActive(false);
                legendWaterMolding.SetActive(false);
                legendWaterMilling.SetActive(true);

                toggleDifference.interactable = false;
                toggleDifference.isOn = false;

                currentGameObject = flangeWaterMilling;
            }
            else if (dropdownResourceValue == 1 && dropdownProcessValue == 1 && toggleDifference.isOn) //Water - Milling - Difference
            {
                flangePowerMolding.SetActive(false);
                flangePowerMilling.SetActive(false);
                flangePowerMillingDifference.SetActive(false);

                flangeWaterMolding.SetActive(false);
                flangeWaterMilling.SetActive(false);
                flangeWaterMillingDifference.SetActive(true);

                legendPowerMolding.SetActive(false);
                legendPowerMilling.SetActive(false);
                legendWaterMolding.SetActive(false);
                legendWaterMilling.SetActive(true);

                toggleDifference.interactable = false;
                toggleDifference.isOn = false;

                currentGameObject = flangeWaterMillingDifference;
            }
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
}
