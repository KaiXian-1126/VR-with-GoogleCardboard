using System.Collections;
using System.Collections.Generic;
using TextSpeech;
using UnityEngine;
using UnityEngine.Android;
public class VoiceController : MonoBehaviour
{
    const string LANG_CODE = "en-US";
    public static VoiceController VC;
    public string voiceResult;
    // Start is called before the first frame update
    void Awake()
    {
        if (VC == null)
            VC = this;
    }
    void Start()
    {
        Setup(LANG_CODE);
#if UNITY_ANDROID
        SpeechToText.instance.onResultCallback = OnPartialSpeechResult;
#endif
        SpeechToText.instance.onResultCallback = OnFinalSpeechResult;

    }

    // Update is called once per frame
    void Update()
    {

    }
    void Setup(string code)
    {
        SpeechToText.instance.Setting(code);
    }
    void CheckPermission()
    {
#if UNITY_ANDROID
        if (!Permission.HasUserAuthorizedPermission(Permission.Microphone))
            Permission.RequestUserPermission(Permission.Microphone);
#endif

    }
    public void StartListening()
    {
        Debug.Log("Start Listening");
        SpeechToText.instance.StartRecording();
    }
    public void StopListening()
    {
        Debug.Log("Stop Listening");
        SpeechToText.instance.StopRecording();
    }
    void OnFinalSpeechResult(string result)
    {
        Debug.Log("result:" + result);
        if (result != "" || result != null)
            voiceResult = result;
    }
    void OnPartialSpeechResult(string result)
    {
        Debug.Log("result:" + result);
        if (result != "" || result != null)
            voiceResult = result;
    }
}
