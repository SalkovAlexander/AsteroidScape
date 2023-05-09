using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointSystem : MonoBehaviour
{
    [SerializeField] private List<GameObject> ringList;
    private int currentRingIndex = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "CheckPoint")
        {
            if (other.gameObject == ringList[currentRingIndex])
            {
                currentRingIndex++;
                Debug.Log("You passed ring " + currentRingIndex);

                if (currentRingIndex >= ringList.Count)
                {
                    Debug.Log("You passed all rings");
                    currentRingIndex = 0;
                }
            }
            else
            {
                Debug.Log("You missed the ring!");
                currentRingIndex--;
                if (currentRingIndex < 0)
                {
                    currentRingIndex = 0;
                }
            }
        }
    }
}