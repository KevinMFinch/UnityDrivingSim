@CustomEditor(EasyRoads3DTerrainID)
class TerrainEditorScript extends Editor
{
function OnSceneGUI()
{
if(Event.current.shift && RoadObjectScript.ODCQQODDCO != null) Selection.activeGameObject = RoadObjectScript.ODCQQODDCO.gameObject;
else RoadObjectScript.ODCQQODDCO = null;
}
}
