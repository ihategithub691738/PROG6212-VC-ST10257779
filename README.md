# PROG6212-VC-ST10257779

ASP.NET Core MVC (.NET 8) **front-end prototype** for the *Contract Monthly Claim System*.

## Run

1. Install .NET 8 SDK and trust the HTTPS dev cert once:
   ```bash
   dotnet dev-certs https --trust
   ```
2. From the project root:
   ```bash
   dotnet restore
   dotnet run
   ```
3. Open `https://localhost:7243` (also serves `http://localhost:5288`).

No database or diagnostics packages are installed.
