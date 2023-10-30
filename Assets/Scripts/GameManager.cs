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
    public LittleFire dungeonSpawner;
    public int actualDungeon = 0;

    public bool playerIsAlive = true;
    public bool playerIsGhost = true;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        dungeonSpawner.fireSpawn.SpawnObjectRandomly();
    }

    public void KillEnemy()
    {
        dungeonSpawner.EnemyCounter();
    }


}
