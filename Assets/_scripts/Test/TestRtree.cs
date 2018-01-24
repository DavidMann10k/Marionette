using UnityEngine;
using System.Collections;
using RTree;

namespace Test
{
	public class TestRtree : MonoBehaviour
	{
		RTree.RTree<GameObject> tree = new RTree.RTree<GameObject> ();

		void Start ()
		{

		}
	}
}