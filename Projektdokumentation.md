# Projekt-Dokumentation

**Projektantrag zu LA_ILA3_0110**

**Projektteam**

| Name        | Vorname  | Klasse |
|-------------|----------|--------|
| Atputharasa | Agachan  | Im22d  |
| Angelov     | Angel    | Im22d  |
| Marku       | Erik     | Im22d  |
| Jashari     | Denis    | Im22d  |

**Versionshistorie**

| Datum      | Version | Zusammenfassung                                                                                       |
|------------|---------|-------------------------------------------------------------------------------------------------------|
| 23.08.2024 | 0.0.1   | Projekt Kickoff und initialen Projektplan festgelegt.                                                 |
| 30.08.2024 | 0.1.0   | Entwicklung der Datenbankstrukturen und Beginn der Implementierung der CRUD-Funktionalität.           |
| 06.09.2024 | 0.2.0   | Weiterführung der Implementierung mit Fokus auf Klassenverwaltung und Rollenmanagement.               |
| 13.09.2024 | 0.3.0   | Benutzerrollen implementiert und erste Tests der Benutzerverwaltung durchgeführt.                     |
| 20.09.2024 | 0.4.0   | Abschluss der Implementierung aller Kernfunktionen und Beginn der End-to-End-Tests.                   |
| 27.09.2024 | 0.5.0   | Fehlerbehebungen und Optimierungen basierend auf Testergebnissen.                                     |
| 01.11.2024 | 0.6.0   | Finale Tests, Projektabschluss und erstellen des Mahara-Portfolios.                                   |
| 02.11.2024 | 1.0.0   | Probleme im Programm gelöst und am Mahara-portfolio gearbeitet.                                       |

## 1. Informieren

### 1.1 Projektbeschreibung

Wir entwickeln eine Applikation zur Schulverwaltung, die es ermöglicht, Schüler und Lehrkräfte zu erfassen und zu verwalten. Die Applikation bietet Funktionen zur Klassenzuweisung, Benutzerverwaltung und Zugriffskontrolle über ein Rollenmanagementsystem. C# wird für die Implementierung des Backends genutzt, um Datenoperationen effizient zu handhaben und eine Verbindung zur MongoDB-Datenbank herzustellen.

Die Benutzerrollen und deren Zugriffsrechte sind wie folgt definiert:
- **Administrator**: Hat **read** und **write** Zugriffsrechte auf alle Datenbanken.
- **Lehrer**: Hat **read** und **write** Zugriffsrechte auf spezifische Datensätze (Schüler und Klassen).
- **Schüler**: Hat **read**-Zugriffsrechte auf die ihm zugewiesenen Daten.
- **Benutzer**: Verwendet die Applikation zur Schulverwaltung und hat keine speziellen Zugriffsrechte.

### 1.2 User Stories

| US-№ | Verbindlichkeit | Beschreibung                                                                                     |
|------|-----------------|--------------------------------------------------------------------------------------------------|
| 1    | muss            | Als Benutzer möchte ich Schüler und Lehrer zur Datenbank hinzufügen können, um die Verwaltung zu ermöglichen. |
| 2    | muss            | Als Benutzer möchte ich bestehende Schüler- und Lehrerdaten aktualisieren können, um die Daten auf dem neuesten Stand zu halten. |
| 3    | muss            | Als Benutzer möchte ich Schüler einer bestimmten Klasse zuordnen können, um die Klassenzusammensetzung zu verwalten. |
| 4    | muss            | Als Benutzer möchte ich Benutzerrollen wie „Lehrer“ und „Schüler“ anlegen können, um die Zugriffsrechte zu steuern. |
| 5    | muss            | Als Benutzer möchte ich mich mit einem sicheren Login authentifizieren können, um den Zugang zu meinen Daten zu schützen. |
| 6    | muss            | Als Benutzer möchte ich die Schülerliste einer bestimmten Klasse einsehen können, um einen Überblick über die Klassenzusammensetzung zu erhalten. |
| 7    | kann            | Als Benutzer möchte ich Benutzerrollen Rechte zuweisen können, um den Zugriff auf Funktionen festzulegen. |
| 8    | muss            | Als Benutzer möchte ich die Möglichkeit haben, Schüler zwischen Klassen zu verschieben, um Klassenänderungen vorzunehmen. |
| 9    | muss            | Als Benutzer möchte ich Benutzerkonten löschen können, um die Datenbank aktuell zu halten. |
| 10   | muss            | Als Benutzer möchte ich mein Passwort ändern können, um die Sicherheit meines Kontos zu erhöhen. |
| 11   | kann            | Als Benutzer möchte ich Klassenberichte generieren können, um die Klassenzusammensetzung und Lehrerverteilung zu zeigen. |
| 12   | muss            | Als Benutzer möchte ich direkt in der Applikation auf meine Klassen zugreifen und meine zugewiesenen Schüler einsehen können, um die Schülerlisten schnell aufzurufen. |
| 13   | muss            | Als Entwickler möchte ich das C#-Backend so strukturieren, dass es klar zwischen Benutzerverwaltung, Rollenmanagement und Klassenzuweisung trennt, um den Code wartbar und erweiterbar zu halten. |
| 14   | kann            | Als Benutzer möchte ich eine Benachrichtigung erhalten, wenn Änderungen an einer Klasse vorgenommen werden, um den Überblick über Klassenzuordnungen zu behalten. |

