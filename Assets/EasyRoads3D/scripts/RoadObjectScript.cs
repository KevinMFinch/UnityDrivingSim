using UnityEngine;

using System.Collections;
using System.Collections.Generic;
using System;
using EasyRoads3D;

public class RoadObjectScript : MonoBehaviour {
static public string version = "";
public int objectType = 0;
public bool displayRoad = true;
public float roadWidth = 5.0f;
public float indent = 3.0f;
public float surrounding = 5.0f;
public float raise = 1.0f;
public float raiseMarkers = 0.5f;
public bool OOQDOOQQ = false;
public bool renderRoad = true;
public bool beveledRoad = false;
public bool applySplatmap = false;
public int splatmapLayer = 4;
public bool autoUpdate = true;
public float geoResolution = 5.0f;
public int roadResolution = 1;
public float tuw =  15.0f;
public int splatmapSmoothLevel;
public float opacity = 1.0f;
public int expand = 0;
public int offsetX = 0;
public int offsetY = 0;
private Material surfaceMaterial;
public float surfaceOpacity = 1.0f;
public float smoothDistance = 1.0f;
public float smoothSurDistance = 3.0f;
private bool handleInsertFlag;
public bool handleVegetation = true;
public float OCQQCOCCCQ = 2.0f;
public float OODODDCCCQ = 1f;
public int materialType = 0;
String[] materialStrings;
public string uname;
public string email;
private MarkerScript[] mSc;

private bool OOCDOOCQOQ;
private bool[] OCCOCODOCO = null;
private bool[] OQODOOOOQC = null;
public string[] OOCODCOQDQ;
public string[] ODODQOQO;
public int[] ODODQOQOInt;
public int OCCCOCOQOC = -1;
public int OOCOQOOODC = -1;
static public GUISkin OCDQQDOODQ;
static public GUISkin ODDOQQCQDC;
public bool ODCQDCQDOC = false;
private Vector3 cPos;
private Vector3 ePos;
public bool OCDQCOOOOC;
static public Texture2D OCDCQCDOCC;
public int markers = 1;
public OOQCOQOQQD OOOOODODCQ;
private GameObject ODOQDQOO;
public bool OQCCDOOOCC;
public bool doTerrain;
private Transform OOCODCOCQQ = null;
public GameObject[] OOCODCOCQQs;
private static string ODCCQODQCO = null;
public Transform obj;
private string OQCDDDCQQO;
public static string erInit = "";
static public Transform ODCQQODDCO;
private RoadObjectScript OQOCQODQCO;
public bool flyby;


private Vector3 pos;
private float fl;
private float oldfl;
private bool OQQOQDDQQQ;
private bool OOODCQDCOQ;
private bool OCOQDCOCCQ;
public Transform OCCOCOOOCC;
public int OdQODQOD = 1;
public float OOQQQDOD = 0f;
public float OOQQQDODOffset = 0f;
public float OOQQQDODLength = 0f;
public bool ODODDDOO = false;
static public string[] ODOQDOQO;
static public string[] ODODOQQO; 
static public string[] ODODQOOQ;
public int ODQDOOQO = 0;
public string[] ODQQQQQO;  
public string[] ODODDQOO; 
public bool[] ODODQQOD; 
public int[] OOQQQOQO; 
public int ODOQOOQO = 0; 

public bool forceY = false;
public float yChange = 0f;
public float floorDepth = 2f;
public float waterLevel = 1.5f; 
public bool lockWaterLevel = true;
public float lastY = 0f;
public string distance = "0";
public string markerDisplayStr = "Hide Markers";
static public string[] objectStrings;
public string objectText = "Road";
public bool applyAnimation = false;
public float waveSize = 1.5f;
public float waveHeight = 0.15f;
public bool snapY = true;

private TextAnchor origAnchor;
public bool autoODODDQQO;
public Texture2D roadTexture;
public Texture2D roadMaterial;
public string[] ODCDCDCCDO;
public string[] OQDDDDCQOQ;
public int selectedWaterMaterial;
public int selectedWaterScript;
private bool doRestore = false;
public bool doFlyOver;
public static GameObject tracer;
public Camera goCam;
public float speed = 1f;
public float offset = 0f;
public bool camInit;
public GameObject customMesh = null;
static public bool disableFreeAlerts = true;
public bool multipleTerrains;
public bool editRestore = true;
public Material roadMaterialEdit;
static public int backupLocation = 0;
public string[] backupStrings = new string[2]{"Outside Assets folder path","Inside Assets folder path"};
public Vector3[] leftVecs = new Vector3[0];
public Vector3[] rightVecs = new Vector3[0];
public bool applyTangents = false;
public bool sosBuild = false;
public float splinePos = 0;
public float camHeight = 3;
public Vector3 splinePosV3 = Vector3.zero;
public bool blendFlag; 
public float startBlendDistance = 5;
public float endBlendDistance = 5;
public bool iOS = false;
static public string extensionPath = "";
public void ODODCDOOQC(List<ODODDQQO> arr, String[] DOODQOQO, String[] OODDQOQO){

OCQOQOCQDC(transform, arr, DOODQOQO, OODDQOQO);
}
public void OQCQDQCDQO(MarkerScript markerScript){

OOCODCOCQQ = markerScript.transform;



List<GameObject> tmp = new List<GameObject>();
for(int i=0;i<OOCODCOCQQs.Length;i++){
if(OOCODCOCQQs[i] != markerScript.gameObject)tmp.Add(OOCODCOCQQs[i]);
}




tmp.Add(markerScript.gameObject);
OOCODCOCQQs = tmp.ToArray();
OOCODCOCQQ = markerScript.transform;

OOOOODODCQ.OOQDOCCDQO(OOCODCOCQQ, OOCODCOCQQs, markerScript.OQODDCOODQ, markerScript.OOQQQOCQCD, OCCOCOOOCC, out markerScript.OOCODCOCQQs, out markerScript.trperc, OOCODCOCQQs);

OOCOQOOODC = -1;
}
public void ODQOCODDCQ(MarkerScript markerScript){
if(markerScript.OOQQQOCQCD != markerScript.ODOOQQOO || markerScript.OOQQQOCQCD != markerScript.ODOOQQOO){
OOOOODODCQ.OOQDOCCDQO(OOCODCOCQQ, OOCODCOCQQs, markerScript.OQODDCOODQ, markerScript.OOQQQOCQCD, OCCOCOOOCC, out markerScript.OOCODCOCQQs, out markerScript.trperc, OOCODCOCQQs);
markerScript.ODQDOQOO = markerScript.OQODDCOODQ;
markerScript.ODOOQQOO = markerScript.OOQQQOCQCD;
}
if(OQOCQODQCO.autoUpdate) ODQCCQDQQC(OQOCQODQCO.geoResolution, false, false);
}
public void ResetMaterials(MarkerScript markerScript){
if(OOOOODODCQ != null)OOOOODODCQ.OOQDOCCDQO(OOCODCOCQQ, OOCODCOCQQs, markerScript.OQODDCOODQ, markerScript.OOQQQOCQCD, OCCOCOOOCC, out markerScript.OOCODCOCQQs, out markerScript.trperc, OOCODCOCQQs);
}
public void OOODQCCQDD(MarkerScript markerScript){
if(markerScript.OOQQQOCQCD != markerScript.ODOOQQOO){
OOOOODODCQ.OOQDOCCDQO(OOCODCOCQQ, OOCODCOCQQs, markerScript.OQODDCOODQ, markerScript.OOQQQOCQCD, OCCOCOOOCC, out markerScript.OOCODCOCQQs, out markerScript.trperc, OOCODCOCQQs);
markerScript.ODOOQQOO = markerScript.OOQQQOCQCD;
}
ODQCCQDQQC(OQOCQODQCO.geoResolution, false, false);
}
private void OOCQQQOODD(string ctrl, MarkerScript markerScript){
int i = 0;
foreach(Transform tr in markerScript.OOCODCOCQQs){
MarkerScript wsScript = (MarkerScript) tr.GetComponent<MarkerScript>();
if(ctrl == "rs") wsScript.LeftSurrounding(markerScript.rs - markerScript.ODOQQOOO, markerScript.trperc[i]);
else if(ctrl == "ls") wsScript.RightSurrounding(markerScript.ls - markerScript.DODOQQOO, markerScript.trperc[i]);
else if(ctrl == "ri") wsScript.LeftIndent(markerScript.ri - markerScript.OOQOQQOO, markerScript.trperc[i]);
else if(ctrl == "li") wsScript.RightIndent(markerScript.li - markerScript.ODODQQOO, markerScript.trperc[i]);
else if(ctrl == "rt") wsScript.LeftTilting(markerScript.rt - markerScript.ODDQODOO, markerScript.trperc[i]);
else if(ctrl == "lt") wsScript.RightTilting(markerScript.lt - markerScript.ODDOQOQQ, markerScript.trperc[i]);
else if(ctrl == "floorDepth") wsScript.FloorDepth(markerScript.floorDepth - markerScript.oldFloorDepth, markerScript.trperc[i]);
i++;
}
}
public void OOODDQDQQO(){
if(markers > 1) ODQCCQDQQC(OQOCQODQCO.geoResolution, false, false);
}
public void OCQOQOCQDC(Transform tr, List<ODODDQQO> arr, String[] DOODQOQO, String[] OODDQOQO){
version = "2.5.9.3";
OCDQQDOODQ = (GUISkin)Resources.Load("ER3DSkin", typeof(GUISkin));


OCDCQCDOCC = (Texture2D)Resources.Load("ER3DLogo", typeof(Texture2D));
if(RoadObjectScript.objectStrings == null){
RoadObjectScript.objectStrings = new string[3];
RoadObjectScript.objectStrings[0] = "Road Object"; RoadObjectScript.objectStrings[1]="River Object";RoadObjectScript.objectStrings[2]="Procedural Mesh Object";
}
obj = tr;
OOOOODODCQ = new OOQCOQOQQD();
OQOCQODQCO = obj.GetComponent<RoadObjectScript>();
foreach(Transform child in obj){
if(child.name == "Markers") OCCOCOOOCC = child;
}
RoadObjectScript[] rscrpts = (RoadObjectScript[])FindObjectsOfType(typeof(RoadObjectScript));
OOQCOQOQQD.terrainList.Clear();
Terrain[] terrains = (Terrain[])FindObjectsOfType(typeof(Terrain));
foreach(Terrain terrain in terrains) {
Terrains t = new Terrains();
t.terrain = terrain;
if(!terrain.gameObject.GetComponent<EasyRoads3DTerrainID>()){
EasyRoads3DTerrainID terrainscript = (EasyRoads3DTerrainID)terrain.gameObject.AddComponent<EasyRoads3DTerrainID>();
string id = UnityEngine.Random.Range(100000000,999999999).ToString();
terrainscript.terrainid = id;
t.id = id;
}else{
t.id = terrain.gameObject.GetComponent<EasyRoads3DTerrainID>().terrainid;
}
OOOOODODCQ.OCDCQQCDDC(t);
}
OQCQQDCCCO.OCDCQQCDDC();
if(roadMaterialEdit == null){
roadMaterialEdit = (Material)Resources.Load("materials/roadMaterialEdit", typeof(Material));
}
if(objectType == 0 && GameObject.Find(gameObject.name + "/road") == null){
GameObject road = new GameObject("road");
road.transform.parent = transform;
}

OOOOODODCQ.OOOODCDDQD(obj, ODCCQODQCO, OQOCQODQCO.roadWidth, surfaceOpacity, out OCDQCOOOOC, out indent, applyAnimation, waveSize, waveHeight);
OOOOODODCQ.OODODDCCCQ = OODODDCCCQ;
OOOOODODCQ.OCQQCOCCCQ = OCQQCOCCCQ;
OOOOODODCQ.OdQODQOD = OdQODQOD + 1;
OOOOODODCQ.OOQQQDOD = OOQQQDOD;
OOOOODODCQ.OOQQQDODOffset = OOQQQDODOffset;
OOOOODODCQ.OOQQQDODLength = OOQQQDODLength;
OOOOODODCQ.objectType = objectType;
OOOOODODCQ.snapY = snapY;
OOOOODODCQ.terrainRendered = OQCCDOOOCC;
OOOOODODCQ.handleVegetation = handleVegetation;
OOOOODODCQ.raise = raise;
OOOOODODCQ.roadResolution = roadResolution;
OOOOODODCQ.multipleTerrains = multipleTerrains;
OOOOODODCQ.editRestore = editRestore;
OOOOODODCQ.roadMaterialEdit = roadMaterialEdit;
OOOOODODCQ.renderRoad = renderRoad;
OOOOODODCQ.rscrpts = rscrpts.Length;
OOOOODODCQ.blendFlag = blendFlag; 
OOOOODODCQ.startBlendDistance = startBlendDistance;
OOOOODODCQ.endBlendDistance = endBlendDistance;

OOOOODODCQ.iOS = iOS;

if(backupLocation == 0)ODQQDOOOOO.backupFolder = "/EasyRoads3D";
else ODQQDOOOOO.backupFolder =  ODQQDOOOOO.extensionPath + "/Backups";

ODODQOQO = OOOOODODCQ.OCDCOOOOQC();
ODODQOQOInt = OOOOODODCQ.OCQQCCDCDD();


if(OQCCDOOOCC){




doRestore = true;
}


OQOQQQCDOQ();

if(arr != null || ODODQOOQ == null) OCODODQDDO(arr, DOODQOQO, OODDQOQO);


if(doRestore) return;
}
public void UpdateBackupFolder(){
}
public void ODQQCODQDC(){
if(!ODODDDOO || objectType == 2){
if(OCCOCODOCO != null){
for(int i = 0; i < OCCOCODOCO.Length; i++){
OCCOCODOCO[i] = false;
OQODOOOOQC[i] = false;
}
}
}
}

public void OQDCOOOOQC(Vector3 pos){


if(!displayRoad){
displayRoad = true;
OOOOODODCQ.OOQCQOCOOC(displayRoad, OCCOCOOOCC);
}
pos.y += OQOCQODQCO.raiseMarkers;
if(forceY && ODOQDQOO != null){
float dist = Vector3.Distance(pos, ODOQDQOO.transform.position);
pos.y = ODOQDQOO.transform.position.y + (yChange * (dist / 100f));
}else if(forceY && markers == 0) lastY = pos.y;
GameObject go = null;
if (ODOQDQOO != null)
go = (GameObject)Instantiate (ODOQDQOO);
else {
go = Instantiate (Resources.Load ("marker", typeof(GameObject))) as GameObject;

}
Transform newnode = go.transform;
newnode.position = pos;
newnode.parent = OCCOCOOOCC;
markers++;
string n;
if(markers < 10) n = "Marker000" + markers.ToString();
else if (markers < 100) n = "Marker00" + markers.ToString();
else n = "Marker0" + markers.ToString();
newnode.gameObject.name = n;
MarkerScript scr = newnode.GetComponent<MarkerScript>();
foreach(Transform child in go.transform)
{
if(child.name == "surface"){
scr.surface = child;
if(child.GetComponent<MeshFilter>()){
if(child.GetComponent<MeshFilter> ().sharedMesh == null)child.GetComponent<MeshFilter> ().sharedMesh = new Mesh ();
if(child.GetComponent<MeshCollider>()){
child.GetComponent<MeshCollider> ().sharedMesh = child.GetComponent<MeshFilter> ().sharedMesh;
}
}
}
}
scr.OCDQCOOOOC = false;
scr.objectScript = obj.GetComponent<RoadObjectScript>();
if(ODOQDQOO == null){
scr.waterLevel = OQOCQODQCO.waterLevel;
scr.floorDepth = OQOCQODQCO.floorDepth;
scr.ri = OQOCQODQCO.indent;
scr.li = OQOCQODQCO.indent;
scr.rs = OQOCQODQCO.surrounding;
scr.ls = OQOCQODQCO.surrounding;
scr.tension = 0.5f;
if(objectType == 1){

pos.y -= waterLevel;
newnode.position = pos;
}
}
if(objectType == 2){
#if UNITY_3_5
if(scr.surface != null)scr.surface.gameObject.active = false;
#else
if(scr.surface != null)scr.surface.gameObject.SetActive(false);
#endif
}
ODOQDQOO = newnode.gameObject;
if(markers > 1){
ODQCCQDQQC(OQOCQODQCO.geoResolution, false, false);
if(materialType == 0){

OOOOODODCQ.OCCDCCQDCQ(materialType);

}
}
}
public void ODQCCQDQQC(float geo, bool renderMode, bool camMode){
OOOOODODCQ.OCDQDDDDCO.Clear();
int ii = 0;
ODQOOCQDQD k;
foreach(Transform child  in obj)
{
if(child.name == "Markers"){
foreach(Transform marker   in child) {
MarkerScript markerScript = marker.GetComponent<MarkerScript>();
markerScript.objectScript = obj.GetComponent<RoadObjectScript>();
if(!markerScript.OCDQCOOOOC) markerScript.OCDQCOOOOC = OOOOODODCQ.OCODDOQQDO(marker);
k  = new ODQOOCQDQD();
k.position = marker.position;
k.num = OOOOODODCQ.OCDQDDDDCO.Count;
k.object1 = marker;
k.object2 = markerScript.surface;
k.tension = markerScript.tension;
k.ri = markerScript.ri;
if(k.ri < 1)k.ri = 1f;
k.li =markerScript.li;
if(k.li < 1)k.li = 1f;
k.rt = markerScript.rt;
k.lt = markerScript.lt;
k.rs = markerScript.rs;
if(k.rs < 1)k.rs = 1f;
k.OQQQOOOQQQ = markerScript.rs;
k.ls = markerScript.ls;
if(k.ls < 1)k.ls = 1f;
k.OQDDOOQCOC = markerScript.ls;
k.renderFlag = markerScript.bridgeObject;
k.OOQOCDCQDD = markerScript.distHeights;
k.newSegment = markerScript.newSegment;
k.tunnelFlag = markerScript.tunnelFlag;
k.floorDepth = markerScript.floorDepth;
k.waterLevel = waterLevel;
k.lockWaterLevel = markerScript.lockWaterLevel;
k.sharpCorner = markerScript.sharpCorner;
k.OQCQOCOOQD = OOOOODODCQ;
markerScript.markerNum = ii;
markerScript.distance = "-1";
markerScript.OCOQOQCDCD = "-1";
OOOOODODCQ.OCDQDDDDCO.Add(k);
ii++;
}
}
}
distance = "-1";

OOOOODODCQ.OOOQDCCOCD = OQOCQODQCO.roadWidth;

OOOOODODCQ.OOOOQCCQOO(geo, obj, OQOCQODQCO.OOQDOOQQ, renderMode, camMode, objectType);
if(OOOOODODCQ.leftVecs.Count > 0){
leftVecs = OOOOODODCQ.leftVecs.ToArray();
rightVecs = OOOOODODCQ.rightVecs.ToArray();
}
}
public void StartCam(){

ODQCCQDQQC(0.5f, false, true);

}
public void OQOQQQCDOQ(){
int i = 0;
foreach(Transform child  in obj)
{
if(child.name == "Markers"){
i = 1;
string n;
foreach(Transform marker in child) {
if(i < 10) n = "Marker000" + i.ToString();
else if (i < 100) n = "Marker00" + i.ToString();
else n = "Marker0" + i.ToString();
marker.name = n;
ODOQDQOO = marker.gameObject;
i++;
}
}
}
markers = i - 1;

ODQCCQDQQC(OQOCQODQCO.geoResolution, false, false);
}
public List<Transform> RebuildObjs(){
RoadObjectScript[] scripts = (RoadObjectScript[])FindObjectsOfType(typeof(RoadObjectScript));
List<Transform> rObj = new List<Transform>();
foreach (RoadObjectScript script in scripts) {
if(script.transform != transform) rObj.Add(script.transform);
}
return rObj;
}
public void RestoreTerrain1(){

ODQCCQDQQC(OQOCQODQCO.geoResolution, false, false);
if(OOOOODODCQ != null) OOOOODODCQ.OOOQOODDOC();
ODODDDOO = false;
}
public void ODCDQOOOQC(){
OOOOODODCQ.ODCDQOOOQC(OQOCQODQCO.applySplatmap, OQOCQODQCO.splatmapSmoothLevel, OQOCQODQCO.renderRoad, OQOCQODQCO.tuw, OQOCQODQCO.roadResolution, OQOCQODQCO.raise, OQOCQODQCO.opacity, OQOCQODQCO.expand, OQOCQODQCO.offsetX, OQOCQODQCO.offsetY, OQOCQODQCO.beveledRoad, OQOCQODQCO.splatmapLayer, OQOCQODQCO.OdQODQOD, OOQQQDOD, OOQQQDODOffset, OOQQQDODLength);
}
public void OQOQQDOQDQ(){
OOOOODODCQ.OQOQQDOQDQ(OQOCQODQCO.renderRoad, OQOCQODQCO.tuw, OQOCQODQCO.roadResolution, OQOCQODQCO.raise, OQOCQODQCO.beveledRoad, OQOCQODQCO.OdQODQOD, OOQQQDOD, OOQQQDODOffset, OOQQQDODLength);
}
public void OQODDQOODQ(Vector3 pos, bool doInsert){


if(!displayRoad){
displayRoad = true;
OOOOODODCQ.OOQCQOCOOC(displayRoad, OCCOCOOOCC);
}

int first = -1;
int second = -1;
float dist1 = 10000;
float dist2 = 10000;
Vector3 newpos = pos;
ODQOOCQDQD k;
ODQOOCQDQD k1 = (ODQOOCQDQD)OOOOODODCQ.OCDQDDDDCO[0];
ODQOOCQDQD k2 = (ODQOOCQDQD)OOOOODODCQ.OCDQDDDDCO[1];

if(doInsert){

}
OOOOODODCQ.OOOCDCDQDD(pos, out first, out second, out dist1, out dist2, out k1, out k2, out newpos, doInsert);
if(doInsert){


}
pos = newpos;
if(doInsert && first >= 0 && second >= 0){


if(OQOCQODQCO.OOQDOOQQ && second == OOOOODODCQ.OCDQDDDDCO.Count - 1){
OQDCOOOOQC(pos);
}else{
k = (ODQOOCQDQD)OOOOODODCQ.OCDQDDDDCO[second];
string name = k.object1.name;
string n;
int j = second + 2;
for(int i = second; i < OOOOODODCQ.OCDQDDDDCO.Count - 1; i++){
k = (ODQOOCQDQD)OOOOODODCQ.OCDQDDDDCO[i];
if(j < 10) n = "Marker000" + j.ToString();
else if (j < 100) n = "Marker00" + j.ToString();
else n = "Marker0" + j.ToString();
k.object1.name = n;
j++;
}
k = (ODQOOCQDQD)OOOOODODCQ.OCDQDDDDCO[first];
Transform newnode = (Transform)Instantiate(k.object1.transform, pos, k.object1.rotation);
newnode.gameObject.name = name;
newnode.parent = OCCOCOOOCC;
newnode.SetSiblingIndex(second);
MarkerScript scr = newnode.GetComponent<MarkerScript>();
scr.OCDQCOOOOC = false;
float	totalDist = dist1 + dist2;
float perc1 = dist1 / totalDist;
float paramDif = k1.ri - k2.ri;
scr.ri = k1.ri - (paramDif * perc1);
paramDif = k1.li - k2.li;
scr.li = k1.li - (paramDif * perc1);
paramDif = k1.rt - k2.rt;
scr.rt = k1.rt - (paramDif * perc1);
paramDif = k1.lt - k2.lt;
scr.lt = k1.lt - (paramDif * perc1);
paramDif = k1.rs - k2.rs;
scr.rs = k1.rs - (paramDif * perc1);
paramDif = k1.ls - k2.ls;
scr.ls = k1.ls - (paramDif * perc1);
ODQCCQDQQC(OQOCQODQCO.geoResolution, false, false);
if(materialType == 0)OOOOODODCQ.OCCDCCQDCQ(materialType);
#if UNITY_3_5
if(objectType == 2) scr.surface.gameObject.active = false;
#else
if(objectType == 2) scr.surface.gameObject.SetActive(false);
#endif
}
}
OQOQQQCDOQ();
}
public void OCDCCCOCDD(){

DestroyImmediate(OQOCQODQCO.OOCODCOCQQ.gameObject);
OOCODCOCQQ = null;
OQOQQQCDOQ();
}
public void OCCCDOQDOD(){

OOOOODODCQ.OOQODOOQOD(12);

}

public List<SideObjectParams> OOCCOOODOO(){

List<SideObjectParams> param = new List<SideObjectParams>();
SideObjectParams sop;
foreach(Transform child in obj){
if(child.name == "Markers"){
foreach(Transform marker in child){
MarkerScript markerScript = marker.GetComponent<MarkerScript>();
sop  = new SideObjectParams();
sop.ODDGDOOO = markerScript.ODDGDOOO;
sop.ODDQOODO = markerScript.ODDQOODO;
sop.ODDQOOO = markerScript.ODDQOOO;
param.Add(sop);
}
}
}
return param;

}
public void OCCDOOOOCC(){

List<string> arrNames = new List<string>();
List<int> arrInts = new List<int>();
List<string> arrIDs = new List<string>();

for(int i=0;i<ODODOQQO.Length;i++){
if(ODODQQOD[i] == true){
arrNames.Add(ODODQOOQ[i]);
arrIDs.Add(ODODOQQO[i]);
arrInts.Add(i);
}
}
ODODDQOO = arrNames.ToArray();
OOQQQOQO = arrInts.ToArray();

}
public void OCODODQDDO(List<ODODDQQO> arr, String[] DOODQOQO, String[] OODDQOQO){




bool saveSOs = false;
ODODOQQO = DOODQOQO;
ODODQOOQ = OODDQOQO;






List<MarkerScript> markerArray = new List<MarkerScript>();
if(obj == null)OCQOQOCQDC(transform, null, null, null);
foreach(Transform child  in obj) {
if(child.name == "Markers"){
foreach(Transform marker  in child) {
MarkerScript markerScript = marker.GetComponent<MarkerScript>();
markerScript.OQODQQDO.Clear();
markerScript.ODOQQQDO.Clear();
markerScript.OQQODQQOO.Clear();
markerScript.ODDOQQOO.Clear();
markerArray.Add(markerScript);
}
}
}
mSc = markerArray.ToArray();





List<bool> arBools = new List<bool>();



int counter1 = 0;
int counter2 = 0;

if(ODQQQQQO != null){

if(arr.Count == 0) return;



for(int i = 0; i < ODODOQQO.Length; i++){
ODODDQQO so = (ODODDQQO)arr[i];

for(int j = 0; j < ODQQQQQO.Length; j++){
if(ODODOQQO[i] == ODQQQQQO[j]){
counter1++;


if(ODODQQOD.Length > j ) arBools.Add(ODODQQOD[j]);
else arBools.Add(false);

foreach(MarkerScript scr  in mSc) {


int l = -1;
for(int k = 0; k < scr.ODDOOQDO.Length; k++){
if(so.id == scr.ODDOOQDO[k]){
l = k;
break;
}
}
if(l >= 0){
scr.OQODQQDO.Add(scr.ODDOOQDO[l]);
scr.ODOQQQDO.Add(scr.ODDGDOOO[l]);
scr.OQQODQQOO.Add(scr.ODDQOOO[l]);

if(so.sidewaysDistanceUpdate == 0 || (so.sidewaysDistanceUpdate == 2 && (float)scr.ODDQOODO[l] != so.oldSidwaysDistance)){
scr.ODDOQQOO.Add(scr.ODDQOODO[l]);

}else{
scr.ODDOQQOO.Add(so.splinePosition);

}




}else{
scr.OQODQQDO.Add(so.id);
scr.ODOQQQDO.Add(so.markerActive);
scr.OQQODQQOO.Add(true);
scr.ODDOQQOO.Add(so.splinePosition);
}

}
}
}
if(so.sidewaysDistanceUpdate != 0){



}
saveSOs = false;
}
}


for(int i = 0; i < ODODOQQO.Length; i++){
ODODDQQO so = (ODODDQQO)arr[i];
bool flag = false;
for(int j = 0; j < ODQQQQQO.Length; j++){

if(ODODOQQO[i] == ODQQQQQO[j])flag = true;
}
if(!flag){
counter2++;

arBools.Add(false);

foreach(MarkerScript scr  in mSc) {
scr.OQODQQDO.Add(so.id);
scr.ODOQQQDO.Add(so.markerActive);
scr.OQQODQQOO.Add(true);
scr.ODDOQQOO.Add(so.splinePosition);
}

}
}

ODODQQOD = arBools.ToArray();


ODQQQQQO = new String[ODODOQQO.Length];
ODODOQQO.CopyTo(ODQQQQQO,0);





List<int> arInt= new List<int>();
for(int i = 0; i < ODODQQOD.Length; i++){
if(ODODQQOD[i]) arInt.Add(i);
}
OOQQQOQO  = arInt.ToArray();


foreach(MarkerScript scr  in mSc) {
scr.ODDOOQDO = scr.OQODQQDO.ToArray();
scr.ODDGDOOO = scr.ODOQQQDO.ToArray();
scr.ODDQOOO = scr.OQQODQQOO.ToArray();
scr.ODDQOODO = scr.ODDOQQOO.ToArray();

}
if(saveSOs){

}




}
public void SetMultipleTerrains(bool flag){
RoadObjectScript[] scrpts = (RoadObjectScript[])FindObjectsOfType(typeof(RoadObjectScript));
foreach(RoadObjectScript scr in scrpts){
scr.multipleTerrains = flag;
if(scr.OOOOODODCQ != null)scr.OOOOODODCQ.multipleTerrains = flag;
}
}
public bool CheckWaterHeights(){
if(OQCQQDCCCO.terrain == null) return false;
bool flag = true;

float y = OQCQQDCCCO.terrain.transform.position.y;
foreach(Transform child  in obj) {
if(child.name == "Markers"){
foreach(Transform marker  in child) {

if(marker.position.y - y <= 0.1f) flag = false;
}
}
}
return flag;
}
}
