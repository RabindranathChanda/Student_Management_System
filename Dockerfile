# Use a .NET SDK image as the build environment
FROM mcr.microsoft.com/dotnet/sdk:4.8 AS build

WORKDIR /app

# Copy the project file and restore dependencies
COPY *.csproj ./
RUN dotnet restore

# Copy the remaining source code and build the application
COPY . .
RUN dotnet publish -c Release -o out

# Use a .NET Runtime image as the runtime environment
FROM mcr.microsoft.com/dotnet/runtime:4.8 AS runtime

WORKDIR /app

# Install dependencies for WPF applications (e.g., fontconfig, libgdiplus)
# This might vary depending on your specific WPF application's needs
RUN apt-get update && apt-get install -y \
    fontconfig \
    libgdiplus \
    && rm -rf /var/lib/apt/lists/*

# Copy the published application from the build stage
COPY --from=build /app/out ./

# Set the entry point for the application
ENTRYPOINT ["SMS.exe"]
