using System;
using System.Linq;
using UnityEditor.AnimatedValues;
using UnityEngine;
using UnityEngine.Events;

namespace UnityEditor
{
	[CanEditMultipleObjects, CustomEditor(typeof(Rigidbody2D))]
	internal class Rigidbody2DEditor : Editor
	{
		private SerializedProperty m_Simulated;

		private SerializedProperty m_BodyType;

		private SerializedProperty m_Material;

		private SerializedProperty m_UseFullKinematicContacts;

		private SerializedProperty m_UseAutoMass;

		private SerializedProperty m_Mass;

		private SerializedProperty m_LinearDrag;

		private SerializedProperty m_AngularDrag;

		private SerializedProperty m_GravityScale;

		private SerializedProperty m_Interpolate;

		private SerializedProperty m_SleepingMode;

		private SerializedProperty m_CollisionDetection;

		private SerializedProperty m_Constraints;

		private readonly AnimBool m_ShowIsStatic = new AnimBool();

		private readonly AnimBool m_ShowIsKinematic = new AnimBool();

		private readonly AnimBool m_ShowInfo = new AnimBool();

		private readonly AnimBool m_ShowContacts = new AnimBool();

		private Vector2 m_ContactScrollPosition;

		private static readonly GUIContent m_FreezePositionLabel = EditorGUIUtility.TrTextContent("Freeze Position", null, null);

		private static readonly GUIContent m_FreezeRotationLabel = EditorGUIUtility.TrTextContent("Freeze Rotation", null, null);

		private static ContactPoint2D[] m_Contacts = new ContactPoint2D[100];

		private const int k_ToggleOffset = 30;

		public void OnEnable()
		{
			Rigidbody2D rigidbody2D = base.target as Rigidbody2D;
			this.m_Simulated = base.serializedObject.FindProperty("m_Simulated");
			this.m_BodyType = base.serializedObject.FindProperty("m_BodyType");
			this.m_Material = base.serializedObject.FindProperty("m_Material");
			this.m_UseFullKinematicContacts = base.serializedObject.FindProperty("m_UseFullKinematicContacts");
			this.m_UseAutoMass = base.serializedObject.FindProperty("m_UseAutoMass");
			this.m_Mass = base.serializedObject.FindProperty("m_Mass");
			this.m_LinearDrag = base.serializedObject.FindProperty("m_LinearDrag");
			this.m_AngularDrag = base.serializedObject.FindProperty("m_AngularDrag");
			this.m_GravityScale = base.serializedObject.FindProperty("m_GravityScale");
			this.m_Interpolate = base.serializedObject.FindProperty("m_Interpolate");
			this.m_SleepingMode = base.serializedObject.FindProperty("m_SleepingMode");
			this.m_CollisionDetection = base.serializedObject.FindProperty("m_CollisionDetection");
			this.m_Constraints = base.serializedObject.FindProperty("m_Constraints");
			this.m_ShowIsStatic.value = (rigidbody2D.bodyType != RigidbodyType2D.Static);
			this.m_ShowIsStatic.valueChanged.AddListener(new UnityAction(base.Repaint));
			this.m_ShowIsKinematic.value = (rigidbody2D.bodyType != RigidbodyType2D.Kinematic);
			this.m_ShowIsKinematic.valueChanged.AddListener(new UnityAction(base.Repaint));
			this.m_ShowInfo.valueChanged.AddListener(new UnityAction(base.Repaint));
			this.m_ShowContacts.valueChanged.AddListener(new UnityAction(base.Repaint));
			this.m_ContactScrollPosition = Vector2.zero;
		}

		public void OnDisable()
		{
			this.m_ShowIsStatic.valueChanged.RemoveListener(new UnityAction(base.Repaint));
			this.m_ShowIsKinematic.valueChanged.RemoveListener(new UnityAction(base.Repaint));
			this.m_ShowInfo.valueChanged.RemoveListener(new UnityAction(base.Repaint));
			this.m_ShowContacts.valueChanged.RemoveListener(new UnityAction(base.Repaint));
		}

