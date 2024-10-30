# Projekt-Dokumentation

**Projektantrag zu LA_ILA3_0110**

**Projektteam (1. Zeile = Projektleitung):**

| Name          | Vorname     | Klasse |
|---------------|-------------|--------|
| Atputharasa   | Agachan     | Im22d  |
| Angelov       | Angel       | Im22d  |
| Marku         | Erik        | Im22d  |
| Jashari       | Denis       | Im22d  |

---

| Datum      | Version | Zusammenfassung                                                                                       |
|------------|---------|-------------------------------------------------------------------------------------------------------|
| 30.08.2024 | 0.0.1   | Datenmodellierung abgeschlossen; grundlegende Datenbankstrukturen für Schüler, Lehrer und Klassen erstellt. |
| 06.09.2024 | 0.0.2   | CRUD-Funktionalität implementiert für Schüler- und Lehrerverwaltung. Erste Tests der Benutzerverwaltung durchgeführt. |
| 13.09.2024 | 0.0.3   | Klassenverwaltungssystem entwickelt; Schüler können nach Schuljahren eingeteilt werden. |
| 20.09.2024 | 0.0.4   | Rollenmanagementsystem implementiert; Benutzerrollen erstellt und Rechte zugewiesen. |
| 27.09.2024 | 0.0.5   | Benutzerverwaltung und Sicherheitsfeatures integriert. |
| 04.10.2024 | 1.0.0   | Abschluss der Entwicklung und finale Tests; Projektdokumentation finalisiert. |

## 1. Informieren

### 1.1 Projektbeschreibung

Wir erstellen eine Applikation zur Schulverwaltung, die es ermöglicht, Schüler und Lehrpersonen zu erfassen und zu verwalten sowie nach Schuljahren in Klassen einzuteilen.

### 1.2 User Stories

| US-№ | Verbindlichkeit | Typ         | Beschreibung                                                                                   |
|------|-----------------|-------------|-----------------------------------------------------------------------------------------------|
| 1    | muss           | Funktional  | Als Administrator möchte ich neue Schüler und Lehrer anlegen, um deren Stammdaten im System zu pflegen. |
| 2    | muss           | Funktional  | Als Administrator möchte ich die Daten bestehender Schüler und Lehrer bearbeiten können, um aktuelle Informationen zu gewährleisten. |
| 3    | muss           | Funktional  | Als Lehrer möchte ich Schüler zu bestimmten Klassen zuordnen, um Klassenübersichten zu erstellen. |
| 4    | muss           | Funktional  | Als Administrator möchte ich Benutzerrollen (z.B. Lehrer, Schüler) mit spezifischen Zugriffsrechten definieren, um den Zugriff zu steuern. |
| 5    | muss           | Funktional  | Als Benutzer möchte ich eine sichere Authentifizierung, um den Zugang zu meiner Rolle zu beschränken. |
| 6    | muss           | Funktional  | Als Benutzer möchte ich die Möglichkeit haben, mein Passwort zu ändern, um die Sicherheit zu erhöhen. |
| 7    | kann           | Funktional  | Als Lehrer möchte ich Klassengruppen mit ihren Klassenaktivitäten dokumentieren können, um Berichte zu erstellen. |
| 8    | kann           | Funktional  | Als Administrator möchte ich eine Übersicht aller Benutzer, um das System effizient zu verwalten. |
| 9    | muss           | Qualität    | Als Benutzer möchte ich eine intuitive und benutzerfreundliche Oberfläche, um die Applikation effizient zu nutzen. |
| 10   | muss           | Qualität    | Als Administrator möchte ich die Möglichkeit haben, die Datenbank zu sichern und wiederherzustellen, um Datenverlust zu vermeiden. |

### 1.3 Testfälle

| TC-№ | Ausgangslage             | Eingabe                               | Erwartete Ausgabe                                |
|------|---------------------------|---------------------------------------|--------------------------------------------------|
| 1.1  | Anmeldeseite              | gültige Anmeldedaten                  | Zugriff auf das System                           |
| 1.2  | Anmeldeseite              | ungültige Anmeldedaten                | Fehlermeldung „Ungültige Anmeldedaten“          |
| 2.1  | Hauptseite                | "Neuer Schüler" Button klicken       | Eingabeformular für neue Schüler wird geöffnet   |
| 2.2  | Neues Schülerformular     | Schülerdaten vollständig eingeben     | Neuer Schüler wird in der Datenbank gespeichert  |
| 3.1  | Schüler-Übersichtsseite   | Bearbeiten-Button für Schüler wählen  | Daten des ausgewählten Schülers können geändert werden |
| 3.2  | Schüler-Übersichtsseite   | Löschen-Button für Schüler wählen     | Schüler wird aus der Datenbank entfernt          |
| 4.1  | Rollenmanagementseite     | Rolle "Lehrer" erstellen              | Neue Rolle wird erfolgreich hinzugefügt          |
| 4.2  | Rollenmanagementseite     | Rechte für Rolle „Lehrer“ definieren  | Rechte für die Rolle werden erfolgreich gespeichert |
| 5.1  | Passwortänderungsseite     | Neues Passwort eingeben               | Passwort wird erfolgreich geändert               |
| 6.1  | Klassenzuordnungsseite    | Schüler zur Klasse hinzufügen         | Schüler wird in die gewünschte Klasse eingefügt  |
| 7.1  | Benutzerübersichtsseite    | Alle Benutzer anzeigen                | Liste aller Benutzer wird angezeigt              |
| 8.1  | Sicherungsfunktion        | Sicherung starten                     | Datenbank wird erfolgreich gesichert             |
| 8.2  | Wiederherstellungsfunktion | Wiederherstellung starten             | Datenbank wird erfolgreich wiederhergestellt     |
| 9.1  | Klassengruppenseite        | Klassenbericht erstellen              | Klassenbericht wird erfolgreich generiert        |

### 1.4 Diagramme

Diagramme für das Datenmodell, Use-Case-Diagramme und das Rollenmanagement sind im GitHub-Repository abgelegt.

---

## 2. Planen

| AP-№ | Frist      | Zuständig    | Beschreibung                                          | geplante Zeit |
|------|------------|--------------|-------------------------------------------------------|---------------|
| 1.A  | 30.08.2024 | Atputharasa  | CRUD-Implementation für Schüler und Lehrer            | 60'          |
| 2.A  | 30.08.2024 | Jashari      | Datenmodellierung für Schüler-, Lehrer- und Klassendaten | 60'          |
| 3.A  | 06.09.2024 | Angelov      | Klassenverwaltung zur Einteilung nach Schuljahren     | 60'          |
| 4.A  | 13.09.2024 | Marku        | Rollenmanagement für Benutzerrechte                    | 60'          |
| 5.A  | 13.09.2024 | Atputharasa  | Backend-Integration mit MongoDB                       | 60'          |
| 6.A  | 20.09.2024 | Angelov      | Schnittstellenimplementierung                         | 60'          |
| 7.A  | 20.09.2024 | Marku        | Benutzerverwaltung                                    | 60'          |
| 8.A  | 27.09.2024 | Jashari      | Sicherheitsfeatures implementieren                    | 60'          |
| 9.A  | 04.10.2024 | Marku        | Implementierung der Datenbanksicherungsfunktion       | 60'          |
| 10.A | 04.10.2024 | Jashari      | Erstellung der Dokumentation für Benutzer und Admins   | 60'          |

Total: 10 Arbeitspakete

## 3. Entscheiden

Entscheidungen im Projekt:

1. **Technologien**: Verwendung von C# und MongoDB für die Applikation zur Speicherung und Verwaltung der Daten.
2. **Projektmethode**: IPERKA (Informieren, Planen, Entscheiden, Realisieren, Kontrollieren, Auswerten).
3. **Aufteilung des Teams**: Die Teammitglieder sind den Arbeitspaketen zugeordnet, um parallel an verschiedenen Komponenten zu arbeiten.

## 4. Realisieren

| AP-№ | Datum      | Zuständig    | geplante Zeit | tatsächliche Zeit |
|------|------------|--------------|---------------|-------------------|
| 1.A  | 30.08.2024 | Atputharasa  | 60'          | 60'              |
| 2.A  | 30.08.2024 | Jashari      | 60'          | 55'              |
| 3.A  | 06.09.2024 | Angelov      | 60'          | 60'              |
| 4.A  | 13.09.2024 | Marku        | 60'          | 65'              |
| 5.A  | 13.09.2024 | Atputharasa  | 60'          | 60'              |
| 6.A  | 20.09.2024 | Angelov      | 60'          | 55'              |
| 7.A  | 20.09.2024 | Marku        | 60'          | 60'              |
| 8.A  | 27.09.2024 | Jashari      | 60'          | 60'              |
| 9.A  | 04.10.2024 | Marku        | 60'          | 60'              |
| 10.A | 04.10.2024 | Jashari      | 60'          | 55'              |

## 5. Kontrollieren

### 5.1 Testprotokoll

| TC-№ | Datum      | Resultat | Tester      |
|------|------------|----------|-------------|
| 1.1  | 04.10.2024 | OK       | Atputharasa |
| 1.2  | 04.10.2024 | OK       | Atputharasa |
| 2.1  | 04.10.2024 | OK       | Marku       |
| 2.2  | 04.10.2024 | OK       | Marku       |
| 3.1  | 04.10.2024 | OK       | Angelov     |
| 3.2  | 04.10.2024 | OK       | Angelov     |
| 4.1  | 04.10.2024 | OK       | Jashari     |
| 4.2  | 04.10.2024 | OK       | Jashari     |
| 5.1  | 04.10.2024 | OK       | Atputharasa |
| 6.1  | 04.10.2024 | OK       | Angelov     |
| 7.1  | 04.10.2024 | OK       | Marku       |
| 8.1  | 04.10.2024 | OK       | Jashari     |
| 8.2  | 04.10.2024 | OK       | Jashari     |
| 9.1  | 04.10.2024 | OK       | Angelov     |

Alle Tests sind erfolgreich verlaufen, und die Software ist bereit für die Einführung in die Schulverwaltung.

---

## 6. Auswerten

Der Lernbericht und die vollständige Projektdokumentation sind im GitHub-Repository abgelegt.

