# Balatro

This repository provides Crowd Control mods for two Balatro mod-loader
layouts:

- `steamodded\CrowdControl` for **Steamodded** (the manifest requires
  Steamodded `>=1.*~`);
- `balamod\CrowdControl` for the Balamod layout.

Install one layout that matches the mod loader in use. Do not install both
copies of the CrowdControl mod in the same game installation.

## Requirements

- Balatro with the selected supported mod loader.
- Crowd Control with the matching **Balatro** or **BalatroSteamodded** pack.

## Installation and setup

1. Install the applicable Balatro mod loader.
2. Copy the matching `CrowdControl` directory from this repository into that
   loader's normal mod directory.
3. Start the Crowd Control desktop app and select the matching pack.
4. Launch Balatro so the mod can initialize and connect.

## Connection behavior

Both Lua implementations create a local TCP client and connect to
`127.0.0.1:58430`, the port on which the corresponding Crowd Control pack
listens. Start the desktop session before launching or reloading the mod so
the initial connection can succeed.

## Troubleshooting

- **No connection:** verify that the desktop app is running with the matching
  Balatro pack and that port `58430` is available locally.
- **The mod does not load:** check that the selected directory matches the
  installed loader, especially the Steamodded dependency for the
  `steamodded` variant.
- **Behavior is duplicated or inconsistent:** remove the other CrowdControl
  variant; only one loader-specific implementation should be installed.

## Repository layout

- `Balatro.cs` and `BalatroSteamodded.cs` define the supported pack variants.
- `balamod/` and `steamodded/` contain their respective game-side integrations.
