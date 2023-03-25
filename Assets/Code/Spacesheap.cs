using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spacesheap : MonoBehaviour
{
    public Rigidbody rb;
    public  Light lightEngineLeft;
    public  Light lightEngineRight;
    public Gun gun;

    //Move Var Setting
    public float speed;
    private float angle = 0;
    private float angleAceleration = 3;
    public int engineLightIntensive;
    private float maxAngle = 10;
    public int amo_count;
    public int health;
    public float flyHeight;
    private int amo_count_default;
    private int health_default;
    public int score;
    private RigidbodyConstraints originalConstraints;
    private float originalSpeed;

    void Start()
    {
        //Spacesheap obj
        rb = GetComponent<Rigidbody>();
        amo_count_default = amo_count;
        health_default = health;
        originalConstraints = rb.constraints;
        originalSpeed = speed;
        score = 0;
    }

    void Update(){
        if(health <= 0){
            SpacesheapDead();
        }
    }

    public void GunFire(){
        if(amo_count > 0) {
            gun.Fire();
            amo_count--;
        }
    }

    public void Mover(Vector2 movementInput){
        //Debug.Log(" Move x: " +  movementInput.x + " Move y: " +  movementInput.y);

        //Light
        EngineLightSet(lightEngineLeft, engineLightIntensive, true, movementInput);
        EngineLightSet(lightEngineRight, engineLightIntensive, false, movementInput);

        //Angle
        //AngleSet(movementInput);

        //Force
        Vector3 dir = new Vector3(movementInput.x * speed, 0, movementInput.y * speed);
        rb.AddForce(dir);
    }

    private void AngleSet(Vector2 movementInput){
        if(movementInput.y != 0f){
             //Debug.Log(" V: " + v);
             if(angle < maxAngle && angle > -maxAngle){
                 
                 transform.rotation = Quaternion.AngleAxis(angle, new Vector3(1, 0, 0));
                 angle+=movementInput.y * angleAceleration;
             }
        }
        else{
            DeafultAngle();
        }
    }

    void DeafultAngle(){
        if(angle < angleAceleration && angle > -angleAceleration){
            angle = 0;
        }
        if(transform.rotation.x > 0){
            angle-=angleAceleration;
        }
        if(transform.rotation.x < 0){
            angle+=angleAceleration;
        }
        transform.rotation =  Quaternion.AngleAxis( angle, new Vector3(1, 0, 0));
    }

    private void EngineLightSet(Light lightEngine, int intensity, bool left, Vector2 movementInput){
        //Debug.Log(" [Engine L] X: " +  movementInput.x + " Y: " + movementInput.y + " Intensity: " + (Mathf.Abs(movementInput.y) + (Mathf.Abs(movementInput.x))*2) * 100);
        float deafultLight = 2;
        if(!left){
            if(movementInput.x < 0){
                lightEngine.intensity = (Mathf.Abs(movementInput.y) + (Mathf.Abs(movementInput.x))*2) * intensity;
            }else{
                lightEngine.intensity = (Mathf.Abs(movementInput.y) * intensity) + deafultLight;
            }
        }
        else{
            if(movementInput.x > 0){
                lightEngine.intensity = (Mathf.Abs(movementInput.y) + (Mathf.Abs(movementInput.x))*2) * intensity;
            }else{
                lightEngine.intensity = (Mathf.Abs(movementInput.y) * intensity) + deafultLight;
            }
        }
        
    }
    void OnCollisionEnter (Collision other) {
        //Debug(other);
        if(other.gameObject.tag == "TreeOn"){
            Destroy(other.gameObject);
            health = health - 25;
         }
    }

     private void OnTriggerExit(Collider other)
    {
         print("Trigger spacesheap: seccess)");
         print("Trigger spacesheap: " + other.gameObject.name + " Tag name: " +  other.gameObject.tag + " Position x: " + transform.position.x + " y: "+ transform.position.y + " z: " + transform.position.z);
         if(other.gameObject.tag == "Portal"){
            RechargeSpacesheap();
         }         
    }

    private void Debug(Collision other){
        print("Collision spacesheap: " + other.gameObject.name + " Tag name: " +  other.gameObject.tag + " Position x: " + transform.position.x + " y: "+ transform.position.y + " z: " + transform.position.z);
    }

    private void RechargeSpacesheap(){
        amo_count = amo_count_default;
        health = health_default;
    }

    private void SpacesheapDead(){
        //NewSpacesheap();
        SpacesheapTresh();
    }

    public void NewSpacesheap(){
        amo_count = 5;
        health = 20;
        speed = originalSpeed;
        float randomPositionX = Random.Range(-40.0F, 40.0F);
        Vector3 DeafultPosition = new Vector3(randomPositionX, flyHeight, 0);//Позиція спавну
        rb.constraints = originalConstraints;
        transform.position = DeafultPosition;
    }

    public void SpacesheapTresh(){
        //rb.constraints = RigidbodyConstraints.None;
        speed = 0;
        //rb.useGravity = true;
        rb.constraints &= ~RigidbodyConstraints.FreezePositionY;
    }

}
