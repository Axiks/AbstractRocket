using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    private int Score = 1;
    public static PlayerData _instance;
    public static PlayerData Instance
    {
        get {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<PlayerData>();
                
                if (_instance == null)
                {
                    GameObject container = new GameObject("Player");
                    _instance = container.AddComponent<PlayerData>();
                }
            }
        
            return _instance;
        }
    }

    public void AddScore(){
        Score++;
    }

    public int GetScore(){
        return Score;
    }
}
