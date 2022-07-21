//Allows the steak to be cooked and produces smoke particles if burnt
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Steak : MonoBehaviour
{
    public Color RawSteakColor;
    public Color CookedSteakColor;

    public float CookingTime;
    public float CookTimer;

    public float BurntTime;

    public ParticleSystem Smoke;

    public Material SteakMaterial;

    private void Start() //checks if object has cooking script
    {
        SteakMaterial = GetComponentInChildren<MeshRenderer>().material;
        CookTimer = CookingTime;
        SteakMaterial.color = RawSteakColor;
    }

    public void CookSteak() //cook steak by using a timer
    {
        CookingTime -= Time.deltaTime;
        float percentCooked = CookingTime / CookTimer;
        SteakMaterial.color = TransitionColor(RawSteakColor, CookedSteakColor, percentCooked);

        if(CookingTime < BurntTime)
        {
            Smoke.Play();
        }
    }   
    
    public Color TransitionColor(Color rawColor, Color cookedColor, float cooked) //Changes the patties colour by grabbing the RGB Values
    {
        float redRaw = rawColor.r;
        float greenRaw = rawColor.g;
        float blueRaw = rawColor.b;

        float redCooked = cookedColor.r;
        float greenCooked = cookedColor.g;
        float blueCooked = cookedColor.b;

        float transitionRed = Mathf.Lerp(redCooked, redRaw, cooked);
        float transitiongreen = Mathf.Lerp(greenCooked, greenRaw, cooked);
        float transitionblue = Mathf.Lerp(blueCooked, blueRaw, cooked);

        Color transtionColor = new Color(transitionRed, transitiongreen, transitionblue, 1);

        return transtionColor;
    }
}