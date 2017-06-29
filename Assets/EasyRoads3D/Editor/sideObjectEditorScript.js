@CustomEditor(sideObjectScript)
class sideObjectEditorScript extends Editor
{

function OnInspectorGUI()
{
if(target.OQOCQODQCO.OOOOODODCQ == null || target.OQOCQODQCO.erInit == ""){
var arr = OCDQDCQOCQ.OQOODCQQCO(false);
target.OQOCQODQCO.ODODCDOOQC(arr, OCDQDCQOCQ.OQQQOOOOOC(arr), OCDQDCQOCQ.OQODCCCCCD(arr));
Selection.activeGameObject = target.transform.parent.parent.gameObject;
}
EditorGUILayout.Space();
EditorGUILayout.Space();

EditorGUILayout.BeginVertical("Box");
EditorGUILayout.LabelField(" EasyRoads3D Side Object", EditorStyles.boldLabel);
EditorGUILayout.EndVertical();
EditorGUILayout.Space();
GUILayout.Label("    Name: "+target.soName);
EditorGUILayout.Space();
if(target.rotationStrings == null || target.rotationStrings.Length == 0){
target.rotationStrings = new String[4];
target.rotationStrings[0] = "none";
target.rotationStrings[1] = "Terrain Normal";
target.rotationStrings[2] = "Path Normal";
target.rotationStrings[3] = "Path Sideways";
target.childOrderStrings = new String[3];
target.childOrderStrings[0] = "All";
target.childOrderStrings[1] = "Child Sequence";
target.childOrderStrings[2] = "Random";
if(target.goInstantiated != null)target.childCount =  target.goInstantiated.transform.childCount;
}

EditorGUILayout.BeginHorizontal();
GUILayout.Label(new GUIContent("    X Position", "The distance on the x-axis to the current point on the active spline"), GUILayout.Width(85) );
var so : float = target.xPosition;
target.xPosition = EditorGUILayout.Slider(target.xPosition, -50, 50);
EditorGUILayout.EndHorizontal();
if(so != target.xPosition) {
var scr: RoadObjectScript = target.transform.parent.parent.gameObject.GetComponent("RoadObjectScript");

OCDQDCQOCQ.ODDOQCCOCD(scr.transform, target.soIndex, target.xPosition);
RoadObjectEditorScript.OODODODOOD(scr, target.soIndex, target.objectScript);
}
EditorGUILayout.BeginHorizontal();
GUILayout.Label(new GUIContent("    Y Position", "The distance on the y-axis to the current point the active spline"), GUILayout.Width(85) );
so = target.yPosition;
target.yPosition = EditorGUILayout.Slider(target.yPosition, -50, 50);
EditorGUILayout.EndHorizontal();
if(so != target.yPosition) {

scr = target.transform.parent.parent.gameObject.GetComponent("RoadObjectScript");

OCDQDCQOCQ.OOCOQQOQOO(scr.transform, target.soIndex, target.yPosition);
RoadObjectEditorScript.OODODODOOD(scr, target.soIndex, target.objectScript);
}


var oA : int = target.soAlign;
EditorGUILayout.BeginHorizontal();
GUILayout.Label(new GUIContent("    Align with Terrain", "This controls the x, z rotation of the side objects"), GUILayout.Width(125) );
target.soAlign = EditorGUILayout.Popup (target.soAlign, target.rotationStrings);
EditorGUILayout.EndHorizontal();
if(oA != target.soAlign){

scr = target.transform.parent.parent.gameObject.GetComponent("RoadObjectScript");

OCDQDCQOCQ.OOCDCCDODD(scr.transform, target.soIndex, target.soAlign);
RoadObjectEditorScript.OODODODOOD(scr, target.soIndex, target.objectScript);


}

if(target.objectType == 2 || target.position == 2){
EditorGUILayout.BeginHorizontal();
GUILayout.Label(new GUIContent("    Distance", "The face or object Distance in metres."), GUILayout.Width(85) );
so = target.m_distance;
target.m_distance = EditorGUILayout.Slider(target.m_distance, 1, 50);
EditorGUILayout.EndHorizontal();
if(so != target.m_distance) {

scr = target.transform.parent.parent.gameObject.GetComponent("RoadObjectScript");

OCDQDCQOCQ.OCCCOOCDDC(scr.transform, target.soIndex, target.m_distance);
RoadObjectEditorScript.OODODODOOD(scr, target.soIndex, target.objectScript);
}
}
if(target.objectType > 0){
if(target.uvStrings == null){
target.uvStrings = new String[2];
target.uvStrings[0] = "Tiled"; target.uvStrings[1]="Clamped";
}
var uvInt : int = target.uvInt;
EditorGUILayout.BeginHorizontal();
GUILayout.Label("    UV Type",GUILayout.Width(85));
target.uvInt = EditorGUILayout.Popup (target.uvInt, target.uvStrings);
EditorGUILayout.EndHorizontal();
if(uvInt != target.uvInt){

scr = target.transform.parent.parent.gameObject.GetComponent("RoadObjectScript");

OCDQDCQOCQ.OODOOODDQC(scr.transform, target.soIndex, target.uvInt);
RoadObjectEditorScript.OODODODOOD(scr, target.soIndex, target.objectScript);
}
if(target.uvInt == 0){
EditorGUILayout.BeginHorizontal();
GUILayout.Label(new GUIContent("    UV X Tiling", "This controls the uv in the width of the object."), GUILayout.Width(85) );
so = target.soUVx;
target.soUVx = EditorGUILayout.Slider(target.soUVx, 0, 5);
EditorGUILayout.EndHorizontal();
if(so != target.soUVx) {

scr = target.transform.parent.parent.gameObject.GetComponent("RoadObjectScript");

OCDQDCQOCQ.ODOOCQDQOO(scr.transform, target.soIndex, target.soUVx, target.soUVy);
RoadObjectEditorScript.OODODODOOD(scr, target.soIndex, target.objectScript);
}
EditorGUILayout.BeginHorizontal();
GUILayout.Label(new GUIContent("    UV Y Tiling", "This controls the uv in the length of the object."), GUILayout.Width(85) );
so = target.soUVy;
target.soUVy = EditorGUILayout.Slider(target.soUVy, 0, 5);
EditorGUILayout.EndHorizontal();
if(so != target.soUVy) {

scr = target.transform.parent.parent.gameObject.GetComponent("RoadObjectScript");

OCDQDCQOCQ.ODOOCQDQOO(scr.transform, target.soIndex, target.soUVx, target.soUVy);
RoadObjectEditorScript.OODODODOOD(scr, target.soIndex, target.objectScript);
}
}
if(target.ODQQOCOODO != "" || target.OOOCCODCDO != ""){
EditorGUILayout.BeginHorizontal();
GUILayout.Space(20);
var bo : boolean = target.combine;
target.combine = EditorGUILayout.Toggle (target.combine );
EditorGUILayout.EndHorizontal();
GUILayout.Space(-20);
GUILayout.Label(new GUIContent("         Combine procedural objects", "Combine procedural geometry and start / end objects"), GUILayout.Width(250) );
if(bo != target.combine){

scr = target.transform.parent.parent.gameObject.GetComponent("RoadObjectScript");

OCDQDCQOCQ.OOCCCCCDCO(scr.transform, target.soIndex, target.combine);
RoadObjectEditorScript.OODODODOOD(scr, target.soIndex, target.objectScript);
}
if(target.combine){
EditorGUILayout.BeginHorizontal();
GUILayout.Space(20);
bo = target.weld;
target.weld = EditorGUILayout.Toggle (target.weld );
EditorGUILayout.EndHorizontal();
GUILayout.Space(-20);
GUILayout.Label(new GUIContent("        Weld Vertices", "Weld matching vertices of procedural geometry and start / end objects"), GUILayout.Width(250) );
if(bo != target.weld){

scr = target.transform.parent.parent.gameObject.GetComponent("RoadObjectScript");

OCDQDCQOCQ.OCQCDOCOCC(scr.transform, target.soIndex, target.weld);
RoadObjectEditorScript.OODODODOOD(scr, target.soIndex, target.objectScript);
}
}
}
EditorGUILayout.Space();
EditorGUILayout.BeginHorizontal();
GUILayout.Space(20);
co = target.m_tangents;
target.m_tangents = EditorGUILayout.Toggle (target.m_tangents );
EditorGUILayout.EndHorizontal();
GUILayout.Space(-20);
GUILayout.Label(new GUIContent("        Add Mesh Tangents", "This will automatically calculate mesh tangents data required for bump mapping. Note that this will take a little bit more processing time."), GUILayout.Width(250) );
if(co != target.m_tangents){

scr = target.transform.parent.parent.gameObject.GetComponent("RoadObjectScript");
OCDQDCQOCQ.HandleTangents(scr.transform, target.soIndex, target.m_tangents);
RoadObjectEditorScript.OODODODOOD(scr, target.soIndex, target.objectScript);
}
EditorGUILayout.Space();
EditorGUILayout.BeginHorizontal();
GUILayout.Space(20);
co = target.m_collider;
target.m_collider = EditorGUILayout.Toggle (target.m_collider );
EditorGUILayout.EndHorizontal();
GUILayout.Space(-20);
GUILayout.Label(new GUIContent("        Add Mesh Collider", "Add a Mesh Collider to the created procedural mesh"), GUILayout.Width(250) );
if(co != target.m_collider){

scr = target.transform.parent.parent.gameObject.GetComponent("RoadObjectScript");
OCDQDCQOCQ.HandleCollision(scr.transform, target.soIndex, target.m_collider);
RoadObjectEditorScript.OODODODOOD(scr, target.soIndex, target.objectScript);
}
EditorGUILayout.Space();
if( target.m_go != ""){

EditorGUILayout.BeginHorizontal();
GUILayout.Space(20);
bo = target.ODQDOQCCDC;
target.ODQDOQCCDC = EditorGUILayout.Toggle (target.ODQDOQCCDC );
EditorGUILayout.EndHorizontal();
GUILayout.Space(-20);
GUILayout.Label(new GUIContent("         Combine instantiated objects", "Combine instantiated objects"), GUILayout.Width(250) );
if(bo != target.ODQDOQCCDC){

scr = target.transform.parent.parent.gameObject.GetComponent("RoadObjectScript");

OCDQDCQOCQ.OQCOOCQOQO(scr.transform, target.soIndex, target.ODQDOQCCDC, true);
RoadObjectEditorScript.OODODODOOD(scr, target.soIndex, target.objectScript);
}

}
EditorGUILayout.Space();
var mat : Material = target.mat;
EditorGUILayout.BeginHorizontal();
GUILayout.Label("    Material",GUILayout.Width(85));
target.mat = EditorGUILayout.ObjectField(target.mat, typeof(Material), false);
EditorGUILayout.EndHorizontal();
if(mat != target.mat){

scr = target.transform.parent.parent.gameObject.GetComponent("RoadObjectScript");

OCDQDCQOCQ.OCDDOQDCDD(scr.transform, target.soIndex, AssetDatabase.AssetPathToGUID(AssetDatabase.GetAssetPath(target.mat)), AssetDatabase.GetAssetPath(target.mat));
RoadObjectEditorScript.OODODODOOD(scr, target.soIndex, target.objectScript);
}
EditorGUILayout.Space();
EditorGUILayout.BeginHorizontal();
GUILayout.FlexibleSpace();
if(GUILayout.Button ("Flip Faces", GUILayout.Width(235))){
scr = target.transform.parent.parent.gameObject.GetComponent("RoadObjectScript");

OCDQDCQOCQ.OOCCDOQOQO(scr.transform, target.soIndex);

RoadObjectEditorScript.OODODODOOD(scr, target.soIndex, target.objectScript);

}
GUILayout.FlexibleSpace();
EditorGUILayout.EndHorizontal();
EditorGUILayout.BeginHorizontal();
GUILayout.FlexibleSpace();
if(GUILayout.Button ("Mirror Horizontally", GUILayout.Width(235))){
scr = target.transform.parent.parent.gameObject.GetComponent("RoadObjectScript");

OCDQDCQOCQ.OQCDCOCDDD(scr.transform, target.soIndex);
RoadObjectEditorScript.OODODODOOD(scr, target.soIndex, target.objectScript);
}
GUILayout.FlexibleSpace();
EditorGUILayout.EndHorizontal();
}else{
EditorGUILayout.BeginHorizontal();
GUILayout.Label(new GUIContent("    Distance", "The face or object Distance in metres."), GUILayout.Width(85) );
so = target.m_distance;
target.m_distance = EditorGUILayout.Slider(target.m_distance, 1, 50);
EditorGUILayout.EndHorizontal();
if(so != target.m_distance) {

scr = target.transform.parent.parent.gameObject.GetComponent("RoadObjectScript");

OCDQDCQOCQ.OCCCOOCDDC(scr.transform, target.soIndex, target.m_distance);
RoadObjectEditorScript.OODODODOOD(scr, target.soIndex, target.objectScript);
}
if(sideObjectScript.rotationOptions == null){
sideObjectScript.rotationOptions = new String[3];
sideObjectScript.rotationOptions[0] = "Follow Road";
sideObjectScript.rotationOptions[1] = "Fixed";
sideObjectScript.rotationOptions[2] = "Random";
}

var rt : int = target.selectedRotation;
EditorGUILayout.BeginHorizontal();
GUILayout.Label(new GUIContent("    Y-axis Rotation", ""), GUILayout.Width(105) );
target.selectedRotation = EditorGUILayout.Popup (target.selectedRotation, target.rotationOptions);
EditorGUILayout.EndHorizontal();
if(rt != target.selectedRotation){

scr = target.transform.parent.parent.gameObject.GetComponent("RoadObjectScript");

OCDQDCQOCQ.ODDQQQOCCC(scr.transform, target.soIndex, target.selectedRotation);
RoadObjectEditorScript.OODODODOOD(scr, target.soIndex,target.objectScript);
}

if(target.childCount < 2) GUI.enabled = false;
rt = target.childOrder;
EditorGUILayout.BeginHorizontal();
GUILayout.Label(new GUIContent("    Prefab childs", "Here you can choose how prefabs with multiple childs objects should be hanfled per instance"), GUILayout.Width(105));

target.childOrder = EditorGUILayout.Popup (target.childOrder, target.childOrderStrings);
EditorGUILayout.EndHorizontal();
if(rt != target.childOrder){

scr = target.transform.parent.parent.gameObject.GetComponent("RoadObjectScript");
OCDQDCQOCQ.OODOOCCCCC(scr.transform, target.soIndex, target.childOrder);
RoadObjectEditorScript.OODODODOOD(scr, target.soIndex, target.objectScript);
}
GUI.enabled = true;
so =  target.density;
EditorGUILayout.BeginHorizontal();
GUILayout.Label(new GUIContent("    Density", "Use this to add variation along the path"), GUILayout.Width(85));
target.density = EditorGUILayout.Slider(target.density,0,1f);
EditorGUILayout.EndHorizontal();
if(so != target.density){
scr = target.transform.parent.parent.gameObject.GetComponent("RoadObjectScript");
OCDQDCQOCQ.ODCOCDDOCQ(scr.transform, target.soIndex, target.density);
RoadObjectEditorScript.OODODODOOD(scr, target.soIndex, target.objectScript);
}
so =  target.sidewaysOffset;
EditorGUILayout.BeginHorizontal();
GUILayout.Label(new GUIContent("    Max offset", "This randomly moves objects sideways within the chosen distance (m)"), GUILayout.Width(85));
target.sidewaysOffset = EditorGUILayout.Slider(target.sidewaysOffset,0,10);
GUILayout.Label("m", EditorStyles.label);
EditorGUILayout.EndHorizontal();
if(so != target.sidewaysOffset){

scr = target.transform.parent.parent.gameObject.GetComponent("RoadObjectScript");
OCDQDCQOCQ.OODQDDCCQD(scr.transform, target.soIndex, target.sidewaysOffset);
RoadObjectEditorScript.OODODODOOD(scr, target.soIndex, target.objectScript);
}

}
if(target.objectType == 0){
EditorGUILayout.BeginHorizontal();
GUILayout.Space(20);
bo = target.ODQDOQCCDC;
target.ODQDOQCCDC = EditorGUILayout.Toggle (target.ODQDOQCCDC );
EditorGUILayout.EndHorizontal();
GUILayout.Space(-20);
GUILayout.Label(new GUIContent("        Combine instantiated objects", "Combine instantiated objects"), GUILayout.Width(250) );
if(bo != target.ODQDOQCCDC){

scr = target.transform.parent.parent.gameObject.GetComponent("RoadObjectScript");

if(target.OQOCQODQCO.objectType != 2){
OCDQDCQOCQ.OQCOOCQOQO(scr.transform, target.soIndex, target.ODQDOQCCDC, true);
RoadObjectEditorScript.OODODODOOD(scr, target.soIndex, target.objectScript);
}else if(!target.ODQDOQCCDC){
OCDQDCQOCQ.OQCOOCQOQO(scr.transform, target.soIndex, target.ODQDOQCCDC, false);
OCDQDCQOCQ.UnOOOQODDCDQ(target.gameObject);
}else{
OCDQDCQOCQ.OQCOOCQOQO(scr.transform, target.soIndex, target.ODQDOQCCDC, false);
OCDQDCQOCQ.OOOQODDCDQ(target.gameObject, null, null, target.OQOCQODQCO.objectType);
}
}

}
GUILayout.Space(10);
if(target.terrainTree > 0){
GUILayout.Space(10);
EditorGUILayout.BeginHorizontal();
GUILayout.FlexibleSpace();
if(GUILayout.Button ("Update Terrain Vegetation", GUILayout.Width(175))){
Debug.Log(target.soIndex);
OCDQDCQOCQ.OQQCCDQCQD(target.soIndex, target.transform);
}
GUILayout.FlexibleSpace();
EditorGUILayout.EndHorizontal();
}
GUILayout.Space(30);
}

}
