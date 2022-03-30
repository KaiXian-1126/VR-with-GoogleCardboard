using System.Collections;
using System.Collections.Generic;
using TextSpeech;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.UI;

public class CandleEventManager : MonoBehaviour
{
    public string instruction = "say ON!";
    // Start is called before the first frame update
    public GameObject canvas, candleLight, fire;
    public Text text;
    public bool startRecording = false;

    public float timeCounter = 2.0f;

    void Update()
    {
        if (startRecording)
        {
            timeCounter -= Time.deltaTime;
        }
        if (timeCounter <= 0)
        {
            canvas.SetActive(false);
            startRecording = false;
            VoiceController.VC.StopListening();
            timeCounter = 2.0f;
        }
        if (VoiceController.VC.voiceResult == "on" && gameObject.CompareTag("candle"))
        {
            instruction = "say OFF!";
            if (!candleLight.activeSelf)
                candleLight.SetActive(true);
            if (!fire.activeSelf)
                fire.SetActive(true);
        }
        if (VoiceController.VC.voiceResult == "off" && gameObject.CompareTag("candle"))
        {
            instruction = "say ON!";
            if (candleLight.activeSelf)
                candleLight.SetActive(false);
            if (fire.activeSelf)
                fire.SetActive(false);
        }
    }
    public void StartListening()
    {
        canvas.SetActive(true);
        text.text = instruction;
        VoiceController.VC.StartListening();
        startRecording = true;
    }
    public void StopListening()
    {
        canvas.SetActive(false);
        if (startRecording)
        {
            startRecording = false;
            VoiceController.VC.StopListening();
            timeCounter = 2.0f;
        }
    }
}
