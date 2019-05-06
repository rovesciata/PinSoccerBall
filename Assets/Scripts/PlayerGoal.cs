using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerGoal : MonoBehaviour
{
// GameManagerクラスを入れる変数
    public GameManager gameManager;
    // ボールのPrefabを入れる変数
    public GameObject ballPrefab;
    // ボールの初期位置
    Vector3 placePosition = new Vector3(0f, 0f, -0.65f);

    // ボールが下に落ちた場合
    void OnCollisionEnter (Collision collision) {
        // ボールを消す
        Destroy(collision.gameObject,1f);

        // ボールの残数が0より多い場合
        if (gameManager.life > 0)
        {
            // ボールを生成
            Instantiate(
            ballPrefab,
            placePosition,
            Quaternion.identity
            );
            // 残数を1減らす
            gameManager.life--;
        }
        // 残数が0になった場合
        else if (gameManager.life == 0)
        {
            // ゲームオーバー画面に移動
            SceneManager.LoadScene("GameOver");
        }
    }
}
