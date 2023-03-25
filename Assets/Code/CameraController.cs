using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Player;
    private Vector3 offset;
    Quaternion origrnPosition;
    float mouseY;
    float stikSens= 10;

    private PlayerController controls;

    void Start()
    {
        offset = transform.position - Player.transform.position;//Вираховуємо зміщення
        origrnPosition = transform.rotation;
    }

    private void Awake(){
        controls = new PlayerController();
    }

    private void OnEnable(){
        controls.Gameplay.Enable();
    }

    private void onDisable(){
        controls.Gameplay.Disable();
    }

    void FixedUpdate(){

    }

    void LateUpdate()
    {
        var cameraInput = controls.Gameplay.Camera.ReadValue<Vector2>();
        float v = cameraInput.y;
        float h = cameraInput.x;
        Vector3 dir = new Vector3(h * stikSens, v * stikSens, 0);
        transform.position = Player.transform.position + offset + dir;
        //transform.rotation = Quaternion.AngleAxis(Player.transform.rotation.y, new Vector3(transform.rotation.x, 1, transform.rotation.y));
    }

}
