



# Weather API Wrapper Service 🌦️

### Project Description
This project is a **Weather API Wrapper Service** built with ASP.NET Core. Instead of fetching weather data directly from the provider every time, this service acts as a middleware that implements an **intelligent caching strategy** using **Redis**.

It solves two main problems:

1. **Rate Limiting & Cost:** Reduces the number of calls to the third-party API (Visual Crossing).
2. **Latency:** Provides instant responses for frequently requested cities by serving data from the cache.


### 🚀 Features

- **Third-Party Integration:** Wraps the Visual Crossing Weather API.
- **Redis Caching:** Implements the **Cache-Aside** pattern:
  - Checks Redis first for cached city data
  - If not found, fetches from the API and saves to Redis
- **TTL (Time-To-Live):** Cached data expires automatically after **12 hours**
- **Dockerized:** Fully containerized using Docker Compose (API + Redis)
- **Secure Configuration:** Uses Environment Variables and `.env` files to protect API keys

---

### 🛠️ Tech Stack

- **.NET 9** (ASP.NET Core Web API)
- **StackExchange.Redis**
- **Docker & Docker Compose**
- **Scalar / Swagger** (API Documentation)

---

### ⚙️ Getting Started

#### Prerequisites

- [Docker Desktop](https://www.docker.com/products/docker-desktop)
- A free API key from [Visual Crossing](https://www.visualcrossing.com/)

#### Installation & Running

1. **Clone the repository**
```bash
git clone <your-repo-url>
cd <your-project-folder>
````

2. **Create a `.env` file**

```properties
# .env
WEATHER_API_KEY=your_visual_crossing_api_key_here
```

3. **Run with Docker Compose**

```bash
docker-compose up --build
```

4. **Access the API**

* **Scalar / Swagger UI:** [http://localhost:8080/scalar/v1](http://localhost:8080/scalar/v1)
* **Endpoint:**
  `GET http://localhost:8080/weather/{city}`

---
## 🇹🇷 Türkçe

### Proje Açıklaması

Bu proje, ASP.NET Core ile geliştirilmiş **Hava Durumu API Sarmalayıcı (Wrapper) Servisidir**. Hava durumu verilerini her istek için doğrudan sağlayıcıdan almak yerine, **Redis** kullanarak akıllı bir **önbellekleme (caching) stratejisi** uygular.

Çözdüğü ana problemler:

1. **Maliyet ve Rate Limit:** Üçüncü parti API çağrılarını azaltır
2. **Performans:** Sık istenen şehirler için milisaniyeler içinde yanıt döner

---

### 🚀 Özellikler

* **Visual Crossing API Entegrasyonu**
* **Redis Önbellekleme (Cache-Aside Pattern)**

  * Önce Redis kontrol edilir
  * Veri yoksa API’den çekilip Redis’e kaydedilir
* **TTL:** Veriler 12 saat sonra otomatik silinir
* **Docker Desteği:** API ve Redis Docker Compose ile ayağa kalkar
* **Güvenli Konfigürasyon:** `.env` ve environment variable kullanımı

---

### 🛠️ Kullanılan Teknolojiler

* **.NET 9** (ASP.NET Core Web API)
* **StackExchange.Redis**
* **Docker & Docker Compose**
* **Scalar / Swagger**

---

### ⚙️ Kurulum ve Çalıştırma

#### Gereksinimler

* Docker Desktop
* Visual Crossing API Anahtarı

#### Adımlar

1. **Projeyi klonla**

```bash
git clone <repo-adresiniz>
cd <proje-klasoru>
```

2. **`.env` dosyası oluştur**

```properties
WEATHER_API_KEY=sizin_visual_crossing_api_keyiniz
```

3. **Docker ile başlat**

```bash
docker-compose up --build
```

4. **API Kullanımı**

* **Swagger:** [http://localhost:8080/scalar/v1](http://localhost:8080/scalar/v1)
* **Örnek İstek:**

```http
GET http://localhost:8080/weather/ISTANBUL
```
