using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // スワイプの方向
    Vector2 startPos, endPos, direction;
    public float force = 3.0f;
    Rigidbody rb;
    [SerializeField]
    float throwForceInX = 1f; // x軸に対する強さ

    [SerializeField]
    float throwForceInY = 1f; // z軸に対する強さ

    // ボールの音を入れる変数
    AudioClip getBallSound;
    AudioSource audioSource;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // ボールの音を取得
        getBallSound = Resources.Load<AudioClip>("Audio/Shoot");
        audioSource = transform.GetComponent<AudioSource>();
    }


    void OnCollisionStay(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {

            rb.isKinematic = false;

            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                startPos = Input.GetTouch(0).position;

            }
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
            {

                // 指を話した位置を取得
                endPos = Input.GetTouch(0).position;

                // スワイプ方向を取得
                direction = startPos - endPos;

                rb.isKinematic = false;

                rb.AddForce(-direction.x * throwForceInX, -direction.y * throwForceInY, -1f, ForceMode.Impulse);
                // ボールを回転
                rb.AddTorque(100f, 0f, 0f, ForceMode.Impulse);

                // ボールの音を鳴らす
                audioSource.PlayOneShot(getBallSound);

            }
        } 
    }
}
