using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using EasyRoads3D;
using EasyRoads3DEditor;
public class ProceduralObjectsEditor : EditorWindow
{

public static ProceduralObjectsEditor instance;
public OQQODQCCCD so_editor;
public int sideObject;
private ODODDQQO so;

private GameObject so_go;

string[] traceStrings;

public ProceduralObjectsEditor() {
instance = this;
}
void OnDestroy(){
ODQDODDCQO.OnDestroy1();
instance = null;
}
public void DisplayNodes (int index, ODODDQQO soi, GameObject sso_go)

{
so_go = sso_go;
List<Vector2> tmpNodes = new List<Vector2>();
if(soi != null) tmpNodes.AddRange(soi.nodeList);

if(so_go != null && tmpNodes.Count == 0){

List<Vector2> arr = OQQODQCCCD.OOCOQQCQQQ(2, so_go, ODQDODDCQO.traceOffset);
if(arr != null){
if(arr.Count > 1){
tmpNodes = arr;
}
}
}
bool clamped = false;
so = soi;
sideObject = index;
if (so_editor == null){
try{
so_editor = new OQQODQCCCD(position, tmpNodes, clamped);
}catch{
}
}



if(so_editor.OQCDQOCDOQ.Count > 0){
if((Vector2)so_editor.OQCDQOCDOQ[0] == (Vector2)so_editor.OQCDQOCDOQ[so_editor.OQCDQOCDOQ.Count - 1]){

so_editor.closed = true;
so_editor.OQCDQOCDOQ.RemoveAt(so_editor.OQCDQOCDOQ.Count - 1);
}
}
if(tmpNodes.Count != 0){
Rect rect = new Rect(stageSelectionGridWidth, 0, Screen.width - stageSelectionGridWidth, Screen.height);
so_editor.FrameSelected(rect);
}
ODQDODDCQO.OCOOQCDDDC(index, soi, sso_go, so_editor);
return;
}
void OnGUI ()
{
Rect rect = new Rect(stageSelectionGridWidth, 0, Screen.width - stageSelectionGridWidth, Screen.height);
EditorGUILayout.BeginHorizontal();
GUILayout.Space(210);
GUILayout.Label(new GUIContent("Hit [r] to center the editor, hit [z] to zoom in on the nodes, click drag to move the canvas, Scrollwheel (or [shift] click drag) zoom in / out", ""), GUILayout.Width(800) );
EditorGUILayout.EndHorizontal();
GUILayout.Space(-15);
ODQDODDCQO.OOOQCQQQDC(rect);
DoGUI ();
so_editor.OnGUI(rect);
}
float stageSelectionGridWidth = 200;
void DoGUI ()
{

EditorGUILayout.BeginHorizontal();
GUILayout.Space(60);
if(GUILayout.Button ("Apply", GUILayout.Width(65))){
ODQDODDCQO.ODCCOQDCOC();
instance.Close();
}
if(GUILayout.Button ("Close", GUILayout.Width(65))){
instance.Close();
}
EditorGUILayout.EndHorizontal();
GUILayout.Space(5);
if(so_editor.isChanged == false) GUI.enabled = false;
EditorGUILayout.BeginHorizontal();
GUILayout.Space(60);
if(GUILayout.Button ("Update Scene", GUILayout.Width(135))){

so.nodeList.Clear();
if(so_editor.closed) so_editor.OQCDQOCDOQ.Add(so_editor.OQCDQOCDOQ[0]);
so.nodeList.AddRange(so_editor.OQCDQOCDOQ);
so_editor.isChanged = false;
OOCQCOCDOQ.OQQODQDDQQ(OOCQCOCDOQ.selectedObject);
OOCQCOCDOQ.OQQDDQQQQQ();

List<ODODDQQO> arr = OCDQDCQOCQ.OQOODCQQCO(false);
RoadObjectScript.ODODOQQO = OCDQDCQOCQ.OQQQOOOOOC(arr);
RoadObjectScript[] scripts = (RoadObjectScript[])FindObjectsOfType(typeof(RoadObjectScript));
foreach(RoadObjectScript scr in scripts){

if(scr.OOOOODODCQ == null) {
List<ODODDQQO> arr1  = OCDQDCQOCQ.OQOODCQQCO(false);
scr.ODODCDOOQC(arr1, OCDQDCQOCQ.OQQQOOOOOC(arr1), OCDQDCQOCQ.OQODCCCCCD(arr1));
}
scr.OCODODQDDO(arr, OCDQDCQOCQ.OQQQOOOOOC(arr), OCDQDCQOCQ.OQODCCCCCD(arr));
if(scr.OQCCDOOOCC == true || scr.objectType == 2){
GameObject go = GameObject.Find(scr.gameObject.name+"/Side Objects/"+so.name);


if(go != null){
ODDOQODQCQ.OODODODOOD((sideObjectScript)go.GetComponent(typeof(sideObjectScript)), sideObject, scr, go.transform);
}
}
}
}
EditorGUILayout.EndHorizontal();
GUI.enabled = true;
if (GUI.changed)
{
so_editor.isChanged = true;

}
Handles.color = Color.black;
Handles.DrawLine(new Vector2 (stageSelectionGridWidth,0), new Vector2 (stageSelectionGridWidth,Screen.height));

Handles.DrawLine(new Vector2 (stageSelectionGridWidth - 1,0), new Vector2 (stageSelectionGridWidth - 1,Screen.height));

}

}