		public override void OnInspectorGUI()
		{
			Rigidbody2D rigidbody2D = base.target as Rigidbody2D;
			base.serializedObject.Update();
			EditorGUILayout.PropertyField(this.m_BodyType, new GUILayoutOption[0]);
			EditorGUILayout.PropertyField(this.m_Material, new GUILayoutOption[0]);
			EditorGUILayout.PropertyField(this.m_Simulated, new GUILayoutOption[0]);
			if (!this.m_Simulated.boolValue && !this.m_Simulated.hasMultipleDifferentValues)
			{
				EditorGUILayout.HelpBox("The body has now been taken out of the simulation along with any attached colliders, joints or effectors.", MessageType.Info);
			}
			if (this.m_BodyType.hasMultipleDifferentValues)
			{
				EditorGUILayout.HelpBox("Cannot edit properties that are body type specific when the selection contains different body types.", MessageType.Info);
			}
			else
			{
				this.m_ShowIsStatic.target = (rigidbody2D.bodyType != RigidbodyType2D.Static);
				if (EditorGUILayout.BeginFadeGroup(this.m_ShowIsStatic.faded))
				{
					this.m_ShowIsKinematic.target = (rigidbody2D.bodyType != RigidbodyType2D.Kinematic);
					if (EditorGUILayout.BeginFadeGroup(this.m_ShowIsKinematic.faded))
					{
						EditorGUILayout.PropertyField(this.m_UseAutoMass, new GUILayoutOption[0]);
						if (!this.m_UseAutoMass.hasMultipleDifferentValues)
						{
							if (this.m_UseAutoMass.boolValue)
							{
								if (base.targets.Any((UnityEngine.Object x) => PrefabUtility.GetPrefabType(x) == PrefabType.Prefab || !(x as Rigidbody2D).gameObject.activeInHierarchy))
								{
									EditorGUILayout.HelpBox("The auto mass value cannot be displayed for a prefab or if the object is not active.  The value will be calculated for a prefab instance and when the object is active.", MessageType.Info);
									goto IL_18C;
								}
							}
							EditorGUI.BeginDisabledGroup(rigidbody2D.useAutoMass);
							EditorGUILayout.PropertyField(this.m_Mass, new GUILayoutOption[0]);
							EditorGUI.EndDisabledGroup();
							IL_18C:;
						}
						EditorGUILayout.PropertyField(this.m_LinearDrag, new GUILayoutOption[0]);
						EditorGUILayout.PropertyField(this.m_AngularDrag, new GUILayoutOption[0]);
						EditorGUILayout.PropertyField(this.m_GravityScale, new GUILayoutOption[0]);
					}
					Rigidbody2DEditor.FixedEndFadeGroup(this.m_ShowIsKinematic.faded);
					if (!this.m_ShowIsKinematic.target)
					{
						EditorGUILayout.PropertyField(this.m_UseFullKinematicContacts, new GUILayoutOption[0]);
					}
					EditorGUILayout.PropertyField(this.m_CollisionDetection, new GUILayoutOption[0]);
					EditorGUILayout.PropertyField(this.m_SleepingMode, new GUILayoutOption[0]);
					EditorGUILayout.PropertyField(this.m_Interpolate, new GUILayoutOption[0]);
					GUILayout.BeginHorizontal(new GUILayoutOption[0]);
					this.m_Constraints.isExpanded = EditorGUILayout.Foldout(this.m_Constraints.isExpanded, "Constraints", true);
					GUILayout.EndHorizontal();
					RigidbodyConstraints2D intValue = (RigidbodyConstraints2D)this.m_Constraints.intValue;
					if (this.m_Constraints.isExpanded)
					{
						EditorGUI.indentLevel++;
						this.ToggleFreezePosition(intValue, Rigidbody2DEditor.m_FreezePositionLabel, 0, 1);
						this.ToggleFreezeRotation(intValue, Rigidbody2DEditor.m_FreezeRotationLabel, 2);
						EditorGUI.indentLevel--;
					}
					if (intValue == RigidbodyConstraints2D.FreezeAll)
					{
						EditorGUILayout.HelpBox("Rather than turning on all constraints, you may want to consider removing the Rigidbody2D component which makes any colliders static.  This gives far better performance overall.", MessageType.Info);
					}
				}
				Rigidbody2DEditor.FixedEndFadeGroup(this.m_ShowIsStatic.faded);
			}
			base.serializedObject.ApplyModifiedProperties();
			this.ShowBodyInfoProperties();
		}

