using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngryMaterial : MonoBehaviour
{
    public Material[] material;
    Renderer rend; //reference to renderer
    Transform tankRenderer; //reference variable to the TankRenderer game object in the Chaser and Patroller Tank

    void Start()
    {
        tankRenderer = this.transform.GetChild(0); //get the "TankRenderer" game object in the tank prefab
        foreach (Transform child in tankRenderer) { // for each child of the tankRenderer
            rend = child.GetComponent<Renderer>(); //get renderer of each child
            rend.enabled = true; //set the enabled to true
            rend.sharedMaterial = material[0]; //set to the first material set in the Inspector
        }
    }

    // Change color when chasing
    public void Chaseroo()
    {
        tankRenderer = this.transform.GetChild(0); //get the "TankRenderer" game object in the tank prefab
        foreach (Transform child in tankRenderer)
        { // for each child of the tankRenderer
            rend = child.GetComponent<Renderer>(); //get renderer of each child
            rend.enabled = true; //set the enabled to true
            rend.sharedMaterial = material[1]; //set to the Second (Alternate) material set in the Inspector
        }
    }

    // Back to normal color once chasing ends
    public void Normalroo()
    {
        tankRenderer = this.transform.GetChild(0); //get the "TankRenderer" game object in the tank prefab
        foreach (Transform child in tankRenderer)
        { // for each child of the tankRenderer
            rend = child.GetComponent<Renderer>(); //get renderer of each child
            rend.enabled = true; //set the enabled to true
            rend.sharedMaterial = material[0]; //set to the first material set in the Inspector
        }
    }
}
