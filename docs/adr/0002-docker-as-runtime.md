# ADR 0002 – Docker jako standard uruchamiania aplikacji

**Status:** Accepted

## Context
Aplikacja ma być uruchamiana w powtarzalny, transportowalny sposób i przygotowana pod przyszłą orkiestrację.

## Decision
Aplikacja będzie zawsze uruchamiana w kontenerze Docker — lokalnie i produkcyjnie.

## Alternatives
- Self-contained .NET publish — odrzucone.
- Docker Compose — zbyt wcześnie.

## Consequences
- spójność środowisk,
- łatwy deploy z GitHub Actions,
- gotowość pod K8s.