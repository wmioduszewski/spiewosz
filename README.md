# 🎶 Spiewosz

**Spiewosz** to celowo przeinżynierowany, edukacyjny projekt .NET, którego celem jest praktyczne ogarnięcie:
- konteneryzacji (Docker),
- CI/CD (GitHub Actions),
- hostingu na VPS,
- reverse proxy + SSL (Cytrus),
- domen (OVH),
- automatycznego deployu,
- infrastruktury jako kod (w przyszłości),
- mikroserwisów, Orkiestracji (Aspire, Kubernetes – w kolejnych etapach).

A jednocześnie — funkcjonalnie — to **rodzinny śpiewnik**: prosty CRUD na piosenkach i tekstach.

Projekt jest realny, ale jego głównym celem jest **nauka DevOps / Cloud / Architecture** na praktycznym przykładzie.

---

## 🚀 Aktualny stan

### ✔️ Aplikacja
- Jedna usługa: `spiewosz.WebApp`
- Napisana w **.NET 10**
- Konteneryzowana w Dockerze
- Nasłuchuje na porcie **8080**

### ✔️ Hosting
- VPS Mikrus
- Ruch z `https://spiewosz.pl` obsługiwany przez **Cytrus** (proxy + SSL)
- Aplikacja wewnętrznie działa na porcie publicznym **20176**

### ✔️ CI/CD
- GitHub Actions:
  - **CI**: kompilacja .NET
  - **CD**: docker build → docker save → SCP → docker run na VPS
- Automatyczny deploy przy pushu na `main`

### ✔️ Domena
- `spiewosz.pl` (OVH)
- Rekord A → Cytrus
- SSL aktywne

---

## 🧱 Architektura obecna (v1)

GitHub → GitHub Actions → Docker image → SCP → VPS (Mikrus)
↓
Cytrus (HTTPS / proxy)
↓
20176 → Docker → WebApp


---

## 🛠️ Najbliższe planowane prace (v1.1)

- [ ] **HEALTHCHECK** w Dockerfile  
- [ ] Dodanie endpointu `/health`
- [ ] `--restart unless-stopped` w kontenerze
- [ ] Montowanie katalogu na logi (`/home/spiewosz/logs`)
- [ ] Uporządkowanie Dockerfile (`ASPNETCORE_URLS`, user, layers)
- [ ] Opcjonalnie: minimalny Serilog do pliku

---

## 🔭 Średnioterminowy roadmap (v2+)

- [ ] Drugie środowisko (staging na porcie 30176)
- [ ] Drugi mikroserwis (np. Playlists)
- [ ] Aspire do orkiestracji lokalnej
- [ ] Kafka (zdarzenia: historii zmian, sesji śpiewania)
- [ ] Monitoring:
  - Application Insights **lub**
  - Prometheus + Grafana
- [ ] Wstęp do Kubernetes (K3s / AKS)
- [ ] Helm + ArgoCD (GitOps)
- [ ] Integracja OAuth (np. Google)

---

## 🎯 Dlaczego powstał Spiewosz?

Projekt ma dwa cele:

### 👨‍💻 1. Edukacyjny (główny)
Potrenować:
- Dockera,
- CI/CD,
- infrastruktury (DNS, reverse proxy, SSL),
- deploye,
- architekturę chmurową,
- orkiestrację mikroserwisów,
- narzędzi typu Terraform, Kafka, K8s.

### 👨‍👩‍👧‍👦 2. Użytkowy (poboczny)
Stworzyć prosty rodzinny śpiewnik,
który realnie można wykorzystać u siebie w domu.

---

## 🧩 Tech stack

**Backend:**  
- .NET 10  
- ASP.NET Minimal APIs / MVC (zależnie od rozwoju)

**Infra:**  
- Docker  
- GitHub Actions  
- VPS Mikrus  
- Cytrus (SSL+Proxy)  
- OVH DNS  
- SCP deploy  

**Planowane:**  
- Kafka  
- Terraform  
- Azure (AI, Key Vault, Service Bus)  
- Aspire  
- Kubernetes (AKS/K3s)  

---

## 📝 Licencja

Projekt jest tworzony **wyłącznie edukacyjnie**, bez komercyjnych ambicji.  
Można go traktować jako sandbox i materiał do nauki.

---

## 💬 Kontakt

Repo prowadzone przez autora, a cała infrastruktura powstaje krok po kroku w duchu:
> Prosty projekt → celowo przeinżynierowana infrastruktura
