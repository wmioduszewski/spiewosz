# ADR 0007 – Zarządzanie domeną: OVH + Cytrus

**Status:** Accepted

## Context
Domena `spiewosz.pl` jest zarejestrowana w OVH, a Cytrus obsługuje SSL i routing.

## Decision
DNS pozostaje w OVH, natomiast rekord A kieruje na Cytrusa.

## Alternatives
- Cloudflare Tunnel — rozważane, ale niepotrzebne.

## Consequences
- pełne wsparcie Cytrusa,
- poprawna integracja z Let's Encrypt.