
# 🚀 PostgreSQL + pgAdmin using Docker

This README explains how do I to set up a PostgreSQL database and pgAdmin interface using Docker.

---

## 📦 Prerequisites

- Docker installed
- Docker Hub account (`docker login` completed)

---

## 🔨 Step-by-Step Commands

### 1. Create a `Dockerfile` for PostgreSQL

```Dockerfile
# Dockerfile
FROM postgres:latest

ENV POSTGRES_USER=admin
ENV POSTGRES_PASSWORD=admin
ENV POSTGRES_DB=mydatabase
```

---

### 2. Build the Postgres Image

```bash
docker build -t mydatabase_db .
```

---

### 3. Run the Postgres Container

```bash
docker run -d -e POSTGRES_USER=admin -e POSTGRES_PASSWORD=admin -e POSTGRES_DB=mydatabase -p 5432:5432 mydatabase_db
```

---

### 4. Run the pgAdmin Container

```bash
docker run -d --name pgadmin_container -e PGADMIN_DEFAULT_EMAIL=admin@admin.com -e PGADMIN_DEFAULT_PASSWORD=admin123 -p 5050:80 dpage/pgadmin4
```

---

### 5. Access pgAdmin in Your Browser

Go to [http://localhost:5050](http://localhost:5050)

- **Email:** `admin@admin.com`  
- **Password:** `admin123`

---

