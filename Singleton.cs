using UnityEngine;

namespace XenoWare.Assets.Scripts.Core
{
    public abstract class Singleton<T> : MonoBehaviour where T : Component
    {

        #region Fields

        /// <summary>
        /// The instance.
        /// </summary>
        private static T instance;

        #endregion

        #region Properties

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <value>The instance.</value>
        public static T Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = FindObjectOfType<T>();
                    if (instance == null)
                    {
                        GameObject obj = new GameObject();
                        obj.name = typeof(T).Name;
                        instance = obj.AddComponent<T>();
                    }
                }
                return instance;
            }
        }

        public static bool HasInstance
        {
            get
            {
                return instance != null;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Use this for initialization.
        /// </summary>
        protected virtual void Awake()
        {
            if (instance == null)
            {
                instance = this as T;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                gameObject.SetActive(false); //setting to false, as destroy is done after a render cycle, so in something like 1/1000 this object would still be seen before destroy, but now it is ignored
                Destroy(gameObject);
            }
        }

        public void DestroySingleton()
        {
            gameObject.SetActive(false); //setting to false, as destroy is done after a render cycle, so in something like 1/1000 this object would still be seen before destroy, but now it is ignored
            Destroy(gameObject);
            instance = null;
        }

        #endregion

    }
}