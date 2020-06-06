using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour
{
    public int currentObject;

    public int correctObject;

    public Transform Object_1;

    public Transform Object_2;

    public Transform Object_3;

    public Transform Object_4;


    private void Start()
    {
        switch (currentObject)
        {
            case 1:
                //Instantiate(Object_1, transform);
                break;
            case 2:
                Instantiate(Object_2, transform);
                break;
            case 3:
                Instantiate(Object_3, transform);
                break;
            case 4:
                Instantiate(Object_4, transform);
                break;
        }
    }
}
