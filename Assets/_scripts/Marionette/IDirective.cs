using System;
using UnityEngine;

namespace Marionette
{
	public enum DirectiveType
	{
		movement}

	;

	public interface IDirective
	{
		int Priority { get; }

		void Execute (Marionette caller);
	}
}
