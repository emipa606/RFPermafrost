# GitHub Copilot Instructions for [RF] Permafrost (Continued) Mod

## Mod Overview and Purpose

[RF] Permafrost (Continued) is an updated version of the Rainbeau Flambes mod, originally developed for RimWorld. This mod adds a new biome called Permafrost, which is situated on the border between tundra and ice sheets. The Permafrost biome features permanently frozen ground covered in ice, with limited vegetation and fauna. Additionally, the mod introduces the feature of water freezing, which affects lakes, rivers, and marshes across all biomes, and ground ice in Permafrost biomes. This feature can be disabled through the mod's options menu.

## Key Features and Systems

### New Biome: Permafrost
- **Description**: A new biome characterized by permanently frozen ground, sparse vegetation, and limited fauna.
- **Biome Characteristics**: Ground is permanently frozen, covered in ice, and supports minimal vegetation like scrub brush.
- **Environmental Impact**: Ground ice in Permafrost biomes slowly advances and retreats with temperature changes.

### Water Freezing
- **Functionality**: Lakes, rivers, and marshes freeze when temperatures drop below freezing and thaw when temperatures rise.
- **Compatibility**: The feature can be disabled via the mod's options menu.
- **Fishing Impact**: Fishing spots on frozen water tiles are destroyed, while fishing piers and shellfish traps remain unaffected.

### Compatibility
- **Mod Compatibility**: The mod is designed to be compatible with most other RimWorld mods.
- **In-Game Compatibility**: The mod can be safely added to an in-progress game. However, removing the mod from an already-generated map is not advised.
- **Version Compatibility**: Updated for RimWorld versions 1.1, 1.2, and 1.3.

## Coding Patterns and Conventions

- **Code Organization**: The mod is organized into several C# files, each responsible for specific functionality.
  - `BiomeWorker_Permafrost.cs`: Handles the scoring and selection of the Permafrost biome.
  - `Controller.cs`: Manages the mod's settings and user interface.
  - `Rivers.cs`: Manages the freezing behavior of rivers.
  - `Lakes.cs`: Manages the freezing behavior of lakes.
  - `RPF_Initializer.cs`: Initializes the mod.

- **XML Integration**: The mod uses XML files to define new biomes and patches.
  - `Biomes_Permafrost.xml`: Defines the Permafrost biome.
  - `Patch.xml`: Contains Harmony patches for modifying RimWorld behavior.
  - `About.xml`: Provides mod metadata.
  - `Biomes_Permafrost.xml` (TranslationTemplate): Template for translations.

- **Harmony Patching**: The mod uses Harmony to patch RimWorld's codebase to add new features and modify existing behavior.
  - **Purpose**: To seamlessly integrate the Permafrost biome and water freezing features without altering the original RimWorld code.

## XML Integration

- **Biome Definition**: The `Biomes_Permafrost.xml` file defines the Permafrost biome, including its properties, environmental features, and resource availability.
- **Patch File**: The `Patch.xml` file contains Harmony patches that modify RimWorld's behavior to support the new biome and water freezing features.

## Harmony Patching

- **Purpose**: To inject custom code into RimWorld's existing codebase to add new features and modify existing behavior.
- **Examples**:
  - **Biome Selection**: The `BiomeWorker_Permafrost.cs` file uses Harmony to patch the biome selection process to include the Permafrost biome.
  - **Water Freezing**: The `Rivers.cs` and `Lakes.cs` files use Harmony to patch the water freezing logic to apply to all biomes and the Permafrost biome specifically.

## Suggestions for Copilot

1. **Mod Integration**: When working on integrating new features or fixing bugs, consider the impact on the existing Permafrost biome and water freezing system.
2. **XML Handling**: When modifying XML files, ensure that the changes maintain compatibility with the mod's existing XML structures and definitions.
3. **Harmony Patches**: When creating Harmony patches, ensure that the patches are well-documented and do not conflict with other mods or future updates to RimWorld.
4. **Testing**: After making changes, thoroughly test the mod in-game to ensure that the new features work as intended and do not introduce any bugs or issues.

By following these guidelines, developers can effectively use GitHub Copilot to enhance and maintain the [RF] Permafrost (Continued) mod, ensuring that it continues to provide a rich and dynamic experience for RimWorld players.

## Project Solution Guidelines
- Relevant mod XML files are included as Solution Items under the solution folder named XML, these can be read and modified from within the solution.
- Use these in-solution XML files as the primary files for reference and modification.
- The `.github/copilot-instructions.md` file is included in the solution under the `.github` solution folder, so it should be read/modified from within the solution instead of using paths outside the solution. Update this file once only, as it and the parent-path solution reference point to the same file in this workspace.
- When making functional changes in this mod, ensure the documented features stay in sync with implementation; use the in-solution `.github` copy as the primary file.
- In the solution is also a project called Assembly-CSharp, containing a read-only version of the decompiled game source, for reference and debugging purposes.
- For any new documentation, update this copilot-instructions.md file rather than creating separate documentation files.


## Hard rules (must follow)
- Do NOT run commands that modify the repo (no git commit, git apply, dotnet format) unless explicitly asked.
- Prefer minimal reads: read only the smallest code region needed (around the suspicious lines).
- When mentioning SonarQube issues, automatically use the SonarQube MCP service to fetch and address issues instead of making inferred fixes without querying SonarQube first.
- When mentioning the rimworld log, automatically use the Rimworld MCP service to fetch the log.

