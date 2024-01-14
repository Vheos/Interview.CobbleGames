#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using Vheos.Interview.CobbleGames;

[CustomPropertyDrawer(typeof(ReadOnlyAttribute))]
public class ReadOnly_PropertyDrawer : PropertyDrawer
{
	public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
	{
		GUI.enabled = false;
		EditorGUI.PropertyField(position, property, label, true);
		GUI.enabled = true;
	}
}
#endif