		private void ShowBodyInfoProperties()
		{
			this.m_ShowInfo.target = EditorGUILayout.Foldout(this.m_ShowInfo.target, "Info", true);
			if (EditorGUILayout.BeginFadeGroup(this.m_ShowInfo.faded))
			{
				if (base.targets.Length == 1)
				{
					Rigidbody2D rigidbody2D = base.targets[0] as Rigidbody2D;
					EditorGUI.BeginDisabledGroup(true);
					EditorGUILayout.Vector2Field("Position", rigidbody2D.position, new GUILayoutOption[0]);
					EditorGUILayout.FloatField("Rotation", rigidbody2D.rotation, new GUILayoutOption[0]);
					EditorGUILayout.Vector2Field("Velocity", rigidbody2D.velocity, new GUILayoutOption[0]);
					EditorGUILayout.FloatField("Angular Velocity", rigidbody2D.angularVelocity, new GUILayoutOption[0]);
					EditorGUILayout.FloatField("Inertia", rigidbody2D.inertia, new GUILayoutOption[0]);
					EditorGUILayout.Vector2Field("Local Center of Mass", rigidbody2D.centerOfMass, new GUILayoutOption[0]);
					EditorGUILayout.Vector2Field("World Center of Mass", rigidbody2D.worldCenterOfMass, new GUILayoutOption[0]);
					EditorGUILayout.LabelField("Sleep State", (!rigidbody2D.IsSleeping()) ? "Awake" : "Asleep", new GUILayoutOption[0]);
					EditorGUI.EndDisabledGroup();
					this.ShowContacts(rigidbody2D);
					base.Repaint();
				}
				else
				{
					EditorGUILayout.HelpBox("Cannot show Info properties when multiple bodies are selected.", MessageType.Info);
				}
			}
			Rigidbody2DEditor.FixedEndFadeGroup(this.m_ShowInfo.faded);
		}

