using UnityEngine;
using System.Collections;

namespace VRReactionSystem
{
    public class MainRoleTransform : MonoBehaviour
    {
        void Awake()
        {
            DependManager.RegisterMainRoleTransform(this.transform);
        }
    }
}