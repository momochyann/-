using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using static Types;

public class VideoController : MonoBehaviour
{
    private VideoPlayer videoPlayer;
    double video_time, currentTime;

    // Start is called before the first frame update
    void Start()
    {
        VideoInit();
        VideoPlay();
    }

    // Update is called once per frame
    void Update()
    {
        VideoCheck();
        if (Input.GetKeyDown(KeyCode.Space) && videoPlayer != null)
        {
            if (videoPlayer.isPlaying)
            {
                videoPlayer.Pause(); // ��ͣ
            }
            else
            {
                videoPlayer.Play(); // ����
            }
        }
        if (Input.GetKeyDown(KeyCode.X) ){
            Destroy(this.gameObject);
        }
    }

    private void VideoInit()
    {
        
        this.transform.parent = GameObject.Find("CreatPoint").transform;
        Debug.Log(this.transform.parent.name);
        this.transform.localScale = new Vector3(1, 1, 1);
        videoPlayer = this.GetComponent<VideoPlayer>();
        videoPlayer.clip = Resources.Load<VideoClip>(UserMode.Instance.VedioPath+UserMode.Instance.VedioName);
        videoPlayer.Prepare();                                                                                                      // ��������׼������߿�ʼ����ʱ���ٶȣ�
        video_time = videoPlayer.clip.length;
        currentTime = 0;
    }

    private void VideoPlay()
    {
        videoPlayer.Play();
    }


    private void VideoCheck()
    {
        currentTime += Time.deltaTime;
        if (currentTime >= video_time)
        {
            Destroy(this.gameObject);
        }

    }


    void OnDestroy(){
        RedArmyStateEvent redArmyStateEvent = new RedArmyStateEvent();
        redArmyStateEvent.redArmyState = RedArmyState.Move;
        EventManager.Broadcast(redArmyStateEvent);
    }

}