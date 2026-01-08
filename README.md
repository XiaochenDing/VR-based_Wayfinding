# VR-based Wayfinding
Wayfinding Strategy Demo
AI-Assisted Adaptive Wayfinding in Urban VR Navigation

This project explores an AI-assisted, sensor-driven, real-time adaptive wayfinding system designed to improve navigation performance and reduce cognitive load during complex urban transitions, such as moving from street-level environments into underground metro stations.

🔍 Research Objective

To evaluate whether adaptive multimodal guidance (visual, auditory, and potentially haptic), triggered by real-time behavioral cues, can outperform conventional static navigation tools (e.g., static maps) in VR-based urban navigation tasks.

🧪 Experimental Task

Participants navigate through a VR environment simulating a city-to-subway transition. These spatial handover zones are often challenging for standard tools like Google Maps, especially when navigating vertical transitions where above-ground and underground spaces overlap.

🧠 Adaptive Strategy

This system uses a closed-loop architecture to monitor proxy behavioral indicators:

Head movement (as a substitute for gaze)

Pausing and hesitation

Turning back

These indicators trigger adaptive guidance prompts, such as:

Visual: arrows appear when confusion is inferred

Auditory: proximity-based audio cues increase in volume as the user approaches their goal

The system currently runs on rule-based logic and is designed for future machine learning model integration using collected behavioral data.

🎮 Experimental Conditions

Condition A – Static Guidance: Non-reactive map displayed in Unity

Condition B – Adaptive Guidance: Dynamic, behavior-triggered visual/audio prompts

📊 Data Collection

Behavioral Data (CSV):

Position, orientation, head rotation, movement speed, gaze proxy

Event-based triggers (prompt activation)

Subjective Measures (to be added):

Simulator Sickness Questionnaire

Presence Questionnaire

System Usability Scale (SUS)

Wayfinding Strategy Survey

Demographics and prior VR/navigation experience

🌐 Generalizability

This adaptive framework is applicable to other navigation challenges, including:

Vertical navigation in multi-level environments

3D intersections

Reducing GPS drift and improving spatial orientation in complex urban settings

⚠️ Limitations & Future Work

No rerouting mechanism yet; off-path feedback limited to audio cues

System logic is heuristic; next phase involves ML-based adaptation

Currently only head-motion-based input and visual/audio output; future versions will include contrast/size cues, haptics, and user-type-sensitive feedback

📦 Assets Used

City Model: CGTrader – Order #16310507

Metro Station Model: CGTrader – Download

Audio Cues: Mixkit Sound Effects

🖥️ System Requirements

Unity 2021 or later

VR headset (e.g., Oculus Quest 2)

Git LFS for asset management (due to large 3D models)
