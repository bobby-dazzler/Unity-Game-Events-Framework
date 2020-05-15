using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UnityEventsFramework {
	[System.Serializable]
	public abstract class RuntimeSetFactory : ScriptableObject {

        public string saveFileName = "";
		public string saveFolderName = "";

		[SerializeField]
		public List<FactoryContent> items = new List<FactoryContent>();

		//JsonSerializerSettings settings = new JsonSerializerSettings{TypeNameHandling = TypeNameHandling.All};

		public void Add(FactoryContent item) {
			//if (!items.Contains(item)) {
				items.Add(item);
			//}
		}

		public void Insert(int index, FactoryContent item) {
			items.Insert(index, item);
		}

		public void Remove(FactoryContent item) {
			if (items.Contains(item)) {
				items.Remove(item);
			}
		}

		public void Clear () {
			for (int i = items.Count - 1; i >= 0; i--) {
				items.RemoveAt(i);
			}
		}

		public int Count () {
			return items.Count;
		}

        public Transform gameObjectParent;

        List<GameObject>[] pools;

        //Scene scene;

        Transform recycleBin;

        public GameObject GetOrCreateInstance(int index) {
            if (gameObjectParent == null) {
                gameObjectParent = new GameObject().transform;
                gameObjectParent.transform.name = name;
                gameObjectParent.SetParent(GameObject.Find("Factory Content").transform);
            }
            if (pools == null) {
                CreatePools();
            }

            List<GameObject> pool = pools[index];
            int lastIndex = pool.Count - 1;
            GameObject obj;
            if (lastIndex >= 0) {
                Debug.Log("Creating from pool: " +  index);
                obj = pool[lastIndex];
                obj.SetActive(true);
                pool.RemoveAt(lastIndex);
            } else {
                obj = Instantiate(items[index].prefab);
            }
            
            return obj;
        }

        public void ReclaimInstance (GameObject obj, int index) {
            pools[index].Add(obj);
            //SceneManager.MoveGameObjectToScene(obj, scene);
            obj.transform.SetParent(recycleBin);
        }

        public void CreatePools() {
/*             if (!scene.isLoaded) {
                if (Application.isEditor) {
                    scene = SceneManager.GetSceneByName(name);
                    if (!scene.isLoaded) {
                        scene = SceneManager.CreateScene(name);
                    }
                } else {
                    scene = SceneManager.CreateScene(name);
                }
            } */
            
            if (recycleBin == null) {
                recycleBin = new GameObject().transform;
                recycleBin.transform.name = "Recycle Bin";
                recycleBin.SetParent(gameObjectParent);
            }
            pools = new List<GameObject>[items.Count];
            for (int i = 0; i < items.Count; i++) {
                pools[i] = new List<GameObject>();
            }
        }

        public void ClearPools() {
            if (pools != null) {
                for (int i = 0; i < pools.Length; i++) {
                    pools[i].Clear();
                }
            }
        }

        public void OnEnable() {
            CheckIDMatchesIndex();
        }

        public void CheckIDMatchesIndex() {
            for (int i = 0; i < items.Count; i++) {
                if (items[i].factoryIndex != i) {
                    Debug.Log("item " + items[i] + " at index " + i + " in the factory has an incorrect id. This will cause problems when saving and loading. Check what index it is in the runtime set and set it on the scriptable object");
                } 
            }
        }
    }
}