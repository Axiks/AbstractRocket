using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Gun : MonoBehaviour
{
    //PlayerControls controls;
    public Rigidbody Amo;
    public Transform StartFirePosition;

    public float power;

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(" Gun Start");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Fire(){
        //Debug.Log(" Fire: ");
        Rigidbody StartFireInstance;
        StartFireInstance = Instantiate(Amo, StartFirePosition.position, StartFirePosition.rotation); //Створеня копії об'єкта
        StartFireInstance.AddForce(StartFirePosition.forward * power); //Прикладання сили
    }
}
