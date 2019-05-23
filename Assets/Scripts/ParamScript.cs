using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ParamScript : MonoBehaviour
{
    // GameManagerクラスを入れる変数
    public GameManager gameManager;
    // GUIStyleを入れる変数
    public GUIStyle guiStyle;
    // トータル時間
    public float totalTime;
    // 秒数
    int seconds;


    // 時間、スコア数を表示
    void OnGUI()
    {
        Rect position1 = new Rect(10, 10, 200, 40);
        Rect position2 = new Rect(10, 50, 200, 40);

        // 時間を表示
        GUI.Label(position1, "Time : " + seconds.ToString(), guiStyle);
        // スコア数を表示
        GUI.Label(position2, "BLUE " + gameManager.blueScore.ToString() + " - " + gameManager.greenScore.ToString() + " GREEN ", guiStyle);
    }

    // Update is called once per frame
    void Update()
    {
        // 時間の経過
        totalTime -= Time.deltaTime;
        seconds = (int)totalTime;

        // 時間が0になった時
        if (seconds == 0)
        {
            
            if (gameManager.blueScore > gameManager.greenScore)
            {
                SceneManager.LoadScene("WinScene");
            }
            else
            {
                // ゲームオーバー
                SceneManager.LoadScene("GameOver");

            }

        }
    }

}
