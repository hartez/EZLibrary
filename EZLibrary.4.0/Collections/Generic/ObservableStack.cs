using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace EZLibrary.Collections.Generic
{
	/// <summary>
	/// A wrapper for Stack<typeparamref name="T"/> which implements INotifyCollectionChanged
	/// </summary>
	/// <typeparam name="T">The generic type</typeparam>
	/// <remarks>The default constructor will create an internal Stack<typeparamref name="T"/>;
	/// you can also wrap an existing Stack<typeparamref name="T"/></remarks>
	public class ObservableStack<T> : INotifyCollectionChanged, IEnumerable<T>, ICollection
	{
		private readonly Stack<T> _internalStack;

		public ObservableStack(Stack<T> stack)
		{
			_internalStack = stack;
		}

		public ObservableStack()
		{
			_internalStack = new Stack<T>();
		}

		#region ICollection Members

		public void CopyTo(Array array, int index)
		{
			((ICollection)_internalStack).CopyTo(array, index);
		}

		public int Count
		{
			get { return _internalStack.Count; }
		}

		public object SyncRoot
		{
			get { return ((ICollection)_internalStack).SyncRoot; }
		}

		public bool IsSynchronized
		{
			get { return ((ICollection)_internalStack).IsSynchronized; }
		}

		#endregion

		#region IEnumerable<T> Members

		IEnumerator<T> IEnumerable<T>.GetEnumerator()
		{
			return _internalStack.GetEnumerator();
		}

		public IEnumerator GetEnumerator()
		{
			return _internalStack.GetEnumerator();
		}

		#endregion

		#region INotifyCollectionChanged Members

		public event NotifyCollectionChangedEventHandler CollectionChanged;

		#endregion

		public void Clear()
		{
			_internalStack.Clear();
			InvokeCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
		}

		public bool Contains(T item)
		{
			return _internalStack.Contains(item);
		}

		public void CopyTo(T[] array, int arrayIndex)
		{
			_internalStack.CopyTo(array, arrayIndex);
		}

		public void TrimExcess()
		{
			_internalStack.TrimExcess();
		}

		public T Peek()
		{
			return _internalStack.Peek();
		}

		public T Pop()
		{
			T item = _internalStack.Pop();
			InvokeCollectionChanged(
				new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove,
													 item, _internalStack.Count));
			return item;
		}

		public void Push(T item)
		{
			_internalStack.Push(item);
			InvokeCollectionChanged(
				new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add,
													 item, _internalStack.Count - 1));
		}

		public T[] ToArray()
		{
			return _internalStack.ToArray();
		}

		public void InvokeCollectionChanged(NotifyCollectionChangedEventArgs e)
		{
			NotifyCollectionChangedEventHandler handler = CollectionChanged;
			if (handler != null)
			{
				handler(this, e);
			}
		}
	}
}