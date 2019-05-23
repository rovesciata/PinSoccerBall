using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalGet : MonoBehaviour
{

    // GameManagerクラスを入れる変数
    public GameManager gameManager;
    // ボールのPrefabを入れる変数
    public GameObject ballPrefab;
    // ボールの初期位置
    Vector3 placePosition = new Vector3(0f, 0f, -0.65f);

    // 歓声を入れる変数
    AudioClip getGoalSound;
    AudioSource audioSource;
    AudioClip whistleSound;

    void Start()
    {
        // 歓声を取得
        getGoalSound = Resources.Load<AudioClip>("Audio/Goal");
        whistleSound = Resources.Load<AudioClip>("Audio/Whistle");
        audioSource = transform.GetComponent<AudioSource>();
    }


    // 点を入れた場合
    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Ball")
        {
            // ボールを消す
            Destroy(collision.gameObject);

            // ボールの残数が0より多い場合
            if (gameManager.totalTIme > 0)
            {
                // ボールを生成
                Instantiate(
                ballPrefab,
                placePosition,
                Quaternion.identity
                );
                // 残数を1減らす
                gameManager.blueScore++;

                // ボールの音を鳴らす
                audioSource.PlayOneShot(getGoalSound);
                audioSource.PlayOneShot(whistleSound);

            }
        }

    }
}
