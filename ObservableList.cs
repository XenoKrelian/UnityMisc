using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

[Serializable]
public sealed class ObservableList<T> : IList<T>
{
	[SerializeReference] private List<T> _items = new List<T>();

	public T this[int index]
	{
		get => _items[index];

		set
		{
			if (!EqualityComparer<T>.Default.Equals(_items[index], value))
			{
				_items[index] = value;

				RaiseOnChanged();
			}
		}
	}

	public int Count => _items.Count;

	bool ICollection<T>.IsReadOnly => throw new NotImplementedException();

	public event Action<T[]> OnChanged;

	public ObservableList(IEnumerable<T> items) => _items = new List<T>(items);

	public ObservableList(params T[] items) => _items = new List<T>(items);

	public void RaiseOnChanged() => OnChanged?.Invoke(_items.ToArray());

	public void Add(T item)
	{
		_items.Add(item);

		RaiseOnChanged();
	}

	public void Add(IEnumerable<T> items)
	{
		_items.AddRange(items);

		RaiseOnChanged();
	}

	public void Add(params T[] items) => Add(items);

	public void Insert(int index, T item)
	{
		_items.Insert(index, item);

		RaiseOnChanged();
	}

	public void Insert(IEnumerable<(int Index, T Item)> items)
	{
		foreach ((int Index, T Item) in items)
		{
			_items.Insert(Index, Item);
		}

		RaiseOnChanged();
	}

	public void Insert(params (int Index, T Item)[] items) => Insert(items);

	public bool Remove(T item)
	{
		bool removed = _items.Remove(item);

		if (removed)
		{
			RaiseOnChanged();
		}

		return removed;
	}

	public void Remove(IEnumerable<T> items)
	{
		bool removed = false;

		foreach (T item in items)
		{
			if (_items.Remove(item))
			{
				removed = true;
			}
		}

		if (removed)
		{
			RaiseOnChanged();
		}
	}

	public void Remove(params T[] items) => Remove(items);

	public void RemoveAt(int index)
	{
		_items.RemoveAt(index);

		RaiseOnChanged();
	}

	public void RemoveAt(params int[] indices)
	{
		for (int i = 0; i < indices.Length; i++)
		{
			_items.RemoveAt(indices[i]);
		}

		RaiseOnChanged();
	}

	public void Clear()
	{
		_items.Clear();

		RaiseOnChanged();
	}

	public bool Contains(T item) => _items.Contains(item);

	public void CopyTo(T[] array, int arrayIndex) => _items.CopyTo(array, arrayIndex);

	public IEnumerator<T> GetEnumerator()
	{
		for (int i = 0; i < _items.Count; i++)
		{
			yield return _items[i];
		}
	}

	public int IndexOf(T item) => _items.IndexOf(item);

	IEnumerator IEnumerable.GetEnumerator() => throw new NotImplementedException();
}
