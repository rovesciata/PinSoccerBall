using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        Invoke("ShowAd", 2f);

        Invoke("GoTitle", 5f);
    }


    // タイトル画面に移動
    void GoTitle()
    {
        SceneManager.LoadScene("GameStart");
    }

    // 広告実装
    public void ShowAd()
    {
        if (Advertisement.IsReady())
        {
            Advertisement.Show();
        }
    }
}
