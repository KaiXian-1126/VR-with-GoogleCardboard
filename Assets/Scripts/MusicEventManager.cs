using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicEventManager : MonoBehaviour
{
    public GameObject canvas;
    public Text text;
    public AudioSource audioSource;
    public bool startRecording = false;
    public float timeCounter = 2.0f;
    public string instruction = "say PLAY!";
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
        if (VoiceController.VC.voiceResult == "play" && gameObject.CompareTag("music_box"))
        {
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
                instruction = "say STOP!";
            }

        }
        if (VoiceController.VC.voiceResult == "stop" && gameObject.CompareTag("music_box"))
        {
            if (audioSource.isPlaying)
            {
                audioSource.Stop();
                instruction = "say PLAY!";
            }
        }
    }
    public void startMusicBoxListening()
    {
        canvas.SetActive(true);
        text.text = instruction;
        //canvas.SetActive(true);
        //audioSource.Play();
        VoiceController.VC.StartListening();
        startRecording = true;
    }
    public void stopMusicBoxListening()
    {
        //canvas.SetActive(false);
        if (startRecording)
        {
            canvas.SetActive(false);
            startRecording = false;
            VoiceController.VC.StopListening();
            timeCounter = 2.0f;
        }
    }
}