### 1.3 Testfälle

| TC-№ | Ausgangslage               | Eingabe                                      | Erwartete Ausgabe                                |
|------|-----------------------------|----------------------------------------------|--------------------------------------------------|
| 1.1  | Schüler- und Lehrerdatenbank leer | Neuen Schüler und Lehrer hinzufügen          | Schüler und Lehrer sind in der Datenbank gespeichert (US-1) |
| 2.1  | Vorhandene Schülerdaten     | Bestehenden Schülerdatensatz aktualisieren     | Geänderte Schülerdaten werden gespeichert (US-2) |
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
| 14.1 | Änderungen an Klassenstruktur vorhanden | Klasse 10A wird aktualisiert | Benutzer erhält Benachrichtigung über die Änderungen (US-14) |

### 1.4 Diagramme

Die Diagramme für das Datenmodell, die Benutzerrollen und Klassenübersichten sind im GitHub-Repository abgelegt und können bei Bedarf abgerufen werden.

## 2. Planen


| AP-№ | Frist      | Zuständig                   | Beschreibung                                             | geplante Zeit |
|------|------------|-----------------------------|----------------------------------------------------------|---------------|
| 1.A  | 30.08.2024 | Atputharasa, Jashari        | CRUD-Implementation für Schüler und Lehrer (US-1)        | 180 min       |
| 2.A  | 30.08.2024 | Jashari, Atputharasa        | Datenmodellierung und Testdaten erstellen (US-2)         | 180 min       |
| 3.A  | 06.09.2024 | Angelov                     | Implementierung der Klassenverwaltung (US-3)             | 180 min       |
| 4.A  | 13.09.2024 | Marku, Angelov              | Rollenmanagement und Zuweisung von Zugriffsrechten (US-4) | 200 min       |
| 5.A  | 13.09.2024 | Atputharasa, Marku          | Implementierung des sicheren Logins (US-5)               | 150 min       |
| 6.A  | 20.09.2024 | Angelov, Marku              | Klassenverwaltung: Schülerlisten für Lehrer anzeigen (US-6) | 150 min    |
| 7.A  | 20.09.2024 | Marku, Jashari              | Zuweisung und Verwaltung von Benutzerrollen (US-7)       | 180 min       |
| 8.A  | 27.09.2024 | Angelov, Marku              | Verschieben von Schülern zwischen Klassen (US-8)         | 160 min       |
| 9.A  | 04.10.2024 | Jashari                     | Löschen von Benutzerkonten und Datenaktualisierung (US-9) | 120 min       |
| 10.A | 04.10.2024 | Team                        | Passwortänderungsfunktionalität implementieren (US-10)   | 150 min       |
| 11.A | 04.10.2024 | Angelov                     | Generieren von Klassenberichten (US-11)                  | 130 min       |
| 12.A | 04.10.2024 | Marku, Atputharasa          | Zugriff auf Klassen und Schülerlisten für Lehrer (US-12) | 140 min       |
| 13.A | 04.10.2024 | Atputharasa                 | Strukturierung des C#-Backends (US-13)                   | 150 min       |
| 14.A | 04.10.2024 | Jashari                     | Benachrichtigungen bei Klassenänderungen (US-14)         | 130 min       |
| 15.A | 04.10.2024 | Team                        | Erstellung der Projektdokumentation                      | 120 min       |
| 16.A | 04.10.2024 | Team                        | Mahara Portfolio schreiben                               | 120 min       |
| 17.A | 04.10.2024 | Team                        | Tägliche Team-Sitzungen (5 Minuten pro Tag)              | 30 min total  |

## 3. Entscheiden

Die Entscheidung zur Nutzung von C# und MongoDB basiert auf der Notwendigkeit effizienter Datenverwaltung und der Fähigkeit, komplexe Benutzerverwaltungs- und Klassenzuweisungsfunktionen zu implementieren.

## 4. Realisieren

