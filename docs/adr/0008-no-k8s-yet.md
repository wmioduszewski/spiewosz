# ADR 0008 – Kubernetes nie jest używany na wczesnym etapie

**Status:** Accepted

## Context
Na razie istnieje tylko jeden mikroserwis. Kubernetes byłby nadmiarowy.

## Decision
Wdrożenie K8s nastąpi dopiero po dodaniu kolejnych usług, Aspire, Kafka itd.

## Consequences
- mniejsza złożoność projektu,
- możliwość późniejszej migracji.