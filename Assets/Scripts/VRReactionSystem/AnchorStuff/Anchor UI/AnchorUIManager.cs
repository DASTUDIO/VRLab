using System;
using UnityEngine;
using System.Collections;

namespace VRReactionSystem
{
    public class AnchorUIManager : MonoBehaviour
    {
        #region Elements

        [SerializeField]
        AnchorUIElement leftAnchor = null;

        [SerializeField]
        AnchorUIElement rightAnchor = null;

        public enum AnchorUIColor : byte
        {
            Green = 0,                          // idle
            Red = 1                             // actived
        }

        #endregion

        #region Beans do not call manually

        public void setLeftAnchor(AnchorUIElement aue)
        {
            this.leftAnchor = aue;
        }

        public void setRightAnchor(AnchorUIElement aue)
        {
            this.rightAnchor = aue;
        }

        #endregion

        #region Facade Methods

        public void SetAnchorsColor(AnchorUIManager.AnchorUIColor color)
        {
            if (leftAnchor)
                leftAnchor._changeColor(color);

            if (rightAnchor)
                rightAnchor._changeColor(color);
        }

        #endregion

        #region Internal Methods

        void Awake()                        //Initialize
        {
            DependManager.RegisterAnchorUIManager(this);
        }

        #endregion

    }
}