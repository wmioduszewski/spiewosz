# Spiewosz — Projekt Edukacyjno-Architektoniczny

## 🟦 1. Cel projektu
**Spiewosz** to celowo przeinżynierowany, lecz funkcjonalnie prosty system służący do nauki:
- pełnego **SDLC**,
- konteneryzacji,
- CI/CD,
- infrastruktury chmurowej,
- orkiestracji usług,
- DevOps / SRE praktyk.

Funkcjonalnie jest to **rodzinny śpiewnik** z prostym CRUD-em na utworach, lecz prawdziwa wartość projektu to **technologie, automatyzacje, infrastruktura i eksperymenty**.

---

## 🟦 2. Stack technologiczny (obecny i docelowy)

### 🔹 Obecnie:
- **.NET 10**
- **Docker** (build + run)
- **GitHub Actions** (CI + CD)
- **VPS Mikrus**
- **Cytrus** (reverse proxy + HTTPS + domeny)
- **Domena spiewosz.pl** (OVH)
- Publiczny port aplikacji: **20176**
- Deployment poprzez SCP + `docker load` + `docker run`
- Jedna usługa: `spiewosz.WebApp`

### 🔹 Planowane:
- Aspire
- Kafka (Confluent, dev-tier)
- Terraform
- Azure resources (Application Insights, Key Vault, itp.)
- Kubernetes (AKS lub K3s)
- Helm, ArgoCD, monitoring, logging

---

## 🟦 3. Aktualny stan projektu

### 🔹 Aplikacja
- Jeden serwis: `spiewosz.WebApp`
- Działa w kontenerze → mapowanie `20176:8080`
- Dockerfile prawidłowo kompiluje i publikuje projekt.

### 🔹 Infrastruktura
- VPS Mikrus
- Port 20176 otwarty publicznie (standard Mikrusa)
- Cytrus przejmuje ruch HTTP/HTTPS z `spiewosz.pl` i kieruje na port 20176
- Reverse proxy NGINX własny — wyłączony (zbędny dzięki Cytrusowi)
- SSL aktywne → Let's Encrypt przez Cytrus

### 🔹 CI/CD
- **CI**: kompilacja .NET przez GitHub Actions
- **CD**:
  - budowa obrazu Dockera
  - zapis `.tar`
  - wysyłka SCP na VPS
  - `docker load`
  - `docker rm -f old`
  - `docker run` nowego kontenera

Aplikacja publicznie dostępna:  
**https://spiewosz.pl**

---

## 🟦 4. Problemy napotkane i rozwiązane

1. **DNS błędnie ustawiony (TXT, A, CNAME)** → poprawiono.
2. **Brak routingu domeny na VPS** → Cytrus + poprawny rekord A.
3. **502 Bad Gateway** → Cytrus kierował na zły port → poprawiono na 20176.
4. **Kontener w stanie `Exited`** → brak restart policy / błędy workflow.
5. **Dockerfile ścieżki** → poprawa kontekstu builda.

---

## 🟦 5. Najbliższe planowane prace

### A) Healthcheck (Dockerfile)
- Dodanie health endpointu `/health`
- `HEALTHCHECK` z `curl -f http://localhost:8080/health`

### B) Stabilność kontenera
- dodanie `--restart unless-stopped`
- ewentualnie systemd do kontroli Dockera

### C) Logowanie
- montowanie katalogu `/home/spiewosz/logs`
- opcjonalnie Serilog do pliku

### D) Porządek w Dockerfile
- `ASPNETCORE_URLS=http://0.0.0.0:8080`
- poprawki po Visual Studio (`USER $APP_UID`)

---

## 🟦 6. Plany średnio- i długoterminowe

1. Drugie środowisko (staging na porcie 30176).
2. Drugi mikroserwis (np. Playlists).
3. API Gateway / Aspire.
4. Publikacja zdarzeń do **Kafka** (history, sync).
5. Monitoring:
   - Application Insights
   - lub Prometheus + Grafana
6. Migracja do Kubernetes:
   - AKS lub K3s
   - Helm charts
   - ArgoCD (GitOps)
7. Integracja OAuth (Google login).

---

## 🟦 7. Kontekst do dalszej pracy (TL;DR)

> **Spiewosz = platforma edukacyjna do nauki DevOps/Cloud + mała aplikacja śpiewnikowa.  
> Hosting: VPS Mikrus + Cytrus.  
> CI/CD: GitHub Actions → Docker → SCP → VPS.  
> Domena: spiewosz.pl (OVH).  
> Najbliższe zadania: HEALTHCHECK, restart policy, logi, poprawa Dockerfile.  
> Docelowo: mikroserwisy, Aspire, Kafka, Terraform, AKS.**

