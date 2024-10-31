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
| 1    | muss           | Funktional  | Als Administrator möchte ich neue Schüler anlegen, um deren Stammdaten im System zu pflegen. |
| 2    | muss           | Funktional  | Als Administrator möchte ich Lehrer hinzufügen können, um Lehrerdaten zentral zu speichern. |
| 3    | muss           | Funktional  | Als Administrator möchte ich bestehende Schüler- und Lehrerdaten bearbeiten, um Aktualität sicherzustellen. |
| 4    | muss           | Funktional  | Als Lehrer möchte ich Schüler bestimmten Klassen zuordnen, um Klassenübersichten zu erstellen. |
| 5    | muss           | Funktional  | Als Administrator möchte ich Rollen für Benutzer definieren, um Zugriffsrechte festzulegen. |
| 6    | muss           | Funktional  | Als Administrator möchte ich die Möglichkeit haben, Benutzerkonten zu löschen, um die Datenbank aktuell zu halten. |
| 7    | muss           | Funktional  | Als Benutzer möchte ich eine sichere Authentifizierung, um unbefugten Zugriff zu verhindern. |
| 8    | muss           | Funktional  | Als Benutzer möchte ich die Möglichkeit haben, mein Passwort zu ändern, um die Sicherheit zu erhöhen. |
| 9    | muss           | Funktional  | Als Lehrer möchte ich Schülerlisten einer Klasse anzeigen können, um meine Klasseneinteilung zu verwalten. |
| 10   | muss           | Funktional  | Als Administrator möchte ich die Möglichkeit haben, eine Rolle zuzuweisen, um Benutzerrechte zu verwalten. |

### 1.3 Testfälle

| TC-№ | Ausgangslage             | Eingabe                               | Erwartete Ausgabe                                |
|------|---------------------------|---------------------------------------|--------------------------------------------------|
| 1.1  | Schülerdatenbank leer     | Neuen Schüler anlegen                 | Schüler wird in der Datenbank gespeichert        |
| 2.1  | Lehrerdatenbank leer      | Neuen Lehrer hinzufügen               | Lehrer wird in der Datenbank gespeichert         |
| 3.1  | Bestehende Schülerdaten   | Schülerdaten ändern                   | Geänderte Schülerdaten werden gespeichert        |
| 4.1  | Klassenübersicht leer     | Schüler einer Klasse zuordnen         | Schüler wird erfolgreich zur Klasse hinzugefügt  |
| 5.1  | Rollenübersicht leer      | Neue Rolle „Lehrer“ erstellen         | Rolle „Lehrer“ wird in der Datenbank gespeichert |
| 6.1  | Bestehendes Benutzerkonto | Benutzerkonto löschen                 | Benutzer wird aus der Datenbank entfernt         |
| 7.1  | Anmeldeseite              | Gültige Anmeldedaten eingeben         | Benutzer wird authentifiziert und angemeldet     |
| 8.1  | Benutzerprofilseite       | Neues Passwort eingeben               | Passwort wird erfolgreich geändert               |
| 9.1  | Klassenübersicht anzeigen | Klasse 10A auswählen                 | Liste der Schüler in Klasse 10A wird angezeigt   |
| 10.1 | Benutzerverwaltung        | Rolle „Administrator“ zuweisen        | Benutzer erhält Administrator-Rechte            |

### 1.4 Diagramme

- Diagramme für das Datenmodell, die Benutzerrollen, und Klassenübersichten sind im GitHub-Repository abgelegt und können bei Bedarf abgerufen werden.

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
| 2.1  | 04.10.2024 | OK       | Atputharasa |
| 3.1  | 04.10.2024 | OK       | Marku       |
| 4.1  | 04.10.2024 | OK       | Marku       |
| 5.1  | 04.10.2024 | OK       | Angelov     |
| 6.1  | 04.10.2024 | OK       | Angelov     |
| 7.1  | 04.10.2024 | OK       | Jashari     |
| 8.1  | 04.10.2024 | OK       | Jashari     |
| 9.1  | 04.10.2024 | OK       | Marku       |
| 10.1 | 04.10.2024 | OK       | Atputharasa |

Alle Tests sind erfolgreich verlaufen, und die Software ist bereit für die Einführung in die Schulverwaltung.

---

## 6. Auswerten

Der Lernbericht und die vollständige Projektdokumentation sind im GitHub-Repository abgelegt.

