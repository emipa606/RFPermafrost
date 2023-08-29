using RimWorld;
using UnityEngine;
using Verse;

namespace RPF_Code;

public class Lakes : MapComponent
{
    public int cycleIndex;

    public Lakes(Map map) : base(map)
    {
    }

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

            var shallowChance = cellTemp * cellTemp / 100f;
            var deepChance = cellTemp * cellTemp * 0.2f / 100f;
            var permafrostChance = deepChance;
            if (permafrostChance > 0.2f)
            {
                permafrostChance = 0.2f;
            }

            if (cellTemp < 0f)
            {
                if (terrainDef.defName is "WaterShallow" or "IceST")
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

                        var iceType = terrainDef.defName == "WaterShallow" ? "IceST" : "IceS";

                        map.terrainGrid.SetTerrain(c, TerrainDef.Named(iceType));
                    }
                }

                if (terrainDef.defName is "WaterDeep" or "IceDT")
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

                    if (Rand.Value < deepChance * freezable)
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

                        var iceType = terrainDef.defName == "WaterDeep" ? "IceDT" : "IceD";

                        map.terrainGrid.SetTerrain(c, TerrainDef.Named(iceType));
                    }
                }

                if (terrainDef.defName is "Marsh" or "IceMarshT")
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

                        var iceType = terrainDef.defName == "Marsh" ? "IceMarshT" : "IceMarsh";

                        map.terrainGrid.SetTerrain(c, TerrainDef.Named(iceType));
                    }
                }

                if (terrainDef.defName is "Soil" or "Gravel" or "MossyTerrain" &&
                    map.Biome.defName.Contains("Permafrost"))
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
                            if (map.terrainGrid.TerrainAt(newSpot).defName == "Ice")
                            {
                                freezable++;
                            }
                        }
                    }

                    if (Rand.Value < permafrostChance / 8 * freezable)
                    {
                        var thingList = c.GetThingList(map);
                        // ReSharper disable once ForCanBeConvertedToForeach
                        for (var j = 0; j < thingList.Count; j++)
                        {
                            var item = thingList[j];
                            if (item.def.thingClass == typeof(Plant))
                            {
                                item.Destroy();
                            }
                        }

                        map.terrainGrid.SetTerrain(c, TerrainDef.Named("Ice"));
                    }
                }
            }

            if (!(cellTemp > -4f))
            {
                continue;
            }

            int quickThaw;
            if (terrainDef.defName is "IceS" or "IceD" or "IceST" or "IceDT")
            {
                quickThaw = 1;
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

                if (Rand.Value < shallowChance * quickThaw)
                {
                    string waterType;
                    if (terrainDef.defName == "IceST")
                    {
                        waterType = "WaterShallow";
                    }
                    else if (terrainDef.defName == "IceS")
                    {
                        waterType = "IceST";
                    }
                    else if (terrainDef.defName == "IceDT")
                    {
                        waterType = "WaterDeep";
                    }
                    else
                    {
                        waterType = "IceDT";
                    }

                    if (waterType.Contains("Water"))
                    {
                        map.snowGrid.SetDepth(c, 0f);
                    }

                    map.terrainGrid.SetTerrain(c, TerrainDef.Named(waterType));
                }
            }

            if (terrainDef.defName.Contains("IceMarsh"))
            {
                quickThaw = 1;
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

                if (Rand.Value < shallowChance * quickThaw)
                {
                    string waterType;
                    if (terrainDef.defName == "IceMarsh")
                    {
                        waterType = "IceMarshT";
                    }
                    else
                    {
                        waterType = "Marsh";
                        map.snowGrid.SetDepth(c, 0f);
                    }

                    map.terrainGrid.SetTerrain(c, TerrainDef.Named(waterType));
                }
            }

            if (terrainDef.defName != "Ice" || !map.Biome.defName.Contains("Permafrost"))
            {
                continue;
            }

            quickThaw = 0;
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
                    if (!map.terrainGrid.TerrainAt(newSpot).defName.Contains("Ice"))
                    {
                        quickThaw++;
                    }
                }
            }

            if (Rand.Value < permafrostChance / 4 * quickThaw)
            {
                map.terrainGrid.SetTerrain(c, TerrainDef.Named("Gravel"));
            }
        }
    }
}