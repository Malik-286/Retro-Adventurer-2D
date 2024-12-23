using UnityEngine;

namespace Helios.GUI {
    public class SingletonMono<T> : MonoBehaviour where T : Component {
        private static T _instance;

        public static T Instance {
            get {
                if (_instance == null) {
                    var objs = FindObjectsOfType(typeof(T)) as T[];
                    if (objs.Length > 0)
                        _instance = objs[0];
                    if (objs.Length > 1) {
                        Debug.LogError("There is more than one " + typeof(T).Name + " in the scene.");
                    }
                    if (_instance == null) {
                        //GameObject obj = new GameObject();
                        //obj.hideFlags = HideFlags.HideAndDontSave;
                        //_instance = obj.AddComponent<T>();
                        Debug.LogError("Null instance " + typeof(T).Name + " in the scene");
                    }
                }
                return _instance;
            }
        }

        /// <summary>
        /// When Unity quits, it destroys objects in a random order.
        /// In principle, a Singleton is only destroyed when application quits.
        /// If any script calls Instance after it have been destroyed, 
        ///   it will create a buggy ghost object that will stay on the Editor scene
        ///   even after stopping playing the Application. Really bad!
        /// So, this was made to be sure we're not creating that buggy ghost object.
        /// </summary>
        protected virtual void OnDestroy() {
            _instance = null;
        }

        protected virtual void OnApplicationQuit() {
        }

        public static bool IsNull() {
            return _instance == null;
        }
    }

    public class Singleton<T> where T : new() {
        static T _instance = default(T);

        public static T Instance {
            get {
                if (_instance == null)
                    _instance = new T();
                return _instance;
            }
        }
    }

    public class SingletonPersistent<T> : MonoBehaviour
        where T : Component {
        private static T instance;
        public static T Instance {
            get {
                if (instance == null) {
                    T[] managers = Object.FindObjectsOfType(typeof(T)) as T[];
                    if (managers.Length != 0) {
                        if (managers.Length == 1) {
                            instance = managers[0];
                            instance.gameObject.name = typeof(T).Name;
                            return instance;
                        }
                        else {
                            Debug.LogError("Class " + typeof(T).Name + " exists multiple times in violation of singleton pattern. Destroying all copies");
                            foreach (T manager in managers) {
                                Destroy(manager.gameObject);
                            }
                        }
                    }
                    var go = new GameObject(typeof(T).Name, typeof(T));
                    instance = go.GetComponent<T>();
                    DontDestroyOnLoad(go);
                }
                return instance;
            }
            set {
                instance = value as T;
            }
        }

        public virtual void Awake() {
            DontDestroyOnLoad(gameObject);
        }
    }
}