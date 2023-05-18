FROM mcr.microsoft.com/dotnet/sdk:6.0 as build
WORKDIR /src
COPY . .
RUN dotnet publish "Booking-Module/Booking-Module.csproj" -c release -o /app

FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build /app ./
ENTRYPOINT [ "dotnet", "Booking-Module.dll" ]

ENV ASPNETCORE_ENVIRONMENT=Docker