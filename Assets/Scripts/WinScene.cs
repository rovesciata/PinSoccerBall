using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("GoTitle", 3f);
    }

    // タイトル画面に移動
    void GoTitle()
    {
        SceneManager.LoadScene("GameStart");
    }
}
