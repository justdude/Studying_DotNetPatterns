using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace NewGameplay{
	
	public class ObjectVarietyPool<T> : IPool<T> where T:UnityEngine.Component {
	
		private GameObject[] _targets = null;
		private System.Collections.Queue _pool = null;
		
		public ObjectVarietyPool(GameObject[] targets)
		{
			this._targets	= targets;
			this._pool 		= new Queue();
			this.Add(false);
		}

		
		GameObject CreateElements (int pos)
		{
			GameObject obj = (GameObject) GameObject.Instantiate(this._targets[pos],
																 Vector3.zero,
																 Quaternion.identity);
			return obj;
		}
		
		private void Add(bool shuffle)
		{
			if (shuffle) ArraysHadler<GameObject>.Shuffle(ref this._targets);
			for(int i=0; i<this._targets.Length; i++)
			{
				var go = CreateElements(i);
				go.SetActive(false);
				_pool.Enqueue(go);
				
			}
		}
		
		public T GetElement()
		{
			return GetElement(Vector3.zero,false);
		}
		
		public T GetElement(Vector3 pos)
		{
			return GetElement(pos,false);
		}
		
		public T GetElement(bool shuffle)
		{
			return GetElement(Vector3.zero,shuffle);
		}
		
		public T GetElement(Vector3 pos,bool shuffle)
		{
			GameObject obj = null;
			T value = null;

			if (_pool.Count<=0)
			{
				Add(shuffle);
			}
				obj = (GameObject)this._pool.Dequeue();
				obj.SetActive(true);
				value = obj.GetComponent<T>();
				obj.transform.position = pos;
			return value;
		}
		
		public void ReleaseElement(GameObject element)
		{
			//if (_pool.Contains(element)) Debug.Log("contain "+element.name);
			element.SetActive(false);
			_pool.Enqueue(element);
		}
		
		public void ChangeTargets(GameObject[] newTargets)
		{
			this._pool.Clear();
			this._targets = newTargets;
		}
		
	}
}