using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEditor;
using System.Reflection;
using EasyRoads3D;
using EasyRoads3DEditor;
public class EasyRoadsEditorMenu : ScriptableObject {







[MenuItem( "GameObject/Create Other/EasyRoads3D/New EasyRoads3D Object" )]
public static void  CreateEasyRoads3DObject ()
{







Terrain[] terrains = (Terrain[]) FindObjectsOfType(typeof(Terrain));
if(terrains.Length == 0){
EditorUtility.DisplayDialog("Alert", "No Terrain objects found! EasyRoads3D objects requires a terrain object to interact with. Please create a Terrain object first", "Close");
return;
}



if(NewEasyRoads3D.instance == null){
NewEasyRoads3D window = (NewEasyRoads3D)ScriptableObject.CreateInstance(typeof(NewEasyRoads3D));
window.ShowUtility();
}



}
[MenuItem( "GameObject/Create Other/EasyRoads3D/Back Up/Terrain Height Data" )]
public static void  GetTerrain ()
{
if(GetEasyRoads3DObjects()){

OCDOOCOODO.ODDOQCOOQC(Selection.activeGameObject);
}else{
EditorUtility.DisplayDialog("Alert", "No EasyRoads3D objects found! Terrain functions cannot be accessed!", "Close");
}
}
[MenuItem( "GameObject/Create Other/EasyRoads3D/Restore/Terrain Height Data" )]
public static void  SetTerrain ()
{
if(GetEasyRoads3DObjects()){

OCDOOCOODO.OCOOQQCDDO(Selection.activeGameObject);
}else{
EditorUtility.DisplayDialog("Alert", "No EasyRoads3D objects found! Terrain functions cannot be accessed!", "Close");
}
}
[MenuItem( "GameObject/Create Other/EasyRoads3D/Back Up/Terrain Splatmap Data" )]
public static void  OQCOCDOCDD()
{
if(GetEasyRoads3DObjects()){

OQCQQDCCCO.OQCOCDOCDD(Selection.activeGameObject);
}else{
EditorUtility.DisplayDialog("Alert", "No EasyRoads3D objects found! Terrain functions cannot be accessed!", "Close");
}
}
[MenuItem( "GameObject/Create Other/EasyRoads3D/Restore/Terrain Splatmap Data" )]
public static void  OOQDODOCQC ()
{
if(GetEasyRoads3DObjects()){
string path = "";
if(EditorUtility.DisplayDialog("Road Splatmap", "Would you like to merge the terrain splatmap(s) with a road splatmap?", "Yes", "No")){
path = EditorUtility.OpenFilePanel("Select png road splatmap texture", "", "png");
}


OQCQQDCCCO.OQCODQDQQO(true, 100, 4, path, Selection.activeGameObject);
}else{
EditorUtility.DisplayDialog("Alert", "No EasyRoads3D objects found! Terrain functions cannot be accessed!", "Close");
}
}
[MenuItem( "GameObject/Create Other/EasyRoads3D/Back Up/Terrain Vegetation Data" )]
public static void  OQCDCDOQQO()
{
if(GetEasyRoads3DObjects()){

OCDOOCOODO.OQCDCDOQQO(Selection.activeGameObject, null, "");
}else{
EditorUtility.DisplayDialog("Alert", "No EasyRoads3D objects found! Terrain functions cannot be accessed!", "Close");
}
}
[MenuItem( "GameObject/Create Other/EasyRoads3D/Back Up/All Terrain Data" )]
public static void  GetAllData()
{
if(GetEasyRoads3DObjects()){

OCDOOCOODO.ODDOQCOOQC(Selection.activeGameObject);
OQCQQDCCCO.OQCOCDOCDD(Selection.activeGameObject);
OCDOOCOODO.OQCDCDOQQO(Selection.activeGameObject, null,"");
}else{
EditorUtility.DisplayDialog("Alert", "No EasyRoads3D objects found! Terrain functions cannot be accessed!", "Close");
}
}
[MenuItem( "GameObject/Create Other/EasyRoads3D/Restore/Terrain Vegetation Data" )]
public static void  OQOQOQQOOD()
{
if(GetEasyRoads3DObjects()){

OCDOOCOODO.OQOQOQQOOD(Selection.activeGameObject);
}else{
EditorUtility.DisplayDialog("Alert", "No EasyRoads3D objects found! Terrain functions cannot be accessed!", "Close");
}
}
[MenuItem( "GameObject/Create Other/EasyRoads3D/Restore/All Terrain Data" )]
public static void  RestoreAllData()
{
if(GetEasyRoads3DObjects()){

OCDOOCOODO.OCOOQQCDDO(Selection.activeGameObject);
OQCQQDCCCO.OQCODQDQQO(true, 100, 4, "", Selection.activeGameObject);
OCDOOCOODO.OQOQOQQOOD(Selection.activeGameObject);

}else{
EditorUtility.DisplayDialog("Alert", "No EasyRoads3D objects found! Terrain functions cannot be accessed!", "Close");
}


}

[MenuItem ("GameObject/Create Other/EasyRoads3D/Side Objects/Object Manager")]
static void ShowObjectManager ()
{

if(RoadObjectScript.erInit == ""){
RoadObjectScript[] scripts = (RoadObjectScript[])FindObjectsOfType(typeof(RoadObjectScript));
if(scripts != null) if(scripts.Length != 0) Selection.activeGameObject = scripts[0].gameObject;


}
if(ObjectManager.instance == null){

if(Terrain.activeTerrain != null)OOCQCOCDOQ.terrainTrees = OOQCOQOQQD.OQDQCDOODQ();
ObjectManager window =(ObjectManager)ScriptableObject.CreateInstance(typeof(ObjectManager));
window.ShowUtility();
}
}


[MenuItem( "GameObject/Create Other/EasyRoads3D/Build EasyRoads3D Objects" )]
public static void  FinalizeRoads ()
{

bool destroyTerrainScript = true;
if(EditorUtility.DisplayDialog("Build EasyRoads3D Objects", "This process includes destroying all EasyRoads3D control objects. Did you make a backup of the Scene? Do you want to continue?\n\nDepending on the number of EasyRoads3D objects in the Scene and used side objects, this process may take a while. Please be patient. ", "Yes", "No")){
RoadObjectScript[] scripts = (RoadObjectScript[])FindObjectsOfType(typeof(RoadObjectScript));
foreach (RoadObjectScript script in scripts) {
bool renderflag = true;
bool renderAlreadyDone = false;
int num = 0;
if(!script.displayRoad){
num = EditorUtility.DisplayDialogComplex ("Disabled EasyRoads3D Object Detected:", script.gameObject.name + " is currently not displayed.\n\nWould you like to activate and finalize this object, destroy this object or skip it in this finalize procedure?", "Finalize", "Destroy", "Skip");
if(num == 0){
script.displayRoad = true;
if(script.OOOOODODCQ == null){
List<ODODDQQO> arr = OCDQDCQOCQ.OQOODCQQCO(false);
script.ODODCDOOQC(arr, OCDQDCQOCQ.OQQQOOOOOC(arr), OCDQDCQOCQ.OQODCCCCCD(arr));
}
script.OOOOODODCQ.OOQCQOCOOC(script.displayRoad, script.OCCOCOOOCC);
}
if(num == 1){

renderflag = false;
}
if(num == 2){
renderflag = false;
destroyTerrainScript = false;
}
}
if(script.transform != null && renderflag && !script.OQCCDOOOCC){
if(script.OOOOODODCQ == null){
List<ODODDQQO> arr = OCDQDCQOCQ.OQOODCQQCO(false);
script.ODODCDOOQC(arr, OCDQDCQOCQ.OQQQOOOOOC(arr), OCDQDCQOCQ.OQODCCCCCD(arr));
}

if(RoadObjectScript.erInit == ""){
RoadObjectScript.erInit = OQCOQQCOQO.OQDODODOQD(RoadObjectScript.version); 
OOQCOQOQQD.erInit = RoadObjectScript.erInit;
}

if(script.OOOOODODCQ == null){
script.OCQOQOCQDC(script.transform, null, null, null);
}
OOQCOQOQQD.OQDQQQCDQQ = true;
if(!script.OQCCDOOOCC){
script.geoResolution = 0.5f;
script.OQOQQQCDOQ();
if(script.objectType < 2) OQCOOCDODD(script);
script.OOOOODODCQ.terrainRendered = true;
script.ODCDQOOOQC();



}
if(script.displayRoad && script.objectType < 2){

if(script.objectType == 1){

SetWaterScript(script);
}
script.OOOOODODCQ.road.transform.parent = null;
script.OOOOODODCQ.road.layer = 0;
script.OOOOODODCQ.road.name = script.gameObject.name;
}
else if(script.OOOOODODCQ.road != null)DestroyImmediate(script.OOOOODODCQ.road);



bool flag = false;
for(int i=0;i<script.ODODQQOD.Length;i++){
if(script.ODODQQOD[i]){
flag = true;
break;
}
}
if(flag){
ODDOQODQCQ.OQODCQDDCO(script);
}
foreach(Transform child in script.transform){
if(child.name == "Side Objects"){
child.name = script.gameObject.name + " - Side Objects ";
child.parent = null;
}
}
}else if(script.OQCCDOOOCC){
renderAlreadyDone = true;
destroyTerrainScript = false;
}
if((script.displayRoad || num != 2) && !renderAlreadyDone)DestroyImmediate(script.gameObject);
}

if(destroyTerrainScript){
EasyRoads3DTerrainID[] terrainscripts = (EasyRoads3DTerrainID[])FindObjectsOfType(typeof(EasyRoads3DTerrainID));
foreach (EasyRoads3DTerrainID script in terrainscripts) {
DestroyImmediate(script);
}
}
}
}

public static bool GetEasyRoads3DObjects(){
RoadObjectScript[] scripts = (RoadObjectScript[])FindObjectsOfType(typeof(RoadObjectScript));
bool flag = false;
foreach (RoadObjectScript script in scripts) {
if(script.OOOOODODCQ == null){

List<ODODDQQO> arr = OCDQDCQOCQ.OQOODCQQCO(false);
script.OCQOQOCQDC(script.transform, arr, OCDQDCQOCQ.OQQQOOOOOC(arr), OCDQDCQOCQ.OQODCCCCCD(arr));


}
flag = true;
}
return flag;
}
static private void OQCOOCDODD(RoadObjectScript target){
EditorUtility.DisplayProgressBar("Build EasyRoads3D Object - " + target.gameObject.name,"Initializing", 0);

RoadObjectScript[] scripts = (RoadObjectScript[])FindObjectsOfType(typeof(RoadObjectScript));
List<Transform> rObj = new List<Transform>();


#if UNITY_4_3

#else
//Undo.RegisterUndo(OQCQQDCCCO.terrain.terrainData, "EasyRoads3D Terrain leveling");
#endif
foreach(RoadObjectScript script in scripts) {
if(script.transform != target.transform) rObj.Add(script.transform);
}
if(target.ODODQOQO == null){
target.ODODQOQO = target.OOOOODODCQ.OCDCOOOOQC();
target.ODODQOQOInt = target.OOOOODODCQ.OCQQCCDCDD();
}
target.ODQCCQDQQC(0.5f, true, false);

List<tPoint> hitOQCDQOCDOQ = target.OOOOODODCQ.OQDOODOOOQ(Vector3.zero, target.raise, target.obj, target.OOQDOOQQ, rObj, target.handleVegetation);
List<Vector3> changeArr = new List<Vector3>();
float stepsf = Mathf.Floor(hitOQCDQOCDOQ.Count / 10);
int steps = Mathf.RoundToInt(stepsf);
for(int i = 0; i < 10;i++){
changeArr = target.OOOOODODCQ.OQCCOQCCCD(hitOQCDQOCDOQ, i * steps, steps, changeArr);
EditorUtility.DisplayProgressBar("Build EasyRoads3D Object - " + target.gameObject.name,"Updating Terrain", i * 10);
}

changeArr = target.OOOOODODCQ.OQCCOQCCCD(hitOQCDQOCDOQ, 10 * steps, hitOQCDQOCDOQ.Count - (10 * steps), changeArr);
target.OOOOODODCQ.OCQCDDCOOC(changeArr, rObj);

target.ODCDQOOOQC();
EditorUtility.ClearProgressBar();

}
private static void SetWaterScript(RoadObjectScript target){
for(int i = 0; i < target.OQDDDDCQOQ.Length; i++){
if(target.OOOOODODCQ.road.GetComponent(target.OQDDDDCQOQ[i]) != null && i != target.selectedWaterScript)DestroyImmediate(target.OOOOODODCQ.road.GetComponent(target.OQDDDDCQOQ[i]));
}
if(target.OQDDDDCQOQ[0] != "None Available!"  && target.OOOOODODCQ.road.GetComponent(target.OQDDDDCQOQ[target.selectedWaterScript]) == null){
#if UNITY_5_0
//UnityEngineInternal.APIUpdaterRuntimeServices.AddComponent(target.OOOOODODCQ.road, "Assets/EasyRoads3D/Editor/EasyRoadsEditorMenu.cs (460,4)", target.OQDDDDCQOQ[target.selectedWaterScript]);
#else
//UnityEngineInternal.APIUpdaterRuntimeServices.AddComponent(target.OOOOODODCQ.road, "Assets/EasyRoads3D/Editor/EasyRoadsEditorMenu.cs (463,4)", target.OQDDDDCQOQ[target.selectedWaterScript]);
#endif

}
}
public static Vector3 ReadFile(string file)
{
Vector3 pos = Vector3.zero;
if(File.Exists(file)){
StreamReader streamReader = File.OpenText(file);
string line = streamReader.ReadLine();
line = line.Replace(",",".");
string[] lines = line.Split("\n"[0]);
string[] arr = lines[0].Split("|"[0]);
float.TryParse(arr[0],System.Globalization.NumberStyles.Float, System.Globalization.NumberFormatInfo.InvariantInfo, out pos.x);
float.TryParse(arr[1],System.Globalization.NumberStyles.Float, System.Globalization.NumberFormatInfo.InvariantInfo, out pos.y);
float.TryParse(arr[2],System.Globalization.NumberStyles.Float, System.Globalization.NumberFormatInfo.InvariantInfo, out pos.z);
}
return pos;
}
}
