using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    void DestroyGameObject()
    {
        var parent = transform.parent.gameObject;
        var parentOfParent = parent.gameObject.transform.parent.gameObject;
        Destroy(parentOfParent);
    }
}
