using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSlot_3 : MonoBehaviour
{
    public enum prefabType
    {
        CorrectAir,
        CorrectEarth,
        CorrectWater,
        CorrectInsect,
        MaxSize
    }

    public List<Transform> correctPrefabsAir;

    public List<Transform> correctPrefabsEarth;
    
    public List<Transform> correctPrefabsWater;

    public List<Transform> correctPrefabInsect;

    public Transform currentPrefab;
    
    public void CreatePrefab(prefabType type, int numberOfPrefab)
    {
        switch (type)
        {
            case prefabType.CorrectAir:
                currentPrefab = Instantiate(correctPrefabsAir[numberOfPrefab], transform);
                break;

            case prefabType.CorrectEarth:
                currentPrefab = Instantiate(correctPrefabsEarth[numberOfPrefab], transform);
                break;

            case prefabType.CorrectWater:
                currentPrefab = Instantiate(correctPrefabsWater[numberOfPrefab], transform);
                break;

            case prefabType.CorrectInsect:
                currentPrefab = Instantiate(correctPrefabInsect[numberOfPrefab], transform);
                break;
        }
    }
    
}
