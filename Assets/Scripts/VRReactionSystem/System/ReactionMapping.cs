using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace VRReactionSystem
{
    public delegate void handlerMethod();

    public class ReactionMapping
    {
        #region HidedSingleTon

        private ReactionMapping() { }

        private static ReactionMapping _Instance = new ReactionMapping();

        #endregion

        #region Elements

        Dictionary<string, handlerMethod> _reactionMap =
            new Dictionary<string, handlerMethod>();

        #endregion

        #region Facade Methods

        public static void RegisterReaction(string reactionKey, handlerMethod method)
        {
            if (_Instance._reactionMap.ContainsKey(reactionKey))
            {
                _Instance._reactionMap[reactionKey] = method;
            }
            else
            {
                _Instance._reactionMap.Add(reactionKey, method);
            }
        }

        public static handlerMethod GetReactionByReactionObjectKey(string key)
        {
            if (_Instance._reactionMap.ContainsKey(key))
            {
                return _Instance._reactionMap[key];
            }
            else
            {
                Debug.LogError("UnRegister Key at Reaction Mapping : " + key);

                return null;
            }
        }

        #endregion

    }
}