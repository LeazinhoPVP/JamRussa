using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Transform target;
    public bool possess = false;
    public PlayerMove player;
    public PlayerPossess playerPossess;
    private void Awake()
    {
        instance = this;
    }
}
