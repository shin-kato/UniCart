using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lap : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SaveScript.LastLapM = SaveScript.LapTimeMinutes;
            SaveScript.LastLapS = SaveScript.LapTimeSeconds;
            SaveScript.LapNumber++;
            SaveScript.LapChange = true;

            if (SaveScript.LapNumber == 2)
            {
                SaveScript.BestLapTimeM = SaveScript.LastLapM;
                SaveScript.BestLapTimeS = SaveScript.LastLapS;
            }
        }
    }
}
