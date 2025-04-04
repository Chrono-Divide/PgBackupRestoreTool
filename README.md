# PgBackupRestoreTool

**PgBackupRestoreTool** is a lightweight GUI tool built with **.NET 8** for backing up and restoring PostgreSQL databases using official client tools (`pg_dump`, `pg_restore`, `psql`, etc). It supports both local and remote PostgreSQL connections.

## 🚀 Features

- 📦 Backup database with:
  - Custom format (`pg_dump -F c`)
  - Plain SQL format (`pg_dump` default)
- ♻️ Restore database from:
  - Custom format (`pg_restore`)
  - Plain SQL format (`psql`)
- 🖥️ Local or remote host selection
- 📂 File browsing support for backup/restore files
- ✅ Test database connection
- 🔒 Auto-disables UI controls during long operations to prevent conflicts
- 🌐 Automatically sets `PGCLIENTENCODING=UTF8` for proper encoding
- 📝 Settings saved in local `settings.conf` file

## 🧰 Requirements

- Windows with [.NET 8 Runtime](https://dotnet.microsoft.com/en-us/download/dotnet/8.0) installed
- PostgreSQL client tools must be installed and available in your system `PATH`:
  - `pg_dump`
  - `pg_restore`
  - `psql`
  - `dropdb`, `createdb`

## 🧑‍💻 How to Use

### 1. Clone the Repository

```bash
git clone https://github.com/Chrono-Divide/PgBackupRestoreTool.git
```

### 2. Build and Run

Open the solution in Visual Studio 2022+ or use the command line:

```bash
dotnet build
dotnet run --project PgBackupRestoreTool
```

> You can also publish it as a standalone `.exe` using:
>
> ```bash
> dotnet publish -c Release -r win-x64 --self-contained true
> ```

### 3. Initial Configuration

On first run, a `settings.conf` file will be created alongside the `.exe`. You can manually edit it to configure database credentials and known IPs.

#### `settings.conf` example:

```ini
PG_USER=admin
PG_PASSWORD=admin
PG_DATABASE=bks
KNOWN_IPS=192.168.1.100;192.168.1.101
```

> ⚠️ The default `settings.conf` is empty. You must edit it manually or use the UI to save new IPs via "Test Connection".

## 📸 Screenshot

> _Optional: You can place a screenshot in `docs/screenshot.png` and uncomment this line._

<!-- ![Screenshot](docs/screenshot.png) -->

## 📝 License

This project is licensed under the [MIT License](LICENSE).
