using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using System.IO;
using System.Text;
using System;
using EasyRoads3D;
using EasyRoads3DEditor;
public class SideObjectImporter : EditorWindow
{

public static SideObjectImporter instance;
public static Vector2 scrollPosition;
public static String[] sideobjects;
public static bool[] flags;
public static string[] soStrings;
public static List<ODODDQQO> importedSos = new List<ODODDQQO>();
public SideObjectImporter()
{
if( instance != null ){
}
instance = this;

position = new Rect((Screen.width - 250.0f) / 2.0f, (Screen.height - 400.0f) / 2.0f, 250.0f, 400.0f);
minSize = new Vector2(250.0f, 200.0f);
maxSize = new Vector2(850.0f, 800.0f);

}
public void OnDestroy(){
instance = null;
}
public static SideObjectImporter Instance{
get
{
if( instance == null ){
new SideObjectImporter();
}
return instance;
}
}
public void OnGUI()
{

if(titleContent.text == "SideObjectImporter")titleContent = new GUIContent("Import Side Objects");
bool sel = false;
foreach(bool flag in flags){
if(flag){
sel = true;
break;
}
}
scrollPosition = EditorGUILayout.BeginScrollView(scrollPosition);
int i = 0;
foreach(String so in sideobjects){
flags[i] = EditorGUILayout.Toggle (flags[i] );
GUILayout.Space(-20);
GUILayout.Label("    "+so,GUILayout.Width(150));
i++;
}
EditorGUILayout.EndScrollView();
if(!sel)GUI.enabled = false;
EditorGUILayout.BeginHorizontal();
GUILayout.FlexibleSpace();
if(GUILayout.Button ("Import", GUILayout.Width(125), GUILayout.Height(25))){
List<string> comboValues = new List<string>();
for(i = 0; i < OOCQCOCDOQ.roadObjects.Length; i++){
comboValues.Add(OOCQCOCDOQ.roadObjects[i]);
}



for(i = 0; i < flags.Length; i++){
if(flags[i]){
ODODDQQO thisso = (ODODDQQO)importedSos[i];
if(CheckExists(thisso)){
}else{
thisso.name = CheckName(thisso.name);
comboValues.Add(thisso.name);
OOCQCOCDOQ.ODCOQOCDCD.Add(thisso);
}
}
}

OOCQCOCDOQ.roadObjects = comboValues.ToArray();
OOCQCOCDOQ.OQDDOCQDDQ();
ObjectManager.instance.Repaint();
instance.Close();
}
EditorGUILayout.EndHorizontal();
}
public static String CheckName(String sideobjectname){
for(int i = 0 ; i < OOCQCOCDOQ.ODCOQOCDCD.Count;i++){
ODODDQQO so = (ODODDQQO)OOCQCOCDOQ.ODCOQOCDCD[i];
if(so.name == sideobjectname){
sideobjectname = sideobjectname + "1";
sideobjectname = CheckName(sideobjectname);
}
}
return sideobjectname;
}
public static bool CheckExists(ODODDQQO so){
return false;
}

}
