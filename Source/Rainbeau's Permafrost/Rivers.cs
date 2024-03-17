using UnityEngine;
using Verse;

namespace RPF_Code;

public class Rivers(Map map) : MapComponent(map)
{
    public int cycleIndex;

    public override void MapComponentTick()
    {
        base.MapComponentTick();
        if (Controller.Settings.waterFreezes.Equals(false))
        {
            return;
        }

        var num = Mathf.RoundToInt(map.Area * 0.00005f);
        var area = map.Area;
        for (var i = 0; i < num; i++)
        {
            cycleIndex++;
            if (cycleIndex >= area)
            {
                cycleIndex = 0;
            }

            var c = map.cellsInRandomOrder.Get(cycleIndex);
            var terrainDef = map.terrainGrid.TerrainAt(c);
            if (!GenTemperature.TryGetTemperatureForCell(c, map, out var cellTemp))
            {
                cellTemp = 0f;
            }

            var shallowChance = cellTemp * cellTemp * 0.8f / 100f;
            var deepChance = cellTemp * cellTemp * 0.16f / 100f;
            var permafrostChance = deepChance;
            if (permafrostChance > 0.2f)
            {
                permafrostChance = 0.2f;
            }

            if (cellTemp < -8f)
            {
                if (terrainDef.defName is "WaterMovingShallow" or "IceSMT")
                {
                    var freezable = 0;
                    for (var k = -1; k < 2; k++)
                    {
                        for (var j = -1; j < 2; j++)
                        {
                            var x = c.x + k;
                            var z = c.z + j;
                            if ((k != 0 || j != 1) && (k != 0 || j != -1) && (k != 1 || j != 0) && (k != -1 || j != 0))
                            {
                                continue;
                            }

                            if (x <= 0 || x >= map.Size.x || z <= 0 || z >= map.Size.z)
                            {
                                continue;
                            }

                            var newSpot = new IntVec3(x, 0, z);
                            if (!map.terrainGrid.TerrainAt(newSpot).defName.Contains("Water") &&
                                map.terrainGrid.TerrainAt(newSpot).defName != "Marsh" &&
                                map.terrainGrid.TerrainAt(newSpot).defName != "BridgeMarsh" &&
                                map.terrainGrid.TerrainAt(newSpot).defName != "Bridge")
                            {
                                freezable++;
                            }
                        }
                    }

                    if (Rand.Value < shallowChance * freezable)
                    {
                        var thingList = c.GetThingList(map);
                        // ReSharper disable once ForCanBeConvertedToForeach
                        for (var j = 0; j < thingList.Count; j++)
                        {
                            var item = thingList[j];
                            if (item.def.defName is "Fishing Spot" or "ZARS_FishingSpot")
                            {
                                item.Destroy();
                            }
                        }

                        var iceType = terrainDef.defName == "WaterMovingShallow" ? "IceSMT" : "IceSM";

                        map.terrainGrid.SetTerrain(c, TerrainDef.Named(iceType));
                    }
                }

                if (terrainDef.defName is "WaterMovingChestDeep" or "IceDMT")
                {
                    var freezable = 0;
                    for (var k = -1; k < 2; k++)
                    {
                        for (var j = -1; j < 2; j++)
                        {
                            var x = c.x + k;
                            var z = c.z + j;
                            if ((k != 0 || j != 1) && (k != 0 || j != -1) && (k != 1 || j != 0) && (k != -1 || j != 0))
                            {
                                continue;
                            }

                            if (x <= 0 || x >= map.Size.x || z <= 0 || z >= map.Size.z)
                            {
                                continue;
                            }

                            var newSpot = new IntVec3(x, 0, z);
                            if (!map.terrainGrid.TerrainAt(newSpot).defName.Contains("Water") &&
                                map.terrainGrid.TerrainAt(newSpot).defName != "Marsh" &&
                                map.terrainGrid.TerrainAt(newSpot).defName != "BridgeMarsh" &&
                                map.terrainGrid.TerrainAt(newSpot).defName != "Bridge")
                            {
                                freezable++;
                            }
                        }
                    }

                    if (Rand.Value < permafrostChance * freezable)
                    {
                        var thingList = c.GetThingList(map);
                        // ReSharper disable once ForCanBeConvertedToForeach
                        for (var j = 0; j < thingList.Count; j++)
                        {
                            var item = thingList[j];
                            if (item.def.defName is "Fishing Spot" or "ZARS_FishingSpot")
                            {
                                item.Destroy();
                            }
                        }

                        var iceType = terrainDef.defName == "WaterMovingChestDeep" ? "IceDMT" : "IceDM";

                        map.terrainGrid.SetTerrain(c, TerrainDef.Named(iceType));
                    }
                }
            }

            if (!(cellTemp > -20f))
            {
                continue;
            }

            if (!terrainDef.defName.Contains("IceSM") && !terrainDef.defName.Contains("IceDM"))
            {
                continue;
            }

            var quickThaw = 1;
            for (var k = -1; k < 2; k++)
            {
                for (var j = -1; j < 2; j++)
                {
                    var x = c.x + k;
                    var z = c.z + j;
                    if ((k != 0 || j != 1) && (k != 0 || j != -1) && (k != 1 || j != 0) && (k != -1 || j != 0))
                    {
                        continue;
                    }

                    if (x <= 0 || x >= map.Size.x || z <= 0 || z >= map.Size.z)
                    {
                        continue;
                    }

                    var newSpot = new IntVec3(x, 0, z);
                    if (!terrainDef.label.Contains("Thin"))
                    {
                        if (map.terrainGrid.TerrainAt(newSpot).defName.Contains("Water") ||
                            map.terrainGrid.TerrainAt(newSpot).defName == "Marsh" ||
                            map.terrainGrid.TerrainAt(newSpot).label.Contains("Thin"))
                        {
                            quickThaw++;
                        }
                    }
                    else
                    {
                        if (map.terrainGrid.TerrainAt(newSpot).defName.Contains("Water") ||
                            map.terrainGrid.TerrainAt(newSpot).defName == "Marsh")
                        {
                            quickThaw++;
                        }
                    }
                }
            }

            if (quickThaw == 1)
            {
                if (Rand.Value < 0.67f)
                {
                    quickThaw = 0;
                }
            }

            if (!(Rand.Value < shallowChance * quickThaw))
            {
                continue;
            }

            string waterType;
            if (terrainDef.defName == "IceSMT")
            {
                waterType = "WaterMovingShallow";
            }
            else if (terrainDef.defName == "IceSM")
            {
                waterType = "IceSMT";
            }
            else if (terrainDef.defName == "IceDMT")
            {
                waterType = "WaterMovingChestDeep";
            }
            else
            {
                waterType = "IceDMT";
            }

            if (waterType.Contains("Water"))
            {
                map.snowGrid.SetDepth(c, 0f);
            }

            map.terrainGrid.SetTerrain(c, TerrainDef.Named(waterType));
        }
    }
}