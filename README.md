# 🚏 VR-based Wayfinding  
**AI-Assisted Adaptive Wayfinding in Urban VR Navigation**

This project explores an AI-assisted, sensor-driven, real-time adaptive wayfinding system designed to improve navigation performance and reduce cognitive load during complex urban transitions, such as moving from street-level environments into underground metro stations.

---

## 🔍 Research Objective

To evaluate whether adaptive multimodal guidance (visual, auditory, and potentially haptic), triggered by real-time behavioral cues, can outperform conventional static navigation tools (e.g., static maps) in VR-based urban navigation tasks.

---

## 🧪 Experimental Task

Participants navigate through a VR environment simulating a **city-to-subway transition**. These spatial handover zones often challenge standard tools like Google Maps, especially when navigating **vertical transitions** where above-ground and underground spaces overlap in location but differ in spatial logic.

---

## 🧠 Adaptive Strategy

The system uses a **closed-loop architecture** that monitors proxy behavioral indicators:

- **Head movement** (as a substitute for gaze)  
- **Pausing and hesitation**  
- **Turning back behavior**

These cues trigger adaptive guidance:

- 🎯 **Visual**: Arrows appear when confusion is inferred  
- 🔊 **Auditory**: Audio cues increase in volume as users approach their goal

The current system is **rule-based**, with future plans to integrate **machine learning** using collected behavioral data.

---

## 🎮 Experimental Conditions

- **Condition A – Static Guidance**  
  Non-reactive map displayed in Unity (no behavior adaptation)

- **Condition B – Adaptive Guidance**  
  Dynamic, behavior-triggered visual and audio prompts

---

## 📊 Data Collection

**Behavioral Data (CSV Logged):**

- 3D position, orientation, head rotation, forward-facing vector (gaze proxy), movement speed  
- Event-based triggers (prompt activation)

**Subjective Measures (to be added):**

- Simulator Sickness Questionnaire (SSQ)  
- Presence Questionnaire (PQ)  
- System Usability Scale (SUS)  
- Wayfinding Strategy Questionnaire  
- Demographics and prior VR/navigation experience

---

## 🌐 Generalizability

The adaptive framework is applicable to a wide range of navigation challenges, such as:

- **Vertical navigation in multi-level environments** (e.g., multi-story streets or underground overlaps)  
- **Complex 3D intersections**  
- **GPS drift compensation** in dense urban areas  
- **Precise landmark recognition** using VR’s spatial tracking

---

## ⚠️ Limitations & Future Work

1. ❌ **No rerouting yet**: Off-path behavior only triggers subtle audio cues  
2. ⚙️ **Rule-based only**: Next phase will include machine learning adaptation  
3. 👁️ **Limited sensing/output**: Current system tracks head motion only; future versions will include:
   - Contrast/size-adjusted visual highlights  
   - Haptic feedback (e.g., controller or wristband vibration)  
   - Group-responsive personalization

---

## 📦 Assets Used

- **City Model**: [CGTrader – Order #16310507](https://www.cgtrader.com/orders/16310507/6430a1fc-ac20-47d7-8abe-21af85df89a3)  
- **Metro Station Model**: [CGTrader Download](https://www.cgtrader.com/items/6687633/download-page)  
- **Audio Cues**: [Mixkit Sound Effects](https://mixkit.co/free-sound-effects/bell/)

---

## 🖥️ System Requirements

- Unity **2021.3 LTS** or later  
- VR headset (tested on **Meta Quest 3**)  
- [Git LFS](https://git-lfs.com) for asset version control  

---

## 🛠️ Getting Started

### 📁 Project Setup in Unity

1. **Clone the Repository**  
   This project uses Git LFS. Before cloning, make sure Git LFS is installed:
   ```bash
   git lfs install
   git clone https://github.com/XiaochenDing/VR-based_Wayfinding.git
2. **Open in Unity**

   - Launch **Unity Hub**
   - Click **Add** and select the folder `VR-based_Wayfinding`
   - Recommended Unity version: **2021.3 LTS or later**
   - Load the scene: `Assets/Scenes/WayfindingExperiment.unity`

3. **Configure Project Settings**

   - Go to `Project Settings > XR Plugin Management`
   - Enable **XR Plugin Management**
   - Adjust **Player Settings** for XR input and resolution
   - Install **Oculus Integration** or **OpenXR Plugin** via the **Package Manager**

---

### 🎧 VR Support

- Connect your VR headset (e.g., **Meta Quest 2**)
- Enable the appropriate XR backend (e.g., **Oculus** or **OpenXR**)
- Press **Play** in the Unity Editor or **Build and Run** to deploy to your VR device (e.g., Android build for Quest)
[🎥 Watch Demo Video](https://youtu.be/Cuw38cmNoQk)
