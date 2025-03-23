using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class timer : MonoBehaviour
{
    public float time = 0;
    [SerializeField] private TextMeshProUGUI text;

    // Update is called once per frame
    void Update()
    {
        int minutes = Mathf.FloorToInt(time/60);
        int secondes = Mathf.FloorToInt(time%60);
        text.text = string.Format("{0:00}:{1:00}", minutes, secondes);
        time += Time.deltaTime;
    }
}
