# GitFlow 

Git Flow (o Gitflow) es una estrategia de trabajo con Git que define cómo organizar las ramas de un proyecto para que el desarrollo sea más ordenado, seguro y colaborativo.

No es una herramienta, sino un modelo de ramas que indica cuándo y para qué usar cada una.

## Idea Principal de Gitflow

| Rama     |                 Uso                 |
|----------|-------------------------------------|
| main     | Codigo en producción (estable)      |
| develop  | Código en desarrollo                |
| feature/ | Nuevas funcionalidades              |
| release/ | Preparar una versión                |
| hotfix/  | Correcciónes urgentes en producción |

## Flujo Básico
1. **main**: Contiene solo versiones listas para producción.
2. **develop**: Es la rama donde se integra todo lo nuevo antes de pasar a producción.
3. **feature**: Cada nueva tarea va en una rama:
```bash
feature/login
feature/pagos
feature/reportes
```
4. **release/**: Cuando ya casi está listo: 
```bash
release/v1.0.0
```
Aquí se afinan detalles y luego se mezcla a **main** y **develp**.

5. **hotfix**: Para errores urgentes en producción:
```bash
hotfix/v1.0.0.1
```
Sale de **main** y vuelve a **main** y **develop**.
![alt text](img/image.png)

## Ejemplo con comandos
```bash
git checkout develop
git checkout -b feature/login

# trabajas...
git add .
git commit -m "Agregar login"

git checkout develop
git merge feature/login
git branch -d feature/login
```

## GitFlow en GitKraken

<iframe width="560" height="315" src="https://www.youtube.com/embed/eTOgjQ9o4vQ?si=JMUmduR50lNkJbw_" title="YouTube video player" frameborder="0" allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture; web-share" referrerpolicy="strict-origin-when-cross-origin" allowfullscreen></iframe>