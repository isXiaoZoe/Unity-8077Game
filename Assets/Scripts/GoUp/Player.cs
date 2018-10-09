using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour {

    private int dir = 0;
    private float vx = 300;
    private Vector3 origin;
    private Rigidbody2D rigid;
    private bool first = true;
    private bool over = false;

    private void Awake()
    {
        origin = transform.position;
        rigid = GetComponent<Rigidbody2D>();
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        dir = (collision.gameObject.tag == "1" ? 1 : -1);
        if(first)
        {
            first = false;
            return;
        }
        if(rigid.transform.position.y <= collision.transform.position.y + 0.5f)
        {
            over = true;
            GoupCtrl.GameOver();
        }
        else
        {
            GoupCtrl.AddScore();
        }
    }

    private void OnBecameInvisible()
    {
        if (first)
            return;
        over = true;
        GoupCtrl.GameOver();
    }
    
    public void falldown()
    {
        rigid.WakeUp();
    }

    public void reset()
    {
        first = true;
        over = false;
        rigid.Sleep();
        transform.position = origin;
    }

    public void OnBtnTap()
    {
        if (!over)
            rigid.AddForce(new Vector2(vx * dir, 1500f));
    }

}
