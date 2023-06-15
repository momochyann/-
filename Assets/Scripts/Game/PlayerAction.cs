using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;
using System;
using Cinemachine;
public class PlayerAction : MonoBehaviour
{
    [SerializeField] List<Vector2> stopPoints = new List<Vector2>();
    [SerializeField]  float   epsilon;
    [SerializeField]  float  animationScale;
    float  currentAnimationScale;
    CinemachineDollyCart cinemachineDollyCart;
    SkeletonAnimation skeletonAnimation;
    Quaternion init;
    void Start()
    {
        cinemachineDollyCart = transform.parent.GetComponent<CinemachineDollyCart>();
        skeletonAnimation = GetComponent<SkeletonAnimation>();
        currentAnimationScale = animationScale;
        EventManager.AddListener<HandleResultEvent>(PlayMove);
        init = transform.rotation;
    }

    private void PlayMove(HandleResultEvent evt)
    {
        
        currentAnimationScale = animationScale;
        cinemachineDollyCart.enabled =true;
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.rotation = init;
    }
    private void FixedUpdate() {
        CheckPoint();
        AnimationContorl();
    }
    void AnimationContorl()
    {
        skeletonAnimation.timeScale  =    cinemachineDollyCart.m_Speed  * currentAnimationScale;
    }
    void CheckPoint()
    {
        for (int i = 0; i < stopPoints.Count; i++)
        {
             if ( Mathf.Abs(cinemachineDollyCart.m_Position  - stopPoints[i].x) < epsilon)
            {  
                
                currentAnimationScale  = 0;
                cinemachineDollyCart.enabled = false;
                ArivePointEvent evt = new ArivePointEvent();
                evt.actionIndex =  (int) stopPoints[i].y;
                Debug.Log(  evt.actionIndex);
                stopPoints[i] = Vector2.zero;
                EventManager.Broadcast(evt);
               
              
            }
        }
    }
    private void OnDestroy()
    {
        EventManager.RemoveListener<HandleResultEvent>(PlayMove);
    }
}
