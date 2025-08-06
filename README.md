# PgBackupRestoreTool

**PgBackupRestoreTool** is a lightweight GUI tool built with **.NET 8** for backing up and restoring PostgreSQL databases using official client tools (`pg_dump`, `pg_restore`, `psql`, etc). It supports both local and remote PostgreSQL connections.

## 🚀 Features

- 📦 **Backup** database with:
  - Custom format (`pg_dump -F c`)
  - Plain SQL format (`pg_dump` default)
- ♻️ **Restore** database from:
  - Custom format (`pg_restore`)
  - Plain SQL format (`psql`)
  - Optional schema drop/clean before plain SQL restores
- 🖱️ **Drag & drop** support: drop a file onto the Restore-file textbox to auto-populate the path
- 🗜️ Improved status bar layout using `TableLayoutPanel` for consistent spacing
- 🖥️ Local or remote host selection via connection‐string dropdown
- 📂 File‐browsing dialogs for both backup and restore paths
- ✅ **Connection test** with async process execution and deadlock-free stream handling
- 🔒 UI controls auto‐disable during long‐running operations to prevent conflicts
- 🌐 Automatically sets `PGCLIENTENCODING=UTF8` for proper encoding
- 💾 Configuration persisted to `dbconfig.json`

## 🧰 Requirements

- Windows with [.NET 8 Runtime](https://dotnet.microsoft.com/en-us/download/dotnet/8.0) installed  
- PostgreSQL client tools must be installed and available in your system `PATH`:
  - `pg_dump`
  - `pg_restore`
  - `psql`
  - (optional) `dropdb`, `createdb` for schema operations

## 🔧 Recent Fixes

- Async connection testing to avoid UI freezing when listing databases
- Concurrent stdout/stderr reading to prevent deadlocks on large `psql -l` output
- `-w` flag automatically added to prevent blocking password prompts
- Schema cleanup options disabled for custom-format restores to avoid confusion

## 🧑‍💻 How to Use

### 1. Clone the Repository

```bash
git clone https://github.com/Chrono-Divide/PgBackupRestoreTool.git
cd PgBackupRestoreTool
```

### 2. Build and Run

Open the solution in Visual Studio 2022+ or use the .NET CLI:

```bash
dotnet build
dotnet run --project PgBackupRestoreTool
```

> To publish as a standalone executable:
> 
> ```bash
> dotnet publish -c Release -r win-x64 --self-contained true
> ```

### 3. Initial Configuration

On first run, a `dbconfig.json` file will be created in the application folder. You can edit it manually or let the UI save new connection strings.

#### `dbconfig.json` example

```json
{
  "ConnectionStrings": [
    "Host=localhost;Port=5432;Username=admin;Password=admin;Database=bks"
  ],
  "LastUsedConnection": "Host=localhost;Port=5432;Username=admin;Password=admin;Database=bks"
}
```

* **ConnectionStrings**: list of known connection‐string entries
* **LastUsedConnection**: which entry was last tested/saved

## 📸 Screenshot

![Screenshot](screenshot.png)

## 📝 License

This project is licensed under the [MIT License](LICENSE).
