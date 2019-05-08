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
    float throwForceInX = 1f; // to control throw force in X and Y directions

    [SerializeField]
    float throwForceInY = 1f; // to control throw force in Z direction

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
            //rb.velocity = Vector3.zero;
            //rb.angularVelocity = Vector3.zero;
            rb.isKinematic = false;

            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                startPos = Input.GetTouch(0).position;

            }
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
            {

                // getting release finger position
                endPos = Input.GetTouch(0).position;

                // calculating swipe direction in 2D space
                direction = startPos - endPos;

                // add force to ball rigidbody in 3D space depending on swipe time, direction and throw forces
                rb.isKinematic = false;

                rb.AddForce(-direction.x * throwForceInX, -direction.y * throwForceInY, -1f, ForceMode.Impulse);
                rb.AddTorque(100f, 0f, 0f, ForceMode.Impulse);

                // ボールの音を鳴らす
                audioSource.PlayOneShot(getBallSound);

            }
        } 
    }
}
