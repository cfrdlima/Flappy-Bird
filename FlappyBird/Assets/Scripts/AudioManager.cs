using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public Image on;
    public Image off;
    int index;

    void Start(){

    }

    void Update(){
        if(index == 1){
            on.gameObject.SetActive(false);
        }else if(index == 0){
            off.gameObject.SetActive(true);
        }
    }

    public void ON(){
        index = 1;
        off.gameObject.SetActive(true);
        on.gameObject.SetActive(false);
    }

    public void OFF(){
        index = 0;
        on.gameObject.SetActive(false); 
        off.gameObject.SetActive(true);
    }
}
