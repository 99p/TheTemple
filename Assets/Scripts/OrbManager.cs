using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbManager : MonoBehaviour
{
    private GameObject gameManager;

    void Start()
    {
        gameManager = GameObject.Find("GameManager");
    }

    void Update()
    {
        
    }

    public void TouchOrb(){
        // Pointer Enter時の条件を指定している
        // 左クリックを押下しながらPointer Enterしていない場合抜ける
        if(Input.GetMouseButton(0) == false){
            return;
        }
        
        gameManager.GetComponent<GameManager>().GetOrb();
        Destroy(this.gameObject);
    }
}
