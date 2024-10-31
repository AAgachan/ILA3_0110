# Projekt-Dokumentation

**Projektantrag zu LA_ILA3_0110**

**Projektteam**

| Name          | Vorname     | Klasse |
|---------------|-------------|--------|
| Atputharasa   | Agachan     | Im22d  |
| Angelov       | Angel       | Im22d  |
| Marku         | Erik        | Im22d  |
| Jashari       | Denis       | Im22d  |


| Datum      | Version | Zusammenfassung                                                                                       |
|------------|---------|-------------------------------------------------------------------------------------------------------|
| 30.08.2024 | 0.0.1   | Datenmodellierung abgeschlossen; grundlegende Datenbankstrukturen für Schüler, Lehrer, Rollen und Klassen erstellt. |
| 06.09.2024 | 0.0.2   | CRUD-Funktionalität implementiert für Schüler- und Lehrerverwaltung. Erste Tests der Benutzerverwaltung durchgeführt. |
| 13.09.2024 | 0.0.3   | Klassenverwaltungssystem entwickelt; Schüler können nach Schuljahren in Klassen eingeteilt werden. |
| 20.09.2024 | 0.0.4   | Rollenmanagementsystem implementiert; Benutzerrollen erstellt und Rechte zugewiesen. |
| 27.09.2024 | 0.0.5   | Benutzerverwaltung und Sicherheitsfeatures integriert. |
| 04.10.2024 | 1.0.0   | Abschluss der Entwicklung und finale Tests; Projektdokumentation finalisiert. |

## 1. Informieren

### 1.1 Projektbeschreibung

Wir entwickeln eine Applikation zur Schulverwaltung, die es ermöglicht, Schüler und Lehrkräfte zu erfassen und zu verwalten. Die Applikation bietet Funktionen zur Klassenzuweisung, Benutzerverwaltung und Zugriffskontrolle über ein Rollenmanagementsystem. C# wird für die Implementierung des Backends genutzt, um Datenoperationen effizient zu handhaben und eine Verbindung zur MongoDB-Datenbank herzustellen.

### 1.2 User Stories

| US-№ | Verbindlichkeit | Typ         | Beschreibung                                                                                   |
|------|-----------------|-------------|-----------------------------------------------------------------------------------------------|
| 1    | muss           | Funktional  | Als Administrator möchte ich Schüler und Lehrer zur Datenbank hinzufügen, um die Verwaltung zu ermöglichen. |
| 2    | muss           | Funktional  | Als Administrator möchte ich bestehende Schüler- und Lehrerdaten aktualisieren, um Daten auf dem neuesten Stand zu halten. |
| 3    | muss           | Funktional  | Als Lehrer möchte ich Schüler einer bestimmten Klasse zuordnen, um meine Klassenzusammensetzung zu verwalten. |
| 4    | muss           | Funktional  | Als Administrator möchte ich Benutzerrollen wie „Lehrer“ und „Schüler“ anlegen, um die Zugriffsrechte zu steuern. |
| 5    | muss           | Funktional  | Als Benutzer möchte ich mich mit einem sicheren Login authentifizieren, um den Zugang zu meinen Daten zu schützen. |
| 6    | muss           | Funktional  | Als Lehrer möchte ich die Schülerliste einer bestimmten Klasse einsehen können, um einen Überblick über die Klassenzusammensetzung zu erhalten. |
| 7    | kann           | Funktional  | Als Administrator möchte ich Benutzerrollen Rechte zuweisen können, um den Zugriff auf Funktionen festzulegen. |
| 8    | muss           | Funktional  | Als Lehrer möchte ich die Möglichkeit haben, Schüler zwischen Klassen zu verschieben, um Klassenänderungen vorzunehmen. |
| 9    | muss           | Funktional  | Als Administrator möchte ich Benutzerkonten löschen können, um die Datenbank aktuell zu halten. |
| 10   | muss           | Funktional  | Als Benutzer möchte ich mein Passwort ändern können, um die Sicherheit meines Kontos zu erhöhen. |
| 11   | kann           | Funktional  | Als Administrator möchte ich Klassenberichte generieren, die die Klassenzusammensetzung und Lehrerverteilung zeigen, um die Schulverwaltung zu erleichtern. |
| 12   | muss           | Funktional  | Als Lehrer möchte ich direkt in der Applikation auf meine Klassen zugreifen und meine zugewiesenen Schüler einsehen können, um die Schülerlisten schnell aufzurufen. |
| 13   | muss           | Technisch   | Als Entwickler möchte ich das C#-Backend so strukturieren, dass es klar zwischen Benutzerverwaltung, Rollenmanagement und Klassenzuweisung trennt, um den Code wartbar und erweiterbar zu halten. |
| 14   | kann           | Funktional  | Als Administrator möchte ich eine Benachrichtigung erhalten, wenn Änderungen an einer Klasse vorgenommen wurden, um den Überblick über Klassenzuordnungen zu behalten. |

