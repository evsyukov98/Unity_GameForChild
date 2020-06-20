using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class GameManager_2 : MonoBehaviour
{
    public ItemSlot slot_1;
    public ItemSlot slot_2;
    public ItemSlot slot_3;
    public ItemSlot slot_4;

    public static int StartDelayTime = 4;

    public Transform StartText;

    public Transform TimerText;

    public Transform WinText;

    public bool endGame = false;

    private IEnumerator Start()
    {
        SlotFill();

        yield return new WaitForSeconds(1);
        TimerText.GetComponent<Text>().text = "3";
        yield return new WaitForSeconds(1);
        TimerText.GetComponent<Text>().text = "2";
        yield return new WaitForSeconds(1);
        TimerText.GetComponent<Text>().text = "1";
        yield return new WaitForSeconds(1);
        TimerText.GetComponent<Text>().text = "";

        StartText.gameObject.SetActive(false);
    }

    void Update()
    {
        if (slot_1.GetComponentInChildren<DragItem>() != null &&
            slot_2.GetComponentInChildren<DragItem>() != null &&
            slot_3.GetComponentInChildren<DragItem>() != null &&
            slot_4.GetComponentInChildren<DragItem>()!= null)
        {
            if (slot_1.correctObject ==
                slot_1.GetComponentInChildren<DragItem>().ItemID &&
                slot_2.correctObject ==
                slot_2.GetComponentInChildren<DragItem>().ItemID &&
                slot_3.correctObject ==
                slot_3.GetComponentInChildren<DragItem>().ItemID &&
                slot_4.correctObject ==
                slot_4.GetComponentInChildren<DragItem>().ItemID)
            {
                if (endGame == false)
                {
                    endGame = true;
                    EndGame();
                }
            }
        }
    }

    private void EndGame()
    {
        WinText.gameObject.SetActive(true);
    }

    private void SlotFill()
    {
        int[] correctMass = new int[4];
        correctMass = RandomMass();

        int[] currentMass = new int[4];
        currentMass = RandomMass();

        while (correctMass == currentMass)
        {
            currentMass = RandomMass();
        }

        slot_1.correctObject = correctMass[0];
        slot_2.correctObject = correctMass[1];
        slot_3.correctObject = correctMass[2];
        slot_4.correctObject = correctMass[3];

        slot_1.currentObject = currentMass[0];
        slot_2.currentObject = currentMass[1];
        slot_3.currentObject = currentMass[2];
        slot_4.currentObject = currentMass[3];
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
