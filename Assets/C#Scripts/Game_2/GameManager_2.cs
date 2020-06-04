using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_2 : MonoBehaviour
{
    public Spot spot_1;
    public Spot spot_2;
    public Spot spot_3;
    public Spot spot_4;

    void Start()
    {
        SpotFill();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Victory()
    {
        // будут сравниваться на корректность
        // классы Spot которые 
    }

    private void SpotFill()
    {
        int[] correctMass = new int[4];
        correctMass = RandomMass();

        int[] currentMass = new int[4];
        currentMass = RandomMass();

        while (correctMass == currentMass)
        {
            currentMass = RandomMass();
        }

        spot_1.correctObject = correctMass[0];
        spot_2.correctObject = correctMass[1];
        spot_3.correctObject = correctMass[2];
        spot_4.correctObject = correctMass[3];

        spot_1.currentObject = currentMass[0];
        spot_2.currentObject = currentMass[1];
        spot_3.currentObject = currentMass[2];
        spot_4.currentObject = currentMass[3];
    }

    private int[] RandomMass()
    {
        int[] newMass = new int[4];

        for (int i = 0; i < newMass.Length; i++)
        {
            bool newNumber = true;

            while (newNumber == true)
            {
                int randomInt = Random.Range(1, 4+1);

                if (newMass[0] != randomInt &&
                    newMass[1] != randomInt &&
                    newMass[2] != randomInt &&
                    newMass[3] != randomInt)
                {
                    newMass[i] = randomInt;
                    newNumber = false;
                }
            }
        }

        return newMass;
    }
}
