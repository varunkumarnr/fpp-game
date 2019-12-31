using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManger : MonoBehaviour
{
    public static EnemyManger instance;
    [SerializeField]
    private GameObject boar_Prefab, cannibal_Prefab;
    public Transform[] cannibal_SpawnPoints, boar_SpawnPoints;
    [SerializeField]
    private int Cannibal_enemy_Count, Boar_Enemy_Count;
    private int initial_Cannibal_Count, initial_Boar_Count;
    public float wait_Before_Spawn_Eniemies = 10f;
    void Awake()
    {
        MakeInstance();
    }
    void Start()
    {
        initial_Cannibal_Count = Cannibal_enemy_Count;
        initial_Boar_Count = Boar_Enemy_Count;
        SpawnEnemies();
        StartCoroutine("CheckToSpawnEnimes");
    }
    void MakeInstance()
    {
        if (instance == null)
            instance = this;
    }
    void SpawnEnemies()
    {
        SpawnCannibals();
        SpawnBoars();
    }
    void SpawnCannibals()
    {
        int index = 0;
        for(int i=0;i<Cannibal_enemy_Count;i++)
        {
            if(index>=cannibal_SpawnPoints.Length)
            {
                index = 0;
            }
            Instantiate(cannibal_Prefab,cannibal_SpawnPoints[index].position,Quaternion.identity);
            index++;
        }
        Cannibal_enemy_Count = 0;
    }
    void SpawnBoars()
    {
        int index = 0;
        for (int i = 0; i < Boar_Enemy_Count; i++)
        {
            if (index >= boar_SpawnPoints.Length)
            {
                index = 0;
            }
            Instantiate(boar_Prefab, boar_SpawnPoints[index].position,Quaternion.identity);
            index++;
        }
        Boar_Enemy_Count = 0;
    }
    IEnumerator CheckToSpawnEnimes()
    {
        yield return new WaitForSeconds(wait_Before_Spawn_Eniemies);
        SpawnCannibals();
        SpawnBoars();
        StartCoroutine("CheckToSpawnEnimes");
    }
    public void EnemyDied(bool cannibal)
    {
        if(cannibal)
        {
            Cannibal_enemy_Count++;
            if (Cannibal_enemy_Count > initial_Cannibal_Count)
                Cannibal_enemy_Count = initial_Cannibal_Count;
        }
        else
        {
            Boar_Enemy_Count++;
            if(Boar_Enemy_Count>initial_Boar_Count)
            {
                Boar_Enemy_Count = initial_Boar_Count;
            }
        }
    }
        
    public void StopSpawning()
    {
        StopCoroutine("CheckToSpawnEnimes");
    }

}
