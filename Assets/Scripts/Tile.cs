using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public Vector3 bounds;
    
    public Vector3 GetHalfBounds(){
        return bounds /2;
    }
}
