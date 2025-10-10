# Stage 1: Build the application using the .NET Framework SDK image
FROM mcr.microsoft.com/dotnet/framework/sdk:4.8 AS build

WORKDIR /app

COPY SMS.sln ./
# Ensure Custom Picture Box.dll is available for MSBuild
COPY CustomPictureBox/bin/debug/CustomPictureBox.dll CustomPictureBox/bin/debug/

# Copy the project file and restore dependencies
COPY SMS/ ./SMS/
RUN nuget restore SMS.sln

# Copy the source code and build the project
COPY . ./

RUN msbuild /p:Configuration=Release

# Stage 2: Runtime image
FROM mcr.microsoft.com/dotnet/framework/runtime:4.8 AS runtime

WORKDIR /app

# Copy the built files from the build image
COPY --from=build /app/SMS/bin/Release/ ./

# Set the entry point
ENTRYPOINT ["SMS.exe"]
