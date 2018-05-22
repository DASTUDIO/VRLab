using UnityEngine;
using System.Collections;

namespace VRReactionSystem
{
    public class DependManager
    {
        #region HidedSingleTon

        private DependManager() { }

        private static DependManager _Instance = new DependManager();

        #endregion

        #region  Facades

        public static void RegisterAnchorUIManager(AnchorUIManager aum)
        {
            _Instance.anchorUIManager = aum;
        }

        public static AnchorUIManager GetAnchorUIManager()
        {
            if (_Instance.anchorUIManager)
            {
                return _Instance.anchorUIManager;
            }
            else
            {
                return GameObject.FindObjectOfType<AnchorUIManager>();
            }
        }

        public static void RegisterHelpManager(HelpManager hm)
        {
            _Instance.helpManager = hm;
        }

        public static HelpManager GetHelpManager()
        {
            if (_Instance.helpManager)
            {
                return _Instance.helpManager;
            }
            else
            {
                return GameObject.FindObjectOfType<HelpManager>();
            }
        }

        public static void RegisterMainRoleTransform(Transform tf)
        {
            _Instance.MainRoleTransform = tf;
        }

        public static Transform GetMainRoleTransform()
        {
            return _Instance.MainRoleTransform;
        }

        #endregion

        #region Elements

        private AnchorUIManager anchorUIManager = null;

        private HelpManager helpManager = null;

        private Transform MainRoleTransform = null;

        #endregion

        #region Null Object Pattern

        //static AnchorUIManager blankAum = new AnchorUIManager();

        #endregion

    }
}