﻿using UnityEngine;
using UnityEditor;

namespace Michsky.UI.ModernUIPack
{
    [CustomEditor(typeof(ContextMenuContent))]
    public class ContextMenuContentEditor : Editor
    {
        private GUISkin customSkin;
        private ContextMenuContent cmcTarget;
        private int currentTab;

        private void OnEnable()
        {
            cmcTarget = (ContextMenuContent)target;

            if (EditorGUIUtility.isProSkin == true) { customSkin = (GUISkin)Resources.Load("Editor\\MUI Skin Dark"); }
            else { customSkin = (GUISkin)Resources.Load("Editor\\MUI Skin Light"); }
        }

        public override void OnInspectorGUI()
        {
            MUIPEditorHandler.DrawComponentHeader(customSkin, "CM Top Header");

            GUIContent[] toolbarTabs = new GUIContent[2];
            toolbarTabs[0] = new GUIContent("Content");
            toolbarTabs[1] = new GUIContent("Resources");
          
            currentTab = MUIPEditorHandler.DrawTabs(currentTab, toolbarTabs, customSkin);

            if (GUILayout.Button(new GUIContent("Content", "Content"), customSkin.FindStyle("Tab Content")))
                currentTab = 0;
            if (GUILayout.Button(new GUIContent("Resources", "Resources"), customSkin.FindStyle("Tab Resources")))
                currentTab = 1;

            GUILayout.EndHorizontal();

            var contextManager = serializedObject.FindProperty("contextManager");
            var itemParent = serializedObject.FindProperty("itemParent");
            var contexItems = serializedObject.FindProperty("contexItems");

            switch (currentTab)
            {
                case 0:
                    MUIPEditorHandler.DrawHeader(customSkin, "Content Header", 6);
                    GUILayout.BeginVertical(EditorStyles.helpBox);
                    EditorGUI.indentLevel = 1;

                    EditorGUILayout.PropertyField(contexItems, new GUIContent("Context Menu Items"), true);
                    contexItems.isExpanded = true;

                    EditorGUI.indentLevel = 0;

                    if (GUILayout.Button("+  Add a new item", customSkin.button))
                        cmcTarget.AddNewItem();

                    GUILayout.EndVertical();
                    break;

                case 1:
                    MUIPEditorHandler.DrawHeader(customSkin, "Core Header", 6);
                    MUIPEditorHandler.DrawProperty(contextManager, customSkin, "Context Manager");
                    MUIPEditorHandler.DrawProperty(itemParent, customSkin, "Item Parent");
                    break;
            }

            this.Repaint();
            serializedObject.ApplyModifiedProperties();
        }
    }
}