| AP-№ | Datum      | Zuständig                   | geplante Zeit | tatsächliche Zeit |
|------|------------|-----------------------------|---------------|-------------------|
| 1.A  | 23.08.2024 | Atputharasa, Jashari        | 180 min       | 200 min           |
| 2.A  | 30.08.2024 | Jashari, Atputharasa        | 180 min       | 180 min           |
| 3.A  | 06.09.2024 | Angelov                     | 180 min       | 180 min           |
| 4.A  | 13.09.2024 | Marku, Angelov              | 200 min       | 210 min           |
| 5.A  | 20.09.2024 | Atputharasa, Marku          | 150 min       | 150 min           |
| 6.A  | 20.09.2024 | Angelov, Marku              | 150 min       | 160 min           |
| 7.A  | 27.09.2024 | Marku, Jashari              | 180 min       | 180 min           |
| 8.A  | 27.09.2024 | Angelov, Marku              | 160 min       | 170 min           |
| 9.A  | 04.10.2024 | Jashari                     | 120 min       | 120 min           |
| 10.A | 04.10.2024 | Team                        | 150 min       | 150 min           |
| 11.A | 04.10.2024 | Angelov                     | 130 min       | 130 min           |
| 12.A | 04.10.2024 | Marku, Atputharasa          | 140 min       | 145 min           |
| 13.A | 04.10.2024 | Atputharasa                 | 150 min       | 155 min           |
| 14.A | 04.10.2024 | Jashari                     | 130 min       | 130 min           |
| 15.A | 04.10.2024 | Team                        | 120 min       | 120 min           |
| 16.A | 04.10.2024 | Team                        | 120 min       | 120 min           |
| 17.A | Täglich    | Team                        | 5 min         | 5 min pro Tag     |

## 5. Kontrollieren

### 5.1 Testprotokoll

| TC-№ | Datum      | Resultat | Tester      | Verknüpfte US |
|------|------------|----------|-------------|---------------|
| 1.1  | 04.10.2024 | OK       | Atputharasa | US-1          |
| 2.1  | 04.10.2024 | OK       | Jashari     | US-2          |
| 3.1  | 04.10.2024 | OK       | Angelov     | US-3          |
| 4.1  | 04.10.2024 | OK       | Marku       | US-4          |
| 5.1  | 04.10.2024 | OK       | Team        | US-5          |
| 6.1  | 04.10.2024 | OK       | Angelov     | US-6          |
| 7.1  | 04.10.2024 | OK       | Marku       | US-7          |
| 8.1  | 04.10.2024 | OK       | Jashari     | US-8          |
| 9.1  | 04.10.2024 | OK       | Marku       | US-9          |
| 10.1 | 04.10.2024 | OK       | Atputharasa | US-10         |
| 11.1 | 04.10.2024 | OK       | Atputharasa | US-11         |
| 12.1 | 04.10.2024 | OK       | Team        | US-12         |
| 13.1 | 04.10.2024 | OK       | Angelov     | US-13         |
| 14.1 | 04.10.2024 | OK       | Marku       | US-14         |

## 7. Teamsitzungsbericht


| Datum      | Erledigte Arbeitspakete                                                                                     | Nächste Arbeitspakete                        | Verzögerungen | Änderungen | Pro                                          | Con                                   |
|------------|-------------------------------------------------------------------------------------------------------------|----------------------------------------------|---------------|------------|----------------------------------------------|---------------------------------------|
| 23.08.2024 | Projekt Kickoff, Projektplan festgelegt                                                                     | Datenbankstrukturen, CRUD-Funktionen         | Keine         | Keine      | Strukturierter Start, gemeinsames Verständnis | Keine Planung für Benutzerverwaltung |
| 30.08.2024 | Datenbankstrukturen, CRUD-Implementierung gestartet                                                         | Klassenverwaltung, Rollenmanagement          | Keine         | Keine      | Schneller Fortschritt                        | Keine                                |
| 06.09.2024 | MongoDB eingerichtet, Datenbankstrukturen, Basisprogramm, CRUD-Pakete hinzugefügt                           | Klassenverwaltung, Rollenmanagement          | Keine         | Keine      | Erfolgreiche Datenbank und CRUD               | Keine                                |
| 13.09.2024 | Klassenverwaltung implementiert, Klassenaktionen erstellt                                                   | Rollenverwaltung, Validierungen              | Keine         | Keine      | Erfolgreiche Klassenzuweisung                 | Keine                                |
| 20.09.2024 | Rollenverwaltung abgeschlossen, Validierungen implementiert                                                 | Programmüberarbeitung, Tests                 | Keine         | Keine      | Verbesserte Zugriffskontrolle                | Keine                                |
| 27.09.2024 | Benutzerverwaltung, Programmüberarbeitung, erste Tests abgeschlossen                                        | Unit Tests, Erweiterungen                    | Keine         | Keine      | Stabile Benutzerverwaltung, erfolgreiche Tests | Validierungen könnten angepasst werden |


## 7. Auswerten

Der Lernbericht und die vollständige Projektdokumentation sind im GitHub-Repository abgelegt.
