using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public List<Transform> targets;
    public float sideSpeed, jumpHeight;
    private Rigidbody rig;
    private Transform target;


    void Start()
    {
        FetchComponents();
        target = targets[(int) Mathf.Floor(targets.Count / 2)];
    }

    void FetchComponents(){
        rig = GetComponent<Rigidbody>();
    }

    void Update()
    {
        rig.velocity = (target.position - transform.position) * sideSpeed;
    }

    public void MoveLeft(){
        int currentIndex = targets.IndexOf(target);

        if(currentIndex == 0)
            return;
        else
            target = targets[currentIndex -1];
    }

    public void MoveRight(){
        int currentIndex = targets.IndexOf(target);

        if(currentIndex == targets.Count -1)
            return;
        else
            target = targets[currentIndex +1];
    }

    public void Jump(){
        print("Jump");
        rig.AddForce(0,jumpHeight,0);
    }

    void OnTriggerEnter(Collider other){
        if(other.tag == "Obstacle"){
            GameManager.instance.Lose();
        } else if(other.tag == "Collectible"){
            other.transform.GetComponent<ICollectible>().Collect();
        }
    }
}
