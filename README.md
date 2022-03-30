# Projekt Blueberry - Unity Szene

Entwickelt im Rahmen der Projektgruppe 643: 
"Entwicklung einer browserbasierten Lernplattform für Data Science" an der Fakultät für Informatik der TU Dortmund. Für weitere Details zur Motivation, dem didaktischen Konzept sowie weiteren technischen Details empfiehlt sich ein Blick in den Abschlussbericht.

Dies ist das Schwesterprojekt zu "Bluestberry" : https://github.com/TU-Blueberry/bluestberry
Es beinhaltet die Sortierroboter Szene, welche aus dem Python Kontext über eine Angular Schnittstelle angesprochen werden soll, um einen Beeren Sortierroboter zu simulieren.

# Installation:
#### Voraussetzungen
-  Unity 2019.4.29 + WebGL Plugin

#### Installation
1. Repository klonen
2. Unter ./Assets/Scenes.BerrySort öffnen
3. Unter "Lighting" "Generate Lighting" auswählen und die Ausführung abwarten.

Es kann nun die Szene bearbeitet werden.
Um mit ihr zu interagieren muss sie in das Frontend Exportiert werden.

#### Building Prozess / Ausführung
Bluestberry beinhaltet die Binaries bereits (ca 7mb). Aber bei einem Update von Unity Seite muss diese neu gebaut und eingefügt werden.

1. Bluestberry Auschecken.
2. Zu Unity Wechseln.
3. Zu "Build Settings" navigieren.
4. Falls nicht ausgewählt: WebGL als build Target wählen.
5. > Build
6. Zu ./bluestberry/src/assets/experiences/sortierroboter/unity navigieren.
  6b. Da Unity den Loader mit überschreibt diesen mit unserem Custom Loader wieder herstellen. (../../UnityLoaderBackup.js)
7. Bluestberry starten.

Es kann nun die Szene bearbeitet werden.
Um mit ihr zu interagieren muss sie in das Frontend exportiert werden.


# Hinzufügen und Anpassen von Inhalten
#### Anlegen einer neuen Szene mit Angular Support (Unity)
- Eine neue Szene Bauen.
- Ein Angular Translator Skript für die Szene umsetzen: (vgl. Assets/BerrySort/Scripts/AngularCommunicator/AngularTranslator.cs)
- Ein Gegenstück als Service in Bluestberry entwickeln und in das Unity Modul einhängen (vgl. src/app/unity/experiencesunity.berrysort.ts)
- Ein leeres GameObject "AngularCommunicator" in die Szene einfügen und "Scene Control" / das neue "Angular Translator" (Name Frei wählbar) skript anhängen.

Voila! Diese Schnittstelle basiert auf der folgenden Unity Dokumentation:
https://docs.unity3d.com/Manual/webgl-interactingwithbrowserscripting.html

# Teilnehmerinnen und Teilnehmer
Projektleitung: 
  - Jun.-Prof. Dr. Thomas Liebig
  - Lukas Pfahler  

Organisation:
  - Michael Schwarzkopf

Didaktik: 
  - Daniel Enders
  - Jan Feider
  - Leah Niechcial
  - Isabell Strotkamp

Frontend-Entwicklung: 
  - Jana Gödeke
  - Tim Hallyburton
  - Tim Katzke
  - Maximilian König
  - Henri Schmidt
  
Unity-Entwicklung:
  - Jonas Grobe
  - Christofer Heyer 
