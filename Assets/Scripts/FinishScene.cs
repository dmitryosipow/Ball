using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FinishScene : MonoBehaviour
{
    public Text totalHits;

    public ScoreSO score;
    // Start is called before the first frame update
    void Start()
    {
        totalHits.text = score.hits.ToString();
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("Main");
    }
}
