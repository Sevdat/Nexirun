using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class timer : MonoBehaviour
{
    public TMP_Text time;
    public static float timeCount = 0; 
    string text = "";
    string record = "";
    public static string thanks = "";
    public static bool boxOut = false;
    public static string currentTime = "0.00";
    public static string currentLevel = "";
    string oldLevel = "";
    public static float thankYouTime;
    Color mainColor;
    bool colorBool = false;
    public Button reward;

    void Start(){
        reward.gameObject.SetActive(false);
    }
    
    void Update()
    {

        currentLevel = $"Level {forkliftMovement.level}";
        if (currentLevel != oldLevel) timeCount = 0;

        if (PlayerPrefs.HasKey(currentLevel)) {
            record = PlayerPrefs.GetString(currentLevel);
        } else record = "0.00";
        if (thanks != "" && Time.time - thankYouTime > 3f) thanks = "";
        timeCount += Time.deltaTime;
        if (boxOut){
            if (timeCount > float.Parse(record)){
                PlayerPrefs.DeleteKey(currentLevel);
                PlayerPrefs.SetString(currentLevel, $"{timeCount.ToString("0.00")}");
            }
            timeCount = 0;
            boxOut = false;
        }
        
        oldLevel = currentLevel;
        if (Time.time < 5) {
            if (!colorBool){
                mainColor = time.color;
                colorBool = true;
            }
            time.color = Color.red;
            time.text = $"Swipe up or down to change level";
            } else {
            if (colorBool){
                time.color = mainColor;
                colorBool = false;
                timeCount = 0;
                reward.gameObject.SetActive(true);
            }
                 if (timeCount > 3) currentLevel = "";
                time.text = $"{currentLevel} \n{record} \n{timeCount.ToString("0.00")} \n {thanks}";
            }
        
    }
}