		private void ShowContacts(Rigidbody2D body)
		{
			EditorGUI.indentLevel++;
			this.m_ShowContacts.target = EditorGUILayout.Foldout(this.m_ShowContacts.target, "Contacts");
			if (EditorGUILayout.BeginFadeGroup(this.m_ShowContacts.faded))
			{
				int contacts = body.GetContacts(Rigidbody2DEditor.m_Contacts);
				if (contacts > 0)
				{
					this.m_ContactScrollPosition = EditorGUILayout.BeginScrollView(this.m_ContactScrollPosition, new GUILayoutOption[]
					{
						GUILayout.Height(180f)
					});
					EditorGUI.BeginDisabledGroup(true);
					for (int i = 0; i < contacts; i++)
					{
						ContactPoint2D contactPoint2D = Rigidbody2DEditor.m_Contacts[i];
						EditorGUILayout.HelpBox(string.Format("Contact#{0}", i), MessageType.None);
						EditorGUI.indentLevel++;
						EditorGUILayout.Vector2Field("Point", contactPoint2D.point, new GUILayoutOption[0]);
						EditorGUILayout.Vector2Field("Normal", contactPoint2D.normal, new GUILayoutOption[0]);
						EditorGUILayout.Vector2Field("Relative Velocity", contactPoint2D.relativeVelocity, new GUILayoutOption[0]);
						EditorGUILayout.FloatField("Normal Impulse", contactPoint2D.normalImpulse, new GUILayoutOption[0]);
						EditorGUILayout.FloatField("Tangent Impulse", contactPoint2D.tangentImpulse, new GUILayoutOption[0]);
						EditorGUILayout.ObjectField("Collider", contactPoint2D.collider, typeof(Collider2D), true, new GUILayoutOption[0]);
						EditorGUILayout.ObjectField("Rigidbody", contactPoint2D.rigidbody, typeof(Rigidbody2D), false, new GUILayoutOption[0]);
						EditorGUILayout.ObjectField("OtherCollider", contactPoint2D.otherCollider, typeof(Collider2D), false, new GUILayoutOption[0]);
						EditorGUI.indentLevel--;
						EditorGUILayout.Space();
					}
					EditorGUI.EndDisabledGroup();
					EditorGUILayout.EndScrollView();
				}
				else
				{
					EditorGUILayout.HelpBox("No Contacts", MessageType.Info);
				}
			}
			Rigidbody2DEditor.FixedEndFadeGroup(this.m_ShowContacts.faded);
			EditorGUI.indentLevel--;
		}

		private static void FixedEndFadeGroup(float value)
		{
			if (value != 0f && value != 1f)
			{
				EditorGUILayout.EndFadeGroup();
			}
		}

		private void ConstraintToggle(Rect r, string label, RigidbodyConstraints2D value, int bit)
		{
			bool value2 = (value & (RigidbodyConstraints2D)(1 << bit)) != RigidbodyConstraints2D.None;
			EditorGUI.showMixedValue = ((this.m_Constraints.hasMultipleDifferentValuesBitwise & 1 << bit) != 0);
			EditorGUI.BeginChangeCheck();
			int indentLevel = EditorGUI.indentLevel;
			EditorGUI.indentLevel = 0;
			value2 = EditorGUI.ToggleLeft(r, label, value2);
			EditorGUI.indentLevel = indentLevel;
			if (EditorGUI.EndChangeCheck())
			{
				Undo.RecordObjects(base.targets, "Edit Constraints2D");
				this.m_Constraints.SetBitAtIndexForAllTargetsImmediate(bit, value2);
			}
			EditorGUI.showMixedValue = false;
		}

		private void ToggleFreezePosition(RigidbodyConstraints2D constraints, GUIContent label, int x, int y)
		{
			GUILayout.BeginHorizontal(new GUILayoutOption[0]);
			Rect rect = GUILayoutUtility.GetRect(EditorGUIUtility.fieldWidth, EditorGUILayout.kLabelFloatMaxW, 16f, 16f, EditorStyles.numberField);
			int controlID = GUIUtility.GetControlID(7231, FocusType.Keyboard, rect);
			rect = EditorGUI.PrefixLabel(rect, controlID, label);
			rect.width = 30f;
			this.ConstraintToggle(rect, "X", constraints, x);
			rect.x += 30f;
			this.ConstraintToggle(rect, "Y", constraints, y);
			GUILayout.EndHorizontal();
		}

		private void ToggleFreezeRotation(RigidbodyConstraints2D constraints, GUIContent label, int z)
		{
			GUILayout.BeginHorizontal(new GUILayoutOption[0]);
			Rect rect = GUILayoutUtility.GetRect(EditorGUIUtility.fieldWidth, EditorGUILayout.kLabelFloatMaxW, 16f, 16f, EditorStyles.numberField);
			int controlID = GUIUtility.GetControlID(7231, FocusType.Keyboard, rect);
			rect = EditorGUI.PrefixLabel(rect, controlID, label);
			rect.width = 30f;
			this.ConstraintToggle(rect, "Z", constraints, z);
			GUILayout.EndHorizontal();
		}
	}
}
