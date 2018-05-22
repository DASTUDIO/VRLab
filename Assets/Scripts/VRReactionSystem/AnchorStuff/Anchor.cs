using UnityEngine;
using System.Collections;

namespace VRReactionSystem
{
    public class Anchor : MonoBehaviour
    {
        [SerializeField]
        float fpsOptimizer = 100;

        float nextTime = 0;

        [SerializeField]
        Camera cameraObject;

        string currentCallBackKey = "";

        bool onReactionActive = false;

        bool helpMsgShowed = false;

        RaycastHit rh;

        void Update()
        {
            if (Time.time > nextTime)
            {
                if (fpsOptimizer == 0)
                {
                    nextTime = Time.time + 1.5f;
                }
                else
                {
                    nextTime = Time.time + 1 / fpsOptimizer;
                }

                Vector3 cameraCenterWorldPosition =
                    cameraObject.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));

                #region RayCast Stuff

                if (Physics.Raycast(new Ray(cameraCenterWorldPosition, transform.forward), out rh))
                {
                    if (rh.collider.gameObject.GetComponent<ReactAbleObject>())
                    {
                        DependManager.GetAnchorUIManager()
                            .SetAnchorsColor(AnchorUIManager.AnchorUIColor.Red);

                        currentCallBackKey = rh.collider.gameObject.GetComponent<ReactAbleObject>().key;

                        onReactionActive = true;

                        if (!helpMsgShowed)
                        {
                            DependManager.GetHelpManager().ShowMessage(
                                rh.collider.gameObject.GetComponent<ReactAbleObject>().helpMsg);
                        }

                        helpMsgShowed = true;
                    }
                    else
                    {
                        currentCallBackKey = "";

                        DependManager.GetAnchorUIManager()
                            .SetAnchorsColor(AnchorUIManager.AnchorUIColor.Green);

                        onReactionActive = false;

                        DependManager.GetHelpManager().ClearMessage();

                        helpMsgShowed = false;

                    }
                }
                else
                {
                    currentCallBackKey = "";

                    DependManager.GetAnchorUIManager()
                            .SetAnchorsColor(AnchorUIManager.AnchorUIColor.Green);

                    onReactionActive = false;

                    DependManager.GetHelpManager().ClearMessage();

                    helpMsgShowed = false;

                }

                #endregion

                #region Debug & Test

                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    OnFireButtonPressed();
                }

                #endregion
            }
        }
        
        protected void OnFireButtonPressed()
        {
            if (this.currentCallBackKey != "" && onReactionActive == true)
            {
                ReactionMapping.GetReactionByReactionObjectKey(this.currentCallBackKey)();
            }
        }

    }
}