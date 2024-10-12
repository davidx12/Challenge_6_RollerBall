using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundPiece : MonoBehaviour
{
    
    public bool isColoured = false;
    

    public void ChangeColour(Color color)
    {
            GetComponent<MeshRenderer>().material.color = color;
            isColoured = true;
            
            GameManager.singleton.CheckComplete();
    }

}
