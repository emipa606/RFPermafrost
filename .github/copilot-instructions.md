# GitHub Copilot Instructions for [RF] Permafrost (Continued)

## Mod Overview and Purpose

**[RF] Permafrost (Continued)** introduces a new biome to RimWorld known as Permafrost. This biome simulates a permanently frozen landscape existing between tundra and ice sheets. It offers new challenges and dynamics, such as a lack of vegetation and wildlife. A significant part of the mod includes the mechanic where water bodies freeze over and thaw according to temperature changes, adding a realistic touch to the survival gameplay.

## Key Features and Systems

- **Permafrost Biome**: A new biome featuring frozen ground and minimal vegetation, adding diversity and complexity to the game's environment.
- **Dynamic Ice Mechanics**: Water bodies, including lakes and rivers, freeze and thaw based on temperature fluctuations. This affects navigation and resource gathering.
- **Compatibility Features**: The mod integrates seamlessly with other mods like Vanilla Fishing Expanded and Terraform Rimworld, enhancing the overall gameplay experience.
- **Temperature-based Ice Formation**: Introduced for both flowing and still water, reflecting real-world seasonal and temperature changes.

## Coding Patterns and Conventions

- **Naming Conventions**: Follow PascalCasing for class names (e.g., `BiomeWorker_Permafrost`) and methods. Use camelCase for local variables and arguments.
- **Class Structure**: Each class, such as `BiomeWorker_Permafrost`, is designed to handle specific biome-related logic. This separation of concerns aids in easy maintenance and integration.
- **Mod Controller**: The `Controller` class manages mod-specific settings and initialization, ensuring consistent handling of the mod's lifecycle.

## XML Integration

- Utilize XML for defining biomes, item properties, and configurations. This facilitates easy adjustments and mod compatibility.
- Mod options and biome definitions are typically placed in `Defs` folders, which are essential for XML configuration.

## Harmony Patching

- Harmony patches are used to extend the game's existing methods without altering the original code.
- Focus on identifying target methods that the mod needs to integrate with, especially for features affecting biome generation and resource management.
- Ensure Harmony patches are conflict-free by targeting method signatures precisely.

## Suggestions for Copilot

- **Boilerplate Code**: Use Copilot to quickly generate repetitive code structures such as class definitions and basic method stubs.
- **Harmony Patch Templates**: Leverage Copilot to create Harmony patch templates for commonly modified game functions.
- **XML Definitions**: Allow Copilot to assist in generating XML tags and attributes, which can be a time-consuming task.
- **Temperature-dependent Logic**: Utilize Copilot to help implement logic involving temperature-based changes, such as ice formation mechanics.
- **Integration Tests**: Consider using Copilot to draft basic test scenarios to verify mod interactions and ensure stability across different game mods.

By following these guidelines and utilizing GitHub Copilot effectively, you can enhance the development process of the [RF] Permafrost (Continued) mod, ensuring it integrates smoothly into the RimWorld ecosystem.
