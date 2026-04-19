# TP2 – Application de Réalité Augmentée avec AR Foundation

## 📌 Contexte
Ce projet a été réalisé dans le cadre d’un travail pratique (TP2) dont l’objectif est de développer une mini-application de réalité augmentée sous Unity, capable de :
- Détecter un élément réel (plan horizontal : sol, table, etc.)
- Permettre une interaction utilisateur (tap ou clic)
- Placer un objet 3D à l’endroit détecté
- Intégrer une fonctionnalité d’intelligence artificielle (ici simulation ou appel API)
- Afficher un résultat dynamique basé sur l’analyse IA

## 📌 Binome
Hamza Elmourabit , Oussama Hajar

## 🧠 Technologie utilisée
- **Unity 2021.3 (ou plus récent)** – moteur de jeu
- **AR Foundation** – framework de réalité augmentée
- **ARCore XR Plugin** (pour Android) – utilisé pour la détection de plans
- **XR Interaction Toolkit** – pour la gestion des interactions
- **C#** – scripts d’interaction et d’IA
- **Simulation IA** – reconnaissance d’objets simulée (peut être remplacée par une vraie API comme Hugging Face)

## 🖥️ Fonctionnalités
- ✅ Initialisation automatique de l’AR (caméra + gestion des plans)
- ✅ Détection en temps réel des surfaces planes (sol, mur, bureau)
- ✅ Placement d’un objet 3D (cube, sphère ou modèle personnalisé) par tap (mobile) ou clic (éditeur)
- ✅ Appel d’une IA (simulée ou réelle) après chaque placement
- ✅ Affichage du résultat de l’analyse dans la console et/ou dans un UI Text
- ✅ Compatible test dans l’éditeur Unity avec webcam (pas besoin de téléphone)

## 🎮 Utilisation (dans l’éditeur)
1. Ouvrez le projet avec Unity.
2. Ouvrez la scène principale (ex: `Assets/Scenes/MainScene.unity`).
3. Branchez une webcam (si vous n’en avez pas, la simulation peut fonctionner sans caméra mais sans détection réelle).
4. Appuyez sur le bouton **Play**.
5. Pointez la webcam vers une surface texturée (bureau, tapis, sol).
6. Cliquez avec la souris (clic gauche) sur la surface détectée → un objet 3D apparaît.
7. Le résultat de l’analyse IA s’affiche dans la console et à l’écran (si un UI Text est présent).

## 📱 Utilisation (sur Android)
1. Dans Unity, basculez la plateforme sur **Android** (`File > Build Settings > Android > Switch Platform`).
2. Connectez un téléphone Android en mode développeur (USB debugging activé).
3. Cliquez sur **Build And Run**.
4. Sur le téléphone, autorisez la caméra.
5. Bougez le téléphone pour détecter un plan, puis tapez sur l’écran pour placer l’objet.
6. L’IA s’exécute automatiquement et affiche le résultat.

## 🗂️ Structure du projet
Assets/
├── Scenes/
│ └── MainScene.unity # Scène principale AR
├── Scripts/
│ └── ARTapToPlace.cs # Gestion du tap + appel IA
├── Prefabs/
│ └── VirtualObject.prefab # Objet 3D à placer
├── UI/
│ └── ResultText # (optionnel) TextMeshPro pour affichage IA
├── Materials/ # (optionnel) matériaux

## 🧪 Détail du script principal (`ARTapToPlace.cs`)
- **Rôle** : détecter les taps/clics, lancer un raycast sur les plans AR, instancier l’objet, déclencher l’analyse IA.
- **Compatibilité** : fonctionne aussi bien en mode touch (mobile) qu’en mode clic souris (éditeur).
- **IA simulée** : renvoie aléatoirement un nom d’objet parmi une liste prédéfinie.
- **Extensibilité** : vous pouvez remplacer `SimulateAI()` par un véritable appel HTTP à une API de reconnaissance d’images (Hugging Face, Google Gemini, etc.).

## 🔧 Personnalisation
- **Changer l’objet à placer** : glissez votre propre modèle 3D dans le champ `objectToPlace` du script (sur `XR Origin`).
- **Changer la simulation IA** : modifiez le tableau `reponses` dans la méthode `SimulateAI()`.
- **Ajouter une vraie IA** : décommentez la partie `UnityWebRequest` et insérez votre clé API.

## 📤 Livraison (GitHub)
Ce dépôt contient uniquement les fichiers sources (scripts, scènes, préfabs) – les dossiers `Library/`, `Temp/`, `Builds/` sont exclus grâce au `.gitignore`.  
Pour cloner et exécuter le projet :
```bash
git clone https://github.com/HamzaElmourabit/TP2_augmented_Reality.git

