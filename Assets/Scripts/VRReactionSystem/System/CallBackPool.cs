using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

namespace VRReactionSystem
{
    public class CallBackPool
    {
        public static void OpenDoorAndChangeSence()
        {
            SceneManager.LoadScene("outside");
        }

    }
}