using UnityEngine;

namespace SingletonGeneric
{
    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T instance;

        public static T Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = FindObjectOfType<T>();

                    if (instance == null)
                    {
                        GameObject singletonObject = new GameObject();
                        instance = singletonObject.AddComponent<T>(); 
                        DontDestroyOnLoad(singletonObject);
                    }
                }

                return instance;
            }
        }

          void OnEnable()
        {
            if (instance == null)
            {
                instance = this as T; 
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
