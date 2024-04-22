# Bachelor Thesis VR Experiment

This repository contains the Unity project used for conducting VR experiments as part of a bachelor thesis. The project explores the detection thresholds in virtual reality under different cognitive loads and hand fidelity levels.

## Getting Started

### Installing

To get started with the project:
1. Clone this repository or download the ZIP file.
2. Open the project in Unity by selecting `Open` and navigating to the project folder.

## Running the Experiments

There are four main experiments included in this project, each accessible through different scenes and configurations. Follow the steps below to configure and run each experiment.

### Experiment 1: Low Cognitive Load

1. Open the scene located at `Assets/Bachelor Project/Experiment-1.unity`.
2. Configure hand fidelity as needed (instructions below).
3. To build and run the experiment on your Oculus device, make sure the scene is added in the Build Settings and click on `Build and Run`.

### Experiment 2: High Cognitive Load

1. Open the scene located at `Assets/Bachelor Project/Experiment-2.unity`.
2. Configure hand fidelity as instructed below.
3. Ensure the scene is added to your Build Settings for proper compilation.

### Configuring Hand Fidelity

#### Mid-Hand Fidelity

1. Navigate in the Unity Hierarchy to `OVRCameraRig -> TrackingSpace -> LeftHandAnchor -> OVRHandPrefab`.
2. Activate the `OVR Mesh Renderer (Script)` and `Skinned Mesh Renderer` components.
3. Deactivate the child game object `Sphere`.
4. Repeat steps 1-3 for `RightHandAnchor`.

#### Low-Hand Fidelity

1. Navigate in the Unity Hierarchy to `OVRCameraRig -> TrackingSpace -> LeftHandAnchor -> OVRHandPrefab`.
2. Deactivate the `OVR Mesh Renderer (Script)` and `Skinned Mesh Renderer` components.
3. Activate the child game object `Sphere`.
4. Repeat steps 1-3 for `RightHandAnchor`.

## Building for Android (APK Files)

If you wish to run pre-built experiments, the `build` folder contains APK files for each setup. To install these files on an Oculus or similar device:

1. Ensure your device is in developer mode and connected to your computer.
2. Use Android Debug Bridge (ADB) or your device's app installation method to transfer and install the APK file.

## Troubleshooting

If you encounter issues with building or running the experiments, ensure all scenes are properly configured in the Build Settings and that your Unity and Android SDK setups are correct.


