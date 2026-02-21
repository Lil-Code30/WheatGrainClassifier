# Wheat Grain Classifier

A console application in C# that automatically classify wheat grains (variety : Kama, Rosa, Canadian) with the help of [K-Nearest Neighbor(KNN) Algorithm](https://en.wikipedia.org/wiki/K-nearest_neighbors_algorithm)

![App Menu image](./Assets/app-menu.png)

## Installation

### 1. Clone this repository

```bash
git clone https://github.com/Lil-Code30/WheatGrainClassifier.git

cd WheatGrainClassifier
```
### 2. Install the required Nuget Packages

```bash
Install-Package CsvHelper
Install-Package Newtonsoft.Json
Install-Package Spectre.Console

```
### 3. Files needed

The files needed to run this code are located in the folder `/data`

- **Test seeds data:** `seeds_dataset_test.csv`
- **Training seeds data:** `seeds_dataset_training.csv`

## How the program works

> The csv header : Variety;Area;Perimeter;Compactness;Kernel_Length;Kernel_Width;Asymmetry_Coefficient;Groove_Length
> Which is related to the `WheatGrain.cs` class

## Distance Metrics Used in KNN Algorithm
KNN uses distance metrics to identify nearest neighbor, these neighbors are used for classification and regression task. To identify nearest neighbor we use below distance metrics:

### 1. Euclidean Distance

Euclidean distance is defined as the straight-line distance between two points in a plane or space.  
You can think of it like the shortest path you would walk if you were to go directly from one point to another.

$$
\text{distance}(x, X_i) = \sqrt{\sum_{j=1}^{d} (x_j - X_{ij})^2}
$$

---

### 2. Manhattan Distance

This is the total distance you would travel if you could only move along horizontal and vertical lines like a grid or city streets.  
It’s also called **"taxicab distance"** because a taxi can only drive along the grid-like streets of a city.

$$
d(x, y) = \sum_{i=1}^{n} |x_i - y_i|
$$

> Source : [https://www.geeksforgeeks.org/machine-learning/k-nearest-neighbours/](https://www.geeksforgeeks.org/machine-learning/k-nearest-neighbours/)

## Modélisation UML pour la classification k-NN

```mermaid
classDiagram
    class KNNClassifier {
        -int k
        -IDistanceMetric distanceMetric
        -List~WheatGrain~ trainingGrains
        +KNNClassifier(int k, IDistanceMetric metric, List~WheatGrain~ trainingData)
        +string predict(WheatGrain sample)
        -List~WheatGrain~ findKNearestNeighbors(WheatGrain sample)
    }
    
    class WheatGrain {
        -double Area
        -double Perimeter
        -double Compactness
        -double LengthOfKernel
        -double WidthOfKernel
        -double AsymmetryCoefficient
        -double LengthOfKernelGroove
        -GrainType Variety
        
    }

    class GrainType {
        <<enumeration>>
        Kama
        Rosa
        Canadian
    }

    class IDistanceMetric {
        <<Interface>>
        +double calculate(WheatGrain a, WheatGrain b)
    }

    class EuclideanDistance {
        +double calculate(WheatGrain a, WheatGrain b)
    }

    class ManhattanDistance {
        +double calculate(WheatGrain a, WheatGrain b)
    }

  
    KNNClassifier --> IDistanceMetric : delegates to
    KNNClassifier --> WheatGrain : receives
    EuclideanDistance ..|> IDistanceMetric
    ManhattanDistance ..|> IDistanceMetric
    
```

## Farm Management System Architecture

> Note : This is not implemented in the code just for learning purpose

```mermaid
classDiagram
    class Ferme {
        -String nomFerme
        -String adresse
        -Double surfaceHectares
        -String numeroSIRET
        -Date dateCreation
        -List~Fermier~ employes
        -List~Grains~ stocks
        -List~Clients~ clients
        +void embaucherFermier(Fermier fermier)
        +void licencierFermier(String numeroPermis)
        +void ajouterStock(Grains grain, Double quantiteKg)
        +void vendreGrains(Clients client, Grains grain, Double quantiteKg)
        +Double calculerChiffreAffairesMensuel()
        +List~Grains~ getStocksParQualite(String qualite)
        +Double getSuperficieCultivee()
        +Boolean estCertifieeBio()
    }

    class Fermier {
        -String nom
        -String prenom
        -String numeroPermis
        -Date dateEmbauche
        -List~String~ competences
        -Double salaireHoraire
        +Boolean estCertifieBio()
        +void affecterChamp(String nomChamp)
        +Double calculerSalaireMensuel(Double heuresTravaillees)
        +List~Grains~ recolter(String champ, Date date)
        +void entretenirMateriel(String typeMateriel)
    }

    class Clients {
        -String nomEntreprise
        -String contactPrincipal
        -String telephone
        -String email
        -String typeClient
        -Boolean estFidele
        -List~Commande~ historiqueCommandes
        +Double calculerRemise(Double montantHT)
        +Boolean peutAcheterEnGros()
        +void passerCommande(Grains grain, Double quantiteKg, Date dateLivraison)
        +Double getMontantTotalAchatsAnnuel()
    }

    class Grains {
        <<abstract>>
        -String nomVariete
        -Double poidsSacsKg
        -Double prixParKg
        -Date dateRecolte
        -String qualite
        -Boolean estBio
        +Double calculerValeurTotale()
        +Boolean estUtilisablePourSemence()
        +String getInfosRecolte()
        +Double getTauxHumidite()
    }

    class Kama {
        -String certificationKamut
        -Double teneurProteines
        -String origineGeographique
        +Boolean estAdaptePainArtisanal()
        +Double recommanderDoseSemis()
    }

    class Rosa {
        -String resistanceMaladies
        -Double rendementHectare
        -String periodeCultureOptimale
        +Double estimerRendement()
        +Boolean resisteAuFroid()
    }

    class Canadian {
        -String origineCanadienne
        -Boolean estHardRed
        -Double indiceGluten
        +Boolean convientPainBlanc()
        +String recommanderUtilisation()
    }

    class Commande {
        -String numeroCommande
        -Date dateCommande
        -Date dateLivraison
        -Double quantiteKg
        -Double prixTotal
        -Grains typeGrain
        +Double calculerPrixTotalAvecRemise(Double pourcentageRemise)
        +Boolean estLivre()
    }

    Ferme "1" *-- "1..*" Fermier
    Ferme "1" *-- "0..*" Grains
    Ferme "1" --> "0..*" Clients : à
    Clients "1" *-- "0..*" Commande
    Kama <|-- Grains
    Rosa <|-- Grains
    Canadian <|-- Grains
```
