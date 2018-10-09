using UnityEngine;

public class Character : MonoBehaviour {

    [HideInInspector]
    public GameCtrller gctrl;

    private void Update()
    {
        if (!gctrl.rotate)
        {
            return;
        }
        transform.RotateAround(Vector3.zero, Vector3.forward, 25 * Time.deltaTime);
    }
}
