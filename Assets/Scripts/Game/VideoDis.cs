using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI.ProceduralImage;

public class VideoDis : MonoBehaviour
{

    [SerializeField]  VideoClip[] videoClips;
    VideoPlayer videoPlayer;
    GameObject videoDis;
    ProceduralImage proceduralImage;
    // Start is called before the first frame update
    protected virtual void Start()
    {
        videoPlayer = transform.Find("VidioDIs").Find("Vidio").GetComponent<VideoPlayer>();
        videoDis = transform.Find("VidioDIs").gameObject;
        proceduralImage = videoDis.GetComponent<ProceduralImage>();
        EventManager.AddListener<ArivePointEvent>(OnArive);
        // videoPlayer.gameObject.SetActive(false);
    }

    protected virtual void OnArive(ArivePointEvent evt)
    {
        
        if (evt.actionIndex > 99)
            return;
        videoDis.SetActive(true);
        videoPlayer.clip = videoClips[evt.actionIndex];
        videoPlayer.Prepare();
        videoPlayer.Play();

    }

    // Update is called once per frame
    void Update()
    {
        if (videoPlayer.isPlaying)
        {
            if ((ulong)videoPlayer.frame >= videoPlayer.frameCount - 1)
            {
                sendResult();
            }
        }
        if(Input.GetKeyDown(KeyCode.X))
        {
            sendResult();
        }
    }
    
    void sendResult()
    {
        videoPlayer.Pause();
        videoDis.SetActive(false);
        HandleResultEvent handleResultEvent = new HandleResultEvent();
        EventManager.Broadcast(handleResultEvent);
    }
    protected virtual void OnDestroy()
    {
        EventManager.RemoveListener<ArivePointEvent>(OnArive);
    }

}