### 1.3 Testfälle

| TC-№ | Ausgangslage               | Eingabe                                      | Erwartete Ausgabe                                |
|------|-----------------------------|----------------------------------------------|--------------------------------------------------|
| 1.1  | Schüler- und Lehrerdatenbank leer | Neuen Schüler und Lehrer hinzufügen          | Schüler und Lehrer sind in der Datenbank gespeichert (US-1) |
| 2.1  | Vorhandene Schülerdaten     | Bestehenden Schülerdatensatz aktualisieren    | Geänderte Schülerdaten werden gespeichert (US-2) |
| 3.1  | Klasse ohne zugewiesene Schüler | Schüler einer Klasse zuweisen                | Schüler wird erfolgreich zur Klasse hinzugefügt (US-3) |
| 4.1  | Rollenverwaltung leer       | Neue Rolle „Lehrer“ erstellen                | Rolle „Lehrer“ wird in der Datenbank gespeichert (US-4) |
| 5.1  | Anmeldeseite                | Gültige Anmeldedaten eingeben                | Benutzer wird authentifiziert und angemeldet (US-5) |
| 6.1  | Klasse mit zugewiesenen Schülern | Schülerliste einer Klasse anzeigen           | Liste der Schüler wird angezeigt (US-6) |
| 7.1  | Vorhandene Rolle „Administrator“ | Zugriffsrechte für „Administrator“ anpassen | Rechte für „Administrator“ werden gespeichert (US-7) |
| 8.1  | Schüler in Klasse A         | Schüler von Klasse A zu Klasse B verschieben | Schüler wird erfolgreich in Klasse B gespeichert (US-8) |
| 9.1  | Vorhandenes Benutzerkonto   | Benutzerkonto löschen                        | Benutzer wird aus der Datenbank entfernt (US-9) |
| 10.1 | Benutzerprofilseite         | Neues Passwort eingeben                      | Passwort wird erfolgreich geändert (US-10) |
| 11.1 | Keine vorhandenen Berichte  | Berichterstellung für Klasse 10A anfordern   | Bericht wird erfolgreich generiert und angezeigt (US-11) |
| 12.1 | Lehrer ist in der Applikation angemeldet | Lehrer ruft Schülerliste der eigenen Klasse ab | Die Schülerliste der zugeordneten Klasse wird angezeigt (US-12) |
| 13.1 | Backend-Modulstruktur vorhanden | Backend-Module (Benutzerverwaltung, Rollenmanagement, Klassenzuweisung) aufrufen | Module arbeiten unabhängig und sind gut strukturiert (US-13) |
| 14.1 | Änderungen an Klassenstruktur vorhanden | Klasse 10A wird aktualisiert | Administrator erhält Benachrichtigung über die Änderungen (US-14) |

### 1.4 Diagramme

- Die Diagramme für das Datenmodell, die Benutzerrollen und Klassenübersichten sind im GitHub-Repository abgelegt und können bei Bedarf abgerufen werden.

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

## 6. Auswerten

Der Lernbericht und die vollständige Projektdokumentation sind im GitHub-Repository abgelegt.

