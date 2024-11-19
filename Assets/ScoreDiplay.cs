using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreDiplay : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI score;
    [SerializeField] private Timer timer;

    // Update is called once per frame
    void OnEnable()
    {
        score.text = string.Format("Score:{0}", Mathf.RoundToInt(timer.timeCounter) * 0.1);
    }
}
