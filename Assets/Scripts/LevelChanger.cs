using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    public int blocksCount;


    public void BlockCreated()
    {
        blocksCount++;
        print("block count " + blocksCount);
    }

    public void BlockDestroyed()
    {
        blocksCount--;
        print("block count " + blocksCount);
        if (blocksCount <= 0)
        {
            //УРОВЕНЬ ПРОЙДЕН
            /*int index = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(index + 1);
            GameManager gM = FindObjectOfType<GameManager>();
            gM.RestartLevel();*/
        }
    }
}