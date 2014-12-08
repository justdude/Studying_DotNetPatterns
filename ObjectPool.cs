using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace NewGameplay{
	
	
	public interface IPool<T> where T: UnityEngine.Component
	{
		T GetElement();
		T GetElement(Vector3 pos);
		void ReleaseElement(GameObject element);
	}
	
	public class ObjectPool<T> : IPool<T> where T:UnityEngine.Component {
	
		private GameObject _target = null;
		private ArrayList _pool = null;
		private int position = 0;
		private int size = 0;
		
		public ObjectPool(GameObject target,int size = 10)
		{
			this._target	= target;
			this._pool 		= new ArrayList();
			this.position 	= 0;
			this.size		= size;
			Add(this.size);
		}

		GameObject CreateElement (Vector3 pos,Quaternion rot)
		{
			GameObject obj = (GameObject) GameObject.Instantiate(this._target,
																 pos,
																 rot);
			return obj;
		}
		
		GameObject CreateElement ()
		{
			GameObject obj = (GameObject) GameObject.Instantiate(this._target,
																 Vector3.zero,
																 Quaternion.identity);
			return obj;
		}
		
		private void Add(int count)
		{
			for(int i=0; i<count; i++)
			{
				GameObject obj = CreateElement ();
				obj.SetActive(false);
				_pool.Add(obj);
				position++;
			}
			position--;
		}
		
		public T GetElement()
		{
			return GetElement(Vector3.zero);
		}
		
		public T GetElement(Vector3 pos)
		{
			GameObject obj = null;
			T value = null;

			if (position>=0)
			{
				obj = (GameObject)_pool[position];
				obj.SetActive(true);
				value = obj.GetComponent<T>();
				_pool.RemoveAt(position);
				position--;
				obj.transform.position = pos;
			}
			else
			{
				obj = CreateElement();
				obj.transform.position = pos;
				value = obj.GetComponent<T>();
			}
			return value;
		}
		
		public void ReleaseElement(GameObject element)
		{
			_pool.Add(element);
			element.SetActive(false);
			position++;
		}
		
	}
}