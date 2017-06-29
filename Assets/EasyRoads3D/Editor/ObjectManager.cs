using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using System.IO;
using System.Text;
using System;
using EasyRoads3D;
using EasyRoads3DEditor;
public class ObjectManager : EditorWindow
{

public static ObjectManager instance;
public string strVar;
public int intVar;
public GameObject goVar;
public ODODDQQO soVar;
public string[] strArr;
public List<ODODDQQO> sosArr;
public int returnType = 0;
public bool isStarted = false;
public ObjectManager()
{

if( instance != null ){



}
instance = this;

position = new Rect((Screen.width - 550.0f) / 2.0f, (Screen.height - 400.0f) / 2.0f, 550.0f, 400.0f);
minSize = new Vector2(550.0f, 400.0f);
maxSize = new Vector2(550.0f, 400.0f);


}
public void OnAwake(){


}
public void OnDestroy(){
if(ProceduralObjectsEditor.instance != null){
ProceduralObjectsEditor.instance.Close();
}
OOCQCOCDOQ.newObjectFlag = false;
OOCQCOCDOQ.duplicateObjectFlag = false;
instance = null;
}
public static ObjectManager Instance{
get
{
if( instance == null ){
new ObjectManager();
}
return instance;
}
}
public void OnGUI()
{

if(ODQQDOOOOO.extensionPath == ""){
ODQQDOOOOO.extensionPath = GetExtensionPath();
}
if(titleContent.text == "ObjectManager")titleContent = new GUIContent("EasyRoads3D Object Manager");
if (!isStarted) {
OOCQCOCDOQ.OCDQQDQOCD();
isStarted = true;
}
strArr = null;
sosArr = null;
returnType = 0;
OOCQCOCDOQ.OOOQCQQQDC(ref strVar, ref intVar, ref goVar, ref soVar, ref strArr, ref sosArr, ref returnType);


if(returnType == 2){






ProceduralObjectsEditor editor = null;
if(ProceduralObjectsEditor.instance == null){

editor = (ProceduralObjectsEditor)ScriptableObject.CreateInstance(typeof(ProceduralObjectsEditor));
}else{
editor = ProceduralObjectsEditor.instance;

}
editor.position = new Rect (editor.position.x, editor.position.y, 500, 400);

//editor.title = strVar;
			editor.titleContent = new GUIContent(strVar);


ODODDQQO so = soVar;


editor.DisplayNodes(intVar, so, goVar);
editor.Show();


}else if(returnType == 4){


List<ODODDQQO> arr = OCDQDCQOCQ.OQOODCQQCO(false);
RoadObjectScript.ODODOQQO = OCDQDCQOCQ.OQQQOOOOOC(arr);
RoadObjectScript[] scripts = (RoadObjectScript[])FindObjectsOfType(typeof(RoadObjectScript));
foreach(RoadObjectScript scr in scripts){

scr.OCODODQDDO(arr, OCDQDCQOCQ.OQQQOOOOOC(arr), OCDQDCQOCQ.OQODCCCCCD(arr));
}
if(ProceduralObjectsEditor.instance != null){
ProceduralObjectsEditor.instance.Close();
}
instance.Close();

}else if(returnType == 1){

SideObjectImporter ieditor = (SideObjectImporter)ScriptableObject.CreateInstance(typeof(SideObjectImporter));
SideObjectImporter.sideobjects =  strArr;
SideObjectImporter.flags = new bool[intVar];

SideObjectImporter.importedSos = sosArr;
ieditor.ShowUtility();


}else if(returnType == 3){

List<ODODDQQO> arr = OCDQDCQOCQ.OQOODCQQCO(false);
RoadObjectScript.ODODOQQO = OCDQDCQOCQ.OQQQOOOOOC(arr);
RoadObjectScript[] scripts = (RoadObjectScript[])FindObjectsOfType(typeof(RoadObjectScript));
foreach(RoadObjectScript scr in scripts){

List<ODODDQQO>  arr1  = OCDQDCQOCQ.OQOODCQQCO(false);
if(scr.OOOOODODCQ == null) {

scr.ODODCDOOQC(arr1, OCDQDCQOCQ.OQQQOOOOOC(arr1), OCDQDCQOCQ.OQODCCCCCD(arr1));
}
scr.OCODODQDDO(arr1, OCDQDCQOCQ.OQQQOOOOOC(arr1), OCDQDCQOCQ.OQODCCCCCD(arr1));
if(scr.OQCCDOOOCC == true || scr.objectType == 2){
GameObject go = GameObject.Find(scr.gameObject.name+"/Side Objects/"+strVar);

if(go != null){

ODDOQODQCQ.OODODODOOD((sideObjectScript)go.GetComponent(typeof(sideObjectScript)), intVar, scr, go.transform);
}
}
}
}
}

public string GetExtensionPath(){
string extensionPath  = Path.GetDirectoryName( AssetDatabase.GetAssetPath( MonoScript.FromScriptableObject( this ) ) );

extensionPath = extensionPath.Replace("lib", "");
extensionPath = extensionPath.Replace("Editor", "");
extensionPath = extensionPath.Replace("scripts", "");

return "/" + extensionPath;
}
}
