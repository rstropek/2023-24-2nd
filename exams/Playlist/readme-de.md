# Video-Wiedergabelisten-Warteschlange

![Screenshot](./screenshot.png)

## Einleitung

Diese Prüfung bewertet Ihre Fähigkeit, ein System zur Verwaltung von Video-Wiedergabelisten in C# zu implementieren und zu testen. Sie erhalten Startercode für eine [`TitleQueue`-Klasse](./template/VideoPlaylist.Logic/TitleQueue.cs), die eine Queue von Filmtiteln darstellt. Ihre Aufgabe besteht darin, die Methoden in der `TitleQueue`-Klasse zu implementieren. Zusätzlich können Sie [Unit-Tests](./template/VideoPlaylist.Tests/), eine [Konsolenanwendung](./template/VideoPlaylist.ConsoleApp/) und eine [Blazor-Webanwendung](./template/VideoPlaylist.Web/) verwenden, um die Funktionalität Ihres Codes zu testen.

## Ihre Aufgaben

### Allgemeine Hinweise

Die detaillierten Anforderungen sind als Kommentare vor jeder Methode angegeben, die Sie vervollständigen müssen. Lesen Sie die Dokumentation der Methoden daher sorgfältig!

Regeln für die Übung:

1. Methodensignaturen dürfen **nicht** geändert werden.
2. Die bestehenden Klassen, Methoden und Properties **müssen** verwendet werden.
3. Man **darf** Klassen, Methoden und Properties hinzufügen.
4. Man **muss** so viele Klassen, Methoden und Properties implementieren wie möglich, die den Kommentar `TODO` enthalten.

### Grundanforderungen

- Implementieren Sie die folgenden Methoden in der [`TitleQueue`-Klasse](./template/VideoPlaylist.Logic/TitleQueue.cs):
  - `Append`
  - `InsertAfterFirst`
  - `Next`
  - `CurrentlyPlaying`
- Implementieren Sie die folgende Methode in [*Program.cs* in der Konsolenanwendung](./template/VideoPlaylist.ConsoleApp/Program.cs):
  - `ViewAllMovies`
- Sie können die bereitgestellten Unit-Tests verwenden, um Ihre Implementierung zu validieren.
- Zusätzlich können Sie Ihre Implementierung in der Konsolenanwendung testen.

### Erweiterte Anforderungen

- Implementieren Sie **alle** Methoden in der `TitleQueue`-Klasse.
- Sie können die bereitgestellten Unit-Tests verwenden, um Ihre Implementierung zu validieren.
- Zusätzlich können Sie Ihre Implementierung in einer Blazor-Webanwendung mit einem echten Videoplayer testen.
