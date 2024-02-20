using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    private void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 11;
        this.transform.position = Camera.main.ScreenToWorldPoint(mousePos);
    }
}
