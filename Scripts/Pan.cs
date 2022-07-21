//Checks if steak has enterd pan and cooks
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pan : MonoBehaviour
{
    public Steak Steak;

    public bool IsCooking;
    public Collider PanCollider;

    public Transform ClockFace;

    private void Update() //cooking function
    {
        if (IsCooking)
        {
            Steak.CookSteak();
        }
    }

    private void OnTriggerEnter(Collider other) //collision check
    {
        Debug.Log("Something has enter Pan");
        CheckIfSteak(other);
    }

    private void CheckIfSteak(Collider other)
    {
        string tag = other.tag; // checks if the object is a steak
        if(tag == "Steak")
        {
            Debug.Log("Steak has enter Pan!!!");
            IsCooking = true;
            Steak = other.GetComponent<Steak>();
        }
    }

    private void OnTriggerExit(Collider other) //check if steak exits and stops cooking
    {
        string tag = other.tag;
        if (tag == "Steak")
        {
            Steak stake = other.GetComponent<Steak>();
            stake = Steak;
            IsCooking = false;
            Steak = null;
        }
    }
}