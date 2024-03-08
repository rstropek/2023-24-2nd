# Getting Started

```bash
dotnet new sln --name Adder

mkdir Adder
cd Adder
dotnet new console
cd ..
dotnet sln add Adder

mkdir Adder.Tests
cd Adder.Tests
dotnet new xunit
dotnet add reference ../Adder
cd ..
dotnet sln add Adder.Tests
```
