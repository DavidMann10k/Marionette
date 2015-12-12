using System;
using UnityEngine;

namespace Marionette
{
	public interface IDirective
	{
		int Priority { get; }

		void Execute (Marionette caller);
	}
}
