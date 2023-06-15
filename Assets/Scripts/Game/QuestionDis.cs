using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionDis : VideoDis
{
    Image backImage;
    
    // Start is called before the first frame update
    protected override void Start()
    {
        
        backImage = transform.Find("Back").GetComponent<Image>();
        EventManager.AddListener<ArivePointEvent>(OnArive);
        
    }

    // Update is called once per frame
    protected override void OnArive(ArivePointEvent evt)
    {
        //    Debug.Log("questionInit");
        if(evt.actionIndex <100)
        return;
        questionInit();
        
    }
    private void Update() {
        
    }
    void questionInit()
    {
        backImage.gameObject.SetActive(true);
        
    }
    protected override void OnDestroy() {
        base.OnDestroy();
    }   
}
