﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FPSDisplay : MonoBehaviour
{
    public float updateInterval = 0.5F;

    private float accum = 0; // FPS accumulated over the interval
    private int frames = 0; // Frames drawn over the interval
    private float timeleft; // Left time for current interval

    Text text;

    void Start()
    {
        text = GetComponent<Text>();
        timeleft = updateInterval;
    }

    void Update()
    {
        timeleft -= Time.deltaTime;
        accum += Time.timeScale / Time.deltaTime;
        ++frames;

        if (timeleft <= 0.0)
        {
            // display two fractional digits (f2 format)
            float fps = accum / frames;
            string format = System.String.Format("{0:F2}", fps);
            text.text = format;

            timeleft = updateInterval;
            accum = 0.0F;
            frames = 0;
        }
    }

    //void OnGUI()
    //{
    //    int w = Screen.width, h = Screen.height;

    //    GUIStyle style = new GUIStyle();

    //    Rect rect = new Rect(0, 0, w, h * 2 / 100);
    //    style.alignment = TextAnchor.UpperLeft;
    //    style.fontSize = h * 2 / 100;
    //    style.normal.textColor = new Color(0.0f, 0.0f, 0.5f, 1.0f);
    //    float msec = deltaTime * 1000.0f;
    //    float fps = 1.0f / deltaTime;
    //    string text = string.Format("{0:0.0} ms ({1:0.} fps)", msec, fps);
    //    GUI.Label(rect, text, style);
    //}
}