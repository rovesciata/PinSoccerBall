using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalKeeper : MonoBehaviour
{
    Rigidbody rb;
    public GameObject ball;

    [SerializeField]
    float savingLeft = -10f;

    [SerializeField]
    float savingRight = 10f;

    Vector3 pos;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // ボールのx軸の位置によってキーパーを左右に移動させる
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Ball")
        {
            if (other.transform.position.x < 0)
            {

                this.rb.AddForce(savingLeft, 0, 0, ForceMode.Impulse);

            }
            else if (other.transform.position.x >= 0)
            {
                this.rb.AddForce(savingRight, 0, 0, ForceMode.Impulse);
            }
        }
        
    }
}
