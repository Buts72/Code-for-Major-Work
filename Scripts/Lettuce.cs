//Script that allows lettuce to be cut
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lettuce : MonoBehaviour
{
    private int CutCount;

    public List<GameObject> BodyPart_Main_List;

    public GameObject BodyPart;

    public Transform SpawnPosition;

    private void Start()
    {
        CutCount = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Something has hit this");
        CheckIfKnife(other);
    }

    private void CheckIfKnife(Collider other) //check if object is knife
    {
        string tag = other.tag;
        if (tag == "Knife")
        {
            Debug.Log("Knife has hit this");
            CutMe();
        }
    }

    private void CutMe()
    {
        //Calls spawn new body part
        SpawnPart();

        //Create index int for current main body shown from body part list
        int CurrentBodyPart = CutCount;
        //Create index int for next main body shown from body part list
        int NextBodyPart = CutCount + 1;

        //This turns off the current body part
        BodyPart_Main_List[CurrentBodyPart].SetActive(false);

        //This checks if we have turned off all the body parts
        if(NextBodyPart > BodyPart_Main_List.Count - 1)
        {
            //If we have it destroys the main lettuce object
            Debug.Log("Out of Lettuce!!!");
            Destroy(this.gameObject);
        }
        else
        {
            //if we have it turns on the next main lettuce body part
            Debug.Log("Body parts left = " + CutCount);
            BodyPart_Main_List[NextBodyPart].SetActive(true);
        }

        CutCount++;
    }

    private void SpawnPart()
    {
        //This creates an empty gameObject called bodyPart
        GameObject bodyPart;
        //Assign a Gameobject BodyPart which is refferenced above and exists in the hira
        bodyPart= Instantiate(BodyPart, SpawnPosition.position, SpawnPosition.rotation);
        //this get the rigidbody of the body part and adds a force to it to throw it away
        bodyPart.GetComponent<Rigidbody>().AddForce(bodyPart.transform.forward * 10);
    }
}
