using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpacesheapUI : MonoBehaviour
{
    public Spacesheap spacesheap;
    public TextMeshPro amo_count;
    public TextMeshPro healthText;
    public TextMeshPro scoreText;
    private int prevHealth;
    private int nowHealth;
    private int prevAmo;
    private int nowAmo;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        nowHealth = prevHealth = spacesheap.health;
        nowAmo = prevAmo = spacesheap.amo_count;
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        amo_count.text = nowAmo.ToString();
        healthText.text = "HP " + nowHealth.ToString()+"%";
        scoreText.text = "Score " + spacesheap.score.ToString();
        //Animation
        Animation();
    }
    private void Animation(){
        //HP
        if(nowHealth > spacesheap.health){
            timer += Time.deltaTime;
            if(timer > 0.008){
                nowHealth--;
                timer = 0;
            }
        }

        if(nowHealth < spacesheap.health){
            timer += Time.deltaTime;
            if(timer > 0.008){
                nowHealth++;
                timer = 0;
            }
        }

        //Amo
         if(nowAmo > spacesheap.amo_count){
            timer += Time.deltaTime;
            if(timer > 0.008){
                nowAmo--;
                timer = 0;
            }
        }

        if(nowAmo < spacesheap.amo_count){
            timer += Time.deltaTime;
            if(timer > 0.008){
                nowAmo++;
                timer = 0;
            }
        }
    }
}