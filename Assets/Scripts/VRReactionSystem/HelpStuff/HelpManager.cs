using UnityEngine;
using System.Collections;

namespace VRReactionSystem
{
    public class HelpManager : MonoBehaviour
    {
        [SerializeField]
        HelpElement leftHelper = null;

        [SerializeField]
        HelpElement rightHelper = null;

        public void setLeftHelper(HelpElement element)
        {
            this.leftHelper = element;
        }

        public void setRightHelper(HelpElement element)
        {
            this.rightHelper = element;
        }
        
        public void ShowMessage(string msg)
        {
            if (leftHelper)
            {
                leftHelper.gameObject.SetActive(true);
                leftHelper._showHelpMsg(msg);
            }

            if (rightHelper)
            {
                rightHelper.gameObject.SetActive(true);
                rightHelper._showHelpMsg(msg);
            }

            StartCoroutine(DelayClearMsg());

        }

        public void ClearMessage()
        {
            if (leftHelper)
            {
                leftHelper._clearMsg();
                leftHelper.gameObject.SetActive(false);
            }

            if (rightHelper)
            {
                rightHelper._clearMsg();
                rightHelper.gameObject.SetActive(false);
            }

        }

        IEnumerator DelayClearMsg()
        {
            yield return new WaitForSeconds(2.7f);

            ClearMessage();
        }

        private void Awake()
        {
            DependManager.RegisterHelpManager(this);
        }

        private void Start()
        {
            ClearMessage();
        }

    }
}