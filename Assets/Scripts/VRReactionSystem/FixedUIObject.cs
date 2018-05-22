using UnityEngine;
using System.Collections;

namespace VRReactionSystem
{
    public class FixedUIObject : MonoBehaviour
    {
        [SerializeField]
        GameObject fixedUIObject = null;

        public void CloseFixedUI()
        {
            fixedUIObject.SetActive(false);
        }

        public void ShowFixedUI()
        {
            fixedUIObject.SetActive(true);
        }
        
    }
}