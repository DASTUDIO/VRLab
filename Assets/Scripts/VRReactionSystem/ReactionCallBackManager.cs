using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

namespace VRReactionSystem
{
    public class ReactionCallBackManager : MonoBehaviour
    {
        [SerializeField]
        ReactAbleObject[] handleObjects;

        private void Awake()
        {
            //DontDestroyOnLoad(this);
        }

        private void Start()
        {
            //ReactionMapping.RegisterReaction(handleObjects[0].key, DebutTest);
            ReactionMapping.RegisterReaction(handleObjects[1].key, ChangeScenceToOutside);

            ReactionMapping.RegisterReaction(handleObjects[0].key, PickUpCube);
            //ReactionMapping.RegisterReaction(handleObjects[1].key, ThrownCube);
        }

        public void DebutTest()
        {
            Debug.Log("React Object called!");
        }

        public void PickUpCube()
        {
            Vector3 offset = new Vector3(0, -0.163f, 4.9434f);

            handleObjects[0].transform.position = DependManager.GetMainRoleTransform().position;

            handleObjects[0].transform.parent = DependManager.GetMainRoleTransform();

            handleObjects[0].transform.position += offset;

            if (handleObjects[0].gameObject.GetComponent<Rigidbody>())
                Destroy(handleObjects[0].gameObject.GetComponent<Rigidbody>());

            handleObjects[0].GetComponent<FixedUIObject>().CloseFixedUI();

        }

        public void ThrownCube()
        {
            float forceStrengh = 2000.0f;
            
            Vector3 forceDirection =
                    DependManager.GetMainRoleTransform().forward;
            
            handleObjects[0].gameObject.AddComponent<Rigidbody>();

            handleObjects[0].gameObject.GetComponent<Rigidbody>()
                .AddForce(forceStrengh * Vector3.Normalize(forceDirection));

            handleObjects[0].gameObject.transform.parent = null;
        }

        public void ChangeScenceToOutside()
        {
            SceneManager.LoadScene("outside");
        }

    }
}