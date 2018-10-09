using UnityEngine;

public class Bullet : MonoBehaviour {

    [HideInInspector]
    public Vector3 dirt = Vector3.zero;

    private Vector3 origin;
    private Quaternion rotation;

    private void Awake()
    {
        origin = transform.position;
        rotation = transform.rotation;
    }

    private void Update()
    {
        transform.Translate(dirt * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        destroy();
    }

    private void OnBecameInvisible()
    {
        destroy();
    }

    private void reset()
    {
        gameObject.SetActive(false);
        transform.position = origin;
        transform.rotation = rotation;
    }

    private void destroy()
    {
        reset();
        DicPool.RecycleBullet(this);
    }
}
