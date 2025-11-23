# ADR 0004 – Cytrus jako reverse proxy

**Status:** Accepted

## Context
Wcześniej użyto lokalnego NGINX, ale Mikrus daje gotowy reverse proxy z SSL.

## Decision
Reverse proxy i SSL obsługiwane przez **Cytrus**, a lokalny NGINX wyłączony.

## Alternatives
- Lokalny NGINX — zbędna komplikacja.
- Caddy — niepotrzebny.

## Consequences
- prostsza architektura,
- SSL automatycznie odnawiane,
- mniej konfiguracji.