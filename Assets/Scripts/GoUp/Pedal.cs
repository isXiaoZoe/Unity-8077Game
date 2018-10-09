using UnityEngine;

public class Pedal : MonoBehaviour {

    public GoupCtrl ctrl;
    public float dir;
    private float speedX = 2f;
    private float speedY = -0.8f;
    private float border = 5.87f;
    private Vector3 origin;
    private SpriteRenderer myrender;
    private Rigidbody2D rigid;

    private void Awake()
    {
        origin = transform.position;
        myrender = GetComponent<SpriteRenderer>();
        rigid = GetComponent<Rigidbody2D>();

        speedX *= dir;
        border *= dir;
    }

	private void Update ()
    {
        if(Mathf.Abs(rigid.position.x) >= Mathf.Abs(border))
        {
            rigid.position = new Vector2(-border, rigid.position.y);
        }
        
        if(rigid.position.y <= -4f)
        {
            rigid.position = new Vector2(rigid.position.x, 4);
        }
	}

    public void setPos(float n, float padding)
    {
        n *= dir;
        Vector3 pos = transform.position;
        pos.x += padding * n;
        transform.position = pos;
        myrender.color = ctrl.colors[Random.Range(0, 4)];
        gameObject.SetActive(true);
    }

    public void reset()
    {
        transform.position = origin;
        gameObject.SetActive(false);
    }

    public void move()
    {
        rigid.velocity = new Vector2(speedX, speedY);
    }

}
