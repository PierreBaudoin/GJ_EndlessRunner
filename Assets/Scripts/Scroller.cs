using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroller : MonoBehaviour
{
    public float speed;
    public GameObject g_pool;
    public List<GameObject> levelDesignPaterns;
    
    private List<GameObject> pool;
    private Tile lastTile;

    void Start(){
        pool = new List<GameObject>();
        foreach(GameObject g in levelDesignPaterns){
            for(int i = 0; i < 2; i++){
                GameObject inst = Instantiate(g, Vector3.zero, Quaternion.identity);
                inst.transform.SetParent(transform);
                OnPoolEnter(inst);
            }
        }
    }

    void Update()
    {
        transform.position = transform.position - (Vector3.forward * speed * Time.deltaTime);
    }

    void OnPoolEnter(GameObject g){
        if(g.GetComponent<Tile>() == null)
            return;

        g.SetActive(false);
        pool.Add(g);
        g.transform.SetParent(g_pool.transform);
    }

    void OnPoolExit(GameObject g){
        g.SetActive(true);
        pool.Remove(g);
        g.transform.position = GetNextPos();
        g.transform.rotation = Quaternion.identity;
        g.transform.SetParent(transform);

        lastTile = g.GetComponent<Tile>();
    }

    Vector3 GetNextPos(){
        if(lastTile == null)
            return Vector3.zero;
        return lastTile.transform.position + lastTile.GetHalfBounds();
    }
}
