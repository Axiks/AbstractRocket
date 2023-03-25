using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //public Rigidbody rb;
    //public float Speed;
    public int damage;
    public bool debug;
    public GameObject DebugPoint;
    public Spacesheap ShooterSpacesheap;
    private Vector3 LastPosition;
    private int takt;
     private GameObject instantiatedObj;


    // Start is called before the first frame update
    void Start()
    {
        //LastPosition = transform.position;
        //rb = GetComponent<Rigidbody>();
        //akt = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate(){
        // //transform.Translate(Vector3.forward*Speed);
        // /*Rocket*/
        // Vector3 dir = new Vector3(0, 0, Speed + takt);
        // rb.AddForce(dir);
        // //При зіткнені видаляти
        // // RaycastHit hit;
        // // if(Physics.Linecast(LastPosition ,transform.position, out hit)){
        // //     print (hit.transform.name);
        // //     Destroy(gameObject);
        // // }
        // takt++;
        // LastPosition = transform.position;
    }

    void OnCollisionEnter (Collision other) {
        if(debug) Debug(other);
        if(other.gameObject.tag == "Eninem"){
            print("Shot to:" + other.gameObject.tag);
            //print("Game object tag name " + transform.parent.gameObject.tag);

            //Gun obj = this.transform.parent;


            GameObject player = GameObject.FindWithTag("Player");
            if (player != null){
                Spacesheap spacesheap =  player.GetComponent<Spacesheap>();
                spacesheap.score++;
                print("Player score: "+spacesheap.score.ToString());
            }
            

            //ShooterSpacesheap.score = ShooterSpacesheap.score + 1;
            
            //print("Spacesheap fire:" + other.gameObject.tag);
            //other.gameObject.
            //other.gameObject.health;
            // Spacesheap hinge = other.gameObject.GetComponentInParent(typeof(Spacesheap)) as Spacesheap;
            // print("Object Amo" + hinge.tag);
            //Vector3 DeafultPosition = new Vector3(0, other.transform.position.y, 0);
            //Instantiate(other.gameObject, DeafultPosition, other.transform.rotation);
            //Destroy(other.gameObject);
            //Destroy(gameObject);
        }

        if(other.gameObject.tag == "Wall"){
         //instantiatedObj = (GameObject) Instantiate(spawnBonus, transform.position, transform.rotation);
         Destroy(gameObject);
        }

        if(other.gameObject.tag == "Player" || other.gameObject.tag == "Eninem"){
            //Destroy(gameObject);
            Spacesheap hinge = other.gameObject.GetComponentInParent(typeof(Spacesheap)) as Spacesheap;
            hinge.health -= damage;

            print(other.gameObject.tag + " shot Amo: " + hinge.tag + " Health: " + hinge.health);
            Destroy(gameObject);
            // if(hinge.health == 0){
            //     float randomPositionX = Random.Range(-40.0F, 40.0F);
            //     Vector3 DeafultPosition = new Vector3(randomPositionX, other.transform.position.y, 0);//Позиція спавну


            //     hinge.health = 100; hinge.amo_count = 40;//Fix
            //     Instantiate(other.gameObject, DeafultPosition, other.transform.rotation);
            //     Destroy(other.gameObject);
            // }
        }
    }

    private void Debug(Collision other){
        print("Collision: " + other.gameObject.name + " Tag name: " +  other.gameObject.tag + " Position x: " + transform.position.x + " y: "+ transform.position.y + " z: " + transform.position.z);
        Instantiate(DebugPoint, transform.position, transform.rotation);
    }
}
