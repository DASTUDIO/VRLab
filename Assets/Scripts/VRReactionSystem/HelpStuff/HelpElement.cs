using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace VRReactionSystem
{
    public class HelpElement : MonoBehaviour
    {
        [SerializeField]
        Text text;

        public void _showHelpMsg(string msg)
        {
            text.text = msg;
        }

        public void _clearMsg()
        {
            text.text = "";
        }

        void Start()
        {
            switch (gameObject.name)
            {
                case ("HelperL"):
                    {
                        this.gameObject.transform.parent.parent.GetComponent<HelpManager>()
                            .setLeftHelper(this);
                    }
                    break;

                case ("HelperR"):
                    {
                        this.gameObject.transform.parent.parent.GetComponent<HelpManager>()
                            .setRightHelper(this);
                    }
                    break;
            }
        }
        
    }
}