using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public Vector3 bounds;
    public Scroller scroller;
    
    public Vector3 GetHalfBounds(){
        return bounds /2;
    }

    void Update(){
        if(transform.position.z + GetHalfBounds().z < 0)
            scroller.OnPoolEnter(gameObject);
    }
}
