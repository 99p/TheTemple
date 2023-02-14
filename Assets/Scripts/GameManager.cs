using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class GameManager : MonoBehaviour
{

    private const int MAX_ORB = 10;
    private const int RESPAWN_TIME = 5;
    
    public GameObject orbPrefab;
    public GameObject canvasGame;
    public GameObject textScore;
    
    private int score = 0;
    private int nextScore = 100;
    
    private int currentOrb = 0;
    private DateTime lastDateTime;

    void Start()
    {
        currentOrb = 10;

        for(int i = 0; i < MAX_ORB; i++) {
            CreateOrb();
        }
        
        lastDateTime = DateTime.UtcNow;
        
        RefreshScoreText();
    }

    void Update()
    {
        if(currentOrb < MAX_ORB){
            // TimeSpanは時間を表す 00:00:27.0544630 の形式
            // deltaを保持できる
            TimeSpan timeSpan = DateTime.UtcNow - lastDateTime;
            
            // FromSeconds doubleを受け取ってTimeSpan化する
            if(timeSpan >= TimeSpan.FromSeconds(RESPAWN_TIME)){
                while(timeSpan >= TimeSpan.FromSeconds(RESPAWN_TIME)){
                    CreateNewOrb();
                    timeSpan -= TimeSpan.FromSeconds(RESPAWN_TIME);
                }
            }
        }
    }
    
    public void CreateNewOrb(){
        lastDateTime = DateTime.UtcNow;
        if(currentOrb >= MAX_ORB){
            return;
        }
        CreateOrb();
        currentOrb++;
    }
    
    public void CreateOrb(){
        GameObject orb = (GameObject)Instantiate(orbPrefab);
        orb.transform.SetParent(canvasGame.transform, false);
        orb.transform.localPosition = new Vector3(
            UnityEngine.Random.Range(-300.0f, 300.0f),
            UnityEngine.Random.Range(-140.0f, -500.0f),
            0f);
    }
    
    public void GetOrb(){
        score += 1;
        RefreshScoreText();
        currentOrb--;
    }
    
    void RefreshScoreText(){
        textScore.GetComponent<TextMeshProUGUI>().text = $"徳：{score} / {nextScore}";
    }

}
