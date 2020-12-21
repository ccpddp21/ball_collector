using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerReset : MonoBehaviour
{
    public void ResetPosition()
    {
        this.transform.position = new Vector3(40, 2, -40);
    }
}
