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
        text.text = time.ToString("00:00");
        time += Time.deltaTime;
    }
}
