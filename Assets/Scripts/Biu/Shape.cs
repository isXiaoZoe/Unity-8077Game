using UnityEngine;

public class Shape : MonoBehaviour {

    private Rigidbody2D rigid;
    private Vector2[] velocitys;
    private Vector3[] pos;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();

        velocitys = new Vector2[4]
        {
            new Vector2(3, 0),
            new Vector2(-3, 0),
            new Vector2(0, 3),
            new Vector2(0, -3)
        };

        pos = new Vector3[4]
        {
            new Vector3(-5.4f, 0, 0),
            new Vector3(5.4f, 0, 0),
            new Vector3(0, -4.1f, 0),
            new Vector3(0, 4.1f, 0)
        };
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameObject.SetActive(false);
        DicPool.RecycleShape(this);
    }

    private void OnBecameInvisible()
    {
        gameObject.SetActive(false);
        DicPool.RecycleShape(this);
    }

    public void move()
    {
        int rand = Random.Range(0, 4);
        transform.position = pos[rand];
        rigid.velocity = velocitys[rand];
    }
}
