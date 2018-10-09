using System;
using System.Collections.Generic;
using UnityEngine;

public class DicPool: MonoBehaviour {

    public Shape[] prefShape;
    public Bullet prefBullet;

    private List<Shape> shapePool;
    private List<Bullet> bulletPool;

    private int len;

    public static Func<Shape> GetShape { get; private set; }
    public static Func<Bullet> GetBullet { get; private set; }
    public static Action<Shape> RecycleShape { get; private set; }
    public static Action<Bullet> RecycleBullet { get; private set; }

    private void Start()
    {
        shapePool = new List<Shape>();
        bulletPool = new List<Bullet>();

        len = prefShape.Length;

        GetBullet = getBullet;
        GetShape = getShape;
        RecycleBullet = recycleBullet;
        RecycleShape = recycleShape;
    }

    private Shape getShape()
    {
        Shape s = null;
        if(shapePool.Count > 0)
        {
            s = shapePool[0];
            s.gameObject.SetActive(true);
            shapePool.Remove(s);
        }
        else
        {
            s = Instantiate(prefShape[UnityEngine.Random.Range(0, len)]);
        }
        return s;
    }

    private Bullet getBullet()
    {
        Bullet b = null;
        if(bulletPool.Count > 0)
        {
            b = bulletPool[0];
            bulletPool.Remove(b);
            b.gameObject.SetActive(true);
        }
        else
        {
            b = Instantiate(prefBullet);
        }
        return b;
    }

    private void recycleShape(Shape s)
    {
        shapePool.Add(s);
    }

    private void recycleBullet(Bullet b)
    {
        bulletPool.Add(b);
    }

}
