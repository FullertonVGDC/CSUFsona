using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EdwardVaughnControl : MonoBehaviour
{
    float lockPos = 0;
    float speed = 10;
    Rigidbody2D rigid;
    bool endFlag = false;
    float countDown = 180;
    float jumpForce = 20;

    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        Cycle();
        transform.rotation = Quaternion.Euler(lockPos, lockPos, lockPos);
        //    Jump();

        Ending();
    }

    public void Cycle()
    {
        float movement = -1f * 5f;


        //countDown--;
        //rigid.position = new Vector3(speed, rigid.velocity.y, 0);

        if (countDown < 0)//rigid.position.x < 0)
        {
            endFlag = true;
            //countDown++;
            //rigid.velocity = new Vector3(-movement, rigid.velocity.y, 0);
        }
        else if (countDown > 180)//rigid.position.x > 18)
        {
            endFlag = false;
            //rigid.velocity = new Vector3(-movement, rigid.velocity.y, 0);
        }

        if (endFlag == true)
        {
            rigid.velocity = new Vector3(-movement, rigid.velocity.y, 0);
            rigid.gameObject.transform.localScale = new Vector3(5, 4, 0);
            countDown++;
        }
        else
        {
            rigid.velocity = new Vector3(movement, rigid.velocity.y, 0);
            rigid.gameObject.transform.localScale = new Vector3(-5, 4, 0);
            countDown--;
        }
    }

    void Jump()
    {

        rigid.velocity = new Vector2(0, jumpForce);
    }

    public void Ending()
    {
        if (rigid.position.y < -80)
        {
            SceneManager.LoadScene("GoodEnd");
        }
    }
}
