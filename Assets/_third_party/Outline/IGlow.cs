using UnityEngine;

public interface IGlow
{
	Renderer[] Renderers { get; }

	Color GlowColor { get; }
}

