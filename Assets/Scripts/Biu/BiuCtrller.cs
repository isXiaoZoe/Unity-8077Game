using UnityEngine;

public class BiuCtrller : MonoBehaviour {

    private void Start()
    {
        InvokeRepeating("newShape", 1f, 1f);
    }

    private void Update()
    {
        if (Input.anyKey)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                Bullet b = DicPool.GetBullet();
                b.transform.Rotate(Vector3.forward * -90);
                b.dirt = Vector3.right * -5;
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                Bullet b = DicPool.GetBullet();
                b.transform.Rotate(Vector3.forward * 90);
                b.dirt = Vector3.right * -5;
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                Bullet b = DicPool.GetBullet();
                b.dirt = Vector3.right * -5;
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                Bullet b = DicPool.GetBullet();
                b.transform.Rotate(Vector3.forward * 180);
                b.dirt = Vector3.right * -5;
            }
        }
    }

    private void newShape()
    {
        Shape s = DicPool.GetShape();
        s.move();
    }
}
