using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Spacesheap spacesheap;
    private float timer;
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(spacesheap.health <= 0){
            timer += Time.deltaTime;
            if(timer >= 2.000){
                timer=0;
                spacesheap.NewSpacesheap();
            }
        }
    }
}
