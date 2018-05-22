using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace VRReactionSystem
{
    public class AnchorUIElement : MonoBehaviour
    {
        [SerializeField]
        Image anchorImg = null;

        public void _changeColor(AnchorUIManager.AnchorUIColor color)
        {
            if (anchorImg)
            {
                switch (color)
                {
                    case (AnchorUIManager.AnchorUIColor.Green):
                        {
                            anchorImg.color = Color.white;
                        }
                        break;

                    case (AnchorUIManager.AnchorUIColor.Red):
                        {
                            anchorImg.color = Color.red;
                        }
                        break;
                }
            }
        }

        private void Awake()                    // Initialize
        {
            if (transform.parent.parent.gameObject.GetComponent<AnchorUIManager>())
            {
                switch (gameObject.tag)
                {
                    case ("LeftAnchor"):
                        {
                            transform.parent.parent.gameObject.GetComponent<AnchorUIManager>()
                                .setLeftAnchor(this);
                        }
                        break;

                    case ("RightAnchor"):
                        {
                            transform.parent.parent.gameObject.GetComponent<AnchorUIManager>()
                                .setRightAnchor(this);
                        }
                        break;

                    default:
                        {
                            Debug.LogError("Tag of Anchor is Error!");
                        }
                        break;
                }
            }
        }
    }
}