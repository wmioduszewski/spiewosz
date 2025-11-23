# ADR 0005 – CD przez GitHub Actions + Docker Save/Load + SCP

**Status:** Accepted

## Context
Brak prywatnego rejestru kontenerów. Chęć minimalizmu i pełnej kontroli.

## Decision
CD używa GitHub Actions, buduje obraz, pakuje do `.tar`, wysyła SCP do VPS i uruchamia przez `docker run`.

## Alternatives
- GHCR — wymagałby dodatkowej konfiguracji.
- JFrog — brak darmowej wersji.

## Consequences
- brak zależności od zewnętrznych rejestrów,
- pipeline prosty w utrzymaniu.
