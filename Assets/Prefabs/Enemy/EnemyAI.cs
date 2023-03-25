using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Spacesheap spacesheap;
    private Vector2 movementInput;
    private int frame = 0;
    private int frameFire = 0;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        //Летить у протилежному напрямку
        movementInput = new Vector2(0.0f, -0.9f);
        //Кадр на якому відюудеться вистріл
        RandomFireFrame();
        timer = 0;
    }

    // Update is called once per frame
    void Update(){
        if(spacesheap.health <= 0){
            eminemSpawn();
        }
    }
    void  FixedUpdate()
    {
        spacesheap.Mover(movementInput);

        if(frame == frameFire){
            spacesheap.GunFire();
            frame = 0;
            RandomFireFrame();
        }
        frame++;
    }

    void RandomFireFrame(){
        frameFire = Random.Range(60,  240);
    }

    Vector3 SpawPosition(){
        //Get player position
        Vector3 Position = new Vector3(0, 0, 0);
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null){
            Spacesheap playerSpacesheap =  player.GetComponent<Spacesheap>();
            float randomPositionX =  Random.Range(playerSpacesheap.transform.position.x - 60, playerSpacesheap.transform.position.x + 60);
            float PositionZ = playerSpacesheap.transform.position.z + 100;
            //Щоб корабель не виходив за мещі світу
            if(PositionZ > 480)
                PositionZ = 480;
            if(randomPositionX > 480)
                randomPositionX = 480;
            if(randomPositionX < -480)
                randomPositionX = -480;
            Position = new Vector3(randomPositionX, playerSpacesheap.flyHeight, PositionZ);
        }
        return Position;
    }
    void eminemSpawn(){
        timer += Time.deltaTime;
        if(timer >= 2.000){
            timer=0;
            spacesheap.NewSpacesheap();
            spacesheap.transform.position = SpawPosition();
        }
    }
}
