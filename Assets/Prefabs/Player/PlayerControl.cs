using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;


public class PlayerControl : MonoBehaviour
{
    public Spacesheap spacesheap;
    private PlayerController controls;
    private Vector2 movementInput;

    private float angle2 = 0;

    private void Start(){
        
    }

    private void Awake(){
        controls = new PlayerController();
        
        //var a = GameObject.Find("Engine").GetComponent("Gun");
        //Gun
        controls.Gameplay.Fire.performed += ctx => spacesheap.GunFire();
    }

    private void OnEnable(){
        controls.Gameplay.Enable();
    }

    private void onDisable(){
        controls.Gameplay.Disable();
    }

    // Update is called once per frame
    void  FixedUpdate()
    {
        movementInput = controls.Gameplay.Move.ReadValue<Vector2>();
        spacesheap.Mover(movementInput);

        // transform.Translate(new Vector3(0,0,1));
        // var cameraInput = controls.Gameplay.Camera.ReadValue<Vector2>();
        // transform.rotation =  Quaternion.AngleAxis( cameraInput.x, new Vector3(0, 0, 1));
        // angle2+= cameraInput.x;
        // transform.rotation =  Quaternion.AngleAxis( angle2, new Vector3(0, 1, 0));

        // Debug.Log(" Move x: " +  movementInput.x + " Move y: " +  movementInput.y);
    }
}