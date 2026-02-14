# Wheat Grain Classifier

Une application console en C# qui classe automatiquement des grains de blé (variétés Kama, Rosa et Canadian) à l'aide de l'algorithme k-plus proches voisins (k-NN).


## Installez les packages NuGet nécessaires 

```bash
Install-Package CsvHelper
Install-Package Newtonsoft.Json
Install-Package Spectre.Console

```


## Modélisation UML pour la classification k-NN

```mermaid
classDiagram
    class KNNClassifier {
        -int k
        -IDistanceMetric distanceMetric
        -List~WheatGrain~ trainingData
        +KNNClassifier(int k, IDistanceMetric metric)
        +Label predict(WheatGrain sample)
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
        -GrainType? Variety
        +double[] ToFeatureVector()
        
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
