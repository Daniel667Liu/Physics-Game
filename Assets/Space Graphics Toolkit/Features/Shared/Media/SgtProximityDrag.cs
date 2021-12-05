using UnityEngine;
using FSA = UnityEngine.Serialization.FormerlySerializedAsAttribute;

namespace SpaceGraphicsToolkit
{
	/// <summary>This component rotates the current GameObject.</summary>
	[RequireComponent(typeof(Rigidbody))]
	[HelpURL(SgtHelper.HelpUrlPrefix + "SgtProximityDrag")]
	[AddComponentMenu(SgtHelper.ComponentMenuPrefix + "Proximity Drag")]
	public class SgtProximityDrag : MonoBehaviour
	{
		/// <summary></summary>
		public float DistanceMin { set { distanceMin = value; } get { return distanceMin; } } [FSA("DistanceMin")] [SerializeField] private float distanceMin = 10.0f;

		/// <summary></summary>
		public float DistanceMax { set { distanceMax = value; } get { return distanceMax; } } [FSA("DistanceMax")] [SerializeField] private float distanceMax = 500.0f;

		/// <summary></summary>
		public float DragMin { set { dragMin = value; } get { return dragMin; } } [FSA("DragMin")] [SerializeField] private float dragMin = 0.1f;

		/// <summary></summary>
		public float DragMax { set { dragMax = value; } get { return dragMax; } } [FSA("DragMax")] [SerializeField] private float dragMax = 5.0f;

		/// <summary></summary>
		public float AngularDragMin { set { angularDragMin = value; } get { return angularDragMin; } } [FSA("AngularDragMin")] [SerializeField] private float angularDragMin = 0.1f;

		/// <summary></summary>
		public float AngularDragMax { set { angularDragMax = value; } get { return angularDragMax; } } [FSA("AngularDragMax")] [SerializeField] private float angularDragMax = 5.0f;

		[System.NonSerialized]
		private Rigidbody cachedRigidbody;

		protected virtual void OnEnable()
		{
			cachedRigidbody = GetComponent<Rigidbody>();
		}

		protected virtual void Update()
		{
			var distance = float.PositiveInfinity;

			SgtHelper.InvokeCalculateDistance(transform.position, ref distance);

			if (distance < distanceMax)
			{
				var distance01  = Mathf.InverseLerp(distanceMin, distanceMax, distance);
				var drag        = Mathf.Lerp(dragMax, dragMin, distance01);
				var angularDrag = Mathf.Lerp(angularDragMax, angularDragMin, distance01);

				cachedRigidbody.drag        = drag;
				cachedRigidbody.angularDrag = angularDrag;
			}
			else
			{
				cachedRigidbody.drag        = dragMin;
				cachedRigidbody.angularDrag = angularDragMin;
			}
		}
	}
}

#if UNITY_EDITOR
namespace SpaceGraphicsToolkit
{
	using TARGET = SgtProximityDrag;

	[UnityEditor.CanEditMultipleObjects]
	[UnityEditor.CustomEditor(typeof(TARGET))]
	public class SgtProximityDrag_Editor : SgtEditor
	{
		protected override void OnInspector()
		{
			TARGET tgt; TARGET[] tgts; GetTargets(out tgt, out tgts);

			Draw("distanceMin", "");
			Draw("distanceMax", "");
			Draw("dragMin", "");
			Draw("dragMax", "");
			Draw("angularDragMin", "");
			Draw("angularDragMax", "");
		}
	}
}
#endif