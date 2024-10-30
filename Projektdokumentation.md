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
| 1    | muss           | Funktional  | Als Administrator möchte ich Schüler und Lehrpersonen in das System eintragen, um Stammdaten zu pflegen. |
| 2    | muss           | Funktional  | Als Administrator möchte ich Benutzerrollen definieren, um verschiedene Berechtigungen zu verwalten. |
| 3    | muss           | Funktional  | Als Lehrer möchte ich Schüler in Schulklassen einteilen, um Klassenübersichten zu erstellen. |
| 4    | muss           | Qualität    | Als Benutzer möchte ich, dass die Applikation sicher ist, um Datenintegrität zu gewährleisten. |
| 5    | kann           | Rand        | Als Benutzer möchte ich eine benutzerfreundliche Oberfläche, um die Anwendung intuitiv zu bedienen. |

### 1.3 Testfälle

| TC-№ | Ausgangslage        | Eingabe                          | Erwartete Ausgabe                                |
|------|----------------------|----------------------------------|--------------------------------------------------|
| 1.1  | Benutzerlogin       | gültige Anmeldedaten            | Zugriff auf das System                           |
| 1.2  | Benutzerlogin       | ungültige Anmeldedaten          | Fehlermeldung „Ungültige Anmeldedaten“          |
| 2.1  | Benutzererstellung  | vollständige Angaben             | Neuer Benutzer wird erstellt                     |
| 3.1  | Klasseneinteilung   | Schüler einer Klasse zuordnen    | Schüler erfolgreich zugeteilt                    |
| 4.1  | CRUD-Funktionalität | Schüler- oder Lehrerdaten ändern | Aktualisierte Informationen werden angezeigt     |
| 5.1  | Rollenmanagement    | Benutzerrollen zuweisen         | Benutzer erhält Zugriff auf spezifische Funktionen |

### 1.4 Diagramme

Diagramme für das Datenmodell und die Benutzerrollen sind im GitHub-Repository abgelegt.

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

Total: 8 Arbeitspakete

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

## 5. Kontrollieren

### 5.1 Testprotokoll

| TC-№ | Datum      | Resultat | Tester      |
|------|------------|----------|-------------|
| 1.1  | 04.10.2024 | OK       | Atputharasa |
| 1.2  | 04.10.2024 | OK       | Atputharasa |
| 2.1  | 04.10.2024 | OK       | Marku       |
| 3.1  | 04.10.2024 | OK       | Angelov     |
| 4.1  | 04.10.2024 | OK       | Jashari     |
| 5.1  | 04.10.2024 | OK       | Marku       |

Alle Tests sind erfolgreich verlaufen, und die Software ist bereit für die Einführung in die Schulverwaltung.

---

## 6. Auswerten

Der Lernbericht und die vollständige Projektdokumentation sind im GitHub-Repository verlinkt.

