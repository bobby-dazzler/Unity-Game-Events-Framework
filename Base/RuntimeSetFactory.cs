using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UnityEventsFramework {
	[System.Serializable]
	public abstract class RuntimeSetFactory<T> : ScriptableObject {

        public string saveFileName = "";
		public string saveFolderName = "";

		[SerializeField]
		public List<T> items = new List<T>();

		//JsonSerializerSettings settings = new JsonSerializerSettings{TypeNameHandling = TypeNameHandling.All};

		public void Add(T item) {
			//if (!items.Contains(item)) {
				items.Add(item);
			//}
		}

		public void Insert(int index, T item) {
			items.Insert(index, item);
		}

		public void Remove(T item) {
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


        List<GameObject>[] pools;

        //Scene scene;

        Transform recycleBin;

        public GameObject GetInstance(GameObject prefab, int index) {
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
                obj = Instantiate(prefab);
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
                recycleBin.transform.name = "Tiles Recycle Bin";
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
    }

    
/*         protected T GetTileObject(int index, int materialId, Vector3 position, Vector3 rotation) {
            if (pools == null) {
                CreatePools();
            }
            
            GameObject obj;

            List<GameObject> pool = pools[index];
            int lastIndex = pool.Count - 1;
            if (lastIndex >= 0) {
                Debug.Log("Creating from pool");
                obj = pool[lastIndex];
                obj.SetActive(true);
                obj.transform.position = position;
                obj.transform.Rotate(rotation);
                pool.RemoveAt(lastIndex);
            } else {
                obj = Instantiate(items[index].prefab, position, Quaternion.identity) as GameObject;
                obj.transform.Rotate(rotation);
            }

            if (obj.GetComponent<MeshRenderer>() != null) {
                //obj.GetComponent<MeshRenderer>().material = materials[materialId];
            }
            return obj;
        } */

/*         public void ReclaimTileObject(GridTile tile) {
            if (pools == null) {
                CreatePools();
            }

            GameObject obj = tile.gridTileObject.gameObject;
            for (int i = 0; i < 6; i++) {
                tile.SetProjector(false, i);
            }
            pools[tile.tileType.tileTypeId].Add(obj);
            obj.SetActive(false);
            //obj.SetParent(recycleBin);
            tile.gridTileObject = null;
        } */
}