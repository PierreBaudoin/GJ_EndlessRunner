using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controler : MonoBehaviour
{
    #region Set up
    public delegate void controlerDelegate();
    public controlerDelegate up, down, left, right;
    public enum direction{up, down, left, right} 
    public Dictionary<direction, string> inputs, nextInput;
    
    public List<string> validKeys;

    void Start()
    {
        GameManager.instance.controler = this;
        validKeys = new List<string>();

        validKeys.Add("a");
        validKeys.Add("z");
        validKeys.Add("e");
        validKeys.Add("r");
        validKeys.Add("t");
        validKeys.Add("q");
        validKeys.Add("s");
        validKeys.Add("d");
        validKeys.Add("f");
        validKeys.Add("g");

        inputs = new Dictionary<direction, string>();
        nextInput = new Dictionary<direction, string>();

        up += GameManager.instance.character.Jump;
        down += GameManager.instance.character.Jump;
        left += GameManager.instance.character.MoveLeft;
        right += GameManager.instance.character.MoveRight;

        inputs.Add(direction.up, "up");
        inputs.Add(direction.down, "down");
        inputs.Add(direction.left, "left");
        inputs.Add(direction.right, "right");
        nextInput.Add(direction.up, "");
        nextInput.Add(direction.down, "");
        nextInput.Add(direction.left, "");
        nextInput.Add(direction.right, "");

    }
    #endregion
    
    
    void Update()
    {
        foreach(direction dir in inputs.Keys){
            if(Input.GetKeyDown(inputs[dir]))
                switch(dir){
                    case direction.up:
                        up.Invoke();
                        break;
                    case direction.down:
                        //down.Invoke();
                        break;
                    case direction.left:
                        left.Invoke();
                        break;
                    case direction.right:
                        right.Invoke();
                        break;
                }
        }
    }

    public void AddNextInput(string key){
        // prendre un input au hasard en vérifiant qu'il est pas déja utilisé
        direction d = GetRandomDirection(new List<string>(nextInput.Values));
        
        // L'ajouter à au dictionnaire
        nextInput[d] = key;
        print("next  : " + d + " ++ " + key);

        if(IsNextInputReady())
            AllImputGathered();
    }

        // si le dictionnaire est plein, transférer sur le live et vider le next
        // libérer les anciens inputs
    public void AllImputGathered(){
        foreach(direction d in new List<direction>(inputs.Keys)){
            string oldKey = inputs[d];
            inputs[d] = nextInput[d];
            nextInput[d] = "";

            if(oldKey != "up" && oldKey != "down" && oldKey != "left" && oldKey != "right"){
                GameManager.instance.controler.validKeys.Add(oldKey);
            }
        }
    }

    private Controler.direction GetRandomDirection(List<string> usedDirection){
        int rand = Random.Range(0,4);
        if(usedDirection[rand] != "")
            return GetRandomDirection(usedDirection);

        switch(rand){
            case 0:
                return Controler.direction.up;
            case 1:
                return Controler.direction.down;
            case 2:
                return Controler.direction.left;
            case 3:
                return Controler.direction.right;
            default : 
                return Controler.direction.up;
        }
    }

    private bool IsNextInputReady(){
        foreach(direction d in nextInput.Keys)
            if(nextInput[d] == "")
                return false;
        
        return true;
    }
}
