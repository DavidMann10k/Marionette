using UnityEngine;

public class GlowObjectCmd : MonoBehaviour, IGlow
{
	public Color GlowColor { get; private set; }
	public Renderer[] Renderers { get; private set; }

	[SerializeField]
	Color glow_color = Color.green;

	void Start()
	{
		Renderers = GetComponentsInChildren<Renderer>();
		GlowController.RegisterObject(this);
	}
}
