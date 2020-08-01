using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlsAlterer : MonoBehaviour, ICollectible
{
    public string key;

    void Update(){
        if(key == "")
            SetKey();
    }

    void SetKey(){
        int rand = Random.Range(0, GameManager.instance.controler.validKeys.Count);
        key = GameManager.instance.controler.validKeys[rand];
        GameManager.instance.controler.validKeys.Remove(key);
    }

    public void Collect(){
        GameManager.instance.controler.AddNextInput(key);        

        GameManager.instance.points ++;

        Destroy(this.gameObject);
    }
}
