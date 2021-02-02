using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ScoreSO : ScriptableObject
{
    public int hits;

    public void Reset()
    {
        hits = 0;
    }

    public void AddHit()
    {
        hits++;
    }
}
