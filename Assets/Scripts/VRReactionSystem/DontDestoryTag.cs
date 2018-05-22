using UnityEngine;
using System.Collections;

public class DontDestoryTag : MonoBehaviour {

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
}
