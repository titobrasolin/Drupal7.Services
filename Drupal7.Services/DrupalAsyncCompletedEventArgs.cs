using System;
using System.ComponentModel;
using CookComputing.XmlRpc;
namespace Drupal7.Services
{
	public delegate void DrupalAsyncCompletedEventHandler<T> (object sender, DrupalAsyncCompletedEventArgs<T> args);

	public sealed class DrupalAsyncCompletedEventArgs<T> : AsyncCompletedEventArgs
	{
		private T result;

		public DrupalAsyncCompletedEventArgs (T result, Exception error, object userState)
			: base (error, false, userState)
		{
			this.result = result;
		}

		public T Result {
			get {
				this.RaiseExceptionIfNecessary ();
				return this.result;
			}
		}
	}
}
