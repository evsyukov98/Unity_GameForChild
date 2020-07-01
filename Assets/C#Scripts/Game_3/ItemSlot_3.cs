using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSlot_3 : MonoBehaviour
{
    public enum EnemyType
    {
        Air,
        Earth,
        Water,
        Insect,
        MaxSize
    }

    [SerializeField] public List<Transform> CorrectPrefabsAir;

    [SerializeField] public List<Transform> CorrectPrefabsEarth;

    [SerializeField] public List<Transform> CorrectPrefabsWater;

    [SerializeField] public List<Transform> CorrectPrefabInsect;

    [SerializeField] public Transform CurrentPrefab;
    
    public void CreatePrefab(EnemyType type, int numberOfPrefab)
    {
        switch (type)
        {
            case EnemyType.Air:
                CurrentPrefab = Instantiate(CorrectPrefabsAir[numberOfPrefab], transform);
                break;

            case EnemyType.Earth:
                CurrentPrefab = Instantiate(CorrectPrefabsEarth[numberOfPrefab], transform);
                break;

            case EnemyType.Water:
                CurrentPrefab = Instantiate(CorrectPrefabsWater[numberOfPrefab], transform);
                break;

            case EnemyType.Insect:
                CurrentPrefab = Instantiate(CorrectPrefabInsect[numberOfPrefab], transform);
                break;
        }
    }
    
}
