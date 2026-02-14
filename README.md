# Wheat Grain Classifier

Une application console en C# qui classe automatiquement des grains de blé (variétés Kama, Rosa et Canadian) à l'aide de l'algorithme k-plus proches voisins (k-NN).


## Installez les packages NuGet nécessaires 

```bash
Install-Package CsvHelper
Install-Package Newtonsoft.Json
Install-Package Spectre.Console

```

## Farm Management System Architecture

```mermaid
classDiagram
    class Fermier
    class Clients
    class Ferme
    class Grains
    class Kama
    class Rosa
    class Canadian

    Ferme "1" *-- "1..*" Grains
    Ferme "1" *-- "1..*" Fermier
    Ferme "1" --> "0..*" Clients : à
    Kama <|-- Grains
    Rosa <|-- Grains
    Canadian <|-- Grains
```