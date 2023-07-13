using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

[AttributeUsage(AttributeTargets.Field)]
public class PropertyName : PropertyAttribute
{
    public string Name { get; set; }

    public PropertyName(string name) : base()
    {
        Name = name;
    }
}


#if UNITY_EDITOR
[CustomPropertyDrawer(typeof(PropertyName))]
public class PropertyNamePropertyDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        PropertyName propertyName = attribute as PropertyName;
        label.text = propertyName.Name;
        EditorGUI.PropertyField(position, property, label);
    }
}
#